using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOCompanyDirectory
{
    /// <summary>
    /// 社員・View抽象化
    /// </summary>
    public interface IEmployeeView
    {
        /// <summary>表示するデータ</summary>
        BindingList<Employee> ViewData { get; set; }

        /// <summary>役職コンボボックスアイテム</summary>
        ObjectPosition[] ComboBoxSelectPositionItems { set; }

        /// <summary>全てを表示する</summary>
        Action SearchAllAction { get; set; }

        /// <summary>苗字で検索する</summary>
        Action<string> SearchFirstNameAction { get; set; }

        /// <summary>名前で検索する</summary>
        Action<string> SearchLastNameAction { get; set; }

        /// <summary>役職で検索する</summary>
        Action<object> SearchPositionAction { get; set; }

        /// <summary>更新する</summary>
        Action UpdateAction { get; set; }

        /// <summary>フォームを閉じる</summary>
        Action CloseFormAction { get; set; }

        /// <summary>フォーム閉じる</summary>
        void FormClose();
    }
}