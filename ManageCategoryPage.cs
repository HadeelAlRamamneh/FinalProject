using AventStack.ExtentReports;
using FinalProjectAutomation.Helpers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectAutomation.POM
{
    public class ManageCategoryPage
    {
        private IWebDriver _driver;


        public ManageCategoryPage(IWebDriver driver)
        {
            _driver = driver;
        }

       public List<IWebElement> CreateButtons = new List<IWebElement>
        {
            CommonMethods.WaitAndFindElement(By.XPath("/html/body/app-root/app-home/div/div/div/table/tbody[1]/tr/td[6]/button[1]")),
            CommonMethods.WaitAndFindElement(By.XPath("/html/body/app-root/app-home/div/div/div/table/tbody[2]/tr/td[6]/button[1]")),
            CommonMethods.WaitAndFindElement(By.XPath("/html/body/app-root/app-home/div/div/div/table/tbody[3]/tr/td[6]/button[1]")),
            CommonMethods.WaitAndFindElement(By.XPath("/html/body/app-root/app-home/div/div/div/table/tbody[4]/tr/td[6]/button[1]")),

        };

        public List<IWebElement> ShowButton = new List<IWebElement>
        {
            CommonMethods.WaitAndFindElement(By.XPath("/html/body/app-root/app-home/div/div/div/table/tbody[1]/tr/td[1]/button")),
            CommonMethods.WaitAndFindElement(By.XPath("/html/body/app-root/app-home/div/div/div/table/tbody[2]/tr/td[6]/button")),
            CommonMethods.WaitAndFindElement(By.XPath("/html/body/app-root/app-home/div/div/div/table/tbody[3]/tr/td[6]/button")),
            CommonMethods.WaitAndFindElement(By.XPath("/html/body/app-root/app-home/div/div/div/table/tbody[4]/tr/td[6]/button")),
        };


        By billerName = By.XPath("//input[@formcontrolname='Billname']");
        By email = By.XPath("//input[@formcontrolname='Email']");
        By address = By.XPath("//input[@formcontrolname='Location']");
        By createButtonSubmit = By.XPath("/html/body/div[2]/div[2]/div/mat-dialog-container/form/div/div/div[4]/button");

        public void EnterBillName(string value)
        {
            IWebElement element = CommonMethods.WaitAndFindElement(billerName);
            CommonMethods.HighlightElement(element);
            element.SendKeys(value);

        }
        public void EnterEmail(string value)
        {
            IWebElement element = CommonMethods.WaitAndFindElement(email);
            CommonMethods.HighlightElement(element);
            element.SendKeys(value);

        }
        public void EnterAddress(string value)
        {
            IWebElement element = CommonMethods.WaitAndFindElement(address);
            CommonMethods.HighlightElement(element);
            element.SendKeys(value);
        }

        public void ClickCreateButtonSubmit()
        {
            IWebElement element = CommonMethods.WaitAndFindElement(createButtonSubmit);
            CommonMethods.HighlightElement(element);
            element.Click();

        }
       
        

        

    }
}


    

