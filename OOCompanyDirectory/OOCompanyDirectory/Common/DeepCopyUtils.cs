using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace OOCompanyDirectory
{
    /// <summary>
    /// ユーティリティ・DeepCopy
    /// </summary>
    public static class DeepCopyUtils
    {
        public static object DeepCopy(this object target)
        {
            object result;
            BinaryFormatter b = new BinaryFormatter();
            MemoryStream mem = new MemoryStream();
            try
            {
                b.Serialize(mem, target);
                mem.Position = 0;
                result = b.Deserialize(mem);
            }
            finally
            {
                mem.Close();
            }

            return result;
        }
    }

    /// <summary>
    /// DeepCopyHelper
    /// </summary>
    public static class DeepCopyHelper
    {
        /// <summary>
        /// DeepCopy
        /// </summary>
        /// <param name="target">コピー元</param>
        /// <returns>コピー後</returns>
        public static Employee DeepCopy(Employee target)
        {
            Employee result;
            BinaryFormatter b = new BinaryFormatter();
            MemoryStream mem = new MemoryStream();
            try
            {
                b.Serialize(mem, target);
                mem.Position = 0;
                result = (Employee)b.Deserialize(mem);
            }
            finally
            {
                mem.Close();
            }

            return result;
        }
    }
}
