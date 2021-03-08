using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MSSEntityFrame;
using MSSwindow.CommonClass;

namespace MSSwindow
{
    public partial class FrmTax : Form
    {
        DataTable dtTax = new DataTable();
        int EditRowIndex = 0;
        dynamic psdtl ;
        bool IsEdit = false;
        public readonly int UniqueShopID = 0;
        public FrmTax(int ShopID)
        {
            InitializeComponent();
            UniqueShopID = ShopID;
        }

        public FrmTax(decimal TotalAmount, int Dbid, DataTable TaxDt, dynamic ps, int ShopID)
        {
            InitializeComponent();
            UniqueShopID = ShopID;
            LblTotalAmt.Text = TotalAmount.ToString();
            dtTax = TaxDt;
            NetAmount = TotalAmount;
            BindTax();
          //  AddDataTableColumn();
            psdtl = ps;
            if (TaxDt != null)
            {
                DgvTax.DataSource = TaxDt;
            }

        }

        //public FrmTax(decimal TotalAmount, int Dbid, DataTable TaxDt, PurchaseDetails ps)
        //{
        //    InitializeComponent();
        //    LblTotalAmt.Text = TotalAmount.ToString();
        //    dtTax = TaxDt;
        //    NetAmount = TotalAmount;
        //    BindTax();
        //    AddDataTableColumn();
        //    psdtl = ps;
        //    if (TaxDt != null)
        //    {
        //        DgvTax.DataSource = TaxDt;
        //    }

        //}
        
        private void BindTax()
        {
            MSEntities db = new MSEntities();
            List<TaxBe> tx = new List<TaxBe>();
            tx = (from a in db.TaxesMaster
                  where a.IsActive == true
                  && a.ShopID == UniqueShopID
                  select new TaxBe
                  {
                      TaxID = a.Taxid,
                      TaxName = a.Taxname
                  }).ToList();

            CMBTaxName.DataSource = tx;
            CMBTaxName.ValueMember = "TaxID";
            CMBTaxName.DisplayMember = "Taxname";


        }

        private void BindTaxOption()
        {
            DataTable dtoption = new DataTable();
            dtoption.Columns.Add("ID", typeof(System.Int32));
            dtoption.Columns.Add("Option", typeof(System.String));
          //  dtoption.Rows.Add(1, "Rs.");
            dtoption.Rows.Add(2, "%");
            CmbTaxOption.DataSource = dtoption;
            CmbTaxOption.DisplayMember = "Option";
            CmbTaxOption.ValueMember = "ID";
            CmbTaxOption.SelectedValue = "2";

        }
        private void BindTaxValue(int TaxID)
        {
            MSEntities db = new MSEntities();
            List<TaxesMaster> tx = new List<TaxesMaster>();
            tx = db.TaxesMaster.Where(x => x.Taxid == TaxID).ToList();
            foreach (TaxesMaster TX in tx)
            {
                TxtTaxValue.Text = Convert.ToDecimal(TX.Rate).ToString();
            }


        }

        private void FrmTax_Load(object sender, EventArgs e)
        {
            BindTax();
            BindTaxOption();
            if (dtTax != null)
            {
                DgvTax.DataSource = dtTax;
            }

          

        }

        #region Properties
        public string SelectedTaxName
        {
            get
            {
                if (CMBTaxName.SelectedValue.ToString() != "0")
                {
                    return Convert.ToString(CMBTaxName.Text);
                }
                else
                {
                    return string.Empty;
                }
            }
            set
            {
                CMBTaxName.SelectedValue = value.ToString();
            }
        }

        public int SelectedTaxID
        {
            get
            {
                if (CMBTaxName.SelectedValue != null)
                {
                    return Convert.ToInt32(CMBTaxName.SelectedValue);
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                CMBTaxName.SelectedValue = value.ToString();
            }
        }

        public decimal SelectedTaxRate
        {
            get
            {
                if (TxtTaxValue.Text != string.Empty)
                {
                    return Convert.ToDecimal(TxtTaxValue.Text);
                }
                else
                {
                    return decimal.Zero;
                }
            }
            set
            {
                TxtTaxValue.Text = value.ToString();
            }
        }
        public int SelectedTaxOption
        {
            get
            {
                if (CmbTaxOption.SelectedValue != string.Empty)
                {
                    return Convert.ToInt32(CmbTaxOption.SelectedValue);
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                CmbTaxOption.SelectedValue = value.ToString();
            }
        }
        public string SelectedTaxOptionName
        {
            get
            {
                if (CmbTaxOption.SelectedValue != string.Empty)
                {
                    return CmbTaxOption.Text;
                }
                else
                {
                    return string.Empty;
                }
            }
            set
            {
                CmbTaxOption.SelectedValue = value.ToString();
            }
        }

        public decimal TaxAmountValue { get; set; }
        public decimal NetAmount { get; set; }
        #endregion
        private void CMBTaxName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BindTaxValue(SelectedTaxID);
            }
            catch (Exception)
            {
                
               
            }
          
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (IsEdit == false)
            {
                if (SelectedTaxOption == 1)
                {
                    TaxAmountValue = SelectedTaxRate;
                }
                else
                {
                    if (checkBox1.Checked == false)
                    {
                        TaxAmountValue = (NetAmount * SelectedTaxRate) / 100;
                    }
                    else
                    {
                        NetAmount = (NetAmount * 100) / (100 + SelectedTaxRate);
                        TaxAmountValue = (NetAmount * SelectedTaxRate) / 100;
                    }
                   
                }
                dtTax.Rows.Add(SelectedTaxID, SelectedTaxName, SelectedTaxRate, SelectedTaxOptionName, TaxAmountValue);
                DgvTax.DataSource = dtTax;
                psdtl.CalculateTaxAmount(dtTax);
            }
            else
            { 
               
            }
        }

        private void DgvTax_DoubleClick(object sender, EventArgs e)
        {

        }

        private void DgvTax_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0)
                return;         
            CMBTaxName.SelectedItem = DgvTax.Rows[e.RowIndex].Cells[1].ToString();         
            TxtTaxValue.Text = DgvTax.Rows[e.RowIndex].Cells[3].Value.ToString();          
        }

       


        private void BtnRemove_Click(object sender, EventArgs e)
        {
            if (EditRowIndex>0)
            {
                DataRow[] dr1 = dtTax.Select("TaxID='" + EditRowIndex + "'");
                dtTax.Rows.Remove(dr1[0]);
                int i = 1;
                foreach (DataRow dr in dtTax.Rows)
                {
                    dr["TaxID"] = 1;
                    i = i + 1;
                }
                dtTax.AcceptChanges();
                DgvTax.DataSource = dtTax;
                psdtl.CalculateTaxAmount(dtTax);
                MessageBox.Show(this, "Item Removed Succesfully.", "MSS", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
              
            }
           
        }


        private void ShowItemSummary()
        {
            List<PurchaseBe> lp = new List<PurchaseBe>();
            lp = (from a in dtTax.AsEnumerable()
                  select new PurchaseBe
                  {
                      amount = Convert.ToDecimal(a["NetAmount"].ToString()),
                      price = Convert.ToDecimal(a["Price"].ToString()),
                      disc = Convert.ToDecimal(a["Discount"].ToString()),
                      qty = Convert.ToInt32(a["Qty"].ToString()),
                  }).ToList();
            var disct = lp.Sum(x => x.disc);
            var amountt = lp.Sum(x => x.amount);          
        }

        private void DgvTax_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = Convert.ToInt32(DgvTax.Rows[e.RowIndex].Cells[0].Value.ToString());
            EditRowIndex = i;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                checkBox1.Text = "Yes";

            }
            else
            {
                checkBox1.Text = "No";
            }
        }
           





        }
    }



