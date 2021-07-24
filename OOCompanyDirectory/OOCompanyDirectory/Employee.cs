using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOCompanyDirectory
{
    /// <summary>
    /// 社員
    /// </summary>
    [Serializable]
    public class Employee
    {
        /// <summary>Id</summary>
        public int Id { get;  set; }

        /// <summary>苗字</summary>
        public string FirstName { get; set; }

        /// <summary>名前</summary>
        public string LastName { get; set; }

        /// <summary>年齢</summary>
        public int Age { get; set; }

        /// <summary>性別</summary>
        public Gender Gender { get; set; }

        /// <summary>役職</summary>
        public Position Position { get; set; }

        /// <summary>
        /// 更新項目をセット
        /// </summary>
        /// <param name="updateData">更新データ</param>
        public void SetUpdateColumn(Employee updateData)
        {
            this.FirstName = updateData.FirstName;
            this.LastName = updateData.LastName;
            this.Age = updateData.Age;
            this.Gender = updateData.Gender;
            this.Position = updateData.Position;
        }
    }

    /// <summary>
    /// 社員カラムインデックス
    /// </summary>
    public enum EmployeeColumnIndex
    {
        /// <summary>Id</summary>
        Id,

        /// <summary>苗字</summary>
        FirstName,

        /// <summary>名前</summary>
        LastName,

        /// <summary>年齢</summary>
        Age,

        /// <summary>性別</summary>
        Gender,

        /// <summary>役職</summary>
        Position,
    }
}
