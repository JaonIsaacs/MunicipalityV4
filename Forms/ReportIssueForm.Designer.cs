namespace MunicipalityV4.Forms
{
    partial class ReportIssueForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblReport;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblReport = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblReport
            // 
            this.lblReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblReport.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblReport.Location = new System.Drawing.Point(0, 0);
            this.lblReport.Name = "lblReport";
            this.lblReport.Size = new System.Drawing.Size(800, 450);
            this.lblReport.TabIndex = 0;
            this.lblReport.Text = "Report an Issue Page";
            this.lblReport.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ReportIssueForm
            // 
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblReport);
            this.Name = "ReportIssueForm";
            this.Text = "Report Issue";
            this.ResumeLayout(false);
        }
    }
}
