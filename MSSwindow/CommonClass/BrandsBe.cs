using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MSSwindow.Connection;
using System.Data.SqlClient;

namespace MSSwindow
{
    class BrandsBe
    {
        public int Shopid { get; set; }
        public int BrandID { get; set; }
        public int CategoryBrandID { get; set; }
        public string BrandName { get; set; }
        public string Description { get; set; }
        public int IsActive { get; set; }
    }
}
