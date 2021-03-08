using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSSwindow.CommonClass
{
    class CategoryclassBe : ItemMasterBe
    {
        public int Shopid { get; set; }
        public int Categoryid { get; set; }
        public string Categoryname { get; set; }
        public string Description { get; set; }
        public string FDS1 { get; set; }
        public string FDS2 { get; set; }
        public string FDS3 { get; set; }
        public string FDS4 { get; set; }
        public string FDS5 { get; set; }
        public int IsActive { get; set; }
        public int StatusID { get; set; }
        public string StatusDescription { get; set; }
        public int  TimeDuration { get; set; }
       
       
    }



    class ItemMasterBe
    {
        public int Shopid { get; set; }
        public int Itemid { get; set; }
        public string Itemname { get; set; }
        public string Charge { get; set; }
        public int IsActive { get; set; }

    }
}
