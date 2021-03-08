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
    public partial class Dashboard : Form
    {
        List<SMSCredential> lstCred = new List<SMSCredential>();
        public readonly int Shopid = 2;
        Loginform log_local = null;
        DataTable dtpendingAMC = new DataTable();
        public Dashboard()
        {
            InitializeComponent();
        }

        public Dashboard(int SHOPID, Loginform log)
        {
            InitializeComponent();
            Shopid = SHOPID;
            log_local = log;
        }

        private void TabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SplitContainer1.SplitterIncrement = 20;
            if (SplitContainer1.Panel1Collapsed)
            {
                SplitContainer1.Panel1Collapsed = false;
            }
            else
            {
                SplitContainer1.Panel1Collapsed = true;
            }
        }

        private void splitContainer2_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void TabControl1_MouseClick(object sender, MouseEventArgs e)
        {
            SplitContainer1.SplitterIncrement = 20;
            if (SplitContainer1.Panel1Collapsed)
            {
                SplitContainer1.Panel1Collapsed = false;
            }
            else
            {
                SplitContainer1.Panel1Collapsed = true;
            }
        }

        private void ShowFormInPanel(Form Frm, string frmname)
        {
            this.lblformname.Text = frmname;
            Pnlmdi.Controls.Clear();
            this.IsMdiContainer = true;
            Frm.TopLevel = false;
            Pnlmdi.Controls.Add(Frm);
            Frm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Frm.Dock = DockStyle.Fill;
            Frm.Show();
        }

        private void TreeView2_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void TreeView2_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Name == "CategoryMaster")
            {
                CategoryDetails cat = new CategoryDetails(Shopid);
                ShowFormInPanel(cat, "Category Master");
            }
        }

        private void TreeView2_AfterExpand(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Index > 0)
            {
                e.Node.PrevNode.Collapse(true); 
            }
            
            

        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            log_local.Hide();
        }
    }
}
