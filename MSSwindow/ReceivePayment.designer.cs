namespace MSSwindow
{
    partial class ReceivePayment
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dataGridViewItemServices = new System.Windows.Forms.DataGridView();
            this.PayID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PayMode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RefNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Delete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.TxtRecAmt = new System.Windows.Forms.TextBox();
            this.TxtAmt = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dtp1 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtComplaintNo = new System.Windows.Forms.TextBox();
            this.TxtRef = new System.Windows.Forms.TextBox();
            this.ddlItemName = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblComplainID = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.TxtBalance = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.TxtPaidAmt = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewItemServices)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.dataGridViewItemServices, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel4, 0, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 27.16049F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 72.83951F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 191F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(696, 462);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // dataGridViewItemServices
            // 
            this.dataGridViewItemServices.AllowUserToAddRows = false;
            this.dataGridViewItemServices.AllowUserToDeleteRows = false;
            this.dataGridViewItemServices.AllowUserToResizeColumns = false;
            this.dataGridViewItemServices.AllowUserToResizeRows = false;
            this.dataGridViewItemServices.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewItemServices.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewItemServices.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dataGridViewItemServices.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.HotTrack;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewItemServices.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewItemServices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewItemServices.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PayID,
            this.PayMode,
            this.Amount,
            this.RefNo,
            this.Date,
            this.Delete});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewItemServices.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewItemServices.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewItemServices.Location = new System.Drawing.Point(4, 216);
            this.dataGridViewItemServices.Name = "dataGridViewItemServices";
            this.dataGridViewItemServices.ReadOnly = true;
            this.dataGridViewItemServices.RowHeadersVisible = false;
            this.dataGridViewItemServices.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dataGridViewItemServices.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewItemServices.Size = new System.Drawing.Size(688, 185);
            this.dataGridViewItemServices.TabIndex = 3;
            this.dataGridViewItemServices.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewItemServices_CellClick);
            // 
            // PayID
            // 
            this.PayID.DataPropertyName = "PAYID";
            this.PayID.FillWeight = 75F;
            this.PayID.HeaderText = "Pay ID";
            this.PayID.Name = "PayID";
            this.PayID.ReadOnly = true;
            this.PayID.Visible = false;
            // 
            // PayMode
            // 
            this.PayMode.DataPropertyName = "Mode";
            this.PayMode.FillWeight = 77.41116F;
            this.PayMode.HeaderText = "Mode";
            this.PayMode.Name = "PayMode";
            this.PayMode.ReadOnly = true;
            // 
            // Amount
            // 
            this.Amount.DataPropertyName = "Amount";
            this.Amount.FillWeight = 77.41116F;
            this.Amount.HeaderText = "Amount";
            this.Amount.Name = "Amount";
            this.Amount.ReadOnly = true;
            // 
            // RefNo
            // 
            this.RefNo.DataPropertyName = "Remark";
            this.RefNo.FillWeight = 77.41116F;
            this.RefNo.HeaderText = "Ref. No.";
            this.RefNo.Name = "RefNo";
            this.RefNo.ReadOnly = true;
            // 
            // Date
            // 
            this.Date.DataPropertyName = "PayDate";
            this.Date.HeaderText = "Date";
            this.Date.Name = "Date";
            this.Date.ReadOnly = true;
            // 
            // Delete
            // 
            this.Delete.FillWeight = 77.41116F;
            this.Delete.HeaderText = "Delete Service";
            this.Delete.Name = "Delete";
            this.Delete.ReadOnly = true;
            this.Delete.Text = "Delete";
            this.Delete.UseColumnTextForButtonValue = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(688, 37);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(289, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Receive Payment";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.Controls.Add(this.TxtRecAmt);
            this.panel2.Controls.Add(this.TxtAmt);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.dtp1);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.TxtComplaintNo);
            this.panel2.Controls.Add(this.TxtRef);
            this.panel2.Controls.Add(this.ddlItemName);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.lblComplainID);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(4, 48);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(688, 110);
            this.panel2.TabIndex = 1;
            // 
            // TxtRecAmt
            // 
            this.TxtRecAmt.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.TxtRecAmt.Enabled = false;
            this.TxtRecAmt.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtRecAmt.ForeColor = System.Drawing.Color.Lime;
            this.TxtRecAmt.Location = new System.Drawing.Point(8, 64);
            this.TxtRecAmt.Name = "TxtRecAmt";
            this.TxtRecAmt.ReadOnly = true;
            this.TxtRecAmt.Size = new System.Drawing.Size(140, 33);
            this.TxtRecAmt.TabIndex = 18;
            // 
            // TxtAmt
            // 
            this.TxtAmt.Location = new System.Drawing.Point(349, 36);
            this.TxtAmt.MaxLength = 6;
            this.TxtAmt.Name = "TxtAmt";
            this.TxtAmt.Size = new System.Drawing.Size(170, 25);
            this.TxtAmt.TabIndex = 15;
            this.TxtAmt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtAmt_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(8, 41);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(140, 20);
            this.label7.TabIndex = 17;
            this.label7.Text = "Payment To Receive";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(280, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 20);
            this.label3.TabIndex = 14;
            this.label3.Text = "Amount";
            // 
            // dtp1
            // 
            this.dtp1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp1.Location = new System.Drawing.Point(573, 36);
            this.dtp1.Name = "dtp1";
            this.dtp1.Size = new System.Drawing.Size(112, 25);
            this.dtp1.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(525, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 20);
            this.label2.TabIndex = 12;
            this.label2.Text = "Date";
            // 
            // TxtComplaintNo
            // 
            this.TxtComplaintNo.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtComplaintNo.ForeColor = System.Drawing.SystemColors.Highlight;
            this.TxtComplaintNo.Location = new System.Drawing.Point(8, 4);
            this.TxtComplaintNo.Name = "TxtComplaintNo";
            this.TxtComplaintNo.ReadOnly = true;
            this.TxtComplaintNo.Size = new System.Drawing.Size(222, 33);
            this.TxtComplaintNo.TabIndex = 11;
            // 
            // TxtRef
            // 
            this.TxtRef.Location = new System.Drawing.Point(349, 68);
            this.TxtRef.MaxLength = 200;
            this.TxtRef.Multiline = true;
            this.TxtRef.Name = "TxtRef";
            this.TxtRef.Size = new System.Drawing.Size(336, 40);
            this.TxtRef.TabIndex = 5;
            this.TxtRef.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCharge_KeyPress);
            // 
            // ddlItemName
            // 
            this.ddlItemName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.ddlItemName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.ddlItemName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlItemName.FormattingEnabled = true;
            this.ddlItemName.Location = new System.Drawing.Point(349, 5);
            this.ddlItemName.Name = "ddlItemName";
            this.ddlItemName.Size = new System.Drawing.Size(336, 25);
            this.ddlItemName.TabIndex = 4;
            this.ddlItemName.SelectedIndexChanged += new System.EventHandler(this.ddlItemName_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(285, 71);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 20);
            this.label5.TabIndex = 3;
            this.label5.Text = "Ref No.";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(238, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 20);
            this.label4.TabIndex = 2;
            this.label4.Text = "Payment Mode";
            // 
            // lblComplainID
            // 
            this.lblComplainID.AutoSize = true;
            this.lblComplainID.Location = new System.Drawing.Point(3, 142);
            this.lblComplainID.Name = "lblComplainID";
            this.lblComplainID.Size = new System.Drawing.Size(11, 17);
            this.lblComplainID.TabIndex = 1;
            this.lblComplainID.Text = ".";
            this.lblComplainID.Visible = false;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel3.Controls.Add(this.btnClose);
            this.panel3.Controls.Add(this.btnSave);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(4, 165);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(688, 44);
            this.panel3.TabIndex = 2;
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(358, 9);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(113, 30);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(218, 9);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(102, 30);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.TxtBalance);
            this.panel4.Controls.Add(this.label8);
            this.panel4.Controls.Add(this.label6);
            this.panel4.Controls.Add(this.TxtPaidAmt);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(4, 408);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(688, 50);
            this.panel4.TabIndex = 4;
            // 
            // TxtBalance
            // 
            this.TxtBalance.BackColor = System.Drawing.SystemColors.ControlDark;
            this.TxtBalance.Enabled = false;
            this.TxtBalance.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtBalance.ForeColor = System.Drawing.Color.Lime;
            this.TxtBalance.Location = new System.Drawing.Point(150, 9);
            this.TxtBalance.Name = "TxtBalance";
            this.TxtBalance.ReadOnly = true;
            this.TxtBalance.Size = new System.Drawing.Size(140, 33);
            this.TxtBalance.TabIndex = 19;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(8, 16);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(136, 20);
            this.label8.TabIndex = 18;
            this.label8.Text = "Balance To Receive";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(429, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 20);
            this.label6.TabIndex = 16;
            this.label6.Text = "Paid Amount";
            // 
            // TxtPaidAmt
            // 
            this.TxtPaidAmt.BackColor = System.Drawing.SystemColors.ControlDark;
            this.TxtPaidAmt.Enabled = false;
            this.TxtPaidAmt.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtPaidAmt.ForeColor = System.Drawing.Color.Red;
            this.TxtPaidAmt.Location = new System.Drawing.Point(529, 9);
            this.TxtPaidAmt.Name = "TxtPaidAmt";
            this.TxtPaidAmt.ReadOnly = true;
            this.TxtPaidAmt.Size = new System.Drawing.Size(151, 33);
            this.TxtPaidAmt.TabIndex = 16;
            // 
            // ReceivePayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(696, 462);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MaximizeBox = false;
            this.Name = "ReceivePayment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "[Receive Payment]";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ItemServicesCharge_FormClosing);
            this.Load += new System.EventHandler(this.ItemServicesCharge_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewItemServices)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblComplainID;
        private System.Windows.Forms.ComboBox ddlItemName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TxtRef;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridView dataGridViewItemServices;
        private System.Windows.Forms.TextBox TxtComplaintNo;
        private System.Windows.Forms.TextBox TxtAmt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtp1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox TxtRecAmt;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TxtPaidAmt;
        private System.Windows.Forms.DataGridViewTextBoxColumn PayID;
        private System.Windows.Forms.DataGridViewTextBoxColumn PayMode;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn RefNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewButtonColumn Delete;
        private System.Windows.Forms.TextBox TxtBalance;
        private System.Windows.Forms.Label label8;
    }
}