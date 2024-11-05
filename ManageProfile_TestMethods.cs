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
using OpenQA.Selenium;
using FinalProjectAutomation.POM;

namespace FinalProjectAutomation.TestMethods
{
    [TestClass]
    public class ManageProfile_TestMethods
    {
        public static ExtentReports extentReports = new ExtentReports();
        public static ExtentHtmlReporter reporter = new ExtentHtmlReporter("D:\\c##\\TestProject1\\ProfileReport\\");
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
        public void TestDefaultValuesInAccountSettings()
        {
            var test = extentReports.CreateTest("TestDefaultValuesInAccountSettings", "Verify that email, phone number, and address fields have default data");

            try
            {
                // Navigate to the login page and perform login
                CommonMethods.NavigateToURL(GlobalConstants.loginLink);
                LoginData login = CommonMethods.ReadLoginDataFromExcel(2);
                CommonMethods.FillLoginForm(login);
                Thread.Sleep(2000);

                // Navigate to the Account Settings page
                CommonMethods.NavigateToURL("http://localhost:4200/admin/account");

                // Locate the input fields for email, phone number, and address
               
                IWebElement phoneNumberField = ManageDriver.driver.FindElement(By.XPath("//div[2]//div//input"));
                IWebElement emailField = ManageDriver.driver.FindElement(By.XPath("//div[3]//div//input"));
                IWebElement addressField = ManageDriver.driver.FindElement(By.XPath("//div[5]//div//input"));
                IWebElement userNameField= ManageDriver.driver.FindElement(By.XPath("//div[6]//div//input"));
                // Assert that each field contains default data (is not empty)
                
                Assert.IsFalse(string.IsNullOrEmpty(phoneNumberField.GetAttribute("value")), "Phone number field is empty by default.");
                Assert.IsFalse(string.IsNullOrEmpty(emailField.GetAttribute("value")), "Email field is empty by default.");
                Assert.IsFalse(string.IsNullOrEmpty(addressField.GetAttribute("value")), "Address field is empty by default.");
                Assert.IsFalse(string.IsNullOrEmpty(userNameField.GetAttribute("value")), "UserName field is empty by default.");

                test.Log(Status.Info, "Email, phone number, username and address fields have default data.");
                test.Pass("TestDefaultValuesInAccountSettings completed successfully.");
            }
            catch (Exception ex)
            {
                test.Fail(ex.Message);
                string screenShotPath = CommonMethods.TakeScreenShot();
                test.AddScreenCaptureFromPath(screenShotPath);
            }
        }


        [TestMethod]
        public void TestValidChangeFullName()
        {
            var test = extentReports.CreateTest("TestValidChangeFullName", "verify that on passing valid data to  form, the data added correctly");
            try
            {
                CommonMethods.NavigateToURL(GlobalConstants.loginLink);
                LoginData login = CommonMethods.ReadLoginDataFromExcel(2);
                CommonMethods.FillLoginForm(login);
                Thread.Sleep(2000);

                CommonMethods.NavigateToURL(GlobalConstants.ManageProfileLinke);
               
                ManageProfileData data = ManageProfileAssistentMethods.ReadDataFromExcel(2);

                ManageProfileAssistentMethods.FillLprofilForm(data);
                //test.Log(Status.Info, "Assert.IsTrue(ManageProfileAssistentMethods.CheckSuccessAddBill(data.userName));");
                //Assert.IsTrue(ManageProfileAssistentMethods.CheckSuccessAddBill(data.userName));
                bool result = ManageProfileAssistentMethods.CheckSuccessAddBill(data.userName);
                test.Log(Status.Info, "Result of database "+Convert.ToString(result));
                
               
                
                Assert.IsTrue(result);
                
                
                
                Console.WriteLine("TC1 Completed Successfully");
                

            }

            catch (Exception ex)
            {

                test.Fail(ex.Message);

                string screenShotPath = CommonMethods.TakeScreenShot();
                test.AddScreenCaptureFromPath(screenShotPath);

            }

        }

        [TestMethod]
        public void InvalidNameNumaric()
        {
            var test = extentReports.CreateTest("InvalidNameNumaric", "verify that on passing Invalid data to  form, the data didn't added ");
            try
            {
                CommonMethods.NavigateToURL(GlobalConstants.loginLink);
                LoginData login = CommonMethods.ReadLoginDataFromExcel(2);
                CommonMethods.FillLoginForm(login);
                Thread.Sleep(2000);

                CommonMethods.NavigateToURL(GlobalConstants.ManageProfileLinke);

                ManageProfileData data = ManageProfileAssistentMethods.ReadDataFromExcel(3);

                ManageProfileAssistentMethods.FillLprofilForm(data);

                var expectedSubmitButtonClickable = false;
                var submitButton = ManageDriver.driver.FindElement(By.XPath("/html/body/app-root/app-prfile-a/div/div/div/div/div/form/div/div/div[9]/div/div[2]/div/button"));
                bool actualSubmitButtonClickable = submitButton.Displayed && submitButton.Enabled;
                Assert.AreEqual(expectedSubmitButtonClickable, actualSubmitButtonClickable,
           $"Expected submit button clickable state: {expectedSubmitButtonClickable}, " +
           $"but actual state was: {actualSubmitButtonClickable}");
                test.Log(Status.Info, "Result of  SubmitButtonClickable: " + Convert.ToString(actualSubmitButtonClickable));

               
                

                bool result = ManageProfileAssistentMethods.CheckSuccessAddBill(data.userName);
                test.Log(Status.Info, "Result of database " + Convert.ToString(result));
              
                
                Assert.IsFalse(result);

                test.Pass("can't Update Profile Successfully");
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
        public void InvalidEmptyOtherInformation()
        {
            var test = extentReports.CreateTest("InvalidEmptyOtherInformation", "verify that on passing Invalid data to  form, the data didn't added ");
            try
            {
                CommonMethods.NavigateToURL(GlobalConstants.loginLink);
                LoginData login = CommonMethods.ReadLoginDataFromExcel(2);
                CommonMethods.FillLoginForm(login);
                Thread.Sleep(2000);

                CommonMethods.NavigateToURL(GlobalConstants.ManageProfileLinke);

                ManageProfileData data = ManageProfileAssistentMethods.ReadDataFromExcel(4);

                ManageProfileAssistentMethods.FillLprofilForm(data);

                var expectedSubmitButtonClickable = false;
                var submitButton = ManageDriver.driver.FindElement(By.XPath("/html/body/app-root/app-prfile-a/div/div/div/div/div/form/div/div/div[9]/div/div[2]/div/button"));
                bool actualSubmitButtonClickable = submitButton.Displayed && submitButton.Enabled;
                Assert.AreEqual(expectedSubmitButtonClickable, actualSubmitButtonClickable,
           $"Expected submit button clickable state: {expectedSubmitButtonClickable}, " +
           $"but actual state was: {actualSubmitButtonClickable}");
                test.Log(Status.Info, "Result of  SubmitButtonClickable: " + Convert.ToString(actualSubmitButtonClickable));




                bool result = ManageProfileAssistentMethods.CheckSuccessAddBill(data.userName);
                test.Log(Status.Info, "Result of database " + Convert.ToString(result));

                
                Assert.IsFalse(result);
                test.Pass("can't Update Profile Successfully");
                Console.WriteLine("TC3 Completed Successfully");

            }

            catch (Exception ex)
            {
                test.Fail(ex.Message);

                string screenShotPath = CommonMethods.TakeScreenShot();
                test.AddScreenCaptureFromPath(screenShotPath);


            }

        }


        [TestMethod]
        public void InvalidEmptyName()
        {
            var test = extentReports.CreateTest("InvalidEmptyName ", "verify that on passing Invalid data to  form, the data didn't added ");
            try
            {
                CommonMethods.NavigateToURL(GlobalConstants.loginLink);
                LoginData login = CommonMethods.ReadLoginDataFromExcel(2);
                CommonMethods.FillLoginForm(login);
                Thread.Sleep(2000);

                CommonMethods.NavigateToURL(GlobalConstants.ManageProfileLinke);

                ManageProfileData data = ManageProfileAssistentMethods.ReadDataFromExcel(5);

                ManageProfileAssistentMethods.FillLprofilForm(data);

                var expectedSubmitButtonClickable = false;
                var submitButton = ManageDriver.driver.FindElement(By.XPath("/html/body/app-root/app-prfile-a/div/div/div/div/div/form/div/div/div[9]/div/div[2]/div/button"));
                bool actualSubmitButtonClickable = submitButton.Displayed && submitButton.Enabled;
                Assert.AreEqual(expectedSubmitButtonClickable, actualSubmitButtonClickable,
           $"Expected submit button clickable state: {expectedSubmitButtonClickable}, " +
           $"but actual state was: {actualSubmitButtonClickable}");
                test.Log(Status.Info, "Result of  SubmitButtonClickable: " + Convert.ToString(actualSubmitButtonClickable));




                bool result = ManageProfileAssistentMethods.CheckSuccessAddBill(data.userName);
                test.Log(Status.Info, "Result of database " + Convert.ToString(result));


                Assert.IsFalse(result);
                test.Pass("can't Update Profile Successfully");
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
        public void EmptyPassword()
        {
            var test = extentReports.CreateTest("EmptyPassword ", "verify that on passing Invalid data to  form, the data didn't added ");
            try
            {
                CommonMethods.NavigateToURL(GlobalConstants.loginLink);
                LoginData login = CommonMethods.ReadLoginDataFromExcel(2);
                CommonMethods.FillLoginForm(login);
                Thread.Sleep(2000);

                CommonMethods.NavigateToURL(GlobalConstants.ManageProfileLinke);

                ManageProfileData data = ManageProfileAssistentMethods.ReadDataFromExcel(6);

                ManageProfileAssistentMethods.FillLprofilForm(data);

                var expectedSubmitButtonClickable = false;
                var submitButton = ManageDriver.driver.FindElement(By.XPath("/html/body/app-root/app-prfile-a/div/div/div/div/div/form/div/div/div[9]/div/div[2]/div/button"));
                bool actualSubmitButtonClickable = submitButton.Displayed && submitButton.Enabled;
                Assert.AreEqual(expectedSubmitButtonClickable, actualSubmitButtonClickable,
           $"Expected submit button clickable state: {expectedSubmitButtonClickable}, " +
           $"but actual state was: {actualSubmitButtonClickable}");
                test.Log(Status.Info, "Result of  SubmitButtonClickable: " + Convert.ToString(actualSubmitButtonClickable));




                bool result = ManageProfileAssistentMethods.CheckSuccessAddBill(data.userName);
                test.Log(Status.Info, "Result of database " + Convert.ToString(result));


                Assert.IsFalse(result);
                test.Pass("can't Update Profile Successfully");
                Console.WriteLine("TC5 Completed Successfully");

            }

            catch (Exception ex)
            {
                test.Fail(ex.Message);
             

            }

        }

        [TestMethod]
        public void InvalidIncorrectPassword()
        {
            var test = extentReports.CreateTest("InvalidIncorrectPassword  ", "verify that on passing Invalid data to  form, the data didn't added ");
            try
            {
                CommonMethods.NavigateToURL(GlobalConstants.loginLink);
                LoginData login = CommonMethods.ReadLoginDataFromExcel(2);
                CommonMethods.FillLoginForm(login);
                Thread.Sleep(2000);

                CommonMethods.NavigateToURL(GlobalConstants.ManageProfileLinke);

                ManageProfileData data = ManageProfileAssistentMethods.ReadDataFromExcel(7);

                ManageProfileAssistentMethods.FillLprofilForm(data);

                var expectedSubmitButtonClickable = true;
                var submitButton = ManageDriver.driver.FindElement(By.XPath("/html/body/app-root/app-prfile-a/div/div/div/div/div/form/div/div/div[9]/div/div[2]/div/button"));
                bool actualSubmitButtonClickable = submitButton.Displayed && submitButton.Enabled;
                Assert.AreEqual(expectedSubmitButtonClickable, actualSubmitButtonClickable,
           $"Expected submit button clickable state: {expectedSubmitButtonClickable}, " +
           $"but actual state was: {actualSubmitButtonClickable}");
                test.Log(Status.Info, "Result of  SubmitButtonClickable: " + Convert.ToString(actualSubmitButtonClickable));


                bool result = ManageProfileAssistentMethods.CheckSuccessAddBill(data.userName);
                test.Log(Status.Info, "Result of database " + Convert.ToString(result));


                Assert.IsFalse(result);

                
                test.Pass("can't Update Profile Successfully");
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
        public void InvalidNameoverLimitCharachter()
        {
            var test = extentReports.CreateTest("InvalidNameoverLimitCharachter  ", "verify that on passing Invalid data to  form, the data didn't added ");
            try
            {
                CommonMethods.NavigateToURL(GlobalConstants.loginLink);
                LoginData login = CommonMethods.ReadLoginDataFromExcel(2);
                CommonMethods.FillLoginForm(login);
                Thread.Sleep(2000);

                CommonMethods.NavigateToURL(GlobalConstants.ManageProfileLinke);

                ManageProfileData data = ManageProfileAssistentMethods.ReadDataFromExcel(8);

                ManageProfileAssistentMethods.FillLprofilForm(data);

                bool result = ManageProfileAssistentMethods.CheckSuccessAddBill(data.userName);
                test.Log(Status.Info, "Result of database " + Convert.ToString(result));


                Assert.IsFalse(result);
                var expectedSubmitButtonClickable = false;
                var submitButton = ManageDriver.driver.FindElement(By.XPath("/html/body/app-root/app-prfile-a/div/div/div/div/div/form/div/div/div[9]/div/div[2]/div/button"));
                bool actualSubmitButtonClickable = submitButton.Displayed && submitButton.Enabled;
                Assert.AreEqual(expectedSubmitButtonClickable, actualSubmitButtonClickable,
           $"Expected submit button clickable state: {expectedSubmitButtonClickable}, " +
           $"but actual state was: {actualSubmitButtonClickable}");
                test.Log(Status.Info, "Result of  SubmitButtonClickable: " + Convert.ToString(actualSubmitButtonClickable));




                
                test.Pass("can't Update Profile Successfully");
                Console.WriteLine("TC7 Completed Successfully");

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
