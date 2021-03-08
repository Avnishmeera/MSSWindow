namespace MSSwindow
{
    partial class frmconvertemi
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numericReminderDays = new System.Windows.Forms.NumericUpDown();
            this.ChkEmiRemider = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtinvoiceno = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dtdateofemi = new System.Windows.Forms.DateTimePicker();
            this.txtemiduration = new System.Windows.Forms.NumericUpDown();
            this.txtnumemi = new System.Windows.Forms.NumericUpDown();
            this.txttotalAmt = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dataGridViewEMI = new System.Windows.Forms.DataGridView();
            this.emidetailid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.emiid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EMIDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EMIAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReminderDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.paid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ButtonText = new System.Windows.Forms.DataGridViewButtonColumn();
            this.txtRateofInterest = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnsave = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericReminderDays)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtemiduration)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtnumemi)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEMI)).BeginInit();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.panel4, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 26.30561F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.897486F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 55.12572F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(610, 517);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(604, 45);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Schoolbook", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(218, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(168, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Convert To EMI";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.numericReminderDays);
            this.panel2.Controls.Add(this.ChkEmiRemider);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.txtinvoiceno);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.dtdateofemi);
            this.panel2.Controls.Add(this.txtemiduration);
            this.panel2.Controls.Add(this.txtnumemi);
            this.panel2.Controls.Add(this.txttotalAmt);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 54);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(604, 129);
            this.panel2.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Schoolbook", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(176, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(186, 19);
            this.label4.TabIndex = 20;
            this.label4.Text = "Reminder Before Days";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Schoolbook", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(430, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 19);
            this.label2.TabIndex = 19;
            this.label2.Text = "Enable Reminder";
            // 
            // numericReminderDays
            // 
            this.numericReminderDays.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.numericReminderDays.Location = new System.Drawing.Point(366, 88);
            this.numericReminderDays.Name = "numericReminderDays";
            this.numericReminderDays.Size = new System.Drawing.Size(55, 26);
            this.numericReminderDays.TabIndex = 18;
            // 
            // ChkEmiRemider
            // 
            this.ChkEmiRemider.AutoSize = true;
            this.ChkEmiRemider.Location = new System.Drawing.Point(578, 56);
            this.ChkEmiRemider.Name = "ChkEmiRemider";
            this.ChkEmiRemider.Size = new System.Drawing.Size(15, 14);
            this.ChkEmiRemider.TabIndex = 17;
            this.ChkEmiRemider.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Century Schoolbook", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(370, 11);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(133, 19);
            this.label9.TabIndex = 14;
            this.label9.Text = "Month Duration";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Century Schoolbook", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(223, 11);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 19);
            this.label8.TabIndex = 13;
            this.label8.Text = "No. EMI";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Schoolbook", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(191, 55);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(104, 19);
            this.label6.TabIndex = 11;
            this.label6.Text = "Install. Date";
            // 
            // txtinvoiceno
            // 
            this.txtinvoiceno.Enabled = false;
            this.txtinvoiceno.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtinvoiceno.Location = new System.Drawing.Point(4, 5);
            this.txtinvoiceno.Multiline = true;
            this.txtinvoiceno.Name = "txtinvoiceno";
            this.txtinvoiceno.Size = new System.Drawing.Size(161, 43);
            this.txtinvoiceno.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Schoolbook", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(5, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(160, 19);
            this.label3.TabIndex = 8;
            this.label3.Text = "Amount To Convert";
            // 
            // dtdateofemi
            // 
            this.dtdateofemi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtdateofemi.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtdateofemi.Location = new System.Drawing.Point(301, 49);
            this.dtdateofemi.Name = "dtdateofemi";
            this.dtdateofemi.Size = new System.Drawing.Size(120, 26);
            this.dtdateofemi.TabIndex = 6;
            // 
            // txtemiduration
            // 
            this.txtemiduration.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtemiduration.Location = new System.Drawing.Point(509, 8);
            this.txtemiduration.Name = "txtemiduration";
            this.txtemiduration.Size = new System.Drawing.Size(84, 26);
            this.txtemiduration.TabIndex = 5;
            // 
            // txtnumemi
            // 
            this.txtnumemi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtnumemi.Location = new System.Drawing.Point(301, 8);
            this.txtnumemi.Name = "txtnumemi";
            this.txtnumemi.Size = new System.Drawing.Size(59, 26);
            this.txtnumemi.TabIndex = 4;
            // 
            // txttotalAmt
            // 
            this.txttotalAmt.Enabled = false;
            this.txttotalAmt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txttotalAmt.Location = new System.Drawing.Point(4, 88);
            this.txttotalAmt.Name = "txttotalAmt";
            this.txttotalAmt.Size = new System.Drawing.Size(161, 26);
            this.txttotalAmt.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dataGridViewEMI);
            this.panel3.Controls.Add(this.txtRateofInterest);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 234);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(604, 280);
            this.panel3.TabIndex = 2;
            // 
            // dataGridViewEMI
            // 
            this.dataGridViewEMI.AllowUserToAddRows = false;
            this.dataGridViewEMI.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewEMI.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewEMI.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.emidetailid,
            this.emiid,
            this.EMIDate,
            this.EMIAmount,
            this.ReminderDate,
            this.paid,
            this.ButtonText});
            this.dataGridViewEMI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewEMI.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewEMI.Name = "dataGridViewEMI";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewEMI.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewEMI.RowHeadersVisible = false;
            this.dataGridViewEMI.Size = new System.Drawing.Size(604, 280);
            this.dataGridViewEMI.TabIndex = 2;
            this.dataGridViewEMI.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewEMI_CellContentClick);
            this.dataGridViewEMI.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridViewEMI_CellFormatting);
            // 
            // emidetailid
            // 
            this.emidetailid.DataPropertyName = "emidetailid";
            this.emidetailid.HeaderText = "emidetailid";
            this.emidetailid.Name = "emidetailid";
            this.emidetailid.Visible = false;
            // 
            // emiid
            // 
            this.emiid.DataPropertyName = "emiid";
            this.emiid.HeaderText = "emiid";
            this.emiid.Name = "emiid";
            this.emiid.Visible = false;
            // 
            // EMIDate
            // 
            this.EMIDate.DataPropertyName = "EMIDate";
            dataGridViewCellStyle1.Format = "d";
            dataGridViewCellStyle1.NullValue = null;
            this.EMIDate.DefaultCellStyle = dataGridViewCellStyle1;
            this.EMIDate.HeaderText = "EMI Date ";
            this.EMIDate.Name = "EMIDate";
            // 
            // EMIAmount
            // 
            this.EMIAmount.DataPropertyName = "EMIAmount";
            dataGridViewCellStyle2.Format = "C2";
            dataGridViewCellStyle2.NullValue = null;
            this.EMIAmount.DefaultCellStyle = dataGridViewCellStyle2;
            this.EMIAmount.HeaderText = "EMI Amount";
            this.EMIAmount.Name = "EMIAmount";
            // 
            // ReminderDate
            // 
            this.ReminderDate.DataPropertyName = "ReminderDate";
            dataGridViewCellStyle3.Format = "d";
            dataGridViewCellStyle3.NullValue = null;
            this.ReminderDate.DefaultCellStyle = dataGridViewCellStyle3;
            this.ReminderDate.HeaderText = "Reminder Date";
            this.ReminderDate.Name = "ReminderDate";
            // 
            // paid
            // 
            this.paid.DataPropertyName = "paid";
            this.paid.HeaderText = "Payment Status";
            this.paid.Name = "paid";
            // 
            // ButtonText
            // 
            this.ButtonText.DataPropertyName = "ButtonText";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.ButtonText.DefaultCellStyle = dataGridViewCellStyle4;
            this.ButtonText.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ButtonText.HeaderText = "Pay";
            this.ButtonText.Name = "ButtonText";
            this.ButtonText.Text = "Pay";
            this.ButtonText.UseColumnTextForButtonValue = true;
            // 
            // txtRateofInterest
            // 
            this.txtRateofInterest.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRateofInterest.Location = new System.Drawing.Point(136, 90);
            this.txtRateofInterest.Name = "txtRateofInterest";
            this.txtRateofInterest.Size = new System.Drawing.Size(97, 26);
            this.txtRateofInterest.TabIndex = 7;
            this.txtRateofInterest.Text = "0";
            this.txtRateofInterest.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Schoolbook", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(38, 97);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 19);
            this.label7.TabIndex = 12;
            this.label7.Text = "Interest :";
            this.label7.Visible = false;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btnClose);
            this.panel4.Controls.Add(this.btnsave);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(3, 189);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(604, 39);
            this.panel4.TabIndex = 3;
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Lucida Fax", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(313, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(90, 30);
            this.btnClose.TabIndex = 16;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnsave
            // 
            this.btnsave.Font = new System.Drawing.Font("Lucida Fax", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsave.Location = new System.Drawing.Point(201, 4);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(90, 30);
            this.btnsave.TabIndex = 15;
            this.btnsave.Text = "Save";
            this.btnsave.UseVisualStyleBackColor = true;
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
            // 
            // frmconvertemi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(610, 517);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "frmconvertemi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmconvertemi";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmconvertemi_FormClosing);
            this.Load += new System.EventHandler(this.frmconvertemi_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericReminderDays)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtemiduration)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtnumemi)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEMI)).EndInit();
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dataGridViewEMI;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtinvoiceno;
        private System.Windows.Forms.NumericUpDown txtnumemi;
        private System.Windows.Forms.TextBox txttotalAmt;
        private System.Windows.Forms.TextBox txtRateofInterest;
        private System.Windows.Forms.DateTimePicker dtdateofemi;
        private System.Windows.Forms.NumericUpDown txtemiduration;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnsave;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox ChkEmiRemider;
        private System.Windows.Forms.NumericUpDown numericReminderDays;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DataGridViewTextBoxColumn emidetailid;
        private System.Windows.Forms.DataGridViewTextBoxColumn emiid;
        private System.Windows.Forms.DataGridViewTextBoxColumn EMIDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn EMIAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReminderDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn paid;
        private System.Windows.Forms.DataGridViewButtonColumn ButtonText;
    }
}