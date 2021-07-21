
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
            this.DataGridViewEmployeeDataGrid = new System.Windows.Forms.DataGridView();
            this.ButtonSearchAll = new System.Windows.Forms.Button();
            this.ButtonSearchFirstName = new System.Windows.Forms.Button();
            this.TextBoxSearchFirstName = new System.Windows.Forms.TextBox();
            this.ButtonSearchLastName = new System.Windows.Forms.Button();
            this.TextBoxSearchLastName = new System.Windows.Forms.TextBox();
            this.ComboBoxSelectPosition = new System.Windows.Forms.ComboBox();
            this.ButtonSearcPositionh = new System.Windows.Forms.Button();
            this.ButtonUpdate = new System.Windows.Forms.Button();
            this.ButtonClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewEmployeeDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // DataGridViewEmployeeDataGrid
            // 
            this.DataGridViewEmployeeDataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DataGridViewEmployeeDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridViewEmployeeDataGrid.Location = new System.Drawing.Point(12, 41);
            this.DataGridViewEmployeeDataGrid.Name = "DataGridViewEmployeeDataGrid";
            this.DataGridViewEmployeeDataGrid.RowTemplate.Height = 21;
            this.DataGridViewEmployeeDataGrid.Size = new System.Drawing.Size(754, 355);
            this.DataGridViewEmployeeDataGrid.TabIndex = 0;
            this.DataGridViewEmployeeDataGrid.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.DataGridViewEmployeeDataGrid_EditingControlShowing);
            // 
            // ButtonSearchAll
            // 
            this.ButtonSearchAll.Location = new System.Drawing.Point(12, 12);
            this.ButtonSearchAll.Name = "ButtonSearchAll";
            this.ButtonSearchAll.Size = new System.Drawing.Size(75, 23);
            this.ButtonSearchAll.TabIndex = 1;
            this.ButtonSearchAll.Text = "全検索";
            this.ButtonSearchAll.UseVisualStyleBackColor = true;
            this.ButtonSearchAll.Click += new System.EventHandler(this.ButtonSearchAll_Click);
            // 
            // ButtonSearchFirstName
            // 
            this.ButtonSearchFirstName.Location = new System.Drawing.Point(234, 12);
            this.ButtonSearchFirstName.Name = "ButtonSearchFirstName";
            this.ButtonSearchFirstName.Size = new System.Drawing.Size(75, 23);
            this.ButtonSearchFirstName.TabIndex = 1;
            this.ButtonSearchFirstName.Text = "苗字検索";
            this.ButtonSearchFirstName.UseVisualStyleBackColor = true;
            this.ButtonSearchFirstName.Click += new System.EventHandler(this.ButtonSearchFirstName_Click);
            // 
            // TextBoxSearchFirstName
            // 
            this.TextBoxSearchFirstName.Location = new System.Drawing.Point(128, 16);
            this.TextBoxSearchFirstName.Name = "TextBoxSearchFirstName";
            this.TextBoxSearchFirstName.Size = new System.Drawing.Size(100, 19);
            this.TextBoxSearchFirstName.TabIndex = 2;
            // 
            // ButtonSearchLastName
            // 
            this.ButtonSearchLastName.Location = new System.Drawing.Point(424, 12);
            this.ButtonSearchLastName.Name = "ButtonSearchLastName";
            this.ButtonSearchLastName.Size = new System.Drawing.Size(75, 23);
            this.ButtonSearchLastName.TabIndex = 1;
            this.ButtonSearchLastName.Text = "名前検索";
            this.ButtonSearchLastName.UseVisualStyleBackColor = true;
            this.ButtonSearchLastName.Click += new System.EventHandler(this.ButtonSearchLastName_Click);
            // 
            // TextBoxSearchLastName
            // 
            this.TextBoxSearchLastName.Location = new System.Drawing.Point(318, 16);
            this.TextBoxSearchLastName.Name = "TextBoxSearchLastName";
            this.TextBoxSearchLastName.Size = new System.Drawing.Size(100, 19);
            this.TextBoxSearchLastName.TabIndex = 2;
            // 
            // ComboBoxSelectPosition
            // 
            this.ComboBoxSelectPosition.FormattingEnabled = true;
            this.ComboBoxSelectPosition.Location = new System.Drawing.Point(505, 16);
            this.ComboBoxSelectPosition.Name = "ComboBoxSelectPosition";
            this.ComboBoxSelectPosition.Size = new System.Drawing.Size(180, 20);
            this.ComboBoxSelectPosition.TabIndex = 3;
            // 
            // ButtonSearcPositionh
            // 
            this.ButtonSearcPositionh.Location = new System.Drawing.Point(691, 14);
            this.ButtonSearcPositionh.Name = "ButtonSearcPositionh";
            this.ButtonSearcPositionh.Size = new System.Drawing.Size(75, 23);
            this.ButtonSearcPositionh.TabIndex = 1;
            this.ButtonSearcPositionh.Text = "役職検索";
            this.ButtonSearcPositionh.UseVisualStyleBackColor = true;
            this.ButtonSearcPositionh.Click += new System.EventHandler(this.ButtonSearchPosition_Click);
            // 
            // ButtonUpdate
            // 
            this.ButtonUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonUpdate.Location = new System.Drawing.Point(610, 402);
            this.ButtonUpdate.Name = "ButtonUpdate";
            this.ButtonUpdate.Size = new System.Drawing.Size(75, 23);
            this.ButtonUpdate.TabIndex = 1;
            this.ButtonUpdate.Text = "更新";
            this.ButtonUpdate.UseVisualStyleBackColor = true;
            this.ButtonUpdate.Click += new System.EventHandler(this.ButtonUpdate_Click);
            // 
            // ButtonClose
            // 
            this.ButtonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonClose.Location = new System.Drawing.Point(691, 402);
            this.ButtonClose.Name = "ButtonClose";
            this.ButtonClose.Size = new System.Drawing.Size(75, 23);
            this.ButtonClose.TabIndex = 1;
            this.ButtonClose.Text = "閉じる";
            this.ButtonClose.UseVisualStyleBackColor = true;
            this.ButtonClose.Click += new System.EventHandler(this.ButtonClose_Click);
            // 
            // EmployeeView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(772, 436);
            this.Controls.Add(this.ComboBoxSelectPosition);
            this.Controls.Add(this.TextBoxSearchLastName);
            this.Controls.Add(this.TextBoxSearchFirstName);
            this.Controls.Add(this.ButtonClose);
            this.Controls.Add(this.ButtonUpdate);
            this.Controls.Add(this.ButtonSearcPositionh);
            this.Controls.Add(this.ButtonSearchLastName);
            this.Controls.Add(this.ButtonSearchFirstName);
            this.Controls.Add(this.ButtonSearchAll);
            this.Controls.Add(this.DataGridViewEmployeeDataGrid);
            this.Name = "EmployeeView";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.EmployeeView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewEmployeeDataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DataGridViewEmployeeDataGrid;
        private System.Windows.Forms.Button ButtonSearchAll;
        private System.Windows.Forms.Button ButtonSearchFirstName;
        private System.Windows.Forms.TextBox TextBoxSearchFirstName;
        private System.Windows.Forms.Button ButtonSearchLastName;
        private System.Windows.Forms.TextBox TextBoxSearchLastName;
        private System.Windows.Forms.ComboBox ComboBoxSelectPosition;
        private System.Windows.Forms.Button ButtonSearcPositionh;
        private System.Windows.Forms.Button ButtonUpdate;
        private System.Windows.Forms.Button ButtonClose;
    }
}