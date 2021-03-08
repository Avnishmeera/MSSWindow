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
    public partial class PurchaseSerielNumber : Form
    {
        public PurchaseSerielNumber()
        {
            InitializeComponent();
        }

        int total_qty = 0;


        public PurchaseSerielNumber(int TotalQty)
        {
            InitializeComponent();
            total_qty = TotalQty;
        }

        private void PurchaseSerielNumber_Load(object sender, EventArgs e)
        {
            for (int i = 1; i <= total_qty; i++)
            {                
                dataGridViewPurchaseSrNo.Rows.Add(i,"",1);                
            }
        }

        private void dataGridViewPurchaseSrNo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex==3)
            {
                int x = dataGridViewPurchaseSrNo.CurrentRow.Index;
                dataGridViewPurchaseSrNo.Rows.RemoveAt(x);
            }
        }
    }
}
