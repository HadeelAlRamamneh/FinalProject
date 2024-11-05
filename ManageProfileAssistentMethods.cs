using Bytescout.Spreadsheet;
using FinalProjectAutomation.Data;
using FinalProjectAutomation.Helpers;
using FinalProjectAutomation.POM;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FinalProjectAutomation.AssistantMethods
{
    public class ManageProfileAssistentMethods
    {
        public static void FillLprofilForm(ManageProfileData manageProfileData)
        {
            ManageProfilePage manageProfilePage = new ManageProfilePage(ManageDriver.driver);
            manageProfilePage.EnterFullName(manageProfileData.fullName);
            manageProfilePage.EnterPhoneNumber(manageProfileData.phoneNumber);
            manageProfilePage.EnterEmail(manageProfileData.email);
            manageProfilePage.EnterCurentPassword(manageProfileData.curentPassword);
            manageProfilePage.EnterAddress(manageProfileData.address);
            manageProfilePage.EnterUserName(manageProfileData.userName);
            manageProfilePage.ClickUpdateButton();
            Thread.Sleep(1000);

        }
        public static ManageProfileData ReadDataFromExcel(int row)
        {
            ManageProfileData manageProfileData = new ManageProfileData();

            Worksheet worksheet = CommonMethods.ReadBillDataExcel("EditProfile");
            manageProfileData.fullName = worksheet.Cell(row, 2).Value?.ToString() ?? string.Empty;
            
            manageProfileData.phoneNumber = worksheet.Cell(row, 3).Value?.ToString() ?? string.Empty;
            manageProfileData.email = worksheet.Cell(row, 4).Value?.ToString() ?? string.Empty;
            manageProfileData.curentPassword = worksheet.Cell(row, 5).Value?.ToString() ?? string.Empty;
            manageProfileData.address = worksheet.Cell(row, 6).Value?.ToString() ?? string.Empty;
            manageProfileData.userName =ManageProfileAssistentMethods.GetCleanGuid()+ worksheet.Cell(row, 7).Value?.ToString() ?? string.Empty;
            return manageProfileData;

            

        }
        public static string GetCleanGuid()
        {

            //string guid = Guid.NewGuid().ToString();
            Guid guid = Guid.NewGuid();
            string shortGuid = guid.ToString().Substring(0, 5);

            string cleanGuid = Regex.Replace(shortGuid, @"[^a-zA-Z0-9]", "");

            return cleanGuid;
        }
        public static bool CheckSuccessAddBill(string userName)
        {

            bool isDataExist = false;
            string query = "select count(*) from loginf where username= :value";

            using (OracleConnection connection = new OracleConnection(GlobalConstants.connectionString))
            {
                connection.Open();


                OracleCommand command = new OracleCommand(query, connection);


                command.Parameters.Add(new OracleParameter(":value", userName ));


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
