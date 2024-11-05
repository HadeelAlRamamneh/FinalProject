using Bytescout.Spreadsheet;
using FinalProjectAutomation.Data;
using FinalProjectAutomation.Helpers;
using FinalProjectAutomation.POM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectAutomation.AssistantMethods
{
    public class LoginAssistantMethods
    {

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
            loginData.userName = worksheet.Cell(row, 2).Value?.ToString()??string.Empty;
            loginData.password=worksheet.Cell(row,3).Value?.ToString()??string.Empty;
            return loginData;

        }
    }
}
