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
    public partial class RentDetails : Form
    {
        int UniqueShopID = 0;
        public RentDetails( int ShopID)
        {
            InitializeComponent();
            UniqueShopID = ShopID;

        }

        private void RentDetails_Load(object sender, EventArgs e)
        {
            CustomerClass cls = new CustomerClass();
            dataGridView1.DataSource = cls.RentDetails(UniqueShopID,TxtSearch.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CustomerClass cls = new CustomerClass();
            dataGridView1.DataSource = cls.RentDetails(UniqueShopID, TxtSearch.Text);
        }
    }
}
