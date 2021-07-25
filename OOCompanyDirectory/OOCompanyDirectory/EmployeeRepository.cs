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
    public class EmployeeRepository : IEmployeeRepository
    {
        /// <summary>社員</summary>
        private readonly List<Employee> employees;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeRepository"/> class.
        /// </summary>
        /// <param name="loadFileName">読込ファイル</param>
        public EmployeeRepository(string loadFileName)
        {
            var reader = new StreamReader(loadFileName);
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

            this.employees = JsonSerializer.Deserialize<List<Employee>>(jsonreadtext, option);
        }

        /// <summary>
        /// 全データ取得
        /// </summary>
        /// <returns>社員リスト</returns>
        public List<Employee> GetAllData()
        {
            return this.employees.Select(x => (Employee)x.DeepCopy()).ToList();
        }

        /// <summary>
        /// データ書き込み
        /// </summary>
        private void WriteData()
        {
            var jsonText = JsonSerializer.Serialize(this.employees);
            var file = new StreamWriter("datafile.json");

            file.Write(jsonText);
            file.Close();
        }

        /// <summary>
        /// 追加
        /// </summary>
        /// <param name="employee">社員</param>
        /// <returns>true:正常　false:異常</returns>
        public bool Insert(Employee employee)
        {
            if (this.employees.Any(x => x.Id == employee.Id))
            {
                return false;
            }

            this.employees.Add(employee);
            this.WriteData();

            return true;
        }

        /// <summary>
        /// 指定した[id]で削除
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>true:正常 false:異常</returns>
        public bool Delete(int id)
        {
            var target = this.employees.FirstOrDefault(x => x.Id == id);
            if (target is null)
            {
                return false;
            }

            this.employees.Remove(target);
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
            var target = this.employees.FirstOrDefault(x => x.Id == employee.Id);
            if (target is null)
            {
                return false;
            }

            target.SetUpdateColumn(employee);
            this.WriteData();

            return true;
        }
    }
}
