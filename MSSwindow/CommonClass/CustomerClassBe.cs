using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSSwindow.CommonClass
{
    public class CustomerClassBe
    {
        public int CustomerType;

        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public int Gender { get; set; }

        // Billing Address
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string StateCode { get; set; }
        public string Country { get; set; }
        public string Pincode { get; set; }

        public string Emailid { get; set; }
        public string Contact { get; set; }
        public string AltContact { get; set; }
        public string Descriptions { get; set; }
        public DateTime Birthdate { get; set; }
        public DateTime Aniversarydate { get; set; }
        public int IsActive { get; set; }
        public int ShopID { get; set; }
        public int MaritalStatus { get; set; }

        // Shipping Address
        public string ShippingAddress { get; set; }
        public string ShippingCity { get; set; }
        public string ShippingState { get; set; }
        public string ShippingStateCode { get; set; }
        public string ShippingCountry { get; set; }
        public string ShippingPincode { get; set; }
        public bool SameAsBilling { get; set; }
        public int ZoneID { get; set; }
        public string GSTIN { get; set; }
        public DateTime? ScheduleDate { get; set; }

    }
    public class EMI
    {
        public int shopid { get; set; }
        public int? emiid { get; set; }
        public int invoiceid { get; set; }
        public double TotalAmount { get; set; }
        public double DownPayment { get; set; }
        public double RemaingAmount { get; set; }
        public int Noemi { get; set; }
        public int Emiduration { get; set; }
        public DateTime dateofemi { get; set; }
        public int RateofInterest { get; set; }
        public bool EnableReminder { get; set; }
        public int ReminderBeforeDays { get; set; }
    }
    public class CustomerComplaint
    {
        public int SeqNo { get; set; }
        public int CompID { get; set; }
        public string ComplaintID { get; set; }
        public DateTime ComplaintDate { get; set; }
        public int CustomerID { get; set; }
        public int StatusID { get; set; }
        public int EmpID { get; set; }
        public DateTime VisitDate { get; set; }
        public DateTime CloseDate { get; set; }
        public int ShopID { get; set; }
        public string Remark { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerContact { get; set; }
        public bool IsNewCustomer { get; set; }
        public int ResolutionStatusID { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public int SubmittedBY { get; set; }
        public String ReferenceNo { get; set; }
        public int ComplaintLogType { get; set; }
        public DateTime ActualServiceDate { get; set; }
        public DateTime ServiceDate { get; set; }

        public bool PayStatus { get; set; }
        public int PrevDue { get; set; }

        public int PaidAmt { get; set; }
        public int BalAmt { get; set; }

        public int CurrentCharge { get; set; }
        public int ZoneID { get; set; }
        public String PModelNo { get; set; }
        public DateTime WEXPDate { get; set; }
        public int WExpStatus { get; set; }
        public String AltContact { get; set; }
        public int CategoryID { get; set; }
        public int NextCategoryID { get; set; }
    }

    public class Rent
    {
        public int? rentid { get; set; }

        public String @Invoiceid { get; set; }

        public int productid { get; set; }

        public int customerid { get; set; }

        public DateTime rentstartdate { get; set; }

        public DateTime rentenddate { get; set; }

        public int? securityAmount { get; set; }

        public int Daliyrentamount { get; set; }

        public int Monthlyrentamount { get; set; }

        public int Yearlyrentamount { get; set; }

        public int? penaltycharge { get; set; }

        public int? bouncecharge { get; set; }

        public int? policy { get; set; }

        public DateTime? servicestartdate { get; set; }

        public int remserday { get; set; }

        public int noofser { get; set; }

        public int remrentday { get; set; }

        public int rentcoldays { get; set; }

        public Boolean isactive { get; set; }

        public int Price { get; set; }

        public int Qty { get; set; }

        public int ShopID { get; set; }

    }
    public class OwnerFeedBack
    {

        public int? FBID { get; set; }
        public int CompID { get; set; }
        public string Remark { get; set; }
        public bool NextServiceReminder { get; set; }
        public DateTime NextSerDate { get; set; }
        public int EMP_BehaviourRating { get; set; }
        public int ServiceQualityRating { get; set; }
        public int Charges_iwow { get; set; }
    }

    public class NotifyEmployee
    {

        public int? NotID { get; set; }
        public int CompID { get; set; }
        public string Details { get; set; }
    }
}
