using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSSwindow.CommonClass
{
    class PurchaseBe
    {
        public int Shopid { get; set; }
        public string PONO { get; set; }
        public int SupID { get; set; }
        public string BookNO { get; set; }
        public DateTime PODate { get; set; }
        public int Sno { get; set; }
        public string Barcode { get; set; }
        public int dbid { get; set; }
        public int Categoryid { get; set; }
        public int Brandid { get; set; }
        public int Productid { get; set; }
        public int UnitID  { get; set; }
        public string HSNCode { get; set; }
        public string ModelNo { get; set; }
        public string ItemSrNo { get; set; }
        public decimal BasePrice { get; set; }
        public decimal price { get; set; }
        public int qty { get; set; }
        public decimal disc { get; set; }
        public decimal amount { get; set; }
        public int Mode { get; set; }
        public string Remark { get; set; }
        public bool IsTaxIncluded { get; set; }
      
        public string Bankname { get; set; }
        public string Accountno { get; set; }
        public string IfscCode { get; set; }
        public string Vechicleno { get; set; }
        public bool IsWaranty { get; set; }
        public int WarDuration { get; set; }
        public DateTime ExpDate { get; set; }

        public bool SCGST { get; set; }
        public bool IGST { get; set; }

        public decimal CGSTPer { get; set; }
        public decimal SGSTPer { get; set; }
        public decimal IGSTPer { get; set; }
        public decimal CGSTVal { get; set; }
        public decimal SGSTVal { get; set; }
        public decimal IGSTVal { get; set; }
        public decimal NetTax { get; set; }
        public decimal NetAmt { get; set; }

        public string RefBy { get; set; }
        public int DelMode { get; set; }
        public string DeliverBy { get; set; }
        public decimal? PaidAmt { get; set; }
        public decimal? BalAmt { get; set; }
        public bool? PayStatus { get; set; }
        public bool IsDelivered { get; set; }
        public DateTime? ExpDelDate { get; set; }
        public string DiscType { get; set; }


    }
    class TaxBe
    {
        public int TaxID { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal TaxRate { get; set; }
        public string TaxOption { get; set; }
        public string TaxName { get; set; }
    
    }

    class ScheduleBE
    {
        public int AMCID { get; set; }
        public DateTime AMCDate { get; set; }
        public bool Status { get; set; }
        public bool IgnoreStatus { get; set; }
        public string Remark { get; set; }
       

    }
}
