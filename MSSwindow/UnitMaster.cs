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
    public partial class UnitMaster : Form
    {
        public readonly int UniqueShopid = 0;
        public UnitMaster(MainForm admn)
        {
            InitializeComponent();
            UniqueShopid = admn.Shopid;
        }

        UnitClass uc = new UnitClass();
        private void btnAddnew_Click(object sender, EventArgs e)
        {
            int id = 0;
            lblId.Text = "" + id; 
            lblId.Visible = false;
            txtUnitname.Focus();
           // BtnAddNewClick();
            btnSave.Text = "Save";
            txtUnitname.Enabled = true;
            txtDescription.Enabled = true;
            btnAddnew.Enabled = false;
            btnSave.Enabled = true;
            btnReset.Enabled = true;

        }

        private void BtnAddNewClick()
        {
            btnAddnew.Enabled = false;
            btnSave.Enabled = true;
            btnDelete.Enabled = false;
            btnReset.Enabled = false;
            btnClose.Enabled = true;
        }

        private void formLoad()
        {
            btnAddnew.Enabled = true;
            btnClose.Enabled = true;
            btnSave.Enabled = false;
            btnDelete.Enabled = false;
            btnReset.Enabled = false;
            txtUnitname.Text = string.Empty;
            txtDescription.Text = string.Empty;
            txtUnitname.Enabled = false;
            txtDescription.Enabled = false;
            chkIsActive.Enabled = false;
        }

        private void BtnResetClick()
        {
            btnAddnew.Enabled = true;
            btnSave.Enabled = false;
            btnDelete.Enabled = false;
            btnReset.Enabled = false;
            txtUnitname.Focus();
            txtUnitname.Enabled = false;
            txtDescription.Enabled = false;
            chkIsActive.Enabled = false;               

        }
        private void GridCellMouseClick()
        {
            btnAddnew.Enabled = false;
            btnSave.Enabled = true;
           // btnSave.Text = "Update";
            btnDelete.Enabled = true;
            btnReset.Enabled = true;
            chkIsActive.Checked = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do You Want To Save Record?", "Products Details", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (txtUnitname.Text == string.Empty)
                {
                    MessageBox.Show("Please Fill Unit Name");
                    txtUnitname.Focus();
                }                
                else
                {
                    UnitClassBe be = new UnitClassBe();
                    be.Shopid = UniqueShopid;
                    be.Unitid = Convert.ToInt32(lblId.Text);             
                    be.UnitName = txtUnitname.Text;
                    be.Description = txtDescription.Text;                  
                    be.IsActive = Convert.ToInt32(chkIsActive.Checked);
                    UnitClass pd = new UnitClass();
                    pd.InsertUpdateUnit(be);

                    if (lblId.Text == "0")
                    {
                        MessageBox.Show(this, "Record Saved Successfully.", "Products Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Resetcontrol();
                    }
                    else
                    {
                        MessageBox.Show(this, "Record Updated Successfully.", "Products Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
                       // btnSave.Text = "Save";
                        Resetcontrol();
                    }                   
                    BindGridUnit();
                   // Resetcontrol();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            
                if (MessageBox.Show("Are you sure you want to delete this Record?", "Confirm deleting", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (!string.IsNullOrEmpty(lblId.Text))
                    {
                        UnitClassBe be = new UnitClassBe();
                        be.Unitid = Convert.ToInt32(lblId.Text);
                        uc.DeleteUnit(be);
                        MessageBox.Show("Successfully deleted the Record. ", "Sucessful deletion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        BindGridUnit();
                        Resetcontrol();
                    }
                }
            
            
        }

        private void Resetcontrol()
        {
            txtUnitname.Text = string.Empty;
            txtDescription.Text = string.Empty;
            btnAddnew.Enabled = true;
            btnClose.Enabled = true;
            btnSave.Enabled = false;
            btnDelete.Enabled = false;
            btnDelete.Enabled = false;
            btnReset.Enabled = false;
        }
        
        private void btnReset_Click(object sender, EventArgs e)
        {
            BtnResetClick();
            Resetcontrol();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void BindGridUnit()
        {
            dataGridViewUnit.DataSource = uc.BindUnit(UniqueShopid).Tables[0];
        }

        private void UnitMaster_Load(object sender, EventArgs e)
        {
          //  formLoad();
            BindGridUnit();
            lblId.Visible = false;
            Resetcontrol();
           
        }

        private void dataGridViewUnit_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            GridCellMouseClick();
            if (e.RowIndex < 0)
                return;
            lblId.Text = dataGridViewUnit.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtUnitname.Text = dataGridViewUnit.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtDescription.Text = dataGridViewUnit.Rows[e.RowIndex].Cells[2].Value.ToString();
        }
    }
}
