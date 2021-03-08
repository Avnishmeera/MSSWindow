namespace MSSwindow.Report
{
    partial class FrmPurchaseInvoice
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
            this.CRTaxInvoice = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // CRTaxInvoice
            // 
            this.CRTaxInvoice.ActiveViewIndex = -1;
            this.CRTaxInvoice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CRTaxInvoice.Cursor = System.Windows.Forms.Cursors.Default;
            this.CRTaxInvoice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CRTaxInvoice.Location = new System.Drawing.Point(0, 0);
            this.CRTaxInvoice.Name = "CRTaxInvoice";
            this.CRTaxInvoice.Size = new System.Drawing.Size(960, 503);
            this.CRTaxInvoice.TabIndex = 0;
            // 
            // FrmTaxInvoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(960, 503);
            this.Controls.Add(this.CRTaxInvoice);
            this.Name = "FrmTaxInvoice";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmTaxInvoice";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmTaxInvoice_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer CRTaxInvoice;
    }
}