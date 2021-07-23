using Microsoft.VisualStudio.TestTools.UnitTesting;
using OOCompanyDirectory;
using System;
using System.Collections.Generic;

namespace UnitTestOOCompanyDirectory
{
    public partial class EmployeeManage_社員を管理するクラス
    {
        public class EmployeeManage_Mock_Normal : IEmployeeRepository
        {
            public bool Delete(int id)
            {
                throw new NotImplementedException();
            }

            public List<Employee> GetAllData()
            {
                throw new NotImplementedException();
            }

            public bool Insert(Employee employee)
            {
                throw new NotImplementedException();
            }

            public bool Update(Employee employee)
            {
                throw new NotImplementedException();
            }
        }

        [TestClass]
        public class CheckUpdateDataCountメソッド＿更新前に更新データの件数を確認する
        {
            private EmployeeManage employeeManage;

            [TestInitialize]
            public void 準備()
            {
                this.employeeManage = new EmployeeManage();
            }

            [TestCategory("更新データあり")]
            [TestMethod]
            public void 更新データありのときTureを返す()
            {
                // 実行 & 検証
                Assert.AreEqual(true, this.employeeManage.CheckUpdateDataCount());
            }
        }

        [TestClass]
        public class UpdateDataメソッド＿更新する
        {
            [TestCategory("X")]
            [TestMethod]
            public void X()
            {
            }
        }


    }

}
