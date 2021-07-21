using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace OOCompanyDirectory
{
    /// <summary>
    /// Json社員・リポジトリ
    /// </summary>
    public class JsonEmployeeRepository : IEmployeeRepository
    {
        /// <summary>社員</summary>
        private readonly List<Employee> _employees;

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonEmployeeRepository"/> class.
        /// </summary>
        public JsonEmployeeRepository()
        {
            var reader = new StreamReader("datafile.json");
            var jsonreadtext = reader.ReadToEnd();
            reader.Close();
            var option = new JsonSerializerOptions
            {
                AllowTrailingCommas = true,
                Converters =
                {
                    new JsonStringEnumConverter(JsonNamingPolicy.CamelCase),
                },
            };

            this._employees = JsonSerializer.Deserialize<List<Employee>>(jsonreadtext, option);
        }

        /// <summary>
        /// 指定した[id]で削除
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>true:正常 false:異常</returns>
        public bool Delete(int id)
        {
            var target = this._employees.FirstOrDefault(x => x.Id == id);
            if (target == null)
            {
                return false;
            }

            this._employees.Remove(target);
            this.WriteData();

            return true;
        }

        /// <summary>
        /// データ書き込み
        /// </summary>
        private void WriteData()
        {
            var jsonText = JsonSerializer.Serialize(this._employees);
            var file = new StreamWriter("datafile.json");

            file.Write(jsonText);
            file.Close();
        }

        /// <summary>
        /// 全データ取得
        /// </summary>
        /// <returns>社員リスト</returns>
        public List<Employee> GetAllData()
        {
            return this._employees;
        }

        /// <summary>
        /// 追加
        /// </summary>
        /// <param name="employee">社員</param>
        /// <returns>true:正常　false:異常</returns>
        public bool Insert(Employee employee)
        {
            if (this._employees.Any(x => x.Id == employee.Id))
            {
                return false;
            }

            this._employees.Add(employee);
            this.WriteData();

            return true;
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="employee">社員</param>
        /// <returns>true:正常　false:異常</returns>
        public bool Update(Employee employee)
        {
            var target = this._employees.FirstOrDefault(x => x.Id == employee.Id);
            if (target == null)
            {
                return false;
            }

            target.FirstName = employee.FirstName;
            target.LastName = employee.LastName;
            target.Age = employee.Age;
            target.Gender = employee.Gender;
            target.Position = employee.Position;

            this.WriteData();

            return true;
        }
    }

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
