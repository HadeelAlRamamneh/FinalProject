using AventStack.ExtentReports;
using AventStack.ExtentReports.Model;
using AventStack.ExtentReports.Reporter;
using FinalProjectAutomation.AssistantMethods;
using FinalProjectAutomation.Data;
using FinalProjectAutomation.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectAutomation.TestMethods
{
    [TestClass]
    public class Login_TestMethods
    {
        public static ExtentReports extentReports = new ExtentReports();
        public static ExtentHtmlReporter reporter = new ExtentHtmlReporter("D:\\c##\\TestProject1\\Reports2\\");
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
        public void TestValidLoging()
        {
            var test = extentReports.CreateTest("TestSuccessLogin", "verify that on passing valid data to contact form, the data added correctly");
            try
            {
                CommonMethods.NavigateToURL(GlobalConstants.loginLink);
                LoginData login = LoginAssistantMethods.ReadLoginDataFromExcel(2);
                LoginAssistantMethods.FillLoginForm(login);
                Thread.Sleep(2000);
                var expectedURL = "http://localhost:4200/admin/home";
                var actualURL = ManageDriver.driver.Url;
                Assert.AreEqual(expectedURL, actualURL, "Actual URL not equal the expected URL_TC1");
                Console.WriteLine("TC1 Completed Successfully");
                test.Pass("Login Successfully");
            }
            catch (Exception ex)
            {
               
               Console.WriteLine(ex.ToString());

            }

        }
    }
}
