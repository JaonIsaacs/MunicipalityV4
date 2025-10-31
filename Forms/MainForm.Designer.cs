namespace MunicipalityV4.Forms
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel navPanel;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.PictureBox logoBox;
        private System.Windows.Forms.Button btnDashboard;
        private System.Windows.Forms.Button btnReportIssue;
        private System.Windows.Forms.Button btnLocalEvents;
        private System.Windows.Forms.Button btnServiceRequests;
        private System.Windows.Forms.Button btnExit;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.navPanel = new System.Windows.Forms.Panel();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnServiceRequests = new System.Windows.Forms.Button();
            this.btnLocalEvents = new System.Windows.Forms.Button();
            this.btnReportIssue = new System.Windows.Forms.Button();
            this.btnDashboard = new System.Windows.Forms.Button();
            this.logoBox = new System.Windows.Forms.PictureBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.navPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoBox)).BeginInit();
            this.SuspendLayout();
            // 
            // navPanel
            // 
            this.navPanel.BackColor = System.Drawing.Color.FromArgb(35, 40, 45);
            this.navPanel.Controls.Add(this.btnExit);
            this.navPanel.Controls.Add(this.btnServiceRequests);
            this.navPanel.Controls.Add(this.btnLocalEvents);
            this.navPanel.Controls.Add(this.btnReportIssue);
            this.navPanel.Controls.Add(this.btnDashboard);
            this.navPanel.Controls.Add(this.logoBox);
            this.navPanel.Controls.Add(this.lblTitle);
            this.navPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.navPanel.Padding = new System.Windows.Forms.Padding(10);
            this.navPanel.Size = new System.Drawing.Size(220, 661);
            // 
            // btnExit
            // 
            this.btnExit.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Text = "🚪 Exit";
            this.btnExit.Height = 50;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnServiceRequests
            // 
            this.btnServiceRequests.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnServiceRequests.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnServiceRequests.ForeColor = System.Drawing.Color.White;
            this.btnServiceRequests.Text = "📋 Service Requests";
            this.btnServiceRequests.Height = 50;
            this.btnServiceRequests.Click += new System.EventHandler(this.btnServiceRequests_Click);
            // 
            // btnLocalEvents
            // 
            this.btnLocalEvents.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnLocalEvents.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLocalEvents.ForeColor = System.Drawing.Color.White;
            this.btnLocalEvents.Text = "🎉 Local Events";
            this.btnLocalEvents.Height = 50;
            this.btnLocalEvents.Click += new System.EventHandler(this.btnLocalEvents_Click);
            // 
            // btnReportIssue
            // 
            this.btnReportIssue.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnReportIssue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReportIssue.ForeColor = System.Drawing.Color.White;
            this.btnReportIssue.Text = "📝 Report Issue";
            this.btnReportIssue.Height = 50;
            this.btnReportIssue.Click += new System.EventHandler(this.btnReportIssue_Click);
            // 
            // btnDashboard
            // 
            this.btnDashboard.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDashboard.ForeColor = System.Drawing.Color.White;
            this.btnDashboard.Text = "🏠 Dashboard";
            this.btnDashboard.Height = 50;
            this.btnDashboard.Click += new System.EventHandler(this.btnDashboard_Click);
            // 
            // logoBox
            // 
            this.logoBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.logoBox.Height = 60;
            this.logoBox.Click += new System.EventHandler(this.logoBox_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Text = "MunicipalityV4";
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTitle.Height = 50;
            // 
            // mainPanel
            // 
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.BackColor = System.Drawing.Color.FromArgb(245, 247, 250);
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(1084, 661);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.navPanel);
            this.Text = "MunicipalityV4";
            this.navPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.logoBox)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
