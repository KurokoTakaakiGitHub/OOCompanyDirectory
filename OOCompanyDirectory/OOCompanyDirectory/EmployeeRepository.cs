using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OOCompanyDirectory
{
    interface IEmployeeRepository
    {
        List<Employee> GetAllData();
        bool Insert(Employee employee);
        bool Update(Employee employee);
        bool Delete(int id);
    }

    class JsonEmployeeRepository : IEmployeeRepository
    {
        private List<Employee> employees;

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
                }
            };

            employees = JsonSerializer.Deserialize<List<Employee>>(jsonreadtext, option);
        }

        public bool Delete(int id)
        {
            var target = employees.FirstOrDefault(x => x.Id == id);
            if (target == null)
            {
                return false;
            }

            employees.Remove(target);
            WriteData();

            return true;
        }

        private void WriteData()
        {
            var jsonText = JsonSerializer.Serialize(employees);
            var file = new StreamWriter("datafile.json");

            file.Write(jsonText);
            file.Close();
        }

        public List<Employee> GetAllData()
        {
            return employees;
        }

        public bool Insert(Employee employee)
        {
            if (employees.Any(x => x.Id == employee.Id))
            {
                return false;
            }

            #region LINQを使わないと…
            //bool isExist = false;
            //foreach (var emp in employees)
            //{
            //    if(emp.Id == employee.Id)
            //    {
            //        isExist = true;
            //        break;
            //    }
            //}
            //if (isExist)
            //{
            //    return false;
            //}
            #endregion

            employees.Add(employee);
            WriteData();

            return true;
        }

        public bool Update(Employee employee)
        {
            var target = employees.FirstOrDefault(x => x.Id == employee.Id);
            if(target == null)
            {
                return false;
            }

            target.FirstName = employee.FirstName;
            target.LastName = employee.LastName;
            target.Age = employee.Age;
            target.Gender = employee.Gender;
            target.Position = employee.Position;

            WriteData();

            return true;
        }
    }
}
