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
    public partial class EmployeeView : Form
    {
        public BindingList<Employee> ViewData
        {
            get { return (BindingList < Employee >)EmployeeDataGrid.DataSource; }
            set { EmployeeDataGrid.DataSource = value; }
        }
        
        public EmployeeView()
        {
            InitializeComponent();
        }

        private void DisplayAllCommand_Click(object sender, EventArgs e)
        {

        }

        private void FirstNameSearchCommand_Click(object sender, EventArgs e)
        {

        }

        private void LastNameSearchCommand_Click(object sender, EventArgs e)
        {

        }

        private void PositionSearchCommand_Click(object sender, EventArgs e)
        {

        }

        private void UpdateCommand_Click(object sender, EventArgs e)
        {

        }

        private void CloseCommand_Click(object sender, EventArgs e)
        {

        }
    }
}
