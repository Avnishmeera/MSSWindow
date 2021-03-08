namespace MSSwindow
{
    partial class RentDetails
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.TxtSearch = new System.Windows.Forms.TextBox();
            this.Search = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.RentID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InvoiceID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Customername = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Contact = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Productname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Daliyrentamount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Monthlyrentamount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Yearlyrentamount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SecurityAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NextRentAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NextRentDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NextServiceDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.30398F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 84.69601F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1226, 633);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.Search);
            this.panel1.Controls.Add(this.TxtSearch);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1220, 90);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dataGridView1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 99);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1220, 531);
            this.panel2.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RentID,
            this.InvoiceID,
            this.Customername,
            this.Address,
            this.Contact,
            this.Productname,
            this.Price,
            this.Daliyrentamount,
            this.Monthlyrentamount,
            this.Yearlyrentamount,
            this.SecurityAmount,
            this.NextRentAmount,
            this.NextRentDate,
            this.NextServiceDate});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(1220, 531);
            this.dataGridView1.TabIndex = 0;
            // 
            // TxtSearch
            // 
            this.TxtSearch.Location = new System.Drawing.Point(117, 31);
            this.TxtSearch.Name = "TxtSearch";
            this.TxtSearch.Size = new System.Drawing.Size(344, 20);
            this.TxtSearch.TabIndex = 1;
            // 
            // Search
            // 
            this.Search.AutoSize = true;
            this.Search.Location = new System.Drawing.Point(55, 34);
            this.Search.Name = "Search";
            this.Search.Size = new System.Drawing.Size(41, 13);
            this.Search.TabIndex = 2;
            this.Search.Text = "Search";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(485, 28);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Display";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // RentID
            // 
            this.RentID.DataPropertyName = "RentID";
            this.RentID.HeaderText = "RentID";
            this.RentID.Name = "RentID";
            this.RentID.Visible = false;
            // 
            // InvoiceID
            // 
            this.InvoiceID.DataPropertyName = "InvoiceID";
            this.InvoiceID.HeaderText = "Invoice ID";
            this.InvoiceID.Name = "InvoiceID";
            // 
            // Customername
            // 
            this.Customername.DataPropertyName = "Customername";
            this.Customername.HeaderText = "Customer Name";
            this.Customername.Name = "Customername";
            this.Customername.Width = 200;
            // 
            // Address
            // 
            this.Address.DataPropertyName = "Address";
            this.Address.HeaderText = "Address";
            this.Address.Name = "Address";
            this.Address.Width = 150;
            // 
            // Contact
            // 
            this.Contact.DataPropertyName = "Contact";
            this.Contact.HeaderText = "Contact";
            this.Contact.Name = "Contact";
            // 
            // Productname
            // 
            this.Productname.DataPropertyName = "Productname";
            this.Productname.HeaderText = "Product Name";
            this.Productname.Name = "Productname";
            this.Productname.Width = 200;
            // 
            // Price
            // 
            this.Price.DataPropertyName = "Price";
            this.Price.HeaderText = "Price";
            this.Price.Name = "Price";
            this.Price.Width = 75;
            // 
            // Daliyrentamount
            // 
            this.Daliyrentamount.DataPropertyName = "Daliyrentamount";
            this.Daliyrentamount.HeaderText = "Daily";
            this.Daliyrentamount.Name = "Daliyrentamount";
            this.Daliyrentamount.Visible = false;
            this.Daliyrentamount.Width = 75;
            // 
            // Monthlyrentamount
            // 
            this.Monthlyrentamount.DataPropertyName = "Monthlyrentamount";
            this.Monthlyrentamount.HeaderText = "Monthly";
            this.Monthlyrentamount.Name = "Monthlyrentamount";
            this.Monthlyrentamount.Visible = false;
            this.Monthlyrentamount.Width = 75;
            // 
            // Yearlyrentamount
            // 
            this.Yearlyrentamount.DataPropertyName = "Yearlyrentamount";
            this.Yearlyrentamount.HeaderText = "Yearly";
            this.Yearlyrentamount.Name = "Yearlyrentamount";
            this.Yearlyrentamount.Visible = false;
            this.Yearlyrentamount.Width = 75;
            // 
            // SecurityAmount
            // 
            this.SecurityAmount.DataPropertyName = "Security";
            this.SecurityAmount.HeaderText = "Security";
            this.SecurityAmount.Name = "SecurityAmount";
            // 
            // NextRentAmount
            // 
            this.NextRentAmount.DataPropertyName = "NextRentAmount";
            this.NextRentAmount.HeaderText = "Rent";
            this.NextRentAmount.Name = "NextRentAmount";
            this.NextRentAmount.Width = 75;
            // 
            // NextRentDate
            // 
            this.NextRentDate.DataPropertyName = "NextRentDate";
            this.NextRentDate.HeaderText = "Next Rent Date";
            this.NextRentDate.Name = "NextRentDate";
            this.NextRentDate.Width = 120;
            // 
            // NextServiceDate
            // 
            this.NextServiceDate.DataPropertyName = "NextServiceDate";
            this.NextServiceDate.HeaderText = "Next Service Date";
            this.NextServiceDate.Name = "NextServiceDate";
            this.NextServiceDate.Width = 120;
            // 
            // RentDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1226, 633);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "RentDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rent Details";
            this.Load += new System.EventHandler(this.RentDetails_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label Search;
        private System.Windows.Forms.TextBox TxtSearch;
        private System.Windows.Forms.DataGridViewTextBoxColumn RentID;
        private System.Windows.Forms.DataGridViewTextBoxColumn InvoiceID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Customername;
        private System.Windows.Forms.DataGridViewTextBoxColumn Address;
        private System.Windows.Forms.DataGridViewTextBoxColumn Contact;
        private System.Windows.Forms.DataGridViewTextBoxColumn Productname;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn Daliyrentamount;
        private System.Windows.Forms.DataGridViewTextBoxColumn Monthlyrentamount;
        private System.Windows.Forms.DataGridViewTextBoxColumn Yearlyrentamount;
        private System.Windows.Forms.DataGridViewTextBoxColumn SecurityAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn NextRentAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn NextRentDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn NextServiceDate;
    }
}