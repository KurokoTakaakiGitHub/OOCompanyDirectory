using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace OOCompanyDirectory
{
    /// <summary>
    /// 社員・プレゼンター
    /// </summary>
    public　class EmployeePresenter
    {
        private readonly IEmployeeView employeeView;
        private readonly EmployeeManage employeeManage;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeePresenter"/> class.
        /// </summary>
        /// <param name="view">View</param>
        public EmployeePresenter(IEmployeeView view)
        {
            this.employeeView = view;
            try
            {
                this.employeeView.ButtonEnable(true, false);

                // 各ボタンの処理を登録
                this.employeeView.SearchAllAction += this.ButtonSearchAll;
                this.employeeView.SearchFirstNameAction += this.ButtonSearchFirstName;
                this.employeeView.SearchLastNameAction += this.ButtnSearchLastName;
                this.employeeView.SearchPositionAction += this.ButtnSearchPosition;
                this.employeeView.UpdateAction += this.ButtnUpdate;
                this.employeeView.CloseFormAction += this.ButtnClose;

                // 社員管理生成
                this.employeeManage = new EmployeeManage("datafile.json");

                // 役職コンボボックス設定
                this.SetComboBoxSelectPositionItem();
            }
            catch (System.IO.IOException ex)
            {
                this.ShowMessage(MessageLevel.Error, "Not File datafile.json");
                this.employeeView.ButtonEnable(false, true);
            }
            catch (Exception e)
            {
                this.ShowMessage(MessageLevel.Error, e.Message + "\n" + e.StackTrace);
            }
        }

        /// <summary>
        /// 役職コンボボックス設定
        /// </summary>
        public void SetComboBoxSelectPositionItem()
        {
            var positionsValues = (IEnumerable<Position>)Enum.GetValues(typeof(Position));
            this.employeeView.ComboBoxSelectPositionItems = positionsValues.Select(x => new ObjectPosition(x)).ToArray();
        }

        /// <summary>
        /// 全検索ボタン
        /// </summary>
        private void ButtonSearchAll()
        {
            var listData = this.employeeManage.GetAllData();
            var bindinglist = new BindingList<Employee>(listData.ToList());
            this.employeeView.ViewData = bindinglist;
        }

        /// <summary>
        /// 苗字検索ボタン
        /// </summary>
        /// <param name="firstname">苗字</param>
        private void ButtonSearchFirstName(string firstname)
        {
            if (string.IsNullOrWhiteSpace(firstname))
            {
                this.ShowMessage(MessageLevel.Information, Resource.string_NotSekectFirstName);
                return;
            }

            var listData = this.employeeManage.InquireByFirstName(firstname);
            var bindinglist = new BindingList<Employee>(listData.ToList());
            this.employeeView.ViewData = bindinglist;
        }

        /// <summary>
        /// 名前検索ボタン
        /// </summary>
        /// <param name="lastname">名前</param>
        private void ButtnSearchLastName(string lastname)
        {
            if (string.IsNullOrWhiteSpace(lastname))
            {
                this.ShowMessage(MessageLevel.Information, Resource.string_NotSekectLastName);
                return;
            }

            var listData = this.employeeManage.InquireByLastName(lastname);
            var bindinglist = new BindingList<Employee>(listData.ToList());
            this.employeeView.ViewData = bindinglist;
        }

        /// <summary>
        /// 役職検索ボタン
        /// </summary>
        /// <param name="selecedtPositionItem">選択した役職</param>
        private void ButtnSearchPosition(object selecedtPositionItem)
        {
            if (!(selecedtPositionItem is ObjectPosition objectPosition))
            {
                this.ShowMessage(MessageLevel.Information, Resource.string_NotSelectPosition);
                return;
            }

            var listData = this.employeeManage.InquireByPosition(objectPosition.Value);
            var bindinglist = new BindingList<Employee>(listData.ToList());
            this.employeeView.ViewData = bindinglist;
        }

        /// <summary>
        /// 更新ボタン
        /// </summary>
        private void ButtnUpdate()
        {
            try
            {
                var updateData = this.employeeView.ViewData;
                if (updateData is null)
                {
                    this.ShowMessage(MessageLevel.Information, Resource.string_NotUpdataData);
                    return;
                }

                if (!this.employeeManage.ValidateData(updateData.ToList(), out var errorRowIndex, out var errorMessage))
                {
                    this.ShowMessage(MessageLevel.Warning, errorMessage);

                    if (errorRowIndex != int.MaxValue)
                    {
                        this.employeeView.DataGridViewSelectRow(errorRowIndex);
                    }

                    return;
                }

                if (!this.employeeManage.CheckExistUpdateData(this.employeeView.ViewData.ToList()))
                {
                    this.ShowMessage(MessageLevel.Information, Resource.string_NotUpdataData);
                    return;
                }

                this.employeeManage.Update(this.employeeView.ViewData.ToList());

                this.ShowMessage(MessageLevel.Information, Resource.string_UpdateSucceeded);
            }
            catch (Exception e)
            {
                this.ShowMessage(MessageLevel.Information, Resource.string_UpdateFailed);
            }
        }

        /// <summary>
        /// 閉じるボタン
        /// </summary>
        private void ButtnClose()
        {
            this.employeeView.FormClose();
        }

        /// <summary>
        /// メッセージ表示
        /// </summary>
        /// <param name="message">メッセージ</param>
        private void ShowMessage(MessageLevel messageLevel, string message)
        {
            switch (messageLevel)
            {
                case MessageLevel.Information:
                    CustomMessageBox.Show((IWin32Window)this.employeeView, message, messageLevel.DisplayName(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;

                case MessageLevel.Warning:
                    CustomMessageBox.Show((IWin32Window)this.employeeView, message, messageLevel.DisplayName(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;

                case MessageLevel.Error:
                    CustomMessageBox.Show((IWin32Window)this.employeeView, message, messageLevel.DisplayName(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
            }
        }
    }
}
