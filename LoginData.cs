﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectAutomation.Data
{
    public class LoginData
    {
        public LoginData()
        {

        }

        public LoginData(string userName, string password)
        {
            this.userName = userName;
            this.password = password;
        }

        public string userName { get; set; }
        public string password { get; set; }

       

        
    }
}
