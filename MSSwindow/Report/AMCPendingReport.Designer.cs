namespace MSSwindow.Report
{
    partial class AMCPendingReport
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
            this.CRV1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // CRV1
            // 
            this.CRV1.ActiveViewIndex = -1;
            this.CRV1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CRV1.Cursor = System.Windows.Forms.Cursors.Default;
            this.CRV1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CRV1.Location = new System.Drawing.Point(0, 0);
            this.CRV1.Name = "CRV1";
            this.CRV1.Size = new System.Drawing.Size(1235, 534);
            this.CRV1.TabIndex = 0;
            // 
            // AMCPendingReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1235, 534);
            this.Controls.Add(this.CRV1);
            this.Name = "AMCPendingReport";
            this.Text = "AMCPendingReport";
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer CRV1;
    }
}