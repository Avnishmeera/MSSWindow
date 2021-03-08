using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSSwindow.CommonClass
{
    class LedgerBE
    {
        public int TranID { get; set; }
        public int Shopid { get; set; }
        public string LedgerNO { get; set; }
        public int PayType { get; set; }
        public DateTime PayDt { get; set; }

        public int CustID { get; set; }
        public int SupID { get; set; }
        public int EMPID { get; set; }
        public int Amt { get; set; }
        public string remark { get; set; }

    }
}
