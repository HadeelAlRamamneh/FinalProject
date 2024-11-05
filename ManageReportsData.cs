using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectAutomation.Data
{
    public class ManageReportsData
    {
        public ManageReportsData() { }

        public ManageReportsData(string dteFrom, string dteTo)
        {
            this.dteFrom = dteFrom;
            this.dteTo = dteTo;
        }

        public string dteFrom {  get; set; }
        public string dteTo { get; set;}
    }
}
