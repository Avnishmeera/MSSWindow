namespace MSSwindow
{
    partial class IssueMatrialtoemp
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
            this.btntransfer = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.txtproduct = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbfrom = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.datagridIssueMatrial = new System.Windows.Forms.DataGridView();
            this.LstProduct = new System.Windows.Forms.ListBox();
            this.Productname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Unit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AvlQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Unitid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TransQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RemQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblavlstack = new System.Windows.Forms.Label();
            this.lbltotalprice = new System.Windows.Forms.Label();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datagridIssueMatrial)).BeginInit();
            this.SuspendLayout();
            // 
            // btntransfer
            // 
            this.btntransfer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btntransfer.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btntransfer.Location = new System.Drawing.Point(15, 11);
            this.btntransfer.Name = "btntransfer";
            this.btntransfer.Size = new System.Drawing.Size(105, 30);
            this.btntransfer.TabIndex = 8;
            this.btntransfer.Text = "Print";
            this.btntransfer.UseVisualStyleBackColor = false;
            this.btntransfer.Click += new System.EventHandler(this.btntransfer_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnClose.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(126, 11);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(105, 30);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.lbltotalprice);
            this.panel4.Controls.Add(this.lblavlstack);
            this.panel4.Controls.Add(this.btntransfer);
            this.panel4.Controls.Add(this.btnClose);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(3, 431);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(792, 44);
            this.panel4.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Schoolbook", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(11, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "From Location";
            // 
            // txtproduct
            // 
            this.txtproduct.Font = new System.Drawing.Font("Century Schoolbook", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtproduct.Location = new System.Drawing.Point(427, 8);
            this.txtproduct.Name = "txtproduct";
            this.txtproduct.Size = new System.Drawing.Size(344, 23);
            this.txtproduct.TabIndex = 8;
            this.txtproduct.TextChanged += new System.EventHandler(this.txtproduct_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Schoolbook", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(358, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Product";
            // 
            // cmbfrom
            // 
            this.cmbfrom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbfrom.Font = new System.Drawing.Font("Century Schoolbook", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbfrom.FormattingEnabled = true;
            this.cmbfrom.Location = new System.Drawing.Point(126, 7);
            this.cmbfrom.Name = "cmbfrom";
            this.cmbfrom.Size = new System.Drawing.Size(215, 24);
            this.cmbfrom.TabIndex = 4;
            this.cmbfrom.SelectedIndexChanged += new System.EventHandler(this.cmbfrom_SelectedIndexChanged);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.panel2.Controls.Add(this.LstProduct);
            this.panel2.Controls.Add(this.txtproduct);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.cmbfrom);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 46);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(792, 89);
            this.panel2.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Schoolbook", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(302, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(226, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Inventory Stock Item ";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(792, 37);
            this.panel1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.datagridIssueMatrial, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel4, 0, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.15801F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22.19626F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 67.75701F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 49F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(798, 478);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // datagridIssueMatrial
            // 
            this.datagridIssueMatrial.AllowUserToAddRows = false;
            this.datagridIssueMatrial.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.datagridIssueMatrial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagridIssueMatrial.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Productname,
            this.Unit,
            this.Price,
            this.AvlQty,
            this.Unitid,
            this.TransQty,
            this.RemQty});
            this.datagridIssueMatrial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.datagridIssueMatrial.Location = new System.Drawing.Point(3, 141);
            this.datagridIssueMatrial.Name = "datagridIssueMatrial";
            this.datagridIssueMatrial.RowHeadersVisible = false;
            this.datagridIssueMatrial.Size = new System.Drawing.Size(792, 284);
            this.datagridIssueMatrial.TabIndex = 3;
            // 
            // LstProduct
            // 
            this.LstProduct.FormattingEnabled = true;
            this.LstProduct.Location = new System.Drawing.Point(427, 30);
            this.LstProduct.Name = "LstProduct";
            this.LstProduct.Size = new System.Drawing.Size(344, 56);
            this.LstProduct.TabIndex = 13;
            this.LstProduct.Visible = false;
            this.LstProduct.Click += new System.EventHandler(this.LstProduct_Click);
            // 
            // Productname
            // 
            this.Productname.DataPropertyName = "Productname";
            this.Productname.HeaderText = "Product Name";
            this.Productname.Name = "Productname";
            this.Productname.ReadOnly = true;
            // 
            // Unit
            // 
            this.Unit.DataPropertyName = "Unitname";
            this.Unit.HeaderText = "Unit";
            this.Unit.Name = "Unit";
            this.Unit.ReadOnly = true;
            // 
            // Price
            // 
            this.Price.DataPropertyName = "Price";
            this.Price.HeaderText = "Price";
            this.Price.Name = "Price";
            this.Price.ReadOnly = true;
            // 
            // AvlQty
            // 
            this.AvlQty.DataPropertyName = "AvlQty";
            this.AvlQty.HeaderText = "Available Stock";
            this.AvlQty.Name = "AvlQty";
            this.AvlQty.ReadOnly = true;
            // 
            // Unitid
            // 
            this.Unitid.DataPropertyName = "Unitid";
            this.Unitid.HeaderText = "Unitid";
            this.Unitid.Name = "Unitid";
            this.Unitid.Visible = false;
            // 
            // TransQty
            // 
            this.TransQty.DataPropertyName = "TransQty";
            this.TransQty.HeaderText = "TransQty";
            this.TransQty.Name = "TransQty";
            this.TransQty.Visible = false;
            // 
            // RemQty
            // 
            this.RemQty.DataPropertyName = "RemQty";
            this.RemQty.HeaderText = "RemQty";
            this.RemQty.Name = "RemQty";
            this.RemQty.Visible = false;
            // 
            // lblavlstack
            // 
            this.lblavlstack.AutoSize = true;
            this.lblavlstack.Font = new System.Drawing.Font("Century Schoolbook", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblavlstack.Location = new System.Drawing.Point(527, 14);
            this.lblavlstack.Name = "lblavlstack";
            this.lblavlstack.Size = new System.Drawing.Size(18, 19);
            this.lblavlstack.TabIndex = 14;
            this.lblavlstack.Text = "0";
            // 
            // lbltotalprice
            // 
            this.lbltotalprice.AutoSize = true;
            this.lbltotalprice.Font = new System.Drawing.Font("Century Schoolbook", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltotalprice.Location = new System.Drawing.Point(320, 14);
            this.lbltotalprice.Name = "lbltotalprice";
            this.lbltotalprice.Size = new System.Drawing.Size(18, 19);
            this.lbltotalprice.TabIndex = 15;
            this.lbltotalprice.Text = "0";
            // 
            // IssueMatrialtoemp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(798, 478);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MaximizeBox = false;
            this.Name = "IssueMatrialtoemp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inventory Stock Item";
            this.Load += new System.EventHandler(this.IssueMatrialtoemp_Load);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.datagridIssueMatrial)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btntransfer;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtproduct;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbfrom;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView datagridIssueMatrial;
        private System.Windows.Forms.ListBox LstProduct;
        private System.Windows.Forms.DataGridViewTextBoxColumn Productname;
        private System.Windows.Forms.DataGridViewTextBoxColumn Unit;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn AvlQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn Unitid;
        private System.Windows.Forms.DataGridViewTextBoxColumn TransQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn RemQty;
        private System.Windows.Forms.Label lblavlstack;
        private System.Windows.Forms.Label lbltotalprice;
    }
}