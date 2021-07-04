using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOCompanyDirectory
{
    class EmployeePresenter
    {
        private EmployeeView employeeView;
        private EmployeeManage employeeManage;

        EmployeePresenter()
        {
            employeeView = new EmployeeView();
            employeeManage = new EmployeeManage();
        }

        public void DisplayAllCommand()
        {
            var listData = employeeManage.GetAllData();
            var bindinglist = new BindingList<Employee>(listData);
            employeeView.ViewData = bindinglist;
        }
    }
}
