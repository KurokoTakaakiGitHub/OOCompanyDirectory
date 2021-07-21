using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOCompanyDirectory
{
    /// <summary>
    /// オブジェクト・性別
    /// </summary>
    public class ObjectGender
    {
        /// <summary>Value</summary>
        public Gender Value { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ObjectGender"/> class.
        /// </summary>
        /// <param name="gender">役職</param>
        public ObjectGender(Gender gender)
        {
            this.Value = gender;
        }

        /// <summary>
        /// 文字列のオーバーライド
        /// </summary>
        /// <returns>文字列</returns>
        public override string ToString()
        {
            return GenderExt.DisplayName(this.Value);
        }
    }
}