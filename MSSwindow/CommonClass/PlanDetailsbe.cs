using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSSwindow.CommonClass
{
    class PlanDetailsbe
    {
        public int Shopid { get; set; }
        public int Planid { get; set; }
        public string Planname { get; set; }
        public string PlanDetails { get; set; }
        public int Days { get; set; }
        public string Price { get; set; }
        public string Remarks { get; set; }       
        public string IsActive { get; set; }
        public string IsDelete { get; set; }
    }
}
