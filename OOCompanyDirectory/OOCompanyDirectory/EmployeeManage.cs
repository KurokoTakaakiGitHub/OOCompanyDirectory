using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOCompanyDirectory
{
    /// <summary>
    /// 社員を管理する
    /// </summary>
    public class EmployeeManage
    {
        /// <summary>リポジトリ</summary>
        private readonly IEmployeeRepository _repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeManage"/> class.
        /// </summary>
        public EmployeeManage()
        {
            this._repository = new EmployeeRepository();
        }

        /// <summary>
        /// 苗字で問い合わせ
        /// </summary>
        /// <param name="firstName">苗字</param>
        /// <returns>社員リスト</returns>
        public List<Employee> InquireByFirstName(string firstName)
        {
            var list = this._repository.GetAllData();
            return list.Where(x => x.FirstName == firstName).ToList();
        }

        /// <summary>
        /// 名前で問い合わせ
        /// </summary>
        /// <param name="lastName">苗字</param>
        /// <returns>社員リスト</returns>
        public List<Employee> InquireByLastName(string lastName)
        {
            var list = this._repository.GetAllData();
            return list.Where(x => x.LastName == lastName).ToList();
        }

        /// <summary>
        /// 役職で問い合わせ
        /// </summary>
        /// <param name="position">役職</param>
        /// <returns>社員リスト</returns>
        public List<Employee> InquireByPosition(Position position)
        {
            var list = this._repository.GetAllData();
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
        public bool ValidateData(Employee employee, out string errorMessage)
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
        public bool CheckCorrelation(List<Employee> employees, out int errorRowIndex, out string errorMessage)
        {
            errorRowIndex = int.MaxValue;
            errorMessage = string.Empty;

            // Id重複チェック
            var duplications = employees.GroupBy(x => x.Id).Select(x => new { Id = x.Key, Count = x.Count() }).Where(x => x.Count > 1).FirstOrDefault();

            if (duplications != null)
            {
                errorRowIndex = employees.Select((p, i) => new { data = p, Index = i }).Where(x => x.data.Id == duplications.Id).Select(x => x.Index).FirstOrDefault();
                errorMessage = Resource.string_DuplicateId;
                return false;
            }

            return true;
        }

        /// <summary>
        /// 更新データ件数チェック
        /// </summary>
        /// <returns>true:対象なし false:対象あり</returns>
        public bool CheckUpdateDataCount()
        {
            // 更新前全データ取得
            var sourceData = this._repository.GetAllData();

            // 更新データ作成
            return true;
        }

        private List<Employee> MakeInserData()
        {
            return null;
        }

        private List<Employee> MakeUpdateData()
        {
            return null;
        }

        private List<Employee> MakeDeleteData()
        {
            return null;
        }

        /// <summary>
        /// 挿入
        /// </summary>
        /// <param name="employee">社員</param>
        /// <returns>true:正常 false:異常</returns>
        public bool Insert(Employee employee)
        {
            return this._repository.Insert(employee);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="employee">社員</param>
        /// <returns>true:正常 false:異常</returns>
        public bool Update(Employee employee)
        {
            return this._repository.Update(employee);
        }

        /// <summary>
        /// 削除
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns>true:正常 false:異常</returns>
        public bool Delete(int id)
        {
            return this._repository.Delete(id);
        }

        /// <summary>
        /// 全てのデータを取得
        /// </summary>
        /// <returns>社員リスト</returns>
        public List<Employee> GetAllData()
        {
            return this._repository.GetAllData();
        }
    }
}
