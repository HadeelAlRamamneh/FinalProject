using FinalProjectAutomation.Helpers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectAutomation.POM
{
    public class ManageReportPage
    {
        IWebDriver _driver;
        public ManageReportPage(IWebDriver driver)
        {
            _driver = driver;
        }

        By billerCategoryNam = By.XPath("//select[@formcontrolname='Billercategoryname']");

        By optionAllData = By.XPath("//html/body/app-root/app-adminreport/div/div/div[1]/div/div/div/div/form/div[1]/select/option[1]");
        By optionWater = By.XPath("//select//option[@value='Water1']");
        By optionElectricity = By.XPath(" //select//option[@value='Electricity']");
        By optionTelecommunication = By.XPath("//select//option[@value='Telecommunication']");
        By optionEducation = By.XPath("//select//option[@value='Education']");


        By dateFrom = By.XPath("//form//div//input[@ng-reflect-name='DateFrom']");
        By dateTo = By.XPath("//form//div//input[@ng-reflect-name='DateTo']");
        By buttonOne = By.XPath("//tr[1]/td[4]/button");
        By buttonTow = By.XPath("//tr[1]/td[4]/button");
        By buttonThree = By.XPath("//tr[1]/td[4]/button");
        By buttonFour = By.XPath("//tr[1]/td[4]/button");

        public void ClickBillerCategoryNam()
        {
            IWebElement element = CommonMethods.WaitAndFindElement(billerCategoryNam);
            CommonMethods.HighlightElement(element);
            element.Click();

        }

        public void ClickOptionAllData()
        {
            IWebElement element = CommonMethods.WaitAndFindElement(optionAllData);
            CommonMethods.HighlightElement(element);
            element.Click();

        }
        public void ClickOptionWater()
        {
            IWebElement element = CommonMethods.WaitAndFindElement(optionWater);
            CommonMethods.HighlightElement(element);
            element.Click();

        }
        public void ClickOptionElectricity()
        {
            IWebElement element = CommonMethods.WaitAndFindElement(optionElectricity);
            CommonMethods.HighlightElement(element);
            element.Click();

        }
        public void ClickOptionTelecommunication()
        {
            IWebElement element = CommonMethods.WaitAndFindElement(optionTelecommunication);
            CommonMethods.HighlightElement(element);
            element.Click();

        }
        public void ClickOptionEducation()
        {
            IWebElement element = CommonMethods.WaitAndFindElement(optionEducation);
            CommonMethods.HighlightElement(element);
            element.Click();

        }

        public void EnterDteFrom(String value)
        {
            IWebElement element = CommonMethods.WaitAndFindElement(dateFrom);
            CommonMethods.HighlightElement(element);
            element.SendKeys(value);
           

        }
        public void EnterDteTo(String value)
        {
            IWebElement element = CommonMethods.WaitAndFindElement(dateTo);
            CommonMethods.HighlightElement(element);
            element.SendKeys(value);
            //IJavaScriptExecutor javaScriptExecutor = (IJavaScriptExecutor)ManageDriver.driver;
            //DateTime parseDate = DateTime.ParseExact(value, "dd-MM-yyyy", null);
            //string formatteDate = parseDate.ToString("yyyy-MM-dd");
            //javaScriptExecutor.ExecuteScript("arguments[0].value=arguments[1];", element, formatteDate);
            //Thread.Sleep(1000);
           
          
            //element.SendKeys(Keys.ArrowUp);
            //element.SendKeys(Keys.ArrowDown);
        }

        public void ClickButtonOne()
        {
            IWebElement element = CommonMethods.WaitAndFindElement(buttonOne);
            CommonMethods.HighlightElement(element);
            element.Click();

        }
        public void ClickButtonTow()
        {
            IWebElement element = CommonMethods.WaitAndFindElement(buttonTow);
            CommonMethods.HighlightElement(element);
            element.Click();

        }
        public void ClickButtonThree()
        {
            IWebElement element = CommonMethods.WaitAndFindElement(buttonThree);
            CommonMethods.HighlightElement(element);
            element.Click();

        }
        public void ClickButtonFour()
        {
            IWebElement element = CommonMethods.WaitAndFindElement(buttonFour);
            CommonMethods.HighlightElement(element);
            element.Click();

        }



    }
}
