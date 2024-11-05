using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectAutomation.Data
{
    public class ManageProfileData
    {


        public ManageProfileData() { }

        public ManageProfileData(string fullName, string phoneNumber, string email, string curentPassword, string address, string userName)
        {
            this.fullName = fullName;
            this.phoneNumber = phoneNumber;
            this.email = email;
            this.curentPassword = curentPassword;
            this.address = address;
            this.userName = userName;
        }

        public string fullName {  get; set; }
        public string phoneNumber { get; set; }
        public string email {  get; set; }
        public string curentPassword { get; set; }
        public string address { get; set; }
        public string userName { get; set; }
    }
}
