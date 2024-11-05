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
using System.Globalization;
using System.Xml.Linq;
using static FinalProjectAutomation.AssistantMethods.ManageReportsAssistantMethods;

namespace FinalProjectAutomation.TestMethods
{
    [TestClass]
    public class ManageReportTestMethods
    {
        public static ExtentReports extentReports = new ExtentReports();
        public static ExtentHtmlReporter reporter = new ExtentHtmlReporter("D:\\c##\\TestProject1\\ManageReport\\");
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
        public void TestDropdownOptionAndTableRowComparison()
        {

            var test = extentReports.CreateTest("TestValidCategoryNameAllBiller", "verify loop select in all option and retrived the category name of each option , the data retrieved correctly");
            try
            {
                CommonMethods.NavigateToURL(GlobalConstants.loginLink);
                LoginData login = CommonMethods.ReadLoginDataFromExcel(2);
                CommonMethods.FillLoginForm(login);
                Thread.Sleep(2000);

                CommonMethods.NavigateToURL("http://localhost:4200/admin/report");
                List<IWebElement> billerOption = ManageDriver.driver.FindElements(By.XPath("//select//option")).ToList();

                var dropdownLocator = By.XPath("//div//select");
                var tableRowLocator = By.XPath("//table/tbody/tr[1]/td[1]");

                for (int i = 2; i <= billerOption.Count; i++)
                {
                    ManageReportsAssistantMethods.SelectBiller(i);
                    if (i == 2)
                    {

                        string dropdownText = DropdownHelper.GetSelectedTextFromDropdown(ManageDriver.driver, dropdownLocator);

                        string tableRowText = DropdownHelper.GetTextFromTableRow(ManageDriver.driver, tableRowLocator);


                        Assert.AreEqual(dropdownText, tableRowText, $"The dropdown option text: {dropdownText} does not match the table row text :{tableRowText}.");
                        test.Log(Status.Info, $"the text from drop down :  {dropdownText} equal the text from table row: {tableRowText}");

                    }
                    else if (i == 3)
                    {

                        string dropdownText = DropdownHelper.GetSelectedTextFromDropdown(ManageDriver.driver, dropdownLocator);

                        string tableRowText = DropdownHelper.GetTextFromTableRow(ManageDriver.driver, tableRowLocator);


                        Assert.AreEqual(dropdownText, tableRowText, $"The dropdown option text: {dropdownText} does not match the table row text :{tableRowText}.");
                        test.Log(Status.Info, $"the text from drop down :  {dropdownText} equal the text from table row: {tableRowText}");

                    }
                    else if (i == 4)
                    {

                        string dropdownText = DropdownHelper.GetSelectedTextFromDropdown(ManageDriver.driver, dropdownLocator);

                        string tableRowText = DropdownHelper.GetTextFromTableRow(ManageDriver.driver, tableRowLocator);


                        Assert.AreEqual(dropdownText, tableRowText, $"The dropdown option text: {dropdownText} does not match the table row text :{tableRowText}.");
                        test.Log(Status.Info, $"the text from drop down :  {dropdownText} equal the text from table row: {tableRowText}");

                    }
                    else if (i == 5)
                    {

                        string dropdownText = DropdownHelper.GetSelectedTextFromDropdown(ManageDriver.driver, dropdownLocator);

                        string tableRowText = DropdownHelper.GetTextFromTableRow(ManageDriver.driver, tableRowLocator);


                        Assert.AreEqual(dropdownText, tableRowText, $"The dropdown option text: {dropdownText} does not match the table row text :{tableRowText}.");
                        test.Log(Status.Info, $"the text from drop down :  {dropdownText} equal the text from table row: {tableRowText}");

                    }



                }


                test.Pass("TC1 Completed Successfully");





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
        public void TestValidOptionAllBillers()
        {
            var test = extentReports.CreateTest("TestValidAllBillers", "verify that on passing valid data to  form, the data added correctly");
            try
            {
                CommonMethods.NavigateToURL(GlobalConstants.loginLink);
                LoginData login = CommonMethods.ReadLoginDataFromExcel(2);
                CommonMethods.FillLoginForm(login);
                Thread.Sleep(2000);

                CommonMethods.NavigateToURL("http://localhost:4200/admin/report");

                ManageReportsAssistantMethods.SelectBiller(1);
                IWebElement element = ManageDriver.driver.FindElement(By.XPath("//td[contains(text(), ' Water1 ')]"));
                Assert.IsTrue(element.Displayed, "The element containing 'Water1' is not displayed.");
                test.Log(Status.Info, "The element containing 'Water1' is  displayed.");

                IWebElement element2 = ManageDriver.driver.FindElement(By.XPath("//td[contains(text(), ' Electricity ')]"));
                Assert.IsTrue(element2.Displayed, "The element containing 'Electricity' is not displayed.");
                test.Log(Status.Info, "The element containing 'Electricity' is  displayed.");

                IWebElement element3 = ManageDriver.driver.FindElement(By.XPath("//td[contains(text(), ' Telecommunication ')]"));
                Assert.IsTrue(element3.Displayed, "The element containing 'Telecommunication' is not displayed.");
                test.Log(Status.Info, "The element containing 'Telecommunication' is  displayed.");

                IWebElement element4 = ManageDriver.driver.FindElement(By.XPath("//td[contains(text(), ' Education ')]"));
                Assert.IsTrue(element4.Displayed, "The element containing 'Education' is not displayed.");
                test.Log(Status.Info, "The element containing 'Education' is  displayed.");

                test.Pass("TC2 Completed Successfully");

                



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

        public void TestValidCategoryNameBillers()
        {
            var test = extentReports.CreateTest("TestValidCategoryNameAllBiller", "verify loop select in all option and retrived the category name of each option , the data retrieved correctly");
            try
            {
                CommonMethods.NavigateToURL(GlobalConstants.loginLink);
                LoginData login = CommonMethods.ReadLoginDataFromExcel(2);
                CommonMethods.FillLoginForm(login);
                Thread.Sleep(2000);

                CommonMethods.NavigateToURL("http://localhost:4200/admin/report");
                List<IWebElement> billerOption = ManageDriver.driver.FindElements(By.XPath("//select//option")).ToList();


                for (int i = 2; i <= billerOption.Count; i++)
                {
                    ManageReportsAssistantMethods.SelectBiller(i);
                    if (i == 2)
                    {
                        IWebElement element = ManageDriver.driver.FindElement(By.XPath("//td[contains(text(), ' Water1 ')]"));

                        Assert.IsTrue(element.Displayed, "The element containing 'Water1' is not displayed.");
                        Console.WriteLine("The element containing 'Water1' is displayed.");
                        test.Log(Status.Info, "The element containing 'Water1' is  displayed.");
                        Thread.Sleep(1000);

                    }
                    else if (i == 3)
                    {
                        IWebElement element = ManageDriver.driver.FindElement(By.XPath("//td[contains(text(), ' Electricity ')]"));

                        // Assert that the element is displayed
                        Assert.IsTrue(element.Displayed, "The element containing 'Electricity' is not displayed.");
                        Console.WriteLine("The element containing 'Electricity' is displayed.");
                        test.Log(Status.Info, "The element containing 'Electricity' is  displayed.");


                    }
                    else if (i == 4)
                    {
                        IWebElement element = ManageDriver.driver.FindElement(By.XPath("//td[contains(text(), ' Telecommunication ')]"));

                        // Assert that the element is displayed
                        Assert.IsTrue(element.Displayed, "The element containing 'Telecommunication' is not displayed.");
                        Console.WriteLine("The element containing 'Telecommunication' is displayed.");
                        test.Log(Status.Info, "The element containing 'Telecommunication' is  displayed.");


                    }
                    else if (i == 5)
                    {
                        IWebElement element = ManageDriver.driver.FindElement(By.XPath("//td[contains(text(), ' Education ')]"));

                        Assert.IsTrue(element.Displayed, "The element containing 'Education' is not displayed.");
                        Console.WriteLine("The element containing 'Education' is displayed.");
                        test.Log(Status.Info, "The element containing 'Education' is  displayed.");


                    }



                }


                test.Pass("TC3 Completed Successfully");





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

        public void TestValidWaterBillerCountPay()
        {
            var test = extentReports.CreateTest("TestValidWaterBillerCountPay", "verify that retrieved valid data , the data retrieved correctly");
            try
            {
                CommonMethods.NavigateToURL(GlobalConstants.loginLink);
                LoginData login = CommonMethods.ReadLoginDataFromExcel(2);
                CommonMethods.FillLoginForm(login);
                Thread.Sleep(2000);

                CommonMethods.NavigateToURL("http://localhost:4200/admin/report");
                List<IWebElement> billerOption = ManageDriver.driver.FindElements(By.XPath("//select//option")).ToList();



                ManageReportsAssistantMethods.SelectBiller(2);



                int expectedCount = 7;
                int actualCount = ManageReportsAssistantMethods.GetPaymentCount(1);
                Assert.AreEqual(expectedCount, actualCount, $"Expected {expectedCount} payments, but found {actualCount}.");
                test.Log(Status.Info, $"Expected {expectedCount} payments, Actual {actualCount}.");
                Thread.Sleep(1000);
                //decimal expectedSum = 35;
                //decimal actualSum = ManageReportsAssistantMethods.GetSumProfit(1);
                //Assert.AreEqual(expectedSum, actualSum, $"Expected {expectedSum} payments, but found {actualSum}.");
                //test.Log(Status.Info, $"Expected {expectedSum} payments, Actual {actualSum}.");
                //Thread.Sleep(1000);

                test.Pass("TC4 Completed Successfully");

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

        public void TestValidElectricityBillerCountPay()
        {
            var test = extentReports.CreateTest("TestValidElectricityBillerCountPay", "verify that retrieved valid data , the data retrieved correctly");
            try
            {
                CommonMethods.NavigateToURL(GlobalConstants.loginLink);
                LoginData login = CommonMethods.ReadLoginDataFromExcel(2);
                CommonMethods.FillLoginForm(login);
                Thread.Sleep(2000);

                CommonMethods.NavigateToURL("http://localhost:4200/admin/report");




                ManageReportsAssistantMethods.SelectBiller(3);



                int expectedCount = 2;
                int actualCount = ManageReportsAssistantMethods.GetPaymentCount(2);
                Assert.AreEqual(expectedCount, actualCount, $"Expected {expectedCount} payments, but found {actualCount}.");
                test.Log(Status.Info, $"Expected {expectedCount} payments, Actual {actualCount}.");
                Thread.Sleep(1000);
                //decimal expectedSum = 35;
                //decimal actualSum = ManageReportsAssistantMethods.GetSumProfit(2);
                //Assert.AreEqual(expectedSum, actualSum, $"Expected {expectedSum} payments, but found {actualSum}.");
                //test.Log(Status.Info, $"Expected {expectedSum} payments, Actual {actualSum}.");
                //Thread.Sleep(1000);

                test.Pass("TC5 Completed Successfully");

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

        public void TestValidTelecommunicationBillerCountPay()
        {
            var test = extentReports.CreateTest("TestValidTelecommunicationBillerCountPay", "verify that retrieved valid data , the data retrieved correctly");
            try
            {
                CommonMethods.NavigateToURL(GlobalConstants.loginLink);
                LoginData login = CommonMethods.ReadLoginDataFromExcel(2);
                CommonMethods.FillLoginForm(login);
                Thread.Sleep(2000);

                CommonMethods.NavigateToURL("http://localhost:4200/admin/report");

                ManageReportsAssistantMethods.SelectBiller(4);



                int expectedCount = 4;
                int actualCount = ManageReportsAssistantMethods.GetPaymentCount(3);
                Assert.AreEqual(expectedCount, actualCount, $"Expected {expectedCount} payments, but found {actualCount}.");
                test.Log(Status.Info, $"Expected {expectedCount} payments, Actual {actualCount}.");
                Thread.Sleep(1000);
                //decimal expectedSum = 35;
                //decimal actualSum = ManageReportsAssistantMethods.GetSumProfit(3);
                //Assert.AreEqual(expectedSum, actualSum, $"Expected {expectedSum} payments, but found {actualSum}.");
                //test.Log(Status.Info, $"Expected {expectedSum} payments, Actual {actualSum}.");
                //Thread.Sleep(1000);

                test.Pass("TC6 Completed Successfully");

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

        public void TestValidEducationBillerCountPay()
        {
            var test = extentReports.CreateTest("TestValidEducationBillerCountPay", "verify that retrieved valid data , the data retrieved correctly");
            try
            {
                CommonMethods.NavigateToURL(GlobalConstants.loginLink);
                LoginData login = CommonMethods.ReadLoginDataFromExcel(2);
                CommonMethods.FillLoginForm(login);
                Thread.Sleep(2000);

                CommonMethods.NavigateToURL("http://localhost:4200/admin/report");
                ManageReportsAssistantMethods.SelectBiller(5);


                int expectedCount = 6;
                int actualCount = ManageReportsAssistantMethods.GetPaymentCount(4);
                Assert.AreEqual(expectedCount, actualCount, $"Expected {expectedCount} payments, but found {actualCount}.");
                test.Log(Status.Info, $"Expected {expectedCount} payments, Actual {actualCount}.");
                Thread.Sleep(1000);
                //decimal expectedSum = 35;
                //decimal actualSum = ManageReportsAssistantMethods.GetSumProfit(4);
                //Assert.AreEqual(expectedSum, actualSum, $"Expected {expectedSum} payments, but found {actualSum}.");
                //test.Log(Status.Info, $"Expected {expectedSum} payments, Actual {actualSum}.");
                //Thread.Sleep(1000);

                test.Pass("TC7 Completed Successfully");

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

        public void TestValidWaterBillerSumProfit()
        {
            var test = extentReports.CreateTest("TestValidWaterBillerSumProfit", "verify that retrieved valid data , the data retrieved correctly");
            try
            {
                CommonMethods.NavigateToURL(GlobalConstants.loginLink);
                LoginData login = CommonMethods.ReadLoginDataFromExcel(2);
                CommonMethods.FillLoginForm(login);
                Thread.Sleep(2000);

                CommonMethods.NavigateToURL("http://localhost:4200/admin/report");
                List<IWebElement> billerOption = ManageDriver.driver.FindElements(By.XPath("//select//option")).ToList();



                ManageReportsAssistantMethods.SelectBiller(2);




                decimal expectedSum = 35;
                decimal actualSum = ManageReportsAssistantMethods.GetSumProfit(1);
                Assert.AreEqual(expectedSum, actualSum, $"Expected {expectedSum} payments, but found {actualSum}.");
                test.Log(Status.Info, $"Expected {expectedSum} payments, Actual {actualSum}.");
                Thread.Sleep(1000);

                test.Pass("TC8 Completed Successfully");

                Console.WriteLine("TC8 Completed Successfully");


            }

            catch (Exception ex)
            {

                test.Fail(ex.Message);

                string screenShotPath = CommonMethods.TakeScreenShot();
                test.AddScreenCaptureFromPath(screenShotPath);

            }

        }


        [TestMethod]

        public void TestValidElectricityBillerSumProfit()
        {
            var test = extentReports.CreateTest("TestValidElectricityBillerSumProfit", "verify that retrieved valid data , the data retrieved correctly");
            try
            {
                CommonMethods.NavigateToURL(GlobalConstants.loginLink);
                LoginData login = CommonMethods.ReadLoginDataFromExcel(2);
                CommonMethods.FillLoginForm(login);
                Thread.Sleep(2000);

                CommonMethods.NavigateToURL("http://localhost:4200/admin/report");

                ManageReportsAssistantMethods.SelectBiller(3);

                decimal expectedSum = 4;
                decimal actualSum = ManageReportsAssistantMethods.GetSumProfit(2);
                Assert.AreEqual(expectedSum, actualSum, $"Expected {expectedSum} payments, but found {actualSum}.");
                test.Log(Status.Info, $"Expected {expectedSum} payments, Actual {actualSum}.");
                Thread.Sleep(1000);

                test.Pass("TC9 Completed Successfully");

                Console.WriteLine("TC9 Completed Successfully");


            }

            catch (Exception ex)
            {

                test.Fail(ex.Message);

                string screenShotPath = CommonMethods.TakeScreenShot();
                test.AddScreenCaptureFromPath(screenShotPath);

            }

        }


        [TestMethod]

        public void TestValidTelecommunicationBillerSumProfit()
        {
            var test = extentReports.CreateTest("TestValidTelecommunicationBillerSumProfit", "verify that retrieved valid data , the data retrieved correctly");
            try
            {
                CommonMethods.NavigateToURL(GlobalConstants.loginLink);
                LoginData login = CommonMethods.ReadLoginDataFromExcel(2);
                CommonMethods.FillLoginForm(login);
                Thread.Sleep(2000);

                CommonMethods.NavigateToURL("http://localhost:4200/admin/report");

                ManageReportsAssistantMethods.SelectBiller(4);

                decimal expectedSum = 8;
                decimal actualSum = ManageReportsAssistantMethods.GetSumProfit(3);
                Assert.AreEqual(expectedSum, actualSum, $"Expected {expectedSum} payments, but found {actualSum}.");
                test.Log(Status.Info, $"Expected {expectedSum} payments, Actual {actualSum}.");
                Thread.Sleep(1000);

                test.Pass("TC10 Completed Successfully");

                Console.WriteLine("TC10 Completed Successfully");


            }

            catch (Exception ex)
            {

                test.Fail(ex.Message);

                string screenShotPath = CommonMethods.TakeScreenShot();
                test.AddScreenCaptureFromPath(screenShotPath);

            }

        }
        [TestMethod]

        public void TestValidEducationBillerSumProfit()
        {
            var test = extentReports.CreateTest("TestValidEducationBillerSumProfit", "verify that retrieved valid data , the data retrieved correctly");
            try
            {
                CommonMethods.NavigateToURL(GlobalConstants.loginLink);
                LoginData login = CommonMethods.ReadLoginDataFromExcel(2);
                CommonMethods.FillLoginForm(login);
                Thread.Sleep(2000);

                CommonMethods.NavigateToURL("http://localhost:4200/admin/report");
                ManageReportsAssistantMethods.SelectBiller(5);

                decimal expectedSum = 16;
                decimal actualSum = ManageReportsAssistantMethods.GetSumProfit(4);
                Assert.AreEqual(expectedSum, actualSum, $"Expected {expectedSum} payments, but found {actualSum}.");
                test.Log(Status.Info, $"Expected {expectedSum} payments, Actual {actualSum}.");
                Thread.Sleep(1000);

                test.Pass("TC11 Completed Successfully");

                Console.WriteLine("TC11 Completed Successfully");


            }

            catch (Exception ex)
            {

                test.Fail(ex.Message);

                string screenShotPath = CommonMethods.TakeScreenShot();
                test.AddScreenCaptureFromPath(screenShotPath);

            }

        }

        /// /////////////Date//////////////////

        [TestMethod]
       
        public void TestValidDateRetrievedPaymentDate()
        {
            var test = extentReports.CreateTest("TestValidDateRetrievedPaymentDate", "Verify that retrieved data is valid and displayed correctly");
            try
            {
                
                CommonMethods.NavigateToURL(GlobalConstants.loginLink);
                LoginData login = CommonMethods.ReadLoginDataFromExcel(2);
                CommonMethods.FillLoginForm(login);
                Thread.Sleep(2000);

                CommonMethods.NavigateToURL("http://localhost:4200/admin/report");

                ManageReportsData data = ManageReportsAssistantMethods.ReadDataFromExcel(2);
                ManageReportPage manageReportPage = new ManageReportPage(ManageDriver.driver);
                ManageReportsAssistantMethods.AddDate(data);
                List<IWebElement> tableRows = ManageDriver.driver.FindElements(By.XPath("//tbody//tr")).ToList();

                // Loop through each table row and perform validation
                for (int i = 1; i <= tableRows.Count - 1; i++)
                {
                    // Navigate to the report page again before each button click
                    CommonMethods.NavigateToURL("http://localhost:4200/admin/report");

                    // Add date filter from data
                    ManageReportsAssistantMethods.AddDate(data);

                    // Click the appropriate button based on index
                    if (i == 1)
                    {
                        manageReportPage.ClickButtonOne();
                        Thread.Sleep(1000);
                    }

                    else if (i == 2)
                    {
                        manageReportPage.ClickButtonTow();
                        Thread.Sleep(1000);
                    }
                    else if (i == 3)
                    {
                        manageReportPage.ClickButtonThree();
                        Thread.Sleep(1000);
                    }
                    else if (i == 4)
                    {
                        manageReportPage.ClickButtonFour();
                        Thread.Sleep(1000);
                    }

                    // Find elements containing 'Mar 4, 2022' in the results
                    List<IWebElement> elements = ManageDriver.driver.FindElements(By.XPath("//td[contains(text(), ' Mar 4, 2022 ')]")).ToList();

                    // Assert that elements containing 'Mar 4, 2022' exist
                    Assert.IsTrue(elements.Count > 0, $"No elements containing 'Mar 4, 2022' were found on button {i} click.");

                    // Log and assert visibility of each element found
                    foreach (var element in elements)
                    {
                        Assert.IsTrue(element.Displayed, "An element containing 'Mar 4, 2022' is not displayed.");
                        Console.WriteLine("An element containing 'Mar 4, 2022' is displayed.");
                        test.Log(Status.Info, "An element containing 'Mar 4, 2022' is displayed.");
                        Thread.Sleep(500);
                    }

                    Console.WriteLine($"Total elements found containing 'Mar 4, 2022': {elements.Count}");
                    test.Log(Status.Info, $"Total elements found containing 'Mar 4, 2022': {elements.Count}");
                }

                test.Pass("TC12 Completed Successfully");
                Console.WriteLine("TC12 Completed Successfully");
            }
            catch (Exception ex)
            {
                test.Fail(ex.Message);
                string screenShotPath = CommonMethods.TakeScreenShot();
                test.AddScreenCaptureFromPath(screenShotPath);
            }
        }



        [TestMethod]
        public void TestValidDateRetrievedCountPay()
        {
            var test = extentReports.CreateTest("TestValidDateRetrievedCountPay", "verify that retrieved valid data , the data retrieved correctly");
            try
            {
                CommonMethods.NavigateToURL(GlobalConstants.loginLink);
                LoginData login = CommonMethods.ReadLoginDataFromExcel(2);
                CommonMethods.FillLoginForm(login);
                Thread.Sleep(2000);

                CommonMethods.NavigateToURL("http://localhost:4200/admin/report");

                ManageReportsData data = ManageReportsAssistantMethods.ReadDataFromExcel(2);
                ManageReportsAssistantMethods.AddDate(data);

                

                List<IWebElement> TableRows = ManageDriver.driver.FindElements(By.XPath("//tbody//tr")).ToList();
               

                for (int i = 1; i <= TableRows.Count - 1; i++)
                {
                    CommonMethods.NavigateToURL("http://localhost:4200/admin/report");
                    ManageReportsAssistantMethods.AddDate(data);
                    if (i == 1)
                    {

                        int expectedCount = 1;
                        int actualCount = ManageReportsAssistantMethods.GetPaymentCountUsingDate(1,data);
                        Assert.AreEqual(expectedCount, actualCount, $"Expected {expectedCount} payments, but found {actualCount}.");
                        test.Log(Status.Info, $"Expected {expectedCount} payments, Actual {actualCount}.");
                        Thread.Sleep(1000);
                        


                    }
                    else if (i == 2)
                    {
                        int expectedCount = 2;
                        int actualCount = ManageReportsAssistantMethods.GetPaymentCountUsingDate(3,data);
                        Assert.AreEqual(expectedCount, actualCount, $"Expected {expectedCount} payments, but found {actualCount}.");
                        test.Log(Status.Info, $"Expected {expectedCount} payments, Actual {actualCount}.");
                        Thread.Sleep(1000);

                        Thread.Sleep(1000);

                    }
                    else if (i == 3)
                    {
                        int expectedCount = 1;
                        int actualCount = ManageReportsAssistantMethods.GetPaymentCountUsingDate(4, data);
                        Assert.AreEqual(expectedCount, actualCount, $"Expected {expectedCount} payments, but found {actualCount}.");
                        test.Log(Status.Info, $"Expected {expectedCount} payments, Actual {actualCount}.");
                        Thread.Sleep(1000);

                    }


                }




                test.Pass("TC13 Completed Successfully");

                Console.WriteLine("TC13 Completed Successfully");


            }

            catch (Exception ex)
            {

                test.Fail(ex.Message);
                Console.WriteLine(ex.Message);
                string screenShotPath = CommonMethods.TakeScreenShot();
                test.AddScreenCaptureFromPath(screenShotPath);



            }



        }

        [TestMethod]
        public void TestValidDateRetrievedSumProfit()
        {
            var test = extentReports.CreateTest("TestValidDateRetrievedSumProfit", "verify that retrieved valid data , the data retrieved correctly");
            try
            {
                CommonMethods.NavigateToURL(GlobalConstants.loginLink);
                LoginData login = CommonMethods.ReadLoginDataFromExcel(2);
                CommonMethods.FillLoginForm(login);
                Thread.Sleep(2000);

                CommonMethods.NavigateToURL("http://localhost:4200/admin/report");

                ManageReportsData data = ManageReportsAssistantMethods.ReadDataFromExcel(2);
                ManageReportsAssistantMethods.AddDate(data);



                List<IWebElement> TableRows = ManageDriver.driver.FindElements(By.XPath("//tbody//tr")).ToList();


                for (int i = 1; i <= TableRows.Count - 1; i++)
                {
                    CommonMethods.NavigateToURL("http://localhost:4200/admin/report");
                    ManageReportsAssistantMethods.AddDate(data);

                    if (i == 1)
                    {

                        decimal expectedSum = 5;
                        decimal actualSum=ManageReportsAssistantMethods.GetSumProfitUsingDate(1,data);
                        Assert.AreEqual(expectedSum, actualSum, $"Expected {expectedSum} payments, but found {actualSum}.");
                        test.Log(Status.Info, $"Expected {expectedSum} payments, Actual {actualSum}.");
                        Thread.Sleep(1000);

                    }
                    else if (i == 2)
                    {
                        decimal expectedSum = 4;
                        decimal actualSum = ManageReportsAssistantMethods.GetSumProfitUsingDate(3, data);
                        Assert.AreEqual(expectedSum, actualSum, $"Expected {expectedSum} payments, but found {actualSum}.");
                        test.Log(Status.Info, $"Expected {expectedSum} payments, Actual {actualSum}.");
                        Thread.Sleep(1000);

                    }
                    else if (i == 3)
                    {
                        decimal expectedSum = 3;
                        decimal actualSum = ManageReportsAssistantMethods.GetSumProfitUsingDate(4, data);
                        Assert.AreEqual(expectedSum, actualSum, $"Expected {expectedSum} payments, but found {actualSum}.");
                        test.Log(Status.Info, $"Expected {expectedSum} payments, Actual {actualSum}.");
                        Thread.Sleep(1000);

                    }


                }




                test.Pass("TC14 Completed Successfully");

                Console.WriteLine("TC14 Completed Successfully");


            }

            catch (Exception ex)
            {

                test.Fail(ex.Message);

                string screenShotPath = CommonMethods.TakeScreenShot();
                test.AddScreenCaptureFromPath(screenShotPath);



            }



        }

        [TestMethod]
        public void TestValidDateRetrievedName()
        {
            var test = extentReports.CreateTest("TestValidDateRetrievedName", "verify that retrieved valid data , the data retrieved correctly");
            try
            {
                CommonMethods.NavigateToURL(GlobalConstants.loginLink);
                LoginData login = CommonMethods.ReadLoginDataFromExcel(2);
                CommonMethods.FillLoginForm(login);
                Thread.Sleep(2000);

                CommonMethods.NavigateToURL("http://localhost:4200/admin/report");

                ManageReportsData data = ManageReportsAssistantMethods.ReadDataFromExcel(2);
                ManageReportsAssistantMethods.AddDate(data);

                List<IWebElement> TableRows = ManageDriver.driver.FindElements(By.XPath("//tbody//tr")).ToList();


                for (int i = 1; i <= TableRows.Count - 1; i++)
                {



                    if (i == 1)
                    {
                        IWebElement element = ManageDriver.driver.FindElement(By.XPath("//td[contains(text(), ' Water1 ')]"));
                        string expectedName = ManageReportsAssistantMethods.GetCategoryName(i);
                        string actualNamme = element.Text.Trim();
                        Assert.AreEqual(expectedName, actualNamme, $"Expected {expectedName} , but found {actualNamme}.");
                        test.Log(Status.Info, $"Expected {expectedName} , Actual {actualNamme}.");

                        Thread.Sleep(1000);

                    }
                    else if (i == 2)
                    {
                        IWebElement element = ManageDriver.driver.FindElement(By.XPath("//td[contains(text(), ' Telecommunication ')]"));
                        string expectedName = ManageReportsAssistantMethods.GetCategoryName(i);
                        string actualNamme = element.Text.Trim();
                        Assert.AreEqual(expectedName, actualNamme, $"Expected {expectedName} , but found {actualNamme}.");
                        test.Log(Status.Info, $"Expected {expectedName} , Actual {actualNamme}.");

                        Thread.Sleep(1000);

                    }
                    else if (i == 3)
                    {
                        IWebElement element = ManageDriver.driver.FindElement(By.XPath("//td[contains(text(), ' Education ')]"));
                        string expectedName = ManageReportsAssistantMethods.GetCategoryName(i);
                        string actualNamme = element.Text.Trim();
                        Assert.AreEqual(expectedName, actualNamme, $"Expected {expectedName} , but found {actualNamme}.");
                        test.Log(Status.Info, $"Expected {expectedName} , Actual {actualNamme}.");
                        Thread.Sleep(1000);

                    }


                }




                test.Pass("TC15 Completed Successfully");

                Console.WriteLine("TC15 Completed Successfully");


            }

            catch (Exception ex)
            {

                test.Fail(ex.Message);

                string screenShotPath = CommonMethods.TakeScreenShot();
                test.AddScreenCaptureFromPath(screenShotPath);



            }



        }

        [TestMethod]

        public void InValidTestSearchOnlyDateFrom()
        {
            var test = extentReports.CreateTest("InValidTestSearchOnlyDateFrom", "verify that retrieved valid data , the data retrieved correctly");
            try
            {
                CommonMethods.NavigateToURL(GlobalConstants.loginLink);
                LoginData login = CommonMethods.ReadLoginDataFromExcel(2);
                CommonMethods.FillLoginForm(login);

                Thread.Sleep(2000);

                CommonMethods.NavigateToURL("http://localhost:4200/admin/report");
                ManageReportsData data = ManageReportsAssistantMethods.ReadDataFromExcel(3);
                ManageReportsAssistantMethods.AddDate(data);

                List<IWebElement> TableRows = ManageDriver.driver.FindElements(By.XPath("//tbody//tr")).ToList();
                Assert.IsTrue(TableRows.Count > 1, $"No elements containing .");
                test.Log(Status.Info, $" the number of retrieved rows : {TableRows.Count}");
                
                test.Pass("TC16 Completed Successfully");
                Console.WriteLine("TC16 Completed Successfully");


            }

            catch (Exception ex)
            {

                test.Fail(ex.Message);

                string screenShotPath = CommonMethods.TakeScreenShot();
                test.AddScreenCaptureFromPath(screenShotPath);



            }

        }

        [TestMethod]

        public void InValidTestSearchOnlyDateTo()
        {
            var test = extentReports.CreateTest("InValidTestSearchOnlyDateTo", "verify that retrieved valid data , the data retrieved correctly");
            try
            {
                CommonMethods.NavigateToURL(GlobalConstants.loginLink);
                LoginData login = CommonMethods.ReadLoginDataFromExcel(2);
                CommonMethods.FillLoginForm(login);

                Thread.Sleep(2000);

                CommonMethods.NavigateToURL("http://localhost:4200/admin/report");
                ManageReportsData data = ManageReportsAssistantMethods.ReadDataFromExcel(4);
                ManageReportsAssistantMethods.AddDate(data);

                List<IWebElement> TableRows = ManageDriver.driver.FindElements(By.XPath("//tbody//tr")).ToList();
                Assert.IsTrue(TableRows.Count > 1, $"No elements containing .");
                test.Log(Status.Info, $" the number of retrieved rows : {TableRows.Count}");

                test.Pass("TC17 Completed Successfully");
                Console.WriteLine("TC17 Completed Successfully");


            }

            catch (Exception ex)
            {

                test.Fail(ex.Message);

                string screenShotPath = CommonMethods.TakeScreenShot();
                test.AddScreenCaptureFromPath(screenShotPath);



            }
        }

        [TestMethod]

        public void InvalidTestSearchByFutuerDate()
        {
            var test = extentReports.CreateTest("InvalidTestSearchByFutuerDate", "verify that retrieved valid data , the data retrieved correctly");
            try
            {
                CommonMethods.NavigateToURL(GlobalConstants.loginLink);
                LoginData login = CommonMethods.ReadLoginDataFromExcel(2);
                CommonMethods.FillLoginForm(login);

                Thread.Sleep(2000);

                CommonMethods.NavigateToURL("http://localhost:4200/admin/report");
                ManageReportsData data = ManageReportsAssistantMethods.ReadDataFromExcel(5);
                ManageReportsAssistantMethods.AddDate(data);

                List<IWebElement> TableRows = ManageDriver.driver.FindElements(By.XPath("//tbody//tr")).ToList();
                Assert.IsTrue(TableRows.Count == 1, $"No elements containing .");
                test.Log(Status.Info, $" the number of retrieved rows : {TableRows.Count} that is TotalProfit row");

                test.Pass("TC18 Completed Successfully");
                Console.WriteLine("TC18 Completed Successfully");


            }

            catch (Exception ex)
            {

                test.Fail(ex.Message);

                string screenShotPath = CommonMethods.TakeScreenShot();
                test.AddScreenCaptureFromPath(screenShotPath);



            }
        }

        [TestMethod]

        public void InvalidTestDateFromAfterDateTo()
        {
            var test = extentReports.CreateTest("InvalidTestDateFromAfterDateTo", "verify that retrieved valid data , the data retrieved correctly");
            try
            {
                CommonMethods.NavigateToURL(GlobalConstants.loginLink);
                LoginData login = CommonMethods.ReadLoginDataFromExcel(2);
                CommonMethods.FillLoginForm(login);

                Thread.Sleep(2000);

                CommonMethods.NavigateToURL("http://localhost:4200/admin/report");
                ManageReportsData data = ManageReportsAssistantMethods.ReadDataFromExcel(6);
                ManageReportsAssistantMethods.AddDate(data);

                List<IWebElement> TableRows = ManageDriver.driver.FindElements(By.XPath("//tbody//tr")).ToList();
                Assert.IsTrue(TableRows.Count ==1, $"No elements containing .");
                test.Log(Status.Info, $" the number of retrieved rows : {TableRows.Count} that is TotalProfit row");

                test.Pass("TC19 Completed Successfully");
                Console.WriteLine("TC19 Completed Successfully");


            }

            catch (Exception ex)
            {

                test.Fail(ex.Message);

                string screenShotPath = CommonMethods.TakeScreenShot();
                test.AddScreenCaptureFromPath(screenShotPath);



            }
        }

        [TestMethod]

        public void TestSearchBySpecificNameWithSpecificDuration()
        {
            var test = extentReports.CreateTest("TestSearchBySpecificNameWithSpecificDuration", "verify that retrieved valid data , the data retrieved correctly");
            try
            {
                CommonMethods.NavigateToURL(GlobalConstants.loginLink);
                LoginData login = CommonMethods.ReadLoginDataFromExcel(2);
                CommonMethods.FillLoginForm(login);

                Thread.Sleep(2000);

                CommonMethods.NavigateToURL("http://localhost:4200/admin/report");
                
                ManageReportsData data = ManageReportsAssistantMethods.ReadDataFromExcel(2);
                ManageReportsAssistantMethods.AddDate(data);

                List<IWebElement> TableRows = ManageDriver.driver.FindElements(By.XPath("//tbody//tr")).ToList();
                List<IWebElement> billerOption = ManageDriver.driver.FindElements(By.XPath("//select//option")).ToList();
                for (int i = 1;i < billerOption.Count; i++)
                {
                    ManageReportsAssistantMethods.SelectBiller(i);
                    Assert.IsTrue(TableRows.Count >= 1, $"No elements containing .");
                    test.Log(Status.Info, $" the number of retrieved rows : {TableRows.Count} ");
                }
               

                test.Pass("TC20 Completed Successfully");
                Console.WriteLine("TC20 Completed Successfully");


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
