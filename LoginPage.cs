using FinalProjectAutomation.Helpers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Security;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectAutomation.POM
{
    public class LoginPage
    {
        IWebDriver _driver;
        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
        }

        By userName = By.XPath("//input[@type='email']");
        By password  = By.XPath("//input[@type='password']");
        By signInButton = By.XPath("/html/body/app-root/app-login/div/div/div[1]/form/button");
        By signUpButton = By.XPath("/html/body/app-root/app-login/div/div/div[2]/button");

        public void EnterUserName(string value)
        {
          IWebElement element=  CommonMethods.WaitAndFindElement(userName);
            CommonMethods.HighlightElement(element);
            element.SendKeys(value);
                      
        }

        public void EnterPassword(string value)
        {
            IWebElement element = CommonMethods.WaitAndFindElement(password);
            CommonMethods.HighlightElement(element);
            element.SendKeys(value);
        }

        public void ClickSignInButton()
        {
            IWebElement element = CommonMethods.WaitAndFindElement(signInButton);
            CommonMethods.HighlightElement(element);
            element.Click();

        }
       

    }
}
