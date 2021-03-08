using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSSwindow
{
    class EnquiryClassbe
    {
        public int shopid { get; set; }
        public int Enquiryid { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public int Gender { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public DateTime Date { get; set; }
        public string Occupation { get; set; }
        public string Address { get; set; }

    }


    class Enquriryclsbe
    {
        public int Shopid { get; set; }
        public int Enquiryid { get; set; }
        public string Enquiryno { get; set; }
        public DateTime Enqurirydate { get; set; }
        public int Types { get; set; }       
        public int Customerid { get; set; }
        public int Category { get; set; }
        public int Product{ get; set; }        
        public DateTime Vistitdate { get; set; }
        public DateTime Visittime { get; set; }
        public int Source { get; set; }
        public int CallBy { get; set; }
        public string CallNumber { get; set; }
        public DateTime NextFollowupdate { get; set; }
        public string Followupremarks { get; set; }
        public string Followuplastremarks { get; set; }
        public int SubmitedBy { get; set; }       
        public string Referenceno { get; set; }       
        public int EnqStatus { get; set; }
       
    }
}
