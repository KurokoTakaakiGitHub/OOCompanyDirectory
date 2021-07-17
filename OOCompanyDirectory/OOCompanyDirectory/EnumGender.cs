using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOCompanyDirectory
{
    /// <summary>
    /// 性別
    /// </summary>
    public enum Gender
    {
        /// <summary>男</summary>
        Male,

        /// <summary>女</summary>
        Female,
    }

    /// <summary>
    /// 性別・拡張
    /// </summary>
    public static class GenderExt
    {
        /// <summary>
        /// 性別における・拡張メソッド
        /// </summary>
        /// <param name="gender">性別</param>
        /// <returns>性別名称</returns>
        public static string DisplayName(this Position gender)
        {
            string[] names = { "男", "女", };
            return names[(int)gender];
        }
    }
}
