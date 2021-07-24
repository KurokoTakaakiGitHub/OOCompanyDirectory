using System.Collections.Generic;

namespace OOCompanyDirectory
{
    /// <summary>
    /// 社員・リポジトリ抽象化
    /// </summary>
    public interface IEmployeeRepository
    {
        /// <summary>全データ取得</summary>
        /// <returns>社員リスト</returns>
        List<Employee> GetAllData();

        /// <summary>追加</summary>
        /// <param name="employee">社員</param>
        /// <returns>正常・異常</returns>
        bool Insert(Employee employee);

        /// <summary>更新</summary>
        /// <param name="employee">社員</param>
        /// <returns>正常・異常</returns>
        bool Update(Employee employee);

        /// <summary>削除</summary>
        /// <param name="id">Id</param>
        /// <returns>正常・異常</returns>
        bool Delete(int id);
    }
}