using FinalProjectAutomation.Helpers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectAutomation.POM
{
    public class ManageProfilePage
    {
        IWebDriver _driver;
        public ManageProfilePage(IWebDriver driver)
        {
            _driver = driver;
        }

        By fullName = By.XPath("//div//input[@ng-reflect-name='FullName']");
        By phoneNumber = By.XPath("/html/body/app-root/app-prfile-a/div/div/div/div/div/form/div/div/div[2]/div/input");
        By email = By.XPath("/html/body/app-root/app-prfile-a/div/div/div/div/div/form/div/div/div[3]/div/input");
        By currentPassword = By.XPath("/html/body/app-root/app-prfile-a/div/div/div/div/div/form/div/div/div[4]/div/input");
        By address = By.XPath("/html/body/app-root/app-prfile-a/div/div/div/div/div/form/div/div/div[5]/div/input");
        By userName = By.XPath("//div//input[@ng-reflect-name='username']");
        By newPassword = By.XPath("//div//input[@ng-reflect-name='curenrpassword']");
        By image = By.XPath("//div//input[@accept='image/*']");
        By updateButton = By.XPath("/html/body/app-root/app-prfile-a/div/div/div/div/div/form/div/div/div[9]/div/div[2]/div/button");

        public void EnterFullName(string value)
        {
            IWebElement element = CommonMethods.WaitAndFindElement(fullName);
            CommonMethods.HighlightElement(element);
            element.SendKeys(value);
        }
        public void EnterPhoneNumber(string value)
        {
            IWebElement element = CommonMethods.WaitAndFindElement(phoneNumber);
            CommonMethods.HighlightElement(element);
            element.SendKeys(value);
        }
        public void EnterEmail(string value)
        {
            IWebElement element = CommonMethods.WaitAndFindElement(email);
            CommonMethods.HighlightElement(element);
            element.SendKeys(value);
        }

        public void EnterCurentPassword(string value)
        {
            IWebElement element = CommonMethods.WaitAndFindElement(currentPassword);
            CommonMethods.HighlightElement(element);
            element.SendKeys(value);
        }
        public void EnterAddress(string value) 
        {
            IWebElement element = CommonMethods.WaitAndFindElement(address);
            CommonMethods.HighlightElement(element);
            element.SendKeys(value);
        }
        public void EnterUserName(string value)
        {
            IWebElement element = CommonMethods.WaitAndFindElement(userName);
            CommonMethods.HighlightElement(element);
            element.SendKeys(value);
        }
        public void ClickUpdateButton()
        {
            IWebElement element = CommonMethods.WaitAndFindElement(updateButton);
            CommonMethods.HighlightElement(element);
            element.Click();

        }


    }
}
