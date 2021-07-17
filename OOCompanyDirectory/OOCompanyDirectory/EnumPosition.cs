using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOCompanyDirectory
{
    /// <summary>役職</summary>
    public enum Position
    {
        /// <summary>社員</summary>
        Staff,

        /// <summary>主任</summary>
        Chief,

        /// <summary>係長</summary>
        SectionHead,

        /// <summary>課長代理</summary>
        AssistantSectionChief,

        /// <summary>課長</summary>
        SectionChief,

        /// <summary>次長</summary>
        AssistantGeneralManager,

        /// <summary>部長</summary>
        GeneralManager,

        /// <summary>副社長</summary>
        ExecutiveDirector,

        /// <summary>専務取締役</summary>
        SeniorExecutiveDirector,

        /// <summary>社長</summary>
        President,

        /// <summary>相談役</summary>
        ExecutiveAdviser,

        /// <summary>取締役</summary>
        Director,
    }

    /// <summary>
    /// 役職・拡張
    /// </summary>
    public static class PositionExt
    {
        /// <summary>
        /// 役職における・拡張メソッド
        /// </summary>
        /// <param name="position">役職</param>
        /// <returns>役職名称</returns>
        public static string DisplayName(this Position position)
        {
            string[] names =
            {
                "Staff",
                "Chief", "SectionHead",
                "AssistantSectionChief",
                "SectionChief",
                "AssistantGeneralManager",
                "GeneralManager",
                "ExecutiveDirector",
                "SeniorExecutiveDirector",
                "President",
                "ExecutiveAdviser",
                "Director",
            };
            return names[(int)position];
        }
    }
}
