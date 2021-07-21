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
            this._repository = new JsonEmployeeRepository();
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
        /// <returns>true:正常 false:異常</returns>
        public bool ValidateData(List<Employee> employees , out int errorIndex, out string errorMessage)
        {
            errorIndex = 0;
            errorMessage = string.Empty;
            foreach (var employee in employees)
            {
                if (!this.ValidateData(employee, out errorMessage))
                {
                    return false;
                }

                errorIndex++;
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
        /// <param name="employee">社員</param>
        /// <param name="errorMessage">エラーメッセージ</param>
        /// <returns>true:正常 false:異常</returns>
        public bool ChecCorrelation(Employee employee, out string errorMessage)
        {
            errorMessage = string.Empty;
            return true;
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
