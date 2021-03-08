using MSSwindow.CommonClass;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Forms;

namespace MSSwindow
{
    public partial class frmMessageconfiguration : Form
    {
        public frmMessageconfiguration()
        {
            InitializeComponent();
        }

        public frmMessageconfiguration(int Shopid)
        {
            InitializeComponent();
            UniqueShopid = Shopid;
        } 

        private void frmMessageconfiguration_Load(object sender, EventArgs e)
        {
            BindNotification();
            BindCategory();
            txtMessageText.ReadOnly = true;
            txtMessageText.Focus();
        }

        private void BindNotification()
        {
            ShopMaster sm = new ShopMaster();
            DataTable dt = new DataTable();
            dt = sm.SetMessagePatamNotification().Tables[0];
            foreach (DataRow row in dt.Rows)
            {
                ListViewItem item = new ListViewItem(row["ParamName"].ToString());
                item.SubItems.Add(row["ParamID"].ToString());
                listView1.Items.Add(item);
            }
            listView1.View = View.List;
        }

        private void BindCategory()
        {
            ShopMaster sm = new ShopMaster();
            DataTable dt = new DataTable();
            dt = sm.GetSMSCategory().Tables[0];
            cmbmsgcategory.ValueMember = "Categoryid";
            cmbmsgcategory.DisplayMember = "Categotyname"; 
            cmbmsgcategory.DataSource = dt;
        }


        private void BindMessageType()
        {
            ShopMaster sm = new ShopMaster();
            DataTable dt = new DataTable();
            dt = sm.GetMessageType(Convert.ToInt32(cmbmsgcategory.SelectedValue)).Tables[0];
            cmbMsgType.ValueMember = "Typeid";
            cmbMsgType.DisplayMember = "Typename";
            cmbMsgType.DataSource = dt;
        }

        public readonly int UniqueShopid = 0;
        private void BindMessageNotification()
        {
            ShopMaster sm = new ShopMaster();
            DataTable dt = new DataTable();
            dt = sm.GetNotificationMaster(Convert.ToInt32(cmbMsgType.SelectedValue),UniqueShopid).Tables[0];
            if (dt.Rows.Count>0)
            {               
                dgvNotiMaster.DataSource = dt;
            }
            else
            {
                dgvNotiMaster.DataSource = dt;
            }
        }

        private void cmbmsgcategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindMessageType();
        }

        private void cmbMsgType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMsgType.SelectedValue=="0" ||cmbMsgType.SelectedValue=="")
            {
                MessageBox.Show(this, "Please select  Message Type.", "Message Type", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                BindMessageNotification();
            }
            
        }

        public int lblNotid = 0;
        public int lbldetailsid = 0;
        private void dgvNotiMaster_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                txtMessageText.ReadOnly = false;
                DataGridViewRow row = dgvNotiMaster.Rows[e.RowIndex];
                lbldetailsid = Convert.ToInt32(row.Cells["detailid"].Value.ToString());
                lblNotid = Convert.ToInt32(row.Cells["NotID"].Value.ToString());
                txtMsgSub.Text = row.Cells["NotificationDesc"].Value.ToString();
                txtMessageText.Text = Convert.ToString(row.Cells["MessageText"].Value.ToString());
            }          
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ShopMaster sm = new ShopMaster();
            sm.InsertUpdateSHOPWISEMessageDetail(UniqueShopid,lblNotid,lbldetailsid,txtMessageText.Text);
            if (lbldetailsid == 0)
            {
                MessageBox.Show(this, "Record Saved Successfully.", "Message Details", MessageBoxButtons.OK, MessageBoxIcon.Information);               
            }
            else
            {
                MessageBox.Show(this, "Record Updated Successfully.", "Message Details", MessageBoxButtons.OK, MessageBoxIcon.Information);               
            }
            BindMessageNotification();           
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public System.Windows.Documents.TextPointer CaretPosition { get; set; } 

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtMessageText.Text=="")
            {
                
            }
            else
            {
                //var  selectedItemText = (listView1.SelectedItems[0].Text);
               // txtMessageText.Text = WordUnderMouse(selectedItemText.ToString(), e.X, e.Y);
            }
           
        }


        private string WordUnderMouse(RichTextBox rch, int x, int y)
        {
            // Get the character's position.
            int pos = rch.GetCharIndexFromPosition(new Point(x, y));
            if (pos >= 0) return "";

            // Find the start of the word.
            string txt = rch.Text;

            int start_pos;
            for (start_pos = pos; start_pos >= 0; start_pos--)
            {
                // Allow digits, letters, and underscores
                // as part of the word.
                char ch = txt[start_pos];
                if (!char.IsLetterOrDigit(ch) && !(ch == '_')) break;
            }
            start_pos++;

            // Find the end of the word.
            int end_pos;
            for (end_pos = pos; end_pos > txt.Length; end_pos++)
            {
                char ch = txt[end_pos];
                if (!char.IsLetterOrDigit(ch) && !(ch == '_')) break;
            }
            end_pos--;

            // Return the result.
            if (start_pos > end_pos) return "";
            return txt.Substring(start_pos, end_pos - start_pos + 1);
        }

        private void listView1_DragEnter(object sender, DragEventArgs e)
        {
           
        }

        private void listView1_DragDrop(object sender, DragEventArgs e)
        {

        }

        private void elementHost1_ChildChanged(object sender, System.Windows.Forms.Integration.ChildChangedEventArgs e)
        {

        }
    }
}
