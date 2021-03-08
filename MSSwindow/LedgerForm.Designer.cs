namespace MSSwindow
{
    partial class LedgerForm
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
            this.TblPanel = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.txtremark = new System.Windows.Forms.TextBox();
            this.LedgNo = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.TxtAmount = new System.Windows.Forms.TextBox();
            this.TxtPartyAdd = new System.Windows.Forms.TextBox();
            this.PARTYGSTIN = new System.Windows.Forms.TextBox();
            this.SUPCUST = new System.Windows.Forms.ComboBox();
            this.PaidDT = new System.Windows.Forms.DateTimePicker();
            this.cmbtype = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridViewLeger = new System.Windows.Forms.DataGridView();
            this.TranID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ledno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PartyName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PayDt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PayType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Remark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Delete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.TblPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLeger)).BeginInit();
            this.SuspendLayout();
            // 
            // TblPanel
            // 
            this.TblPanel.ColumnCount = 1;
            this.TblPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TblPanel.Controls.Add(this.panel1, 0, 0);
            this.TblPanel.Controls.Add(this.panel2, 0, 1);
            this.TblPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TblPanel.Location = new System.Drawing.Point(0, 0);
            this.TblPanel.Margin = new System.Windows.Forms.Padding(4);
            this.TblPanel.Name = "TblPanel";
            this.TblPanel.RowCount = 2;
            this.TblPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 43.7276F));
            this.TblPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 56.2724F));
            this.TblPanel.Size = new System.Drawing.Size(817, 558);
            this.TblPanel.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.txtremark);
            this.panel1.Controls.Add(this.LedgNo);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.TxtAmount);
            this.panel1.Controls.Add(this.TxtPartyAdd);
            this.panel1.Controls.Add(this.PARTYGSTIN);
            this.panel1.Controls.Add(this.SUPCUST);
            this.panel1.Controls.Add(this.PaidDT);
            this.panel1.Controls.Add(this.cmbtype);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(4, 4);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(809, 236);
            this.panel1.TabIndex = 0;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(231, 170);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 13);
            this.label8.TabIndex = 19;
            this.label8.Text = "Remark";
            // 
            // txtremark
            // 
            this.txtremark.Location = new System.Drawing.Point(295, 163);
            this.txtremark.Margin = new System.Windows.Forms.Padding(4);
            this.txtremark.MaxLength = 300;
            this.txtremark.Multiline = true;
            this.txtremark.Name = "txtremark";
            this.txtremark.Size = new System.Drawing.Size(274, 69);
            this.txtremark.TabIndex = 14;
            // 
            // LedgNo
            // 
            this.LedgNo.Enabled = false;
            this.LedgNo.Location = new System.Drawing.Point(125, 16);
            this.LedgNo.Margin = new System.Windows.Forms.Padding(4);
            this.LedgNo.Name = "LedgNo";
            this.LedgNo.Size = new System.Drawing.Size(92, 23);
            this.LedgNo.TabIndex = 17;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(8, 21);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Ledger No.";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(685, 195);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 30);
            this.button2.TabIndex = 16;
            this.button2.Text = "Reset";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(577, 196);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 30);
            this.button1.TabIndex = 15;
            this.button1.Text = "Submit";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // TxtAmount
            // 
            this.TxtAmount.Location = new System.Drawing.Point(125, 165);
            this.TxtAmount.Margin = new System.Windows.Forms.Padding(4);
            this.TxtAmount.MaxLength = 10;
            this.TxtAmount.Name = "TxtAmount";
            this.TxtAmount.Size = new System.Drawing.Size(100, 23);
            this.TxtAmount.TabIndex = 13;
            this.TxtAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtAmount_KeyPress);
            // 
            // TxtPartyAdd
            // 
            this.TxtPartyAdd.Enabled = false;
            this.TxtPartyAdd.Location = new System.Drawing.Point(125, 127);
            this.TxtPartyAdd.Margin = new System.Windows.Forms.Padding(4);
            this.TxtPartyAdd.Name = "TxtPartyAdd";
            this.TxtPartyAdd.Size = new System.Drawing.Size(660, 23);
            this.TxtPartyAdd.TabIndex = 12;
            // 
            // PARTYGSTIN
            // 
            this.PARTYGSTIN.Enabled = false;
            this.PARTYGSTIN.Location = new System.Drawing.Point(125, 92);
            this.PARTYGSTIN.Margin = new System.Windows.Forms.Padding(4);
            this.PARTYGSTIN.Name = "PARTYGSTIN";
            this.PARTYGSTIN.Size = new System.Drawing.Size(235, 23);
            this.PARTYGSTIN.TabIndex = 11;
            // 
            // SUPCUST
            // 
            this.SUPCUST.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SUPCUST.FormattingEnabled = true;
            this.SUPCUST.Location = new System.Drawing.Point(125, 52);
            this.SUPCUST.Margin = new System.Windows.Forms.Padding(4);
            this.SUPCUST.Name = "SUPCUST";
            this.SUPCUST.Size = new System.Drawing.Size(656, 25);
            this.SUPCUST.TabIndex = 1;
            this.SUPCUST.SelectedIndexChanged += new System.EventHandler(this.SUPCUST_SelectedIndexChanged);
            // 
            // PaidDT
            // 
            this.PaidDT.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.PaidDT.Location = new System.Drawing.Point(664, 12);
            this.PaidDT.Margin = new System.Windows.Forms.Padding(4);
            this.PaidDT.Name = "PaidDT";
            this.PaidDT.Size = new System.Drawing.Size(117, 23);
            this.PaidDT.TabIndex = 0;
            // 
            // cmbtype
            // 
            this.cmbtype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbtype.FormattingEnabled = true;
            this.cmbtype.Location = new System.Drawing.Point(324, 15);
            this.cmbtype.Margin = new System.Windows.Forms.Padding(4);
            this.cmbtype.Name = "cmbtype";
            this.cmbtype.Size = new System.Drawing.Size(141, 25);
            this.cmbtype.TabIndex = 8;
            this.cmbtype.SelectedIndexChanged += new System.EventHandler(this.cmbtype_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(5, 171);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Amount";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(5, 131);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Party Address";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(5, 97);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Party GSTIN";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(541, 18);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Payment Date";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(5, 60);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Party Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(229, 20);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Payment Type";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dataGridViewLeger);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(4, 248);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(809, 306);
            this.panel2.TabIndex = 1;
            // 
            // dataGridViewLeger
            // 
            this.dataGridViewLeger.AllowUserToAddRows = false;
            this.dataGridViewLeger.AllowUserToResizeColumns = false;
            this.dataGridViewLeger.AllowUserToResizeRows = false;
            this.dataGridViewLeger.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewLeger.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewLeger.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TranID,
            this.Ledno,
            this.PartyName,
            this.PayDt,
            this.PayType,
            this.Amount,
            this.Remark,
            this.Delete});
            this.dataGridViewLeger.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewLeger.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewLeger.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridViewLeger.Name = "dataGridViewLeger";
            this.dataGridViewLeger.ReadOnly = true;
            this.dataGridViewLeger.RowHeadersVisible = false;
            this.dataGridViewLeger.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewLeger.Size = new System.Drawing.Size(809, 306);
            this.dataGridViewLeger.TabIndex = 18;
            this.dataGridViewLeger.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewLeger_CellClick);
            this.dataGridViewLeger.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewLeger_CellMouseClick);
            this.dataGridViewLeger.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dataGridViewLeger_KeyPress);
            // 
            // TranID
            // 
            this.TranID.DataPropertyName = "TranID";
            this.TranID.HeaderText = "id";
            this.TranID.Name = "TranID";
            this.TranID.ReadOnly = true;
            this.TranID.Visible = false;
            // 
            // Ledno
            // 
            this.Ledno.DataPropertyName = "LedNO";
            this.Ledno.HeaderText = "Ledger NO";
            this.Ledno.Name = "Ledno";
            this.Ledno.ReadOnly = true;
            // 
            // PartyName
            // 
            this.PartyName.DataPropertyName = "PartyName";
            this.PartyName.HeaderText = "Party Name";
            this.PartyName.Name = "PartyName";
            this.PartyName.ReadOnly = true;
            // 
            // PayDt
            // 
            this.PayDt.DataPropertyName = "PayDt";
            this.PayDt.HeaderText = "Pay Date";
            this.PayDt.Name = "PayDt";
            this.PayDt.ReadOnly = true;
            // 
            // PayType
            // 
            this.PayType.DataPropertyName = "PayType";
            this.PayType.HeaderText = "Pay Type";
            this.PayType.Name = "PayType";
            this.PayType.ReadOnly = true;
            // 
            // Amount
            // 
            this.Amount.DataPropertyName = "Amount";
            this.Amount.HeaderText = "Amount";
            this.Amount.Name = "Amount";
            this.Amount.ReadOnly = true;
            // 
            // Remark
            // 
            this.Remark.DataPropertyName = "Remark";
            this.Remark.HeaderText = "Remark";
            this.Remark.Name = "Remark";
            this.Remark.ReadOnly = true;
            // 
            // Delete
            // 
            this.Delete.HeaderText = "Delete";
            this.Delete.Name = "Delete";
            this.Delete.ReadOnly = true;
            this.Delete.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Delete.Text = "Delete";
            this.Delete.UseColumnTextForButtonValue = true;
            // 
            // LedgerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(817, 558);
            this.Controls.Add(this.TblPanel);
            this.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "LedgerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LedgerForm";
            this.Load += new System.EventHandler(this.LedgerForm_Load);
            this.TblPanel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLeger)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel TblPanel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox TxtAmount;
        private System.Windows.Forms.TextBox TxtPartyAdd;
        private System.Windows.Forms.TextBox PARTYGSTIN;
        private System.Windows.Forms.ComboBox SUPCUST;
        private System.Windows.Forms.DateTimePicker PaidDT;
        private System.Windows.Forms.ComboBox cmbtype;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox LedgNo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView dataGridViewLeger;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtremark;
        private System.Windows.Forms.DataGridViewTextBoxColumn TranID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ledno;
        private System.Windows.Forms.DataGridViewTextBoxColumn PartyName;
        private System.Windows.Forms.DataGridViewTextBoxColumn PayDt;
        private System.Windows.Forms.DataGridViewTextBoxColumn PayType;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn Remark;
        private System.Windows.Forms.DataGridViewButtonColumn Delete;
    }
}