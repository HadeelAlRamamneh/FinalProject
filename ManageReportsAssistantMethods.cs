using Bytescout.Spreadsheet;
using FinalProjectAutomation.Data;
using FinalProjectAutomation.Helpers;
using FinalProjectAutomation.POM;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectAutomation.AssistantMethods
{
    public class ManageReportsAssistantMethods
    {

        public static void SelectBiller(int i)
        {
            ManageReportPage manageReportPage = new ManageReportPage(ManageDriver.driver);
            manageReportPage.ClickBillerCategoryNam();

            try
            {

                if (i == 1)
                {
                    manageReportPage.ClickOptionAllData();

                    Console.WriteLine("The elementes containing Category name are displayed.");
                    Thread.Sleep(3000);
                }
                else if (i == 2)
                {
                    manageReportPage.ClickOptionWater();

                    Thread.Sleep(3000);

                }
                else if (i == 3)
                {
                    manageReportPage.ClickOptionElectricity();

                    Thread.Sleep(3000);

                }
                else if (i == 4)
                {
                    manageReportPage.ClickOptionTelecommunication();

                    Thread.Sleep(3000);
                }
                else if (i == 5)
                {

                    manageReportPage.ClickOptionEducation();

                    Thread.Sleep(3000);
                }



            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);

            }

        }


        public static int GetPaymentCount(int billerId)
        {
            int paymentCount = 0;
            string query = "select count(billerid) from paymenthistory where billerid = :billerId";

            using (OracleConnection connection = new OracleConnection(GlobalConstants.connectionString))
            {
                connection.Open();

                OracleCommand command = new OracleCommand(query, connection);


                command.Parameters.Add(new OracleParameter(":billerId", billerId));


                paymentCount = Convert.ToInt32(command.ExecuteScalar());
            }
            return paymentCount;
        }

        public static decimal GetSumProfit(int billerId)
        {
            decimal totalProfit = 0;
            string query = "select sum(profits) from paymenthistory where billerid = :billerId";

            using (OracleConnection connection = new OracleConnection(GlobalConstants.connectionString))
            {
                connection.Open();

                OracleCommand command = new OracleCommand(query, connection);

                command.Parameters.Add(new OracleParameter(":billerId", billerId));

                object result = command.ExecuteScalar();

                if (result != DBNull.Value)
                {
                    totalProfit = Convert.ToDecimal(result);
                }
            }
            return totalProfit;
        }

        public static void AddDate(ManageReportsData manageReportsData)
        {
            ManageReportPage manageReportPage = new ManageReportPage(ManageDriver.driver);
            manageReportPage.EnterDteFrom(manageReportsData.dteFrom);
            manageReportPage.EnterDteTo(manageReportsData.dteTo);

        }
        public static ManageReportsData ReadDataFromExcel(int row)
        {
            ManageReportsData manageReportsData = new ManageReportsData();

            Worksheet worksheet = CommonMethods.ReadBillDataExcel("Reports");
            manageReportsData.dteFrom = worksheet.Cell(row, 2).Value?.ToString() ?? string.Empty;

            manageReportsData.dteTo = worksheet.Cell(row, 3).Value?.ToString() ?? string.Empty;

            return manageReportsData;



        }

        public static String GetCategoryName(int billerId)
        {
            String categoryName = "";
            string query = "SELECT  DISTINCT  bc.BILLERCATEGORYNAME FROM paymenthistory b JOIN billercategory bc ON b.billerid = bc.BILLERCATEGORYID WHERE b.billerid= :billerId";

            using (OracleConnection connection = new OracleConnection(GlobalConstants.connectionString))
            {
                connection.Open();

                OracleCommand command = new OracleCommand(query, connection);


                command.Parameters.Add(new OracleParameter(":billerId", billerId));


                categoryName = Convert.ToString(command.ExecuteScalar());
            }
            return categoryName;
        }

        public static int GetPaymentCountUsingDate(int billerId, ManageReportsData manageReportsData)
        {
            int paymentCount = 0;

            string query = "SELECT COUNT(paymentdate) FROM paymenthistory WHERE billerid = :billerId AND paymentdate BETWEEN TO_DATE(:dateFrom, 'MM-DD-YYYY') AND TO_DATE(:dateTo, 'MM-DD-YYYY')";

            using (OracleConnection connection = new OracleConnection(GlobalConstants.connectionString))
            {
                connection.Open();

                OracleCommand command = new OracleCommand(query, connection);

                // Parsing dates from ManageReportsData
                DateTime dateFrom = DateTime.Parse(manageReportsData.dteFrom);
                DateTime dateTo = DateTime.Parse(manageReportsData.dteTo);

                // Formatting dates as "MM-DD-YYYY" to match Oracle's TO_DATE format
                string formattedDateFrom = dateFrom.ToString("MM-dd-yyyy");
                string formattedDateTo = dateTo.ToString("MM-dd-yyyy");

                // Adding parameters for the query
                command.Parameters.Add(new OracleParameter(":billerId", billerId));
                command.Parameters.Add(new OracleParameter(":dateFrom", formattedDateFrom));
                command.Parameters.Add(new OracleParameter(":dateTo", formattedDateTo));

                paymentCount = Convert.ToInt32(command.ExecuteScalar());
            }
            return paymentCount;
        }



        public static decimal GetSumProfitUsingDate(int billerId, ManageReportsData manageReportsData)
        {
            decimal totalProfit = 0;
            string query = "SELECT SUM(profits) FROM paymenthistory WHERE billerid = :billerId AND paymentdate BETWEEN TO_DATE(:dateFrom, 'MM-DD-YYYY') AND TO_DATE(:dateTo, 'MM-DD-YYYY')";

            using (OracleConnection connection = new OracleConnection(GlobalConstants.connectionString))
            {
                connection.Open();

                OracleCommand command = new OracleCommand(query, connection);

                // Parsing and formatting the dates
                DateTime dateFrom = DateTime.Parse(manageReportsData.dteFrom);
                DateTime dateTo = DateTime.Parse(manageReportsData.dteTo);
                string formattedDateFrom = dateFrom.ToString("MM-dd-yyyy");
                string formattedDateTo = dateTo.ToString("MM-dd-yyyy");

                // Adding parameters to the command
                command.Parameters.Add(new OracleParameter(":billerId", billerId));
                command.Parameters.Add(new OracleParameter(":dateFrom", formattedDateFrom));
                command.Parameters.Add(new OracleParameter(":dateTo", formattedDateTo));

                // Executing the query and handling the result
                object result = command.ExecuteScalar();

                if (result != DBNull.Value)
                {
                    totalProfit = Convert.ToDecimal(result);
                }
            }
            return totalProfit;
        }


        //public static string GetDate(int billerId, ManageReportsData manageReportsData)
        //{
        //    string paymentDate = "";

        //    // Use parameter placeholders without colons in the SQL string
        //    string query = @"SELECT DISTINCT paymentdate 
        //             FROM paymenthistory 
        //             WHERE billerid = :billerId  
        //             AND paymentdate IN (TO_DATE(:dteFrom, 'YYYY-MM-DD'), TO_DATE(:dteTo, 'YYYY-MM-DD'))";

        //    using (OracleConnection connection = new OracleConnection(GlobalConstants.connectionString))
        //    {
        //        connection.Open();

        //        using (OracleCommand command = new OracleCommand(query, connection))
        //        {
        //            // Add parameters correctly
        //            command.Parameters.Add(new OracleParameter(":billerId", billerId));
        //            command.Parameters.Add(new OracleParameter(":dteFrom", manageReportsData.dteFrom));
        //            command.Parameters.Add(new OracleParameter(":dteTo", manageReportsData.dteTo));

        //            // Execute and retrieve the payment date
        //            paymentDate = Convert.ToString(command.ExecuteScalar());
        //        }
        //    }
        //    return paymentDate;
        //}

        public static void SelectButtonAndValidateElements(ManageReportPage manageReportPage, int index)
        {
            switch (index)
            {
                case 1:
                    manageReportPage.ClickButtonOne();
                    break;
                case 2:
                    manageReportPage.ClickButtonTow();
                    break;
                case 3:
                    manageReportPage.ClickButtonThree();
                    break;
                case 4:
                    manageReportPage.ClickButtonFour();
                    break;
                default:
                    throw new ArgumentException("Invalid index for button selection");
            }


        }
    
     
        public static class DropdownHelper
        {
       
        public static string GetSelectedTextFromDropdown(IWebDriver driver, By dropdownLocator)
        {
            SelectElement dropdown = new SelectElement(driver.FindElement(dropdownLocator));
            return dropdown.SelectedOption.Text;  // Get the text of the selected option
        }

        // Method to get the text from a table row
        public static string GetTextFromTableRow(IWebDriver driver, By tableRowLocator)
        {
            IWebElement tableRow = driver.FindElement(tableRowLocator);
            return tableRow.Text;  // Get the text of the table row
        }
    }









}
}
