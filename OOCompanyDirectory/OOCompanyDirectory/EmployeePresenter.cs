using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOCompanyDirectory
{
    /// <summary>
    /// 社員・プレゼンター
    /// </summary>
    public　class EmployeePresenter
    {
        private readonly IEmployeeView _employeeView;
        private readonly EmployeeManage _employeeManage;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeePresenter"/> class.
        /// </summary>
        /// <param name="view">View</param>
        public EmployeePresenter(IEmployeeView view)
        {
            this._employeeView = view;
            this._employeeManage = new EmployeeManage();

            // 各ボタンの処理を登録
            this._employeeView.SearchAllAction += this.ButtonSearchAll;
            this._employeeView.SearchFirstNameAction += this.ButtonSearchFirstName;
            this._employeeView.SearchLastNameAction += this.ButtnSearchLastName;
            this._employeeView.SearchPositionAction += this.ButtnSearchPosition;

            // 役職コンボボックス設定
            this.SetComboBoxSelectPositionItem();
        }

        /// <summary>
        /// 役職コンボボックス設定
        /// </summary>
        public void SetComboBoxSelectPositionItem()
        {
            var positionsValues = (IEnumerable<Position>)Enum.GetValues(typeof(Position));
            this._employeeView.ComboBoxSelectPositionItems = positionsValues.Select(x => new ObjectPosition(x)).ToArray();
        }

        /// <summary>
        /// 全検索ボタン
        /// </summary>
        public void ButtonSearchAll()
        {
            var listData = this._employeeManage.GetAllData();
            var bindinglist = new BindingList<Employee>(listData);
            this._employeeView.ViewData = bindinglist;
        }

        /// <summary>
        /// 苗字検索ボタン
        /// </summary>
        /// <param name="firstname">苗字</param>
        public void ButtonSearchFirstName(string firstname)
        {
            if (string.IsNullOrWhiteSpace(firstname))
            {
                this.ShowMessage(Resource.string_NotSekectFirstName);
                return;
            }

            var listData = this._employeeManage.InquireByFirstName(firstname);
            var bindinglist = new BindingList<Employee>(listData);
            this._employeeView.ViewData = bindinglist;
        }

        /// <summary>
        /// 名前検索ボタン
        /// </summary>
        /// <param name="lastname">名前</param>
        public void ButtnSearchLastName(string lastname)
        {
            if (string.IsNullOrWhiteSpace(lastname))
            {
                this.ShowMessage(Resource.string_NotSekectLastName);
                return;
            }

            var listData = this._employeeManage.InquireByLastName(lastname);
            var bindinglist = new BindingList<Employee>(listData);
            this._employeeView.ViewData = bindinglist;
        }

        /// <summary>
        /// 役職検索ボタン
        /// </summary>
        /// <param name="selecedtPositionItem">選択した役職</param>
        public void ButtnSearchPosition(object selecedtPositionItem)
        {
            if (!(selecedtPositionItem is ObjectPosition objectPosition))
            {
                this.ShowMessage(Resource.string_NotSelectPosition);
                return;
            }

            var listData = this._employeeManage.InquireByPosition(objectPosition.Value);
            var bindinglist = new BindingList<Employee>(listData);
            this._employeeView.ViewData = bindinglist;
        }

        /// <summary>
        /// メッセージ表示
        /// </summary>
        /// <param name="message">メッセージ</param>
        public void ShowMessage(string message)
        {
            CustomMessageBox.Show((IWin32Window)this._employeeView, message, "確認", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
