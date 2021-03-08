using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSSwindow.CommonClass
{
    class ProductClassBe
    {
        public int Shopid { get; set; }
        public int ProductID { get; set; }
        public int CategoryPID { get; set; }
        public int BrandPID { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public int Unit { get; set; }
        public string Barcode { get; set; }
        public double Price { get; set; }
        public string HSNCode { get; set; }
        public string ModelNo { get; set; }
        public string Description { get; set; }
        public int IsActive { get; set; }
        public string ImageName { get; set; }

        public double CGST { get; set; }
        public double SGST { get; set; }
        public double IGST { get; set; }
    }
    class StockBE
    {
        public int? StockID;
        public DateTime StockDate;
        public string StockRef;
        public int SupplierID;
        public int ReceivedBy;
        public int ShopID;
        public DataTable ItemDetail = new DataTable();

    }
}
