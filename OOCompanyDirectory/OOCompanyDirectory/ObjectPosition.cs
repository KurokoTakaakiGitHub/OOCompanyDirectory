using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOCompanyDirectory
{
    /// <summary>
    /// オブジェクト・役職
    /// </summary>
    public class ObjectPosition
    {
        /// <summary>Id</summary>
        public Position Value { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ObjectPosition"/> class.
        /// </summary>
        /// <param name="position">役職</param>
        public ObjectPosition(Position position)
        {
            this.Value = position;
        }

        /// <summary>
        /// 文字列のオーバーライド
        /// </summary>
        /// <returns>文字列</returns>
        public override string ToString()
        {
            return PositionExt.DisplayName(this.Value);
        }
    }
}
