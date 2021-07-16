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

        public EmployeePresenter(EmployeeView view)
        {
            employeeView = view;
            employeeManage = new EmployeeManage();
            employeeView.DisplayAllAction += DisplayAllCommand;
            employeeView.FirstNameSearchAction += FirstNameSearchCommand;
            employeeView.LastNameSearchAction += LastNameSearchCommand;
        }

        public void DisplayAllCommand()
        {
            var listData = employeeManage.GetAllData();
            var bindinglist = new BindingList<Employee>(listData);
            employeeView.ViewData = bindinglist;
        }
        public void FirstNameSearchCommand(string firstname)
        {
            var listData = employeeManage.InquireByFirstName(firstname);
            var bindinglist = new BindingList<Employee>(listData);
            employeeView.ViewData = bindinglist;
        }

        public void LastNameSearchCommand(string lastname)
        {
            var listData = employeeManage.InquireByLastName(lastname);
            var bindinglist = new BindingList<Employee>(listData);
            employeeView.ViewData = bindinglist;
        }
    }
}
