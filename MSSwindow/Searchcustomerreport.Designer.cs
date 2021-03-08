namespace MSSwindow
{
    partial class Searchcustomerreport
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridViewCustomer = new System.Windows.Forms.DataGridView();
            this.Customerid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Customername = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.City = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.States = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StateCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Country = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pincode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Contact = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BirthDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AniversaryDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EmailID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GSTIN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descriptions = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsActive = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaritalStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Gender = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ShippingAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ShippingCity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ShippingState = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ShippingStateCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ShippingPinCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SameAsBilling = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ZoneID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Typeid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gstin1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnprint = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCustomer)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.dataGridViewCustomer, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.26119F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 89.73881F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1085, 536);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnprint);
            this.panel1.Controls.Add(this.lblSearch);
            this.panel1.Controls.Add(this.txtSearch);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1079, 49);
            this.panel1.TabIndex = 0;
            // 
            // dataGridViewCustomer
            // 
            this.dataGridViewCustomer.AllowUserToAddRows = false;
            this.dataGridViewCustomer.AllowUserToDeleteRows = false;
            this.dataGridViewCustomer.AllowUserToResizeColumns = false;
            this.dataGridViewCustomer.AllowUserToResizeRows = false;
            this.dataGridViewCustomer.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewCustomer.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewCustomer.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dataGridViewCustomer.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.AppWorkspace;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.HotTrack;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewCustomer.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dataGridViewCustomer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCustomer.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Customerid,
            this.Customername,
            this.City,
            this.States,
            this.StateCode,
            this.Country,
            this.Pincode,
            this.Contact,
            this.BirthDate,
            this.AniversaryDate,
            this.EmailID,
            this.GSTIN,
            this.Address,
            this.Descriptions,
            this.IsActive,
            this.MaritalStatus,
            this.Gender,
            this.ShippingAddress,
            this.ShippingCity,
            this.ShippingState,
            this.ShippingStateCode,
            this.ShippingPinCode,
            this.SameAsBilling,
            this.ZoneID,
            this.Typeid,
            this.gstin1});
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewCustomer.DefaultCellStyle = dataGridViewCellStyle10;
            this.dataGridViewCustomer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewCustomer.Location = new System.Drawing.Point(3, 58);
            this.dataGridViewCustomer.Name = "dataGridViewCustomer";
            this.dataGridViewCustomer.ReadOnly = true;
            this.dataGridViewCustomer.RowHeadersVisible = false;
            this.dataGridViewCustomer.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dataGridViewCustomer.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewCustomer.Size = new System.Drawing.Size(1079, 475);
            this.dataGridViewCustomer.TabIndex = 2;
            // 
            // Customerid
            // 
            this.Customerid.DataPropertyName = "Customerid";
            this.Customerid.HeaderText = "Customer ID";
            this.Customerid.Name = "Customerid";
            this.Customerid.ReadOnly = true;
            this.Customerid.Visible = false;
            // 
            // Customername
            // 
            this.Customername.DataPropertyName = "Customername";
            this.Customername.HeaderText = "Customer Name";
            this.Customername.Name = "Customername";
            this.Customername.ReadOnly = true;
            // 
            // City
            // 
            this.City.DataPropertyName = "city";
            this.City.HeaderText = "City";
            this.City.Name = "City";
            this.City.ReadOnly = true;
            this.City.Visible = false;
            // 
            // States
            // 
            this.States.DataPropertyName = "States";
            this.States.HeaderText = "State";
            this.States.Name = "States";
            this.States.ReadOnly = true;
            this.States.Visible = false;
            // 
            // StateCode
            // 
            this.StateCode.DataPropertyName = "StateCode";
            this.StateCode.HeaderText = "StateCode";
            this.StateCode.Name = "StateCode";
            this.StateCode.ReadOnly = true;
            // 
            // Country
            // 
            this.Country.DataPropertyName = "country";
            this.Country.HeaderText = "Country";
            this.Country.Name = "Country";
            this.Country.ReadOnly = true;
            this.Country.Visible = false;
            // 
            // Pincode
            // 
            this.Pincode.DataPropertyName = "pincode";
            this.Pincode.HeaderText = "Pincode";
            this.Pincode.Name = "Pincode";
            this.Pincode.ReadOnly = true;
            this.Pincode.Visible = false;
            // 
            // Contact
            // 
            this.Contact.DataPropertyName = "Contact";
            this.Contact.HeaderText = "Contact";
            this.Contact.Name = "Contact";
            this.Contact.ReadOnly = true;
            // 
            // BirthDate
            // 
            this.BirthDate.DataPropertyName = "BirthDate";
            this.BirthDate.HeaderText = "Birth Date";
            this.BirthDate.Name = "BirthDate";
            this.BirthDate.ReadOnly = true;
            // 
            // AniversaryDate
            // 
            this.AniversaryDate.DataPropertyName = "AniversaryDate";
            this.AniversaryDate.HeaderText = "Aniversary Date";
            this.AniversaryDate.Name = "AniversaryDate";
            this.AniversaryDate.ReadOnly = true;
            // 
            // EmailID
            // 
            this.EmailID.DataPropertyName = "Emailid";
            this.EmailID.HeaderText = "Email";
            this.EmailID.Name = "EmailID";
            this.EmailID.ReadOnly = true;
            this.EmailID.Visible = false;
            // 
            // GSTIN
            // 
            this.GSTIN.DataPropertyName = "GSTIN";
            this.GSTIN.HeaderText = "Alt Contact";
            this.GSTIN.Name = "GSTIN";
            this.GSTIN.ReadOnly = true;
            // 
            // Address
            // 
            this.Address.DataPropertyName = "Address";
            this.Address.HeaderText = "Address";
            this.Address.Name = "Address";
            this.Address.ReadOnly = true;
            // 
            // Descriptions
            // 
            this.Descriptions.DataPropertyName = "Descriptions";
            this.Descriptions.HeaderText = "Descriptions";
            this.Descriptions.Name = "Descriptions";
            this.Descriptions.ReadOnly = true;
            this.Descriptions.Visible = false;
            // 
            // IsActive
            // 
            this.IsActive.DataPropertyName = "IsActive";
            this.IsActive.HeaderText = "IsActive";
            this.IsActive.Name = "IsActive";
            this.IsActive.ReadOnly = true;
            // 
            // MaritalStatus
            // 
            this.MaritalStatus.DataPropertyName = "MaritalStatus";
            this.MaritalStatus.HeaderText = "MaritalStatus";
            this.MaritalStatus.Name = "MaritalStatus";
            this.MaritalStatus.ReadOnly = true;
            this.MaritalStatus.Visible = false;
            // 
            // Gender
            // 
            this.Gender.DataPropertyName = "Gender";
            this.Gender.HeaderText = "Gender";
            this.Gender.Name = "Gender";
            this.Gender.ReadOnly = true;
            this.Gender.Visible = false;
            // 
            // ShippingAddress
            // 
            this.ShippingAddress.DataPropertyName = "ShippingAddress";
            this.ShippingAddress.HeaderText = "ShippingAddress";
            this.ShippingAddress.Name = "ShippingAddress";
            this.ShippingAddress.ReadOnly = true;
            this.ShippingAddress.Visible = false;
            // 
            // ShippingCity
            // 
            this.ShippingCity.DataPropertyName = "ShippingCity";
            this.ShippingCity.HeaderText = "ShippingCity";
            this.ShippingCity.Name = "ShippingCity";
            this.ShippingCity.ReadOnly = true;
            this.ShippingCity.Visible = false;
            // 
            // ShippingState
            // 
            this.ShippingState.DataPropertyName = "ShippingState";
            this.ShippingState.HeaderText = "ShippingState";
            this.ShippingState.Name = "ShippingState";
            this.ShippingState.ReadOnly = true;
            this.ShippingState.Visible = false;
            // 
            // ShippingStateCode
            // 
            this.ShippingStateCode.DataPropertyName = "ShippingStateCode";
            this.ShippingStateCode.HeaderText = "ShippingStateCode";
            this.ShippingStateCode.Name = "ShippingStateCode";
            this.ShippingStateCode.ReadOnly = true;
            this.ShippingStateCode.Visible = false;
            // 
            // ShippingPinCode
            // 
            this.ShippingPinCode.DataPropertyName = "ShippingPinCode";
            this.ShippingPinCode.HeaderText = "ShippingPinCode";
            this.ShippingPinCode.Name = "ShippingPinCode";
            this.ShippingPinCode.ReadOnly = true;
            this.ShippingPinCode.Visible = false;
            // 
            // SameAsBilling
            // 
            this.SameAsBilling.DataPropertyName = "SameAsBilling";
            this.SameAsBilling.HeaderText = "SameAsBilling";
            this.SameAsBilling.Name = "SameAsBilling";
            this.SameAsBilling.ReadOnly = true;
            this.SameAsBilling.Visible = false;
            // 
            // ZoneID
            // 
            this.ZoneID.DataPropertyName = "ZoneID";
            this.ZoneID.HeaderText = "ZoneID";
            this.ZoneID.Name = "ZoneID";
            this.ZoneID.ReadOnly = true;
            this.ZoneID.Visible = false;
            // 
            // Typeid
            // 
            this.Typeid.DataPropertyName = "Typeid";
            this.Typeid.HeaderText = "Typeid";
            this.Typeid.Name = "Typeid";
            this.Typeid.ReadOnly = true;
            this.Typeid.Visible = false;
            // 
            // gstin1
            // 
            this.gstin1.DataPropertyName = "gstin1";
            this.gstin1.HeaderText = "GSTIN";
            this.gstin1.Name = "gstin1";
            this.gstin1.ReadOnly = true;
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearch.Location = new System.Drawing.Point(546, 17);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(60, 20);
            this.lblSearch.TabIndex = 17;
            this.lblSearch.Text = "Search";
            // 
            // txtSearch
            // 
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(611, 12);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(309, 26);
            this.txtSearch.TabIndex = 18;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // btnprint
            // 
            this.btnprint.BackColor = System.Drawing.Color.SeaShell;
            this.btnprint.Font = new System.Drawing.Font("Century Gothic", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnprint.Location = new System.Drawing.Point(949, 9);
            this.btnprint.Name = "btnprint";
            this.btnprint.Size = new System.Drawing.Size(109, 32);
            this.btnprint.TabIndex = 19;
            this.btnprint.Text = "Print";
            this.btnprint.UseVisualStyleBackColor = false;
            this.btnprint.Click += new System.EventHandler(this.btnprint_Click);
            // 
            // Searchcustomerreport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1085, 536);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Searchcustomerreport";
            this.Text = "Searchcustomerreport";
            this.Load += new System.EventHandler(this.Searchcustomerreport_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCustomer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridViewCustomer;
        private System.Windows.Forms.DataGridViewTextBoxColumn Customerid;
        private System.Windows.Forms.DataGridViewTextBoxColumn Customername;
        private System.Windows.Forms.DataGridViewTextBoxColumn City;
        private System.Windows.Forms.DataGridViewTextBoxColumn States;
        private System.Windows.Forms.DataGridViewTextBoxColumn StateCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn Country;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pincode;
        private System.Windows.Forms.DataGridViewTextBoxColumn Contact;
        private System.Windows.Forms.DataGridViewTextBoxColumn BirthDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn AniversaryDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmailID;
        private System.Windows.Forms.DataGridViewTextBoxColumn GSTIN;
        private System.Windows.Forms.DataGridViewTextBoxColumn Address;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descriptions;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsActive;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaritalStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn Gender;
        private System.Windows.Forms.DataGridViewTextBoxColumn ShippingAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn ShippingCity;
        private System.Windows.Forms.DataGridViewTextBoxColumn ShippingState;
        private System.Windows.Forms.DataGridViewTextBoxColumn ShippingStateCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ShippingPinCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn SameAsBilling;
        private System.Windows.Forms.DataGridViewTextBoxColumn ZoneID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Typeid;
        private System.Windows.Forms.DataGridViewTextBoxColumn gstin1;
        private System.Windows.Forms.Button btnprint;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearch;
    }
}