using Bytescout.Spreadsheet;
using FinalProjectAutomation.Data;
using FinalProjectAutomation.Helpers;
using FinalProjectAutomation.POM;
using OpenQA.Selenium;
using Oracle.ManagedDataAccess.Client;
using System.Text.RegularExpressions;

namespace FinalProjectAutomation.AssistantMethods
{
    public class ManageCategoryAssistantMethods
    {
        //public static void AddRandomBill()
        //{
        //    ManageCategoryPage manageCategoryPage = new ManageCategoryPage(ManageDriver.driver);
        //    List<IWebElement> TableRows = ManageDriver.driver.FindElements(By.XPath("//table//tbody")).ToList();
        //    if (TableRows.Count > 0)
        //    {
        //        Random rand = new Random();
        //        int randomCategoryIndex = rand.Next(manageCategoryPage.CreateButtons.Count);
        //        IWebElement selectedButton = manageCategoryPage.CreateButtons[randomCategoryIndex];
        //        CommonMethods.HighlightElement(selectedButton);
        //        selectedButton.Click();

        //        Console.WriteLine("Bill added successfully to a random category.");
        //    }
        //    else
        //    {
        //        Console.WriteLine("Not all four categories are available.");
        //    }


        //}

        private static int randomCategoryIndex;

        public static void AddRandomBill()
        {
            ManageCategoryPage manageCategoryPage = new ManageCategoryPage(ManageDriver.driver);
            List<IWebElement> TableRows = ManageDriver.driver.FindElements(By.XPath("//table//tbody")).ToList();
            if (TableRows.Count > 0)
            {
                Random rand = new Random();
                randomCategoryIndex = rand.Next(manageCategoryPage.CreateButtons.Count); // Store the random index
                IWebElement selectedButton = manageCategoryPage.CreateButtons[randomCategoryIndex];
                CommonMethods.HighlightElement(selectedButton);
                selectedButton.Click();

                Console.WriteLine("Bill added successfully to a random category.");
            }
            else
            {
                Console.WriteLine("Not all four categories are available.");
            }
        }

        public static void ShowCreateBill()
        {
            ManageCategoryPage manageCategoryPage = new ManageCategoryPage(ManageDriver.driver);
            IWebElement selectedButton = manageCategoryPage.ShowButton[randomCategoryIndex];
            CommonMethods.HighlightElement(selectedButton);
            selectedButton.Click();
        }



        public static void FillLBillForm(ManageCategoryData manageCategoryData)
        {
            ManageCategoryPage manageCategoryPage = new ManageCategoryPage(ManageDriver.driver);
            manageCategoryPage.EnterBillName(manageCategoryData.billerName);
            manageCategoryPage.EnterEmail(manageCategoryData.email);
            manageCategoryPage.EnterAddress(manageCategoryData.address);
            Thread.Sleep(1000);
            manageCategoryPage.ClickCreateButtonSubmit();

           

        }
        public static ManageCategoryData ReadDataFromExcel(int row)
        {
            ManageCategoryData manageCategoryData = new ManageCategoryData();

            Worksheet worksheet = CommonMethods.ReadBillDataExcel("ManageCategory");
            manageCategoryData.billerName = worksheet.Cell(row, 2).Value?.ToString() ?? string.Empty;
            manageCategoryData.email = ManageCategoryAssistantMethods.GetCleanGuid() + worksheet.Cell(row, 3).Value?.ToString() ?? string.Empty;
            manageCategoryData.address = worksheet.Cell(row, 4).Value?.ToString() ?? string.Empty;
            return manageCategoryData;

        }
        public static string GetCleanGuid()
        {

            //string guid = Guid.NewGuid().ToString();
            Guid guid = Guid.NewGuid();
            string shortGuid = guid.ToString().Substring(0, 6);

            string cleanGuid = Regex.Replace(shortGuid, @"[^a-zA-Z0-9]", "");

            return cleanGuid;
        }
        public static bool CheckSuccessAddBill(string email)
        {

            bool isDataExist = false;
            string query = "select count(*) from billername where email = :value";

            using (OracleConnection connection = new OracleConnection(GlobalConstants.connectionString))
            {
                connection.Open();


                OracleCommand command = new OracleCommand(query, connection);


                command.Parameters.Add(new OracleParameter(":value", email));


                int result = Convert.ToInt32(command.ExecuteScalar());

                if (result > 0)
                {
                    isDataExist = true;

                }
                else if (result <= 0)
                {
                    isDataExist = false;

                }
                //isDataExist = result > 0;
                Console.WriteLine(isDataExist);
                ;
                return isDataExist;

                //return isDataExist;

            }
        }

    }

    
}
