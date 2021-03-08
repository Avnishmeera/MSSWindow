using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MSSwindow.CommonClass;


namespace MSSwindow
{
    public partial class frmzone : Form
    {
        public frmzone()
        {
            InitializeComponent();
        }

        
        
        int UniqueShopID = 0;
        public frmzone(int Shopid)
        {
            InitializeComponent();
            UniqueShopID = Shopid;
        }

        private void frmzone_Load(object sender, EventArgs e)
        {
            BindZonedetails();
        }

        Zoneclass cls = new Zoneclass();
        private void BindZonedetails()
        {
            DataTable dt = new DataTable();
            dt = cls.BindZone(UniqueShopID).Tables[0];
            if (dt.Rows.Count>0)
            {
                dataGridZone.DataSource = dt;
            }            
        }


        public int lblzoneid = 0;

        private void btnsave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do You Want To Save Record?", "Zone Details", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (txtzonename.Text == string.Empty)
                {
                    MessageBox.Show(this, "Please Fill Zone Name", "MSS", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                    txtzonename.Focus();
                }
                else
                {
                    Zonebe be = new Zonebe();
                    be.Shopid = UniqueShopID;
                    be.ZoneID = Convert.ToInt32(lblzoneid);
                    be.ZoneName = txtzonename.Text;                                     
                    Zoneclass cls = new Zoneclass();
                    cls.InsertUpdateZone(be);
                    if (lblzoneid == 0)
                    {
                        MessageBox.Show(this, "Record Saved Successfully.", "Zone Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(this, "Record Updated Successfully.", "Zone Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    BindZonedetails(); 
                }
            }
        }

        private void dataGridZone_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                DataGridViewRow row = dataGridZone.Rows[e.RowIndex];
                lblzoneid =Convert.ToInt32(row.Cells[2].Value.ToString());
                txtzonename.Text = row.Cells[4].Value.ToString();               
            }

            if (e.ColumnIndex == 1)
            {
                Zonebe be = new Zonebe();
                DataGridViewRow row = dataGridZone.Rows[e.RowIndex];
                lblzoneid = Convert.ToInt32(row.Cells[2].Value.ToString());
                be.ZoneID = lblzoneid;
                be.Shopid = UniqueShopID;
                cls.DeletedZone(be);
                BindZonedetails();
            }
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
