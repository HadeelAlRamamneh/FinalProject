using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectAutomation.Data
{
    public class ManageCategoryData
    {

        public ManageCategoryData() { }

        public ManageCategoryData(string billerName, string email, string address)
        {
            this.billerName = billerName;
            this.email = email;
            this.address = address;
        }

        public string   billerName { get; set; }
        public string email { get; set; }
        public string address { get; set; }

    }
}
