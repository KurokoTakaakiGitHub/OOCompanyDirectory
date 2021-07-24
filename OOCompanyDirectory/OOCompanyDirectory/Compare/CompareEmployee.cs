using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOCompanyDirectory
{
    /// <summary>
    /// 社員・Idで比較
    /// </summary>
    public class CompareEmployeeId : IEqualityComparer<Employee>
    {
        public bool Equals(Employee x, Employee y)
        {
            return x.Id == y.Id;
        }

        public int GetHashCode(Employee obj)
        {
            return obj.Id.GetHashCode();
        }
    }

    /// <summary>
    /// 社員・全項目で較
    /// </summary>
    public class CompareEmployeeALL : IEqualityComparer<Employee>
    {
        public bool Equals(Employee x, Employee y)
        {
            return
                x.Id == y.Id
             && x.FirstName == y.FirstName
             && x.LastName == y.LastName
             && x.Age == y.Age
             && x.Position == y.Position
             && x.Gender == y.Gender;
        }

        public int GetHashCode(Employee obj)
        {
            return obj.Id.GetHashCode() ^ obj.FirstName.GetHashCode() ^ obj.LastName.GetHashCode() ^ obj.Age.GetHashCode() ^ obj.Position.GetHashCode() ^ obj.Gender.GetHashCode();
        }
    }
}
