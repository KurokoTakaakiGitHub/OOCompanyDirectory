
namespace OOCompanyDirectory
{
    partial class EmployeeView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.EmployeeDataGrid = new System.Windows.Forms.DataGridView();
            this.DisplayAllCommand = new System.Windows.Forms.Button();
            this.FirstNameSearchCommand = new System.Windows.Forms.Button();
            this.FirstNameField = new System.Windows.Forms.TextBox();
            this.LastNameSearchCommand = new System.Windows.Forms.Button();
            this.LastNameField = new System.Windows.Forms.TextBox();
            this.PositionSelect = new System.Windows.Forms.ComboBox();
            this.PositionSearchCommand = new System.Windows.Forms.Button();
            this.UpdateCommand = new System.Windows.Forms.Button();
            this.CloseCommand = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.EmployeeDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // EmployeeDataGrid
            // 
            this.EmployeeDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.EmployeeDataGrid.Location = new System.Drawing.Point(12, 41);
            this.EmployeeDataGrid.Name = "EmployeeDataGrid";
            this.EmployeeDataGrid.RowTemplate.Height = 21;
            this.EmployeeDataGrid.Size = new System.Drawing.Size(695, 355);
            this.EmployeeDataGrid.TabIndex = 0;
            // 
            // DisplayAllCommand
            // 
            this.DisplayAllCommand.Location = new System.Drawing.Point(12, 12);
            this.DisplayAllCommand.Name = "DisplayAllCommand";
            this.DisplayAllCommand.Size = new System.Drawing.Size(75, 23);
            this.DisplayAllCommand.TabIndex = 1;
            this.DisplayAllCommand.Text = "全検索";
            this.DisplayAllCommand.UseVisualStyleBackColor = true;
            this.DisplayAllCommand.Click += new System.EventHandler(this.DisplayAllCommand_Click);
            // 
            // FirstNameSearchCommand
            // 
            this.FirstNameSearchCommand.Location = new System.Drawing.Point(234, 12);
            this.FirstNameSearchCommand.Name = "FirstNameSearchCommand";
            this.FirstNameSearchCommand.Size = new System.Drawing.Size(75, 23);
            this.FirstNameSearchCommand.TabIndex = 1;
            this.FirstNameSearchCommand.Text = "苗字検索";
            this.FirstNameSearchCommand.UseVisualStyleBackColor = true;
            this.FirstNameSearchCommand.Click += new System.EventHandler(this.FirstNameSearchCommand_Click);
            // 
            // FIrstNameField
            // 
            this.FirstNameField.Location = new System.Drawing.Point(128, 16);
            this.FirstNameField.Name = "FIrstNameField";
            this.FirstNameField.Size = new System.Drawing.Size(100, 19);
            this.FirstNameField.TabIndex = 2;
            // 
            // LastNameSearchCommand
            // 
            this.LastNameSearchCommand.Location = new System.Drawing.Point(424, 12);
            this.LastNameSearchCommand.Name = "LastNameSearchCommand";
            this.LastNameSearchCommand.Size = new System.Drawing.Size(75, 23);
            this.LastNameSearchCommand.TabIndex = 1;
            this.LastNameSearchCommand.Text = "名前検索";
            this.LastNameSearchCommand.UseVisualStyleBackColor = true;
            this.LastNameSearchCommand.Click += new System.EventHandler(this.LastNameSearchCommand_Click);
            // 
            // textBox1
            // 
            this.LastNameField.Location = new System.Drawing.Point(318, 16);
            this.LastNameField.Name = "textBox1";
            this.LastNameField.Size = new System.Drawing.Size(100, 19);
            this.LastNameField.TabIndex = 2;
            // 
            // PositionSelect
            // 
            this.PositionSelect.FormattingEnabled = true;
            this.PositionSelect.Location = new System.Drawing.Point(505, 16);
            this.PositionSelect.Name = "PositionSelect";
            this.PositionSelect.Size = new System.Drawing.Size(121, 20);
            this.PositionSelect.TabIndex = 3;
            // 
            // PositionSearchCommand
            // 
            this.PositionSearchCommand.Location = new System.Drawing.Point(632, 14);
            this.PositionSearchCommand.Name = "PositionSearchCommand";
            this.PositionSearchCommand.Size = new System.Drawing.Size(75, 23);
            this.PositionSearchCommand.TabIndex = 1;
            this.PositionSearchCommand.Text = "役職検索";
            this.PositionSearchCommand.UseVisualStyleBackColor = true;
            this.PositionSearchCommand.Click += new System.EventHandler(this.PositionSearchCommand_Click);
            // 
            // UpdateCommand
            // 
            this.UpdateCommand.Location = new System.Drawing.Point(551, 402);
            this.UpdateCommand.Name = "UpdateCommand";
            this.UpdateCommand.Size = new System.Drawing.Size(75, 23);
            this.UpdateCommand.TabIndex = 1;
            this.UpdateCommand.Text = "更新";
            this.UpdateCommand.UseVisualStyleBackColor = true;
            this.UpdateCommand.Click += new System.EventHandler(this.UpdateCommand_Click);
            // 
            // CloseCommand
            // 
            this.CloseCommand.Location = new System.Drawing.Point(632, 402);
            this.CloseCommand.Name = "CloseCommand";
            this.CloseCommand.Size = new System.Drawing.Size(75, 23);
            this.CloseCommand.TabIndex = 1;
            this.CloseCommand.Text = "閉じる";
            this.CloseCommand.UseVisualStyleBackColor = true;
            this.CloseCommand.Click += new System.EventHandler(this.CloseCommand_Click);
            // 
            // EmployeeView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(723, 450);
            this.Controls.Add(this.PositionSelect);
            this.Controls.Add(this.LastNameField);
            this.Controls.Add(this.FirstNameField);
            this.Controls.Add(this.CloseCommand);
            this.Controls.Add(this.UpdateCommand);
            this.Controls.Add(this.PositionSearchCommand);
            this.Controls.Add(this.LastNameSearchCommand);
            this.Controls.Add(this.FirstNameSearchCommand);
            this.Controls.Add(this.DisplayAllCommand);
            this.Controls.Add(this.EmployeeDataGrid);
            this.Name = "EmployeeView";
            this.Text = "MainForm";
            ((System.ComponentModel.ISupportInitialize)(this.EmployeeDataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView EmployeeDataGrid;
        private System.Windows.Forms.Button DisplayAllCommand;
        private System.Windows.Forms.Button FirstNameSearchCommand;
        private System.Windows.Forms.TextBox FirstNameField;
        private System.Windows.Forms.Button LastNameSearchCommand;
        private System.Windows.Forms.TextBox LastNameField;
        private System.Windows.Forms.ComboBox PositionSelect;
        private System.Windows.Forms.Button PositionSearchCommand;
        private System.Windows.Forms.Button UpdateCommand;
        private System.Windows.Forms.Button CloseCommand;
    }
}