using System;
using System.Collections.Generic;
using System.Linq;

namespace OOCompanyDirectory
{
    /// <summary>
    /// 社員を管理する
    /// </summary>
    public class EmployeeManage
    {
        /// <summary>リポジトリ</summary>
        private readonly IEmployeeRepository repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeManage"/> class.
        /// </summary>
        /// <param name="loadFileNname">読込ファイル名</param>
        public EmployeeManage(string loadFileNname)
        {
            this.repository = new EmployeeRepository(loadFileNname);
        }

        /// <summary>
        /// 全てのデータを取得
        /// </summary>
        /// <returns>社員リスト</returns>
        public List<Employee> GetAllData()
        {
            return this.repository.GetAllData();
        }

        /// <summary>
        /// 苗字で問い合わせ
        /// </summary>
        /// <param name="firstName">苗字</param>
        /// <returns>社員リスト</returns>
        public List<Employee> InquireByFirstName(string firstName)
        {
            var list = this.repository.GetAllData();
            return list.Where(x => x.FirstName == firstName).ToList();
        }

        /// <summary>
        /// 名前で問い合わせ
        /// </summary>
        /// <param name="lastName">苗字</param>
        /// <returns>社員リスト</returns>
        public List<Employee> InquireByLastName(string lastName)
        {
            var list = this.repository.GetAllData();
            return list.Where(x => x.LastName == lastName).ToList();
        }

        /// <summary>
        /// 役職で問い合わせ
        /// </summary>
        /// <param name="position">役職</param>
        /// <returns>社員リスト</returns>
        public List<Employee> InquireByPosition(Position position)
        {
            var list = this.repository.GetAllData();
            return list.Where(x => x.Position == position).ToList();
        }

        /// <summary>
        /// データ妥当性
        /// </summary>
        /// <param name="employees">社員</param>
        /// <param name="errorRowIndex">エラー行インデックス</param>
        /// <param name="errorMessage">エラーメッセージ</param>
        /// <returns>true:正常 false:異常</returns>
        public bool ValidateData(List<Employee> employees, out int errorRowIndex, out string errorMessage)
        {
            errorRowIndex = int.MaxValue;
            errorMessage = string.Empty;
            foreach (var employee in employees)
            {
                if (!this.ValidateData(employee, out errorMessage))
                {
                    return false;
                }
            }

            // 相関チェック
            if (!this.CheckCorrelation(employees, out errorRowIndex, out errorMessage))
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// データ妥当性
        /// </summary>
        /// <param name="employee">社員</param>
        /// <param name="errorMessage">エラーメッセージ</param>
        /// <returns>true:正常 false:異常</returns>
        private bool ValidateData(Employee employee, out string errorMessage)
        {
            errorMessage = string.Empty;

            if (string.IsNullOrEmpty(employee.FirstName))
            {
                errorMessage = Resource.string_NotInputFirstName;
                return false;
            }

            if (string.IsNullOrEmpty(employee.LastName))
            {
                errorMessage = Resource.string_NotInputLastName;
                return false;
            }

            if (employee.Age < 18)
            {
                errorMessage = Resource.string_Age18Over;
                return false;
            }

            return true;
        }

        /// <summary>
        /// 相関チェック
        /// </summary>
        /// <param name="employees">社員</param>
        /// <param name="errorRowIndex">エラー行</param>
        /// <param name="errorMessage">エラーメッセージ</param>
        /// <returns>true:正常 false:異常</returns>
        private bool CheckCorrelation(List<Employee> employees, out int errorRowIndex, out string errorMessage)
        {
            errorRowIndex = int.MaxValue;
            errorMessage = string.Empty;

            // Id重複チェック
            var duplications = employees.GroupBy(x => x.Id).Select(x => new { Id = x.Key, Count = x.Count() }).Where(x => x.Count > 1).FirstOrDefault();

            if (duplications != null)
            {
                errorRowIndex = employees.Select((p, i) => new { data = p, Index = i }).Where(x => x.data.Id == duplications.Id).Select(x => x.Index).LastOrDefault();
                errorMessage = Resource.string_DuplicateId;
                return false;
            }

            return true;
        }

        /// <summary>
        /// 更新データがあるかチェックする
        /// </summary>
        /// <param name="viewDatas">viewデータ</param>
        /// <returns>true:対象なし false:対象あり</returns>
        public bool CheckExistUpdateData(List<Employee> viewDatas)
        {
            var original = this.repository.GetAllData();

            var insertDatas = this.MakeInserData(original, viewDatas);

            var deleteDatas = this.MakeDeleteData(original, viewDatas);

            var updateDatas = this.MakeUpdateData(original, viewDatas);

            if (this.ExistUpdateData(insertDatas, deleteDatas, updateDatas))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// 更新データがあるか
        /// </summary>
        /// <param name="insertDatas">追加データ</param>
        /// <param name="deleteDatas">削除データ</param>
        /// <param name="updateDatas">更新データ</param>
        /// <returns>true:データあり false:データなし</returns>
        private bool ExistUpdateData(List<Employee> insertDatas, List<Employee> deleteDatas, List<Employee> updateDatas)
        {
            if (insertDatas.Any() || deleteDatas.Any() || updateDatas.Any())
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// 追加データ作成
        /// </summary>
        /// <param name="original">元データ</param>
        /// <param name="updateData">更新データ</param>
        /// <returns>追加データ</returns>
        private List<Employee> MakeInserData(List<Employee> original, List<Employee> updateData)
        {
            return updateData.Except(original, new CompareEmployeeId()).ToList();
        }

        /// <summary>
        /// 更新データ作成
        /// </summary>
        /// <param name="original">元データ</param>
        /// <param name="updateData">更新データ</param>
        /// <returns>追加データ</returns>
        private List<Employee> MakeUpdateData(List<Employee> original, List<Employee> updateData)
        {
            var updateDatas = updateData.Intersect(original, new CompareEmployeeId()).ToList();
            var originalDatas = original.Intersect(updateData, new CompareEmployeeId()).ToList();
            return updateDatas.Except(originalDatas, new CompareEmployee()).ToList();
        }

        /// <summary>
        /// 削除データ作成
        /// </summary>
        /// <param name="original">元データ</param>
        /// <param name="updateData">更新データ</param>
        /// <returns>追加データ</returns>
        private List<Employee> MakeDeleteData(List<Employee> original, List<Employee> updateData)
        {
            return original.Except(updateData, new CompareEmployeeId()).ToList();
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="viewDatas">viewデータ</param>
        /// <returns>true:対象なし false:対象あり</returns>
        public bool Update(List<Employee> viewDatas)
        {
            var original = this.repository.GetAllData();

            var insertDatas = this.MakeInserData(original, viewDatas);
            var deleteDatas = this.MakeDeleteData(original, viewDatas);
            var updateDatas = this.MakeUpdateData(original, viewDatas);

            if (!this.ExistUpdateData(insertDatas, deleteDatas, updateDatas))
            {
                return false;
            }

            if (insertDatas.Any())
            {
                this.InsertDatas(insertDatas);
            }

            if (updateDatas.Any())
            {
                this.UpdatetDatas(updateDatas);
            }

            if (deleteDatas.Any())
            {
                this.DeleteDatas(deleteDatas);
            }

            return true;
        }

        /// <summary>
        /// 挿入
        /// </summary>
        /// <param name="employees">社員</param>
        /// <returns>true:正常 false:異常</returns>
        private bool InsertDatas(List<Employee> employees)
        {
            foreach (var employee in employees)
            {
                if (!this.repository.Insert(employee))
                {
                    var message = string.Format("Not Update , Exist Id Data InsertDatas" + "[{0}]", employee.Id);
                    throw new Exception(message);
                }
            }

            return true;
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="employees">社員</param>
        /// <returns>true:正常 false:異常</returns>
        private bool UpdatetDatas(List<Employee> employees)
        {
            foreach (var employee in employees)
            {
                if (!this.repository.Update(employee))
                {
                    var message = string.Format("Not Update , Not Id Data UpdateDatas" + "[{0}]", employee.Id);
                    throw new Exception(message);
                }
            }

            return true;
        }

        /// <summary>
        /// 削除
        /// </summary>
        /// <param name="employees">社員</param>
        /// <returns>true:正常 false:異常</returns>
        private bool DeleteDatas(List<Employee> employees)
        {
            foreach (var employee in employees)
            {
                if (!this.repository.Delete(employee.Id))
                {
                    var message = string.Format("Not Update , Not Id Data DeleteDatas" + "[{0}]", employee.Id);
                    throw new Exception(message);
                }
            }

            return true;
        }
    }
}
