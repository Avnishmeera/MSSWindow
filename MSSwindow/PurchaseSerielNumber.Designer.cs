namespace MSSwindow
{
    partial class PurchaseSerielNumber
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
            this.dataGridViewPurchaseSrNo = new System.Windows.Forms.DataGridView();
            this.SrNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SerielNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Action = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPurchaseSrNo)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewPurchaseSrNo
            // 
            this.dataGridViewPurchaseSrNo.AllowUserToAddRows = false;
            this.dataGridViewPurchaseSrNo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewPurchaseSrNo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPurchaseSrNo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SrNo,
            this.SerielNo,
            this.Qty,
            this.Action});
            this.dataGridViewPurchaseSrNo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewPurchaseSrNo.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewPurchaseSrNo.Name = "dataGridViewPurchaseSrNo";
            this.dataGridViewPurchaseSrNo.RowHeadersVisible = false;
            this.dataGridViewPurchaseSrNo.Size = new System.Drawing.Size(465, 296);
            this.dataGridViewPurchaseSrNo.TabIndex = 0;
            this.dataGridViewPurchaseSrNo.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewPurchaseSrNo_CellClick);
            // 
            // SrNo
            // 
            this.SrNo.FillWeight = 25F;
            this.SrNo.HeaderText = "Sr. No.";
            this.SrNo.Name = "SrNo";
            this.SrNo.ReadOnly = true;
            // 
            // SerielNo
            // 
            this.SerielNo.HeaderText = "SerielNo";
            this.SerielNo.Name = "SerielNo";
            // 
            // Qty
            // 
            this.Qty.FillWeight = 20F;
            this.Qty.HeaderText = "Qty";
            this.Qty.Name = "Qty";
            this.Qty.ReadOnly = true;
            // 
            // Action
            // 
            this.Action.FillWeight = 25F;
            this.Action.HeaderText = "Action";
            this.Action.Name = "Action";
            this.Action.Text = "Delete";
            this.Action.UseColumnTextForButtonValue = true;
            // 
            // PurchaseSerielNumber
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(465, 296);
            this.Controls.Add(this.dataGridViewPurchaseSrNo);
            this.MaximizeBox = false;
            this.Name = "PurchaseSerielNumber";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PurchaseSerielNumber";
            this.Load += new System.EventHandler(this.PurchaseSerielNumber_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPurchaseSrNo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewPurchaseSrNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn SrNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn SerielNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Qty;
        private System.Windows.Forms.DataGridViewButtonColumn Action;
    }
}