using Microsoft.VisualStudio.TestTools.UnitTesting;
using OOCompanyDirectory;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;


namespace UnitTestOOCompanyDirectory
{
    public partial class EmployeeManage_社員を管理するクラス
    {
        #region View

        public class EmployeeView_Mock1 : IEmployeeView
        {
            public BindingList<Employee> ViewData { get; set; }
            public ObjectPosition[] ComboBoxSelectPositionItems { get; set; }
            public Action SearchAllAction { get; set; }
            public Action<string> SearchFirstNameAction { get; set; }
            public Action<string> SearchLastNameAction { get; set; }
            public Action<object> SearchPositionAction { get; set; }
            public Action UpdateAction { get; set; }
            public Action CloseFormAction { get; set; }

            public void ButtonEnable(bool isEnable, bool isExceptClosButton)
            {
                
            }

            public void DataGridViewSelectRow(int selectRowIndex)
            {
                
            }

            public void FormClose()
            {
                
            }
        }

        #endregion

        #region Manage_Normal

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

        #endregion

        [TestClass]
        public class コンストラクタ_ファイル読込
        {
            [TestCategory("読込正常")]
            [TestMethod]
            public void ファイル読込正常＿正常終了()
            {
                // 準備
                var employeeManage = new EmployeeManage("datafileTest1.json");
                // 実行 & 検証
            }

            [TestCategory("読込異常")]
            [TestMethod]
            public void ファイル読込異常＿異常終了()
            {
                // 実行 & 検証
                bool exception = false;
                try
                {
                    var employeeManage = new EmployeeManage("xxxx.json");
                }
                catch(Exception e)
                {
                    exception = true;
                }
                Assert.IsTrue(exception);
            }
        }

        [TestClass]
        public class GetAllDataメソッド_全データ読込
        {
            private EmployeeManage employeeManage;

            #region DisplayData_Normal_Data1

            public List<Employee> DisplayData_Normal_NotUpdate_Data()
            {
                var data1 = new Employee { Id = 1, FirstName = "FirstName1", LastName = "LastName1", Age = 18, Position = Position.Staff, Gender = Gender.Male };
                var data2 = new Employee { Id = 2, FirstName = "FirstName2", LastName = "LastName2", Age = 19, Position = Position.Director, Gender = Gender.Female };
                var data3 = new Employee { Id = 3, FirstName = "FirstName3", LastName = "LastName3", Age = 20, Position = Position.Director, Gender = Gender.Female };
                var data4 = new Employee { Id = 4, FirstName = "FirstName4", LastName = "LastName4", Age = 21, Position = Position.Director, Gender = Gender.Female };
                var data5 = new Employee { Id = 5, FirstName = "FirstName5", LastName = "LastName5", Age = 22, Position = Position.Director, Gender = Gender.Female };
                var data6 = new Employee { Id = 6, FirstName = "FirstName2", LastName = "LastName3", Age = 22, Position = Position.Staff, Gender = Gender.Female };

                var list = new List<Employee>();
                list.Add(data1);
                list.Add(data2);
                list.Add(data3);
                list.Add(data4);
                list.Add(data5);
                list.Add(data6);
                return list;
            }

            #endregion
            
            [TestInitialize]
            public void 準備()
            {
                this.employeeManage = new EmployeeManage("datafileTest1.json");
                
            }

            [TestCategory("データ取得")]
            [TestMethod]
            public void ファイル読込内容とファイル内容が一致()
            {
                // 実行 & 検証
                CollectionAssert.AreEqual(DisplayData_Normal_NotUpdate_Data(), this.employeeManage.GetAllData());
            }
        }

        [TestClass]
        public class InquireByFirstNameメソッド_苗字で問い合わせ
        {
            private EmployeeManage employeeManage;

            #region SelectData_FirstName

            public List<Employee> SelectData_FirstName()
            {
                var data2 = new Employee { Id = 2, FirstName = "FirstName2", LastName = "LastName2", Age = 19, Position = Position.Director, Gender = Gender.Female };
                var data6 = new Employee { Id = 6, FirstName = "FirstName2", LastName = "LastName3", Age = 22, Position = Position.Staff, Gender = Gender.Female };

                var list = new List<Employee>();
                list.Add(data2);
                list.Add(data6);
                return list;
            }

            #endregion

            [TestInitialize]
            public void 準備()
            {
                this.employeeManage = new EmployeeManage("datafileTest1.json");

            }

            [TestCategory("存在する苗字を指定")]
            [TestMethod]
            public void 存在する苗字を指定して該当のデータが取得できる()
            {
                // 実行 & 検証
                CollectionAssert.AreEqual(this.SelectData_FirstName(), this.employeeManage.InquireByFirstName("FirstName2"));
            }

            [TestCategory("存在しない苗字を指定")]
            [TestMethod]
            public void 存在しない苗字を指定して０件のデータが取得できる()
            {
                // 実行 & 検証
                CollectionAssert.AreEqual(new List<Employee>(), this.employeeManage.InquireByFirstName("FirstName9"));
            }
        }

        [TestClass]
        public class InquireByLastNameメソッド_名前で問い合わせ
        {
            private EmployeeManage employeeManage;

            #region SelectData_FirstName

            public List<Employee> SelectData_LastName()
            {
                var data3 = new Employee { Id = 3, FirstName = "FirstName3", LastName = "LastName3", Age = 20, Position = Position.Director, Gender = Gender.Female };
                var data6 = new Employee { Id = 6, FirstName = "FirstName2", LastName = "LastName3", Age = 22, Position = Position.Staff, Gender = Gender.Female };

                var list = new List<Employee>();
                list.Add(data3);
                list.Add(data6);
                return list;
            }

            #endregion

            [TestInitialize]
            public void 準備()
            {
                this.employeeManage = new EmployeeManage("datafileTest1.json");

            }

            [TestCategory("存在する名前を指定")]
            [TestMethod]
            public void 存在する苗字を指定して該当のデータが取得できる()
            {
                // 実行 & 検証
                CollectionAssert.AreEqual(this.SelectData_LastName(), this.employeeManage.InquireByLastName("LastName3"));
            }

            [TestCategory("存在しない名前を指定")]
            [TestMethod]
            public void 存在しない苗字を指定して０件のデータが取得できる()
            {
                // 実行 & 検証
                CollectionAssert.AreEqual(new List<Employee>(), this.employeeManage.InquireByLastName("LastName9"));
            }
        }

        [TestClass]
        public class InquireByPositionメソッド_役職で問い合わせ
        {
            private EmployeeManage employeeManage;

            #region SelectData_FirstName

            public List<Employee> SelectData_Position()
            {
                var data1 = new Employee { Id = 1, FirstName = "FirstName1", LastName = "LastName1", Age = 18, Position = Position.Staff, Gender = Gender.Male };
                var data6 = new Employee { Id = 6, FirstName = "FirstName2", LastName = "LastName3", Age = 22, Position = Position.Staff, Gender = Gender.Female };
                
                var list = new List<Employee>();
                list.Add(data1);
                list.Add(data6);
                return list;
            }

            #endregion

            [TestInitialize]
            public void 準備()
            {
                this.employeeManage = new EmployeeManage("datafileTest1.json");

            }

            [TestCategory("存在する職位を指定")]
            [TestMethod]
            public void 存在する職位を指定して該当のデータが取得できる()
            {
                // 実行 & 検証
                CollectionAssert.AreEqual(this.SelectData_Position(), this.employeeManage.InquireByPosition(Position.Staff));
            }

            [TestCategory("存在しない職位を指定")]
            [TestMethod]
            public void 存在しない職位を指定して０件のデータが取得できる()
            {
                // 実行 & 検証
                CollectionAssert.AreEqual(new List<Employee>(), this.employeeManage.InquireByPosition(Position.GeneralManager));
            }
        }

        [TestClass]
        public class IValidateDataメソッド_データ妥当性
        {
            private EmployeeManage employeeManage;

            #region SelectData_FirstName

            public List<Employee> DisplayData_Error_FirstName()
            {
                var data1 = new Employee { Id = 1, FirstName = "", LastName = "LastName1", Age = 18, Position = Position.Staff, Gender = Gender.Male };
              
                var list = new List<Employee>();
                list.Add(data1);
                return list;
            }

            #endregion

            #region SelectData_LastName

            public List<Employee> DisplayData_Error_LastName()
            {
                var data1 = new Employee { Id = 1, FirstName = "FirstName1", LastName = "", Age = 18, Position = Position.Staff, Gender = Gender.Male };

                var list = new List<Employee>();
                list.Add(data1);
                return list;
            }

            #endregion

            #region SelectData_Age

            public List<Employee> DisplayData_Error_Age()
            {
                var data1 = new Employee { Id = 1, FirstName = "FirstName1", LastName = "LastName1", Age = 17, Position = Position.Staff, Gender = Gender.Male };

                var list = new List<Employee>();
                list.Add(data1);
                return list;
            }

            #endregion
            #region SelectData_Age

            public List<Employee> DisplayData_Error_Id()
            {
                var data1 = new Employee { Id = 1, FirstName = "FirstName1", LastName = "LastName1", Age = 18, Position = Position.Staff, Gender = Gender.Male };
                var data2 = new Employee { Id = 2, FirstName = "FirstName2", LastName = "LastName2", Age = 18, Position = Position.Staff, Gender = Gender.Male };
                var data3 = new Employee { Id = 1, FirstName = "FirstName3", LastName = "LastName3", Age = 19, Position = Position.Staff, Gender = Gender.Male };

                var list = new List<Employee>();
                list.Add(data1);
                list.Add(data2);
                list.Add(data3);
                return list;
            }

            #endregion


            [TestInitialize]
            public void 準備()
            {
                this.employeeManage = new EmployeeManage("datafileTest1.json");

            }
           
            [TestCategory("単体チェック＿苗字未入力チェック")]
            [TestMethod]
            public void 苗字を未入力のときエラーメッセージが返却される()
            {
                // 実行 & 検証
                Assert.IsFalse(this.employeeManage.ValidateData(this.DisplayData_Error_FirstName(), out var errorRowIndex, out var errorMessage));
                Assert.AreEqual(int.MaxValue, errorRowIndex);
                Assert.AreEqual("苗字を入力してください", errorMessage);
            }

            [TestCategory("単体チェック＿名前未入力チェック")]
            [TestMethod]
            public void 名前を未入力のときエラーメッセージが返却される()
            {
                // 実行 & 検証
                Assert.IsFalse(this.employeeManage.ValidateData(this.DisplayData_Error_LastName(), out var errorRowIndex, out var errorMessage));
                Assert.AreEqual(int.MaxValue, errorRowIndex);
                Assert.AreEqual("名前を入力してください", errorMessage);
            }

            [TestCategory("単体チェック＿年齢範囲チェック")]
            [TestMethod]
            public void 名前を１８未満のときエラーメッセージが返却される()
            {
                // 実行 & 検証
                Assert.IsFalse(this.employeeManage.ValidateData(this.DisplayData_Error_Age(), out var errorRowIndex, out var errorMessage));
                Assert.AreEqual(int.MaxValue, errorRowIndex);
                Assert.AreEqual("年齢は１８以上を入力してください", errorMessage);
            }

            [TestCategory("相関チェック＿ＩＤ重複チェック")]
            [TestMethod]
            public void ＩＤに重複があるときエラー行とエラーメッセージが返却される()
            {
                // 実行 & 検証
                Assert.IsFalse(this.employeeManage.ValidateData(this.DisplayData_Error_Id(), out var errorRowIndex, out var errorMessage));
                Assert.AreEqual(2, errorRowIndex);
                Assert.AreEqual("Idが重複しています", errorMessage);
            }
        }


        [TestClass]
        public class CheckExistUpdateDataメソッド＿更新データがあるか確認する
        {
            private EmployeeManage employeeManage;

            [TestInitialize]
            public void 準備()
            {
                this.employeeManage = new EmployeeManage("datafileTest1.json");
            }

            #region DisplayData_Null

            public List<Employee> DisplayData_Error_Data_Null()
            {
                return null;
            }

            #endregion

            #region DisplayData_Normal_Data1

            public List<Employee> DisplayData_Normal_NotUpdate_Data()
            {
                var data1 = new Employee { Id = 1, FirstName = "FirstName1", LastName = "LastName1", Age = 18, Position = Position.Staff, Gender = Gender.Male };
                var data2 = new Employee { Id = 2, FirstName = "FirstName2", LastName = "LastName2", Age = 19, Position = Position.Director, Gender = Gender.Female };
                var data3 = new Employee { Id = 3, FirstName = "FirstName3", LastName = "LastName3", Age = 20, Position = Position.Director, Gender = Gender.Female };
                var data4 = new Employee { Id = 4, FirstName = "FirstName4", LastName = "LastName4", Age = 21, Position = Position.Director, Gender = Gender.Female };
                var data5 = new Employee { Id = 5, FirstName = "FirstName5", LastName = "LastName5", Age = 22, Position = Position.Director, Gender = Gender.Female };
                var data6 = new Employee { Id = 6, FirstName = "FirstName2", LastName = "LastName3", Age = 22, Position = Position.Staff, Gender = Gender.Female };

                var list = new List<Employee>();
                list.Add(data1);
                list.Add(data2);
                list.Add(data3);
                list.Add(data4);
                list.Add(data5);
                list.Add(data6);
                return list;
            }

            #endregion

            #region DisplayData_Normal_Data_Insert

            public List<Employee> DisplayData_Normal_Data_Insert()
            {
                var list = this.DisplayData_Normal_NotUpdate_Data();
                var data6 = new Employee { Id = 7, FirstName = "FirstName7", LastName = "LastName7", Age = 23, Position = Position.Director, Gender = Gender.Female };
                list.Add(data6);
                return list;
            }

            #endregion

            #region DisplayData_Normal_Data_Update_FirstName

            public List<Employee> DisplayData_Normal_Data_Update_FirstName()
            {
                var list = this.DisplayData_Normal_NotUpdate_Data();
                list[0].FirstName = "a";
                return list;
            }

            #endregion

            #region DisplayData_Normal_Data_Update_LastName

            public List<Employee> DisplayData_Normal_Data_Update_LastName()
            {
                var list = this.DisplayData_Normal_NotUpdate_Data();
                list[1].LastName = "a";
                return list;
            }

            #endregion

            #region DisplayData_Normal_Data_Update_Age

            public List<Employee> DisplayData_Normal_Data_Update_Age()
            {
                var list = this.DisplayData_Normal_NotUpdate_Data();
                list[2].Age = 99;
                return list;
            }

            #endregion

            #region DisplayData_Normal_Data_Update_Position

            public List<Employee> DisplayData_Normal_Data_Update_Position()
            {
                var list = this.DisplayData_Normal_NotUpdate_Data();
                list[3].Position = Position.AssistantGeneralManager;
                return list;
            }

            #endregion

            #region DisplayData_Normal_Data_Update_Gender

            public List<Employee> DisplayData_Normal_Data_Update_Gender()
            {
                var list = this.DisplayData_Normal_NotUpdate_Data();
                list[4].Gender = Gender.Male;
                return list;
            }

            #endregion

            #region DisplayData_Normal_Data_Delete

            public List<Employee> DisplayData_Normal_Data_Delete()
            {
                var list = this.DisplayData_Normal_NotUpdate_Data();
                var data2 = new Employee { Id = 2, FirstName = "FirstName2", LastName = "LastName2", Age = 19, Position = Position.Director, Gender = Gender.Female };
                list.Remove(data2);
                return list;
            }

            #endregion

            [TestCategory("データなし")]
            [TestMethod]
            public void 正常読込更新データなし_読込したデータと同じ()
            {
                // 実行 & 検証
                Assert.IsFalse(this.employeeManage.CheckExistUpdateData(this.DisplayData_Normal_NotUpdate_Data()));
            }

            [TestCategory("データあり＿挿入")]
            [TestMethod]
            public void 正常読込_挿入データあり()
            {
                // 実行 & 検証
                //CollectionAssert.AreEqual(this.DisplayData_Normal_Data_Insert(), this.employeeManage.GetAllData());
                Assert.IsTrue(this.employeeManage.CheckExistUpdateData(this.DisplayData_Normal_Data_Insert()));
            }

            [TestCategory("データあり＿更新")]
            [TestMethod]
            public void 正常読込_更新データあり()
            {
                // 実行 & 検証
                Assert.IsTrue(this.employeeManage.CheckExistUpdateData(this.DisplayData_Normal_Data_Update_FirstName()));
                Assert.IsTrue(this.employeeManage.CheckExistUpdateData(this.DisplayData_Normal_Data_Update_LastName()));
                Assert.IsTrue(this.employeeManage.CheckExistUpdateData(this.DisplayData_Normal_Data_Update_Age()));
                Assert.IsTrue(this.employeeManage.CheckExistUpdateData(this.DisplayData_Normal_Data_Update_Position()));
                Assert.IsTrue(this.employeeManage.CheckExistUpdateData(this.DisplayData_Normal_Data_Update_Gender()));
            }

            [TestCategory("データあり＿削除")]
            [TestMethod]
            public void 正常読込_削除データあり()
            {
                // 実行 & 検証
                Assert.IsTrue(this.employeeManage.CheckExistUpdateData(this.DisplayData_Normal_Data_Delete()));
            }
        }

      

        [TestClass]
        public class UpdateDataメソッド＿更新する
        {
            #region DisplayData_Normal_Data1

            public List<Employee> DisplayData_Normal_NotUpdate_Data()
            {
                var data1 = new Employee { Id = 1, FirstName = "FirstName1", LastName = "LastName1", Age = 18, Position = Position.Staff, Gender = Gender.Male };
                var data2 = new Employee { Id = 2, FirstName = "FirstName2", LastName = "LastName2", Age = 19, Position = Position.Director, Gender = Gender.Female };
                var data3 = new Employee { Id = 3, FirstName = "FirstName3", LastName = "LastName3", Age = 20, Position = Position.Director, Gender = Gender.Female };
                var data4 = new Employee { Id = 4, FirstName = "FirstName4", LastName = "LastName4", Age = 21, Position = Position.Director, Gender = Gender.Female };
                var data5 = new Employee { Id = 5, FirstName = "FirstName5", LastName = "LastName5", Age = 22, Position = Position.Director, Gender = Gender.Female };
                var data6 = new Employee { Id = 6, FirstName = "FirstName2", LastName = "LastName3", Age = 22, Position = Position.Staff, Gender = Gender.Female };

                var list = new List<Employee>();
                list.Add(data1);
                list.Add(data2);
                list.Add(data3);
                list.Add(data4);
                list.Add(data5);
                list.Add(data6);
                return list;
            }

            #endregion

            #region DisplayData_Normal_Data_Insert

            public List<Employee> DisplayData_Normal_Data_Insert()
            {
                var list = this.DisplayData_Normal_NotUpdate_Data();
                var data6 = new Employee { Id = 7, FirstName = "FirstName7", LastName = "LastName7", Age = 23, Position = Position.Director, Gender = Gender.Female };
                list.Add(data6);
                return list;
            }

            #endregion

            #region DisplayData_Normal_Data_Insert

            public List<Employee> DisplayData_Normal_Data_Insert_Error()
            {
                var list = this.DisplayData_Normal_NotUpdate_Data();
                var data6 = new Employee { Id = 7, FirstName = "FirstName7", LastName = "LastName7", Age = 23, Position = Position.Director, Gender = Gender.Female };
                list.Add(data6);
                list.Add(data6);
                return list;
            }

            #endregion

            #region DisplayData_Normal_Data_Delete

            public List<Employee> DisplayData_Normal_Data_Delete()
            {
                var list = this.DisplayData_Normal_NotUpdate_Data();
                var data2 = new Employee { Id = 2, FirstName = "FirstName2", LastName = "LastName2", Age = 19, Position = Position.Director, Gender = Gender.Female };
                list.Remove(data2);
                return list;
            }

            #endregion

            #region DisplayData_Normal_Data_Update

            public List<Employee> DisplayData_Normal_Data_Update()
            {
                var list = this.DisplayData_Normal_NotUpdate_Data();
                var data2 = list[1];
                var update = new Employee { Id = 2, FirstName = "FirstNamex", LastName = "LastNamex", Age = 19, Position = Position.Director, Gender = Gender.Female };
                data2.SetUpdateColumn(update);
                return list;
            }

            #endregion

            #region DisplayData_Normal_Data_Update_All

            public List<Employee> DisplayData_Normal_Data_Update_All()
            {
                var list = this.DisplayData_Normal_NotUpdate_Data();
                var data6 = new Employee { Id = 7, FirstName = "FirstName7", LastName = "LastName7", Age = 23, Position = Position.Director, Gender = Gender.Female };
                
                var data2 = list[1];
                var update = new Employee { Id = 2, FirstName = "FirstNamex", LastName = "LastNamex", Age = 19, Position = Position.Director, Gender = Gender.Female };
                data2.SetUpdateColumn(update);
                
                var data3 = new Employee { Id = 3, FirstName = "FirstName3", LastName = "LastName3", Age = 20, Position = Position.Director, Gender = Gender.Female };
                list.Add(data6);
                list.Remove(data3);
                return list;
            }

            #endregion


            [TestCategory("データあり＿正常＿挿入")]
            [TestMethod]
            public void 正常_挿入()
            {
                var employeeManage = new EmployeeManage("datafileAddTest.json");
                // 実行 & 検証
                Assert.IsTrue(employeeManage.Update(this.DisplayData_Normal_Data_Insert()));
                CollectionAssert.AreEqual(this.DisplayData_Normal_Data_Insert(), employeeManage.GetAllData());

                // 後戻し
                Assert.IsTrue(employeeManage.Update(this.DisplayData_Normal_NotUpdate_Data()));

            }

            [TestCategory("データあり＿正常＿更新")]
            [TestMethod]
            public void 正常_更新()
            {
                var employeeManage = new EmployeeManage("datafileUpdateTest.json");
                // 実行 & 検証
                Assert.IsTrue(employeeManage.Update(this.DisplayData_Normal_Data_Update()));
                CollectionAssert.AreEqual(this.DisplayData_Normal_Data_Update(), employeeManage.GetAllData());

                // 後戻し
                Assert.IsTrue(employeeManage.Update(this.DisplayData_Normal_NotUpdate_Data()));
            }

            [TestCategory("データあり＿正常＿削除")]
            [TestMethod]
            public void 正常_削除()
            {
                var employeeManage = new EmployeeManage("datafileDelTest.json");
                // 実行 & 検証
                Assert.IsTrue(employeeManage.Update(this.DisplayData_Normal_Data_Delete()));
                CollectionAssert.AreEqual(this.DisplayData_Normal_Data_Delete(), employeeManage.GetAllData());

                // 後戻し
                Assert.IsTrue(employeeManage.Update(this.DisplayData_Normal_NotUpdate_Data()));
            }

            [TestCategory("データあり＿正常＿追加更新削除")]
            [TestMethod]
            public void 正常_追加更新削除()
            {
                var employeeManage = new EmployeeManage("datafileUpdateAllTest.json");
                // 実行 & 検証
                Assert.IsTrue(employeeManage.Update(this.DisplayData_Normal_Data_Update_All()));
                CollectionAssert.AreEqual(this.DisplayData_Normal_Data_Update_All(), employeeManage.GetAllData());

                // 後戻し
                Assert.IsTrue(employeeManage.Update(this.DisplayData_Normal_NotUpdate_Data()));
            }
        }
    }

}
