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
    public partial class StorestockDetails : Form
    {
        public StorestockDetails()
        {
            InitializeComponent();
        }
        public StorestockDetails(int Shopid)
        {
            InitializeComponent();
            UniqueShopID = Shopid;
        }
        DataSet dsProduct = new DataSet();
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (txtproduct.Text == string.Empty)
            {
                LstProduct.Visible = false;
                return;
            }
            if (dsProduct.Tables[0].Rows.Count > 0)
            {
                DataView dv = new DataView(dsProduct.Tables[0]);
                dv.RowFilter = "Productname like '%" + txtproduct.Text + "%'";
                LstProduct.Visible = true;
                LstProduct.DataSource = dv.ToTable();
                LstProduct.DisplayMember = "Productname";
                LstProduct.ValueMember = "Productid";
            }
        }



      

       private void StorestockDetails_Load(object sender, EventArgs e)
       {
           BindFromLocation();
           ProductClass prod = new ProductClass();
           dsProduct = prod.BindProducts(UniqueShopID);
          // BindUnitDropdown();
       }


       public readonly int UniqueShopID;




       private void GetRefNo()
       {
           try
           {
               Stockbe be = new Stockbe();
               be.Shopid = UniqueShopID;
               be.Locationid=(Convert.ToInt32(cmbfrom.SelectedValue));
               Stock st = new Stock();
               DataTable dt = new DataTable();
               dt = st.BindRefNo(be);
               txtrefno.Text = dt.Rows[0]["Refno"].ToString();
           }
           catch (Exception)
           {

           }
       }

       public int Fromlocation
       {
           get
           {
               if (cmbfrom.SelectedValue != string.Empty)
               {
                   return Convert.ToInt32(cmbfrom.SelectedValue);
               }
               else
               {
                   return 0;
               }
           }
       }


       public int Tolocation
       {
           get
           {
               if (cmbto.SelectedValue != string.Empty)
               {
                   return Convert.ToInt32(cmbto.SelectedValue);
               }
               else
               {
                   return 0;
               }
           }
       }

       
       private void BindFromLocation()
       {
           try
           {              
               Stockbe be = new Stockbe();
               be.Shopid = UniqueShopID;
              
               Stock UC = new Stock();
               DataTable dt = new DataTable();
               dt = UC.BindFromLocation(be).Tables[0];
               dt.Rows.Add("0", "Select");
               DataView dv = new DataView(dt);
               dv.Sort = "Locationid asc";
               cmbfrom.DataSource = dv.ToTable();
               cmbfrom.DisplayMember = "Locationname";
               cmbfrom.ValueMember = "Locationid";
           }
           catch (Exception)
           {

           }
       }


       private void BindToLocation(int Locationid)
       {
           try
           {
               Stockbe be = new Stockbe();
               be.Shopid = UniqueShopID;
               be.Locationid = Locationid;
               Stock UC = new Stock();
               DataTable dt = new DataTable();
               dt = UC.BindToLocation(be).Tables[0];
               dt.Rows.Add("0", "Select");
               DataView dv = new DataView(dt);
               dv.Sort = "Locationid asc";
               cmbto.DataSource = dv.ToTable();
               cmbto.DisplayMember = "Locationname";
               cmbto.ValueMember = "Locationid";
           }
           catch (Exception)
           {

           }
       }



       private void BindStockdetails(int locationid)
       {
           try
           {
               Stockbe be = new Stockbe();              
               be.Locationid = locationid;
               be.Productid =Convert.ToInt32(SelectedProductID);
               Stock st = new Stock();
               DataTable dt = new DataTable();
               dt = st.Bind_StockDetails(be);
               datagridStockdetails.DataSource = dt;
           }
           catch (Exception)
           {

           }
       }

       private void cmbfrom_SelectedIndexChanged(object sender, EventArgs e)
       {
           Stockbe be = new Stockbe();
           try
           {
               if (cmbfrom.SelectedValue.ToString() != "System.Data.DataRowView")
               {
                   if (cmbfrom.SelectedValue.ToString() != "0")
                   {
                       GetRefNo();
                       BindToLocation(Convert.ToInt32(cmbfrom.SelectedValue));
                   }
               }
              
           }
           catch (Exception ex)
           {
               MessageBox.Show(ex.Message);
           }
       }


       //string SelectedCustomerID = "0";
       string SelectedProductID = "0";
       private void LstProduct_Click(object sender, EventArgs e)
       {
           SelectedProductID = LstProduct.GetItemText(LstProduct.SelectedValue);
           if (!string.IsNullOrEmpty(SelectedProductID))
           {
               txtproduct.Text = LstProduct.GetItemText(LstProduct.SelectedItem);
               Stockbe be = new Stockbe();
               be.Shopid = UniqueShopID;
               be.Locationid =Convert.ToInt32(cmbfrom.SelectedValue);
               be.Productid = Convert.ToInt32(SelectedProductID);
               Stock p1 = new Stock();
               //DataView dv = new DataView(p1.BindStockDetails(be));
               DataTable dt = new DataTable();
               dt = p1.BindStockDetails(be);
               if (dt.Rows.Count>0)
               {
                   datagridStockdetails.DataSource = dt;
                   datagridStockdetails.Rows[0].Cells[4].Selected = true;
                   LstProduct.Visible = false;
               }
              
               LstProduct.Visible = false;
              
           }
       }


     
       //public int UnitID
       //{
       //    get
       //    {
       //        if (cmbunit.SelectedValue != string.Empty)
       //        {
       //            return Convert.ToInt32(cmbunit.SelectedValue);
       //        }
       //        else
       //        {
       //            return 0;
       //        }
       //    }
       //}

      
       private void btnClose_Click(object sender, EventArgs e)
       {
           this.Close();
       }

       private void txtqty_TextChanged(object sender, EventArgs e)
       {
           CalculatedValue();
       }


       private void CalculatedValue()
       {
           decimal Result = decimal.Zero;
           //Result = ProductQuantity * ProductPrice;
         //  txtamount.Text = Result.ToString();
       }

       //public decimal ProductQuantity
       //{
       //    get
       //    {
       //        if (txtqty.Text != string.Empty)
       //        {
       //            return Convert.ToDecimal(txtqty.Text);
       //        }
       //        else
       //        {
       //            return decimal.Zero;
       //        }
       //    }
       //    set
       //    {
       //        txtqty.Text = value.ToString();
       //    }
       //}


       //public decimal ProductPrice
       //{
       //    get
       //    {
       //        if (txtprice.Text != string.Empty)
       //        {
       //            return Convert.ToDecimal(txtprice.Text);
       //        }
       //        else
       //        {
       //            return decimal.Zero;
       //        }
       //    }
       //    set
       //    {
       //        txtprice.Text = value.ToString();
       //    }
       //}


       //public decimal ProductNetAmount
       //{
       //    get
       //    {
       //        if (txtamount.Text != string.Empty)
       //        {
       //            return Convert.ToDecimal(txtamount.Text);
       //        }
       //        else
       //        {
       //            return decimal.Zero;
       //        }
       //    }
       //    set
       //    {
       //        txtamount.Text = value.ToString();
       //    }
       //}

       private void btnsave_Click(object sender, EventArgs e)
       {
           //if (MessageBox.Show("Do You Want To Save Record?", "Stock Details", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
           //{
           //    if (txtproduct.Text == string.Empty)
           //    {
           //        MessageBox.Show("Please Fill Product Name");
           //        txtproduct.Focus();
           //    }               
           //    else
           //    {
           //        Stockbe be = new Stockbe();  
           //        be.TransferRefNo = txtrefno.Text;
           //        be.fromlocation = Convert.ToInt32(cmbfrom.SelectedValue);
           //        be.tolocation = Convert.ToInt32(cmbto.SelectedValue);
           //        be.Tranferdate = Convert.ToDateTime(datetimeTranferdate.Value); 
           //        be.Productid = Convert.ToInt32(SelectedProductID);                
           //        Stock pd = new Stock();
           //        pd.InsertUpdateStocks(be);
           //    }
           //}




       }

       private void textBox1_TextChanged_1(object sender, EventArgs e)
       {

       }

       private void datagridStockdetails_CellLeave(object sender, DataGridViewCellEventArgs e)
       {
           //if (e.ColumnIndex == 4)
           //{
           //    int TransferQty = 0;
           //    if (int.TryParse(datagridStockdetails.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString(), out TransferQty))
           //    {
           //        datagridStockdetails.Rows[e.RowIndex].Cells[e.ColumnIndex + 1].Value = (Convert.ToInt32(datagridStockdetails.Rows[e.RowIndex].Cells[e.ColumnIndex - 1].Value.ToString()) - Convert.ToInt32(datagridStockdetails.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString())).ToString();
           //    }
           //}

       }

       private void datagridStockdetails_KeyPress(object sender, KeyPressEventArgs e)
       {

       }

       private void datagridStockdetails_CellValueChanged(object sender, DataGridViewCellEventArgs e)
       {
          
       }

       private void datagridStockdetails_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
       {
           if (e.ColumnIndex == 4)
           {
               int TransferQty = 0;
               if (int.TryParse(datagridStockdetails.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString(), out TransferQty))
               {
                   datagridStockdetails.Rows[e.RowIndex].Cells[e.ColumnIndex + 1].Value = (Convert.ToInt32(datagridStockdetails.Rows[e.RowIndex].Cells[e.ColumnIndex - 1].Value.ToString()) - Convert.ToInt32(datagridStockdetails.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString())).ToString();
               }
           }
       }

       private void datagridStockdetails_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
           if (e.ColumnIndex == 4)
           {
               int TransferQty = 0;
              
               if (int.TryParse(datagridStockdetails.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString(), out TransferQty))
               {
                   if (TransferQty < 0)
                   {
                       datagridStockdetails.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 0;
                       datagridStockdetails.Rows[e.RowIndex].Cells[e.ColumnIndex + 1].Value = (Convert.ToInt32(datagridStockdetails.Rows[e.RowIndex].Cells[e.ColumnIndex - 1].Value.ToString()) - Convert.ToInt32(datagridStockdetails.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString())).ToString();
                       MessageBox.Show("Tranfer quantity can not be negative");
                       return;

                   }
                   if ((Convert.ToInt32(datagridStockdetails.Rows[e.RowIndex].Cells[e.ColumnIndex - 1].Value.ToString())) >= TransferQty)
                   {
                       datagridStockdetails.Rows[e.RowIndex].Cells[e.ColumnIndex + 1].Value = (Convert.ToInt32(datagridStockdetails.Rows[e.RowIndex].Cells[e.ColumnIndex - 1].Value.ToString()) - Convert.ToInt32(datagridStockdetails.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString())).ToString();
                   }
                  
                   else
                   {
                       datagridStockdetails.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 0;
                       datagridStockdetails.Rows[e.RowIndex].Cells[e.ColumnIndex + 1].Value = (Convert.ToInt32(datagridStockdetails.Rows[e.RowIndex].Cells[e.ColumnIndex - 1].Value.ToString()) - Convert.ToInt32(datagridStockdetails.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString())).ToString();
                       MessageBox.Show("Tranfer quantity can not exceed available quantity");
                       return;
                      // datagridStockdetails.Rows[e.RowIndex].Cells[e.ColumnIndex + 1].Value = (Convert.ToInt32(datagridStockdetails.Rows[e.RowIndex].Cells[e.ColumnIndex - 1].Value.ToString()) - TransferQty).ToString();
                   }
                  // datagridStockdetails.Rows[e.RowIndex].Cells[e.ColumnIndex + 1].Value = (Convert.ToInt32(datagridStockdetails.Rows[e.RowIndex].Cells[e.ColumnIndex - 1].Value.ToString()) - Convert.ToInt32(datagridStockdetails.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString())).ToString();
               }
               else {
                 
               }
           }
       }

       private void btntransfer_Click(object sender, EventArgs e)
       {
           if (MessageBox.Show("Do You Want To Transfer the Inventory?", "Stock Details", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
           {
               foreach (DataGridViewRow item in datagridStockdetails.Rows)
               {
                   Stockbe be = new Stockbe();
                   be.TransferRefNo = txtrefno.Text;
                   be.fromlocation = Convert.ToInt32(cmbfrom.SelectedValue);
                   be.tolocation = Convert.ToInt32(cmbto.SelectedValue);
                   be.Tranferdate = Convert.ToDateTime(datetimeTranferdate.Value);
                   be.Productid = Convert.ToInt32(SelectedProductID);
                   be.Unit = Convert.ToInt32(item.Cells[6].Value);
                   be.Price = Convert.ToInt32(item.Cells[2].Value);
                   be.Qty = Convert.ToInt32(item.Cells[4].Value); 
                   Stock pd = new Stock();
                  int i=  pd.InsertUpdateStocks(be);
                  if (i>0)
                  {
                      MessageBox.Show(this, "Item Transfer Successfully.", "Store Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
                     
                  }

                  
               } 
           }
       }

       private void datagridStockdetails_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
       {
           e.Control.KeyPress -= new KeyPressEventHandler(Column1_KeyPress);
           if (datagridStockdetails.CurrentCell.ColumnIndex == 0) //Desired Column
           {
               TextBox tb = e.Control as TextBox;
               if (tb != null)
               {
                   tb.KeyPress += new KeyPressEventHandler(Column1_KeyPress);
               }
           }
       }


       private void Column1_KeyPress(object sender, KeyPressEventArgs e)
       {
           if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
           {
               e.Handled = true;
           }
       }

       private void datagridStockdetails_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
       {
           DataGridViewColumn col = datagridStockdetails.Columns[e.ColumnIndex] as DataGridViewColumn;

           //if (col.Name.ToLower() == "cost" || col.Name.ToLower() == "sellingprice")
           //{
               DataGridViewTextBoxCell cell = datagridStockdetails[e.ColumnIndex, e.RowIndex] as DataGridViewTextBoxCell;
               if (cell != null)
               {
                   char[] chars = e.FormattedValue.ToString().ToCharArray();
                   foreach (char c in chars)
                   {
                       if (char.IsDigit(c) == false)
                       {
                           //MessageBox.Show("You have to enter digits only");
                           //e.Cancel = true;
                           //break;
                       }
                   }
              }
           //}
       }

      
    }
}
