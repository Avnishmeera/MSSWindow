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
    public partial class NotifyCustomer : Form
    {
        int _CompID = 0;
        public NotifyCustomer(int CompID)
        {
            InitializeComponent();
            _CompID = CompID;
        }

        private void NotifyCustomer_Load(object sender, EventArgs e)
        {
            BindLog(_CompID);
        }

        private void BindLog(int CompID)
        {
            CustomerClass cls = new CustomerClass();
            DataTable dt = new DataTable();
            dt = cls.EmployeeNotificationLog(CompID);
            dataGridView1.DataSource = dt;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == string.Empty)
            {
                MessageBox.Show(this, "Enter Details Field.", "Notify Customer", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

           

            if (MessageBox.Show("Do You Want To Save the Details?", "Notify Customer", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                NotifyEmployee FB = new NotifyEmployee();
                FB.CompID = _CompID;
                FB.NotID = 0;
                FB.Details = textBox1.Text;
                CustomerClass cls = new CustomerClass();
                cls.NotifyEmployee(FB);
                MessageBox.Show(this, "Details Saved Successfully.", "Notify Customer", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BindLog(_CompID);
            }

        }
    }
}
