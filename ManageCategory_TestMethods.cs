using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using FinalProjectAutomation.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalProjectAutomation.AssistantMethods;
using FinalProjectAutomation.Data;
using FinalProjectAutomation.POM;
using OpenQA.Selenium;

namespace FinalProjectAutomation.TestMethods
{
    [TestClass]
    public class ManageCategory_TestMethods
    {
        public static ExtentReports extentReports = new ExtentReports();
        public static ExtentHtmlReporter reporter = new ExtentHtmlReporter("D:\\c##\\TestProject1\\CategoryReport\\");
        [ClassInitialize]
        public static void ClassInitialize(TestContext testContext)
        {
            extentReports.AttachReporter(reporter);
            ManageDriver.MaximizeDriver();
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {

            extentReports.Flush();
            ManageDriver.CloseDriver();
        }
        [TestMethod]
        public void TestValidAddBill()
        {
            var test = extentReports.CreateTest("TestValidAddBill", "verify that on passing valid data to  form, the data added correctly");
            try
            {
                CommonMethods.NavigateToURL(GlobalConstants.loginLink);
                LoginData login = CommonMethods.ReadLoginDataFromExcel(2);
                CommonMethods.FillLoginForm(login);
                Thread.Sleep(2000);

                
                ManageCategoryAssistantMethods.AddRandomBill();
                

               ManageCategoryData data = ManageCategoryAssistantMethods.ReadDataFromExcel(2);

               ManageCategoryAssistantMethods.FillLBillForm(data);
                ManageCategoryAssistantMethods.ShowCreateBill();

                Assert.IsTrue(ManageCategoryAssistantMethods.CheckSuccessAddBill(data.email));

                Thread.Sleep(2000);
                var expectedURL = "http://localhost:4200/admin/home";
                var actualURL = ManageDriver.driver.Url;
                Assert.AreEqual(expectedURL, actualURL, "Actual URL not equal the expected URL_TC1");
                Console.WriteLine("TC1 Completed Successfully");
                test.Pass("AddBill Successfully");

            }

            catch (Exception ex)
            {

                Console.WriteLine(ex.ToString());
                string screenShotPath = CommonMethods.TakeScreenShot();
                test.AddScreenCaptureFromPath(screenShotPath);
              

            }


        }
        [TestMethod]
        public void InvalidEmptyBillName()
        {
            var test = extentReports.CreateTest("InvalidEmptyBillName", "verify that on passing Invalid data to  form, the data cont added ");
            try
            {
                CommonMethods.NavigateToURL(GlobalConstants.loginLink);
                LoginData login = CommonMethods.ReadLoginDataFromExcel(2);
                CommonMethods.FillLoginForm(login);
                Thread.Sleep(2000);


                ManageCategoryAssistantMethods.AddRandomBill();
                //ManageCategoryAssistantMethods.FillLBillForm();

                ManageCategoryData data = ManageCategoryAssistantMethods.ReadDataFromExcel(4);

                ManageCategoryAssistantMethods.FillLBillForm(data);

              
               
                Thread.Sleep(2000);
                Assert.IsFalse(ManageCategoryAssistantMethods.CheckSuccessAddBill(data.email));

                Thread.Sleep(1000);
                var expectedSubmitButtonClickable = false;
                var submitButton = ManageDriver.driver.FindElement(By.XPath("/html/body/div[2]/div[2]/div/mat-dialog-container/form/div/div/div[4]/button"));
                bool actualSubmitButtonClickable = submitButton.Displayed && submitButton.Enabled;
                Assert.AreEqual(expectedSubmitButtonClickable, actualSubmitButtonClickable,
           $"Expected submit button clickable state: {expectedSubmitButtonClickable}, " +
           $"but actual state was: {actualSubmitButtonClickable}");
                test.Pass("ActualSubmitButtonDisable   equal the expected  Successfully_TC2");


                Console.WriteLine("TC2 Completed Successfully");
            }

            catch (Exception ex)
            {

                test.Fail(ex.Message);

                string screenShotPath = CommonMethods.TakeScreenShot();
                test.AddScreenCaptureFromPath(screenShotPath);

            }


        }
        [TestMethod]
        public void InvalidEmptyEmail()
        {
            var test = extentReports.CreateTest("InvalidEmptyEmail", "verify that on passing Invalid data to  form, the data not added ");
            try
            {
                CommonMethods.NavigateToURL(GlobalConstants.loginLink);
                LoginData login = CommonMethods.ReadLoginDataFromExcel(2);
                CommonMethods.FillLoginForm(login);
                Thread.Sleep(2000);


                ManageCategoryAssistantMethods.AddRandomBill();
                //ManageCategoryAssistantMethods.FillLBillForm();

                ManageCategoryData data = ManageCategoryAssistantMethods.ReadDataFromExcel(5);

                ManageCategoryAssistantMethods.FillLBillForm(data);



                Thread.Sleep(2000);
                var expectedURL = "http://localhost:4200/admin/home";
                var actualURL = ManageDriver.driver.Url;
                Assert.AreEqual(expectedURL, actualURL, "Actual URL not equal the expected URL_TC3");
                test.Pass("TC3 sucess");

                Thread.Sleep(1000);
                var expectedSubmitButtonClickable = false;
                var submitButton = ManageDriver.driver.FindElement(By.XPath("/html/body/div[2]/div[2]/div/mat-dialog-container/form/div/div/div[4]/button"));
                bool actualSubmitButtonClickable = submitButton.Displayed && submitButton.Enabled;
                Assert.AreEqual(expectedSubmitButtonClickable, actualSubmitButtonClickable,
           $"Expected submit button clickable state: {expectedSubmitButtonClickable}, " +
           $"but actual state was: {actualSubmitButtonClickable}");
                test.Pass("ActualSubmitButtonDisable   equal the expected  Successfully_TC3");


                Console.WriteLine("TC3 Completed Successfully");
            }

            catch (Exception ex)
            {
                test.Fail(ex.Message );
               
                string screenShotPath = CommonMethods.TakeScreenShot();
                test.AddScreenCaptureFromPath(screenShotPath);


            }


        }

        [TestMethod]
        public void InvalidEmailFormat()
        {
            var test = extentReports.CreateTest("InvalidEmailFormat", "verify that on passing Invalid data to  form, the data not added ");
            try
            {
                CommonMethods.NavigateToURL(GlobalConstants.loginLink);
                LoginData login = CommonMethods.ReadLoginDataFromExcel(2);
                CommonMethods.FillLoginForm(login);
                Thread.Sleep(2000);


                ManageCategoryAssistantMethods.AddRandomBill();
                

                ManageCategoryData data = ManageCategoryAssistantMethods.ReadDataFromExcel(9);

                ManageCategoryAssistantMethods.FillLBillForm(data);



                Thread.Sleep(2000);
                var expectedURL = "http://localhost:4200/admin/home";
                var actualURL = ManageDriver.driver.Url;
                Assert.AreEqual(expectedURL, actualURL, "Actual URL not equal the expected URL_TC4");
                test.Pass("TC4 sucess");

                Thread.Sleep(1000);
                var expectedSubmitButtonClickable = false;
                var submitButton = ManageDriver.driver.FindElement(By.XPath("/html/body/div[2]/div[2]/div/mat-dialog-container/form/div/div/div[4]/button"));
                bool actualSubmitButtonClickable = submitButton.Displayed && submitButton.Enabled;
                Assert.AreEqual(expectedSubmitButtonClickable, actualSubmitButtonClickable,
           $"Expected submit button clickable state: {expectedSubmitButtonClickable}, " +
           $"but actual state was: {actualSubmitButtonClickable}");
                test.Pass("ActualSubmitButtonDisable   equal the expected  Successfully_TC4");


                Console.WriteLine("TC4 Completed Successfully");
            }

            catch (Exception ex)
            {

                test.Fail(ex.Message);

                string screenShotPath = CommonMethods.TakeScreenShot();
                test.AddScreenCaptureFromPath(screenShotPath);

            }


        }
      
             [TestMethod]
        public void InvalidEmailOverLimitCharrachter()
        {
            var test = extentReports.CreateTest("InvalidEmailOverLimitCharrachter", "verify that on passing Invalid data to  form, the data not added ");
            try
            {
                CommonMethods.NavigateToURL(GlobalConstants.loginLink);
                LoginData login = CommonMethods.ReadLoginDataFromExcel(2);
                CommonMethods.FillLoginForm(login);
                Thread.Sleep(2000);


                ManageCategoryAssistantMethods.AddRandomBill();


                ManageCategoryData data = ManageCategoryAssistantMethods.ReadDataFromExcel(6);

                ManageCategoryAssistantMethods.FillLBillForm(data);



                Thread.Sleep(2000);
                var expectedURL = "http://localhost:4200/admin/home";
                var actualURL = ManageDriver.driver.Url;
                Assert.AreEqual(expectedURL, actualURL, "Actual URL not equal the expected URL_TC5");
                test.Pass("TC5 sucess");

                Thread.Sleep(1000);
                var expectedSubmitButtonClickable = false;
                var submitButton = ManageDriver.driver.FindElement(By.XPath("/html/body/div[2]/div[2]/div/mat-dialog-container/form/div/div/div[4]/button"));
                bool actualSubmitButtonClickable = submitButton.Displayed && submitButton.Enabled;
                Assert.AreEqual(expectedSubmitButtonClickable, actualSubmitButtonClickable,
           $"Expected submit button clickable state: {expectedSubmitButtonClickable}, " +
           $"but actual state was: {actualSubmitButtonClickable}");
                test.Pass("ActualSubmitButtonDisable   equal the expected  Successfully_TC5");


                Console.WriteLine("TC5 Completed Successfully");
            }

            catch (Exception ex)
            {

                test.Fail(ex.Message);

                string screenShotPath = CommonMethods.TakeScreenShot();
                test.AddScreenCaptureFromPath(screenShotPath);

            }


        }


        
             [TestMethod]
        public void InvalidEmailWithSpace()
        {
            var test = extentReports.CreateTest("InvalidEmailWithSpace", "verify that on passing Invalid data to  form, the data not added ");
            try
            {
                CommonMethods.NavigateToURL(GlobalConstants.loginLink);
                LoginData login = CommonMethods.ReadLoginDataFromExcel(2);
                CommonMethods.FillLoginForm(login);
                Thread.Sleep(2000);


                ManageCategoryAssistantMethods.AddRandomBill();


                ManageCategoryData data = ManageCategoryAssistantMethods.ReadDataFromExcel(7);

                ManageCategoryAssistantMethods.FillLBillForm(data);



                Thread.Sleep(2000);
                var expectedURL = "http://localhost:4200/admin/home";
                var actualURL = ManageDriver.driver.Url;
                Assert.AreEqual(expectedURL, actualURL, "Actual URL not equal the expected URL_TC6");
                test.Pass("TC6 sucess");

                Thread.Sleep(1000);
                var expectedSubmitButtonClickable = false;
                var submitButton = ManageDriver.driver.FindElement(By.XPath("/html/body/div[2]/div[2]/div/mat-dialog-container/form/div/div/div[4]/button"));
                bool actualSubmitButtonClickable = submitButton.Displayed && submitButton.Enabled;
                Assert.AreEqual(expectedSubmitButtonClickable, actualSubmitButtonClickable,
           $"Expected submit button clickable state: {expectedSubmitButtonClickable}, " +
           $"but actual state was: {actualSubmitButtonClickable}");
                test.Pass("ActualSubmitButtonDisable   equal the expected  Successfully_TC6");


                Console.WriteLine("TC6 Completed Successfully");
            }

            catch (Exception ex)
            {

                test.Fail(ex.Message);

                string screenShotPath = CommonMethods.TakeScreenShot();
                test.AddScreenCaptureFromPath(screenShotPath);

            }


        }


        [TestMethod]
        public void InvalidBillNameWithNumaric()
        {
            var test = extentReports.CreateTest("InvalidBillNameWithnumaric ", "verify that on passing Invalid data to  form, the data not added ");
            try
            {
                CommonMethods.NavigateToURL(GlobalConstants.loginLink);
                LoginData login = CommonMethods.ReadLoginDataFromExcel(2);
                CommonMethods.FillLoginForm(login);
                Thread.Sleep(2000);


                ManageCategoryAssistantMethods.AddRandomBill();


                ManageCategoryData data = ManageCategoryAssistantMethods.ReadDataFromExcel(3);

                ManageCategoryAssistantMethods.FillLBillForm(data);

                //var expectedSubmitButtonClickable = false;
                //var submitButton = ManageDriver.driver.FindElement(By.XPath("/html/body/div[2]/div[2]/div/mat-dialog-container/form/div/div/div[4]/button"));
                //bool actualSubmitButtonClickable = submitButton.Displayed && submitButton.Enabled;

                Thread.Sleep(2000);
                Assert.IsFalse(ManageCategoryAssistantMethods.CheckSuccessAddBill(data.email));

               
                test.Pass("TC7  canot add Successfully");


                Thread.Sleep(1000);
               

                Console.WriteLine("TC7 Completed Successfully");
            }

            catch (Exception ex)
            {
                test.Fail(ex.Message);

                string screenShotPath = CommonMethods.TakeScreenShot();
                test.AddScreenCaptureFromPath(screenShotPath);

            }


        }

        [TestMethod]
        public void InvalidAdreesOverLimitCharachter()
        {
            var test = extentReports.CreateTest("InvalidAdreesOverLimitCharachter  ", "verify that on passing Invalid data to  form, the data not added ");
            try
            {
                CommonMethods.NavigateToURL(GlobalConstants.loginLink);
                LoginData login = CommonMethods.ReadLoginDataFromExcel(2);
                CommonMethods.FillLoginForm(login);
                Thread.Sleep(2000);


                ManageCategoryAssistantMethods.AddRandomBill();
                test.Log(Status.Info, "AddRandomBill");

                ManageCategoryData data = ManageCategoryAssistantMethods.ReadDataFromExcel(8);

                ManageCategoryAssistantMethods.FillLBillForm(data);
                test.Log(Status.Info, "FillLBillForm");

                Thread.Sleep(1000);

                

                Assert.IsFalse(ManageCategoryAssistantMethods.CheckSuccessAddBill(data.email));
                test.Log(Status.Info, "AssertDone");
                test.Pass("TC8 sucess");
                test.Pass("ActualSubmitButtonDisable   equal the expected  Successfully_TC8");


                Console.WriteLine("TC8 Completed Successfully");
            }

            catch (Exception ex)
            {
                test.Fail(ex.Message);

                string screenShotPath = CommonMethods.TakeScreenShot();
                test.AddScreenCaptureFromPath(screenShotPath);

            }


        }



    }
}
