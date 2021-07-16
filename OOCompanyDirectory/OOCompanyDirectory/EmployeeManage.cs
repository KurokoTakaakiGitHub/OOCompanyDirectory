using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOCompanyDirectory
{
    class EmployeeManage
    {
        private IEmployeeRepository repository;

        public EmployeeManage()
        {
            repository = new JsonEmployeeRepository();
        }

        public List<Employee> InquireByFirstName(string firstName)
        {
            var list = repository.GetAllData();
            /* LINQを使わない
            var employees = new List<Employee>();
            
            foreach (var employee in list)
            {
                if(employee.FirstName == firstName)
                {
                    employees.Add(employee);
                }
            }
            */
            return list.Where(x => x.FirstName == firstName).ToList();
        }

        public List<Employee> InquireByLastName(string lastName)
        {
            var list = repository.GetAllData();

            return list.Where(x => x.LastName == lastName).ToList();
        }

        public List<Employee> InquireByPosition(Position position)
        {
            var list = repository.GetAllData();

            return list.Where(x => x.Position == position).ToList();
        }

        public bool ValidateData(Employee employee)
        {
            if(string.IsNullOrEmpty(employee.FirstName))
            {
                return false;
            }

            if (string.IsNullOrEmpty(employee.LastName))
            {
                return false;
            }

            if (employee.Age < 18)
            {
                return false;
            }

            return true;
        }

        public bool Insert(Employee employee)
        {
            return repository.Insert(employee);
        }

        public bool Update(Employee employee)
        {
            return repository.Update(employee);
        }

        public bool Delete(int id)
        {
            return repository.Delete(id);
        }

        public List<Employee> GetAllData()
        {
            return repository.GetAllData();
        }
    }
}
