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
    public partial class frmstockdetails : Form
    {
        public frmstockdetails()
        {
            InitializeComponent();
        }

        private readonly int UniqueShopID = 0;

        public frmstockdetails(int Shopid)
        {
            InitializeComponent();
            UniqueShopID = Shopid;
            BindStockDetails(UniqueShopID);
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        

        private void BindStockDetails(int ShopID)
        {
            Stock stk = new Stock();
            DataSet ds= new DataSet();
            ds = stk.BindStock(ShopID);
            dataGridStock.DataSource = ds.Tables[0];

        }

        private void dataGridStock_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int HeadID = Convert.ToInt32(dataGridStock.CurrentRow.Cells[0].Value);
                FrmAddStock ads = new FrmAddStock(true, UniqueShopID, HeadID);
                ads.ShowDialog();

            }
        }
    }
}
