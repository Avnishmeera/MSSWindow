using MSSwindow.CommonClass;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MSSEntityFrame;


namespace MSSwindow
{
    public partial class ReceivedEmiPayment : Form
    {
        public ReceivedEmiPayment()
        {
            InitializeComponent();
        }

        readonly int? Invoiceid = 0;
        readonly int? Emidetailid = 0;

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public ReceivedEmiPayment(int Emidetail_id,int Invoice_id,int Amount,string Cmpno,RetailSaleDetails sld)
        {
            InitializeComponent();
            Emidetailid = Emidetail_id;
            Invoiceid = Invoice_id;
            TxtRecAmt.Text = Amount.ToString();
            TxtComplaintNo.Text = Cmpno;
            rsp = sld;
        }

    
        RetailSaleDetails rsp=null;
       

        private void BindItemMasterDetails()
        {
            List<PaymentModeBe> paym = new List<PaymentModeBe>();
            Purchase p = new Purchase();
            paym = p.GetPaymentMode();
            ddlItemName.DataSource = paym;
            ddlItemName.DisplayMember = "Mode";
            ddlItemName.ValueMember = "ID";
        }

        

        private void btnsave_Click(object sender, EventArgs e)
        {
            if (TxtRef.Text == string.Empty)
                {
                    MessageBox.Show(this, "Please Enter Remarks", "MSS", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    return;
                }
                CustomerClass cms = new CustomerClass();
                int i = 0;
                    i = cms.InsertEmiPayment(Emidetailid,Invoiceid,Convert.ToInt32(ddlItemName.SelectedValue),TxtRef.Text);
                if (i > 0)
                {
                    MessageBox.Show(this, "Emi Paid Successfully.", "Received Emi Payment", MessageBoxButtons.OK, MessageBoxIcon.Information);
                      
                    TxtRef.Text = string.Empty;
                    this.Close();
                }
            }

        private void ReceivedEmiPayment_Load(object sender, EventArgs e)
        {
            BindItemMasterDetails();
        }
        }

        }
    

