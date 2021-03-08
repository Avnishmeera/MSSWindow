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
    public partial class FutureSMSHistory : Form
    {
        int UniqueShopID = 0;
        string CustomerContact = string.Empty;
        public FutureSMSHistory( int ShopID,string ContactNo)
        {
            InitializeComponent();
            UniqueShopID = ShopID;
            CustomerContact = ContactNo;

        }

        private void FutureSMSHistory_Load(object sender, EventArgs e)
        {
            DateTime NotDate = dateTimePicker1.Value.Date; 
            BindSMSDetails(NotDate,CustomerContact,UniqueShopID);
        }


        private void BindSMSDetails(DateTime Date,string ContactNo,int ShopID)
        {
            CustomerClass be = new CustomerClass();
            DataTable Dt = new DataTable();
            Dt = be.BindCustomerNotification(Date, ContactNo, ShopID);
            dataGridView1.DataSource = Dt;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                if (MessageBox.Show("Do You Want To Delete SMS", "MSS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    CustomerClass be = new CustomerClass();
                    int I =  be.DeleteNotification(Convert.ToInt32(dataGridView1.CurrentRow.Cells["ID"].Value));
                    if (I > 0)
                    {
                        MessageBox.Show(this, "SMS Deleted Successfully.", "Customer Complaint", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DateTime NotDate = dateTimePicker1.Value.Date;
                        BindSMSDetails(NotDate, CustomerContact, UniqueShopID);
                    }

                }
                   
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime NotDate = dateTimePicker1.Value.Date;
            BindSMSDetails(NotDate, CustomerContact, UniqueShopID);
        }
    }
}
