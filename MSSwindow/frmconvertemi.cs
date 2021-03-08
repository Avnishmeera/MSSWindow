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

namespace MSSwindow
{
    public partial class frmconvertemi : Form
    {
       
        readonly int? OrdID = 0;
        DataTable dtchargedetail = new DataTable();
        int uniqueShopid = 0;
        RetailSaleDetails sld = null;

        public frmconvertemi()
        {
            InitializeComponent();
        }

        int emi_id;
        public frmconvertemi(int OrderID, string InvoiceNo, int Shopid, double AmtToReceive,RetailSaleDetails rsd)
        {
            InitializeComponent();
            OrdID = OrderID;


            txtinvoiceno.Text = InvoiceNo;
            txttotalAmt.Text =AmtToReceive.ToString();            
            uniqueShopid = Shopid;
            sld = rsd;

           
            
        }

        
       
        private void txtdownPayment_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            
        }

        private void txtdownPayment_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            CustomerClass cls = new CustomerClass();
            EMI emobject = new EMI();
            DataSet ds = new DataSet();
            emobject.shopid = uniqueShopid;          
            emobject.emiid = 0; 
            emobject.invoiceid = Convert.ToInt32(OrdID);
            emobject.TotalAmount = Convert.ToInt32(txttotalAmt.Text);
            emobject.DownPayment = 0;
            emobject.RemaingAmount = 0;
            emobject.Noemi = Convert.ToInt32(txtnumemi.Value);
            emobject.Emiduration = Convert.ToInt32(txtemiduration.Value); 
            emobject.dateofemi = dtdateofemi.Value;
            emobject.RateofInterest = 0;
            emobject.EnableReminder = Convert.ToBoolean(ChkEmiRemider.Checked);
            emobject.ReminderBeforeDays = Convert.ToInt32(numericReminderDays.Value);
            ds = cls.InsertEmiDetails(emobject);
            if (ds.Tables.Count > 0)
            {
                MessageBox.Show("Emi Converted Sucessfully!..");
               BindEmiDetails(Convert.ToInt32(OrdID));
            }           
        }

        private void BindEmiDetails(int Invocieid)
        {
            CustomerClass cls = new CustomerClass();
            EMI emobject = new EMI();
            DataSet ds = new DataSet();
            ds = cls.BindEmiDetails(Invocieid);
            if (ds.Tables.Count > 0)
            {
                dataGridViewEMI.DataSource = ds.Tables[0];
            }
            else
            {
                ds = null;
                dataGridViewEMI.DataSource = ds.Tables[0];
            }
        }

        private void frmconvertemi_Load(object sender, EventArgs e)
        {
            BindEmiDetails(Convert.ToInt32(OrdID));
        }

      

        private void dataGridViewEMI_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 6)
            {
                string InvoiceNo = string.Empty;
                int Emidetid = 0;
                int Invid = 0;
                int Amount = 0;
                Emidetid = Convert.ToInt32(dataGridViewEMI.CurrentRow.Cells[0].Value.ToString());
                Invid =Convert.ToInt32(OrdID);
                InvoiceNo = txtinvoiceno.Text;
                Amount = Convert.ToInt32(dataGridViewEMI.CurrentRow.Cells[3].Value.ToString());
                string Paid = "Paid";
                if (Convert.ToString(dataGridViewEMI.CurrentRow.Cells[4].Value)==Paid)
                {
                    MessageBox.Show("Your emi already paid");
                }
                else
                {
                    ReceivedEmiPayment rsp = new ReceivedEmiPayment(Emidetid, Invid, Amount, InvoiceNo, null);
                    rsp.ShowDialog();
                }
               
                // ReceivedEmiPayment rsp = new ReceivedEmiPayment(detailid,GenID,Amount,pono);
                // rsp.ShowDialog();
                // RetailSaleDetails sd = new RetailSaleDetails(true, Shopid, pono, GenID);
                //  sd.ShowDialog();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmconvertemi_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (sld!=null)
            {
                sld.BindPaymentDetails();
            }
        }

        private void dataGridViewEMI_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //int Amount = 0;          
           // Amount = Convert.ToInt32(dataGridViewEMI.CurrentRow.Cells[3].Value.ToString());
            //if (dataGridViewEMI.CurrentRow.Cells["paid"].Value == "paid")
            //{
            //    dataGridViewEMI.CurrentRow.ReadOnly = true;
            //}
            //else
            //{
            //    dataGridViewEMI.CurrentRow.ReadOnly = false;
            //}
            //if (e.ColumnIndex == 6)
            //{
                
            //    string t = e.Value.ToString();
            //    DataGridViewButtonCell cl = (DataGridViewButtonCell)dataGridViewEMI.Rows[e.RowIndex].Cells[e.ColumnIndex];
            //    cl.ReadOnly = true;
                
            
            //}
            //dataGridViewEMI.Rows[0].Cells["Butt"].Visible = true;
            //dataGridViewEMI.Rows(e.RowIndex).Cells(6).Visible = True;

            //int n = Convert.ToInt32(dataGridViewEMI.Rows.Count.ToString());
            //for (int i = 0; i < n; i++)
            //{
            //   // dataGridViewEMI.Rows[i].Cells["ButtonText"].ReadOnly = false;
            //    dataGridViewEMI.Rows[i].Cells["ButtonText"].ReadOnly = Enabled;
            //}
           

           // BindEmiDetails(Convert.ToInt32(OrdID));
        }
    }
}
