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
    /// 社員・View
    /// </summary>
    public partial class EmployeeView : Form, IEmployeeView
    {
        /// <summary>表示するデータ</summary>
        public BindingList<Employee> ViewData
        {
            get { return (BindingList<Employee>)this.DataGridViewEmployeeDataGrid.DataSource; }
            set { this.DataGridViewEmployeeDataGrid.DataSource = value; }
        }

        /// <summary>役職コンボボックスアイテム</summary>
        public ObjectPosition[] ComboBoxSelectPositionItems
        {
            set { this.ComboBoxSelectPosition.Items.AddRange(value); }
        }

        /// <summary>全てを表示する</summary>
        public Action SearchAllAction { get; set; }

        /// <summary>苗字で検索する</summary>
        public Action<string> SearchFirstNameAction { get; set; }

        /// <summary>名前で検索する</summary>
        public Action<string> SearchLastNameAction { get; set; }

        /// <summary>役職で検索する</summary>
        public Action<object> SearchPositionAction { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeView"/> class.
        /// </summary>
        public EmployeeView()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// 読込
        /// </summary>
        /// <param name="sender">呼出し元</param>
        /// <param name="e">パラメータ</param>
        private void EmployeeView_Load(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// 全検索ボタンをクリック
        /// </summary>
        /// <param name="sender">呼出し元</param>
        /// <param name="e">パラメータ</param>
        private void ButtonSearchAll_Click(object sender, EventArgs e)
        {
            this.SearchAllAction();
        }

        /// <summary>
        /// 苗字検索ボタンをクリック
        /// </summary>
        /// <param name="sender">呼出し元</param>
        /// <param name="e">パラメータ</param>
        private void ButtonSearchFirstName_Click(object sender, EventArgs e)
        {
            this.SearchFirstNameAction(this.TextBoxSearchFirstName.Text);
        }

        /// <summary>
        /// 名前検索ボタンをクリック
        /// </summary>
        /// <param name="sender">呼出し元</param>
        /// <param name="e">パラメータ</param>
        private void ButtonSearchLastName_Click(object sender, EventArgs e)
        {
            this.SearchLastNameAction(this.TextBoxSearchLastName.Text);
        }

        /// <summary>
        /// 役職検索ボタンをクリック
        /// </summary>
        /// <param name="sender">呼出し元</param>
        /// <param name="e">パラメータ</param>
        private void ButtonSearchPosition_Click(object sender, EventArgs e)
        {
            this.SearchPositionAction(this.ComboBoxSelectPosition.SelectedItem);
        }

        /// <summary>
        /// 更新ボタンをクリック
        /// </summary>
        /// <param name="sender">呼出し元</param>
        /// <param name="e">パラメータ</param>
        private void ButtonUpdate_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 閉じるボタンをクリック
        /// </summary>
        /// <param name="sender">呼出し元</param>
        /// <param name="e">パラメータ</param>
        private void ButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
