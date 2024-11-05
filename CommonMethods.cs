using Bytescout.Spreadsheet;
using FinalProjectAutomation.Data;
using FinalProjectAutomation.POM;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectAutomation.Helpers
{
    public class CommonMethods
    {
        public static void NavigateToURL(string url)
        {
            ManageDriver.driver.Navigate().GoToUrl(url);

        }
    
       public static IWebElement WaitAndFindElement(By by)
        {
            var fluentWait = new DefaultWait<IWebDriver>(ManageDriver.driver)
            {
                Timeout=TimeSpan.FromSeconds(10),
                PollingInterval=TimeSpan.FromMilliseconds(500),

            };
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.IgnoreExceptionTypes(typeof(ElementClickInterceptedException));
            fluentWait.IgnoreExceptionTypes(typeof(StaleElementReferenceException));
            IWebElement element = fluentWait.Until(x => x.FindElement(by));
            return element;

        }
    
      public static  void HighlightElement(IWebElement element)
        {
            IJavaScriptExecutor javaScriptExecutor = (IJavaScriptExecutor)ManageDriver.driver;
            javaScriptExecutor.ExecuteScript("arguments[0].setAttribute('style', 'background: lightpink !important')", element);
            javaScriptExecutor.ExecuteScript("arguments[0].scrollIntoView(true);", element);
            Thread.Sleep(500);

            javaScriptExecutor.ExecuteScript("arguments[0].setAttribute('style', 'background: none !important')", element);
        }
      public static Worksheet ReadExcel(string sheetName)
        {
            Spreadsheet Excle = new Spreadsheet();
           
            Excle.LoadFromFile(GlobalConstants.TestDataPath);
            Worksheet worksheet =Excle.Workbook.Worksheets.ByName(sheetName);
          
            return worksheet;

        }
        public static Worksheet ReadBillDataExcel(string sheetName)
        {
            Spreadsheet Excle = new Spreadsheet();

            Excle.LoadFromFile(GlobalConstants.TestDatacategoryPath);
            Worksheet worksheet = Excle.Workbook.Worksheets.ByName(sheetName);

            return worksheet;

        }
        public static string TakeScreenShot()
        {
            // Cast the driver to ITakesScreenshot to enable screenshot functionality
            ITakesScreenshot takesScreenshot = (ITakesScreenshot)ManageDriver.driver;

            // Capture the screenshot using the driver
            Screenshot screenshot = takesScreenshot.GetScreenshot();

            // Define the path where the screenshot will be saved
            string path = "C:\\Users\\HP\\Desktop\\Screen";

            // Generate a unique image name using a GUID to avoid filename collisions
            string imageName = Guid.NewGuid().ToString() + "_image.png";

            // Combine the path and image name to create the full file path for the screenshot
            string fullPath = Path.Combine(path + $"\\{imageName}"); // E.g., C:\\Users\\b.alhassoun.ext\\Documents\\HerfaTestReport\\xxxxxxxxxxxxxxxxx_image.png

            // Save the screenshot to the specified path
            screenshot.SaveAsFile(fullPath);

            // Return the full path of the saved screenshot
            return fullPath;
        }

        public static void FillLoginForm(LoginData loginData)
        {
            LoginPage loginPage = new LoginPage(ManageDriver.driver);
            loginPage.EnterUserName(loginData.userName);
            loginPage.EnterPassword(loginData.password);
            Thread.Sleep(1000);
            loginPage.ClickSignInButton();
        }
        public static LoginData ReadLoginDataFromExcel(int row)
        {
            LoginData loginData = new LoginData();
            Worksheet worksheet = CommonMethods.ReadExcel("Login");
            loginData.userName = worksheet.Cell(row, 2).Value?.ToString() ?? string.Empty;
            loginData.password = worksheet.Cell(row, 3).Value?.ToString() ?? string.Empty;
            return loginData;

        }

    }
}
