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

            set { this.SetBindingListDataGlidView(value); }
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

        /// <summary>更新する</summary>
        public Action UpdateAction { get; set; }

        /// <summary>フォームを閉じる</summary>
        public Action CloseFormAction { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeView"/> class.
        /// </summary>
        public EmployeeView()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// ＤＧＶにデータを設定する
        /// </summary>
        /// <param name="bindingList">データ</param>
        private void SetBindingListDataGlidView(BindingList<Employee> bindingList)
        {
            this.DataGridViewEmployeeDataGrid.Columns.Clear();

            this.DataGridViewEmployeeDataGrid.AutoGenerateColumns = false;
            this.DataGridViewEmployeeDataGrid.DataSource = bindingList;

            var test = new List<DataGridViewColumn>();
            this.DataGridViewEmployeeDataGrid.Columns.Add(this.CreateDgvTextBoxColumn(nameof(EmployeeColumnIndex.Id), false));
            this.DataGridViewEmployeeDataGrid.Columns.Add(this.CreateDgvTextBoxColumn(nameof(EmployeeColumnIndex.FirstName), false));
            this.DataGridViewEmployeeDataGrid.Columns.Add(this.CreateDgvTextBoxColumn(nameof(EmployeeColumnIndex.LastName), false));
            this.DataGridViewEmployeeDataGrid.Columns.Add(this.CreateDgvTextBoxColumn(nameof(EmployeeColumnIndex.Age), false));

            // 職位
            var positionColumn = this.CreateDgvComboBoxColumn(nameof(EmployeeColumnIndex.Position), Enum.GetValues(typeof(Position)));
            this.DataGridViewEmployeeDataGrid.Columns.Add(positionColumn);

            // 性別
            var genderColumn = this.CreateDgvComboBoxColumn(nameof(EmployeeColumnIndex.Gender), Enum.GetValues(typeof(Gender)));
            this.DataGridViewEmployeeDataGrid.Columns.Add(genderColumn);

            this.DataGridViewEmployeeDataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        /// <summary>
        /// データグリッドビューのテキストボックスカラムを生成
        /// </summary>
        /// <param name="columnName">列名</param>
        /// <param name="isReadOnly">読み取り専用</param>
        /// <returns>テキストボックスカラム</returns>
        private DataGridViewTextBoxColumn CreateDgvTextBoxColumn(string columnName, bool isReadOnly)
        {
            return new DataGridViewTextBoxColumn()
            {
                DataPropertyName = columnName,
                Name = columnName,
                HeaderText = columnName,
                ReadOnly = isReadOnly,
            };
        }

        /// <summary>
        /// データグリッドビューのコンボボックスカラムを生成
        /// </summary>
        /// <param name="columnName">列名</param>
        /// <param name="array">コンボボックスに設定する配列</param>
        /// <returns>コンボボックスカラム</returns>
        private DataGridViewComboBoxColumn CreateDgvComboBoxColumn(string columnName, Array array)
        {
            return new DataGridViewComboBoxColumn()
            {
                DataPropertyName = columnName,
                Name = columnName,
                HeaderText = columnName,
                FlatStyle = FlatStyle.Flat,
                DataSource = array,
            };
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
            this.UpdateAction();
        }

        /// <summary>
        /// 閉じるボタンをクリック
        /// </summary>
        /// <param name="sender">呼出し元</param>
        /// <param name="e">パラメータ</param>
        private void ButtonClose_Click(object sender, EventArgs e)
        {
            this.CloseFormAction();
        }

        /// <summary>
        /// dgv入力するテキストボックス表示しているとき
        /// </summary>
        /// <param name="sender">呼出し元</param>
        /// <param name="e">パラメータ</param>
        private void DataGridViewEmployeeDataGrid_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control is DataGridViewTextBoxEditingControl)
            {
                var dgv = (DataGridView)sender;
                var textBox = (TextBox)e.Control;

                if (dgv.CurrentCell.ColumnIndex == 0 || dgv.CurrentCell.ColumnIndex == 3)
                {
                    textBox.KeyPress += new KeyPressEventHandler(this.CheckKey);
                }
                else
                {
                    textBox.KeyPress -= new KeyPressEventHandler(this.CheckKey);
                }
            }
        }

        /// <summary>
        /// キーチェック
        /// </summary>
        /// <param name="sender">呼出し元</param>
        /// <param name="e">パラメータ</param>
        private void CheckKey(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// フォームを閉じる
        /// </summary>
        public void FormClose()
        {
            this.Close();
        }

        /// <summary>
        /// データグリッドView・行選択
        /// </summary>
        /// <param name="selectRowIndex">選択する行番号</param>
        public　void DataGridViewSelectRow(int selectRowIndex)
        {
            this.DataGridViewEmployeeDataGrid.ClearSelection();
            this.DataGridViewEmployeeDataGrid.Rows[selectRowIndex].Selected = true;
        }

        /// <summary>
        /// ボタンを有効にする
        /// </summary>
        /// <param name="isEnable">有効にする</param>
        /// <param name="isExceptClosButton">閉じるボタンを除く</param>
        public void ButtonEnable(bool isEnable, bool isExceptClosButton)
        {
            this.ButtonSearchAll.Enabled = isEnable;
            this.ButtonSearchFirstName.Enabled = isEnable;
            this.ButtonSearchLastName.Enabled = isEnable;
            this.ButtonSearcPositionh.Enabled = isEnable;
            this.ButtonUpdate.Enabled = isEnable;
            this.ButtonClose.Enabled = isEnable;

            if (isExceptClosButton)
            {
                this.ButtonClose.Enabled = !isEnable;
            }
        }

        private void DataGridViewEmployeeDataGrid_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            var dgv = (DataGridView)sender;

            if (dgv.Columns[e.ColumnIndex].Name == "Id" && !dgv.Rows[e.RowIndex].IsNewRow)
            {
                e.Cancel = true;
            }
        }
    }
}
