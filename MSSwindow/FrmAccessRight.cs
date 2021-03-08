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
    public partial class FrmAccessRight : Form
    {
        int UniqueShopID = 0;
        public FrmAccessRight(int ShopID)
        {
            InitializeComponent();
            UniqueShopID = ShopID;
        }

        private void FrmAccessRight_Load(object sender, EventArgs e)
        {
            BindDataGridviewEmployee();
        }

        private void BindDataGridviewEmployee()
        {
            RegistractionClass rc = new RegistractionClass();
            DataTable dtemp = new DataTable();
            dtemp.Columns.Add("memid", typeof(System.Int32));
            dtemp.Columns.Add("FullName", typeof(System.String));
            dtemp.Rows.Add(0, "Select");
            DataTable dt = rc.BindMemberDetails(UniqueShopID, string.Empty).Tables[0];
            foreach (DataRow item in dt.Rows)
            {
                dtemp.Rows.Add(item["memid"], item["FullName"]);
            }

            CmbUser.DataSource = dtemp;
            CmbUser.DisplayMember = "FullName";
            CmbUser.ValueMember = "memid";


        }

        private void CmbUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dgv1.Columns.Clear();
            //Dgv1.Rows.Clear();
            if (Convert.ToInt32(CmbUser.SelectedValue) > 0)
            {
                RegistractionClass rc = new RegistractionClass();
                DataTable DT = new DataTable();
                DT = rc.BindAccessRight(UniqueShopID, Convert.ToInt32(CmbUser.SelectedValue)).Tables[0];
                Dgv1.Columns.Clear();
                if (DT.Rows.Count > 0)
                {
                    DataGridViewColumn DCL = new DataGridViewColumn();
                    foreach (DataColumn DR in DT.Columns)
                    {
                        if (DR.ColumnName != "IsActive")
                        {
                            DCL = new DataGridViewColumn();
                            DCL.HeaderText = DR.ColumnName;
                            DCL.Name = DR.ColumnName;
                            DCL.DataPropertyName = DR.ColumnName;
                            DCL.CellTemplate = new DataGridViewTextBoxCell();
                            Dgv1.Columns.Add(DCL);
                        }
                        else
                        {

                            DCL = new DataGridViewCheckBoxColumn();
                            DCL.HeaderText = DR.ColumnName;
                            DCL.Name = DR.ColumnName;
                            DCL.DataPropertyName = DR.ColumnName;
                            DCL.CellTemplate = new DataGridViewCheckBoxCell();
                            Dgv1.Columns.Add(DCL);
                        }

                    }
                    //DataGridViewColumn DCL1 = new DataGridViewColumn();
                    //DCL.HeaderText = "Active";
                    //DCL.DataPropertyName = "IsActive";
                    //DCL.Name = "Active";
                    //DataGridViewCell cell = new DataGridViewCheckBoxCell();
                    //cell.Style.BackColor = Color.Wheat;
                    //DCL1.CellTemplate = cell;
                    //Dgv1.Columns.Add(DCL1);
                    Dgv1.AutoGenerateColumns = false;
                    Dgv1.DataSource = DT;
                }

            }
        }

        private void Dgv1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            try
            {

            }
            catch (Exception)
            {

               
            }
        }

        private void Dgv1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {

        }

        private void Dgv1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //for (int i = Dgv1.Rows.Count - 1; i > 0; i--)
            //{
            //    DataGridViewRow row = Dgv1.Rows[i];
            //    DataGridViewRow previousRow = Dgv1.Rows[i - 1];
            //    for (int j = 2; j <= row.Cells.Count - 6; j++)
            //    {
            //        string LblRow = row.Cells[j].Value.ToString();
            //        string LblPRow = previousRow.Cells[j].Value.ToString();
            //        if (LblRow == LblPRow)
            //        {
            //            if (previousRow.Cells[j].va == 0)
            //            {
            //                if (row.Cells[j].RowSpan == 0)
            //                {
            //                    previousRow.Cells[j].RowSpan += 2;
            //                }
            //                else
            //                {
            //                    previousRow.Cells[j].RowSpan = row.Cells[j].RowSpan + 1;
            //                }
            //                row.Cells[j].Visible = false;
            //            }
            //        }
            //    }
            //}

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BtnSave_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Do You Want To Update the User Access Rights?", "User Accessibility", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                DataTable dt = new DataTable();
                dt.Columns.Add("ModuleID", typeof(System.Int32));
                dt.Columns.Add("IsActive", typeof(System.Boolean));
                dt.Columns.Add("UserID", typeof(System.Int32));
                dt.Columns.Add("ShopID", typeof(System.Int32));

                foreach (DataGridViewRow item in Dgv1.Rows)
                {
                    int MMID = Convert.ToInt32(item.Cells[0].Value);
                    bool Act = Convert.ToBoolean(item.Cells[Dgv1.ColumnCount - 1].Value);
                    dt.Rows.Add(MMID, Act, Convert.ToInt32(CmbUser.SelectedValue), UniqueShopID);
                }
                RegistractionClass rc = new RegistractionClass();
                rc.InsertUpdateAccessRight(dt);

                MessageBox.Show(this, "User access right updated successfully.", "User Accessibility", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
    }
}
