namespace MunicipalityV4.Forms
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private Panel panelMenu;
        private Panel panelMain;
        private Button btnReportIssues;
        private Button btnLocalEvents;
        private Button btnViewReports;
        private Label lblTitle;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panelMenu = new Panel();
            this.panelMain = new Panel();
            this.btnReportIssues = new Button();
            this.btnLocalEvents = new Button();
            this.btnViewReports = new Button();
            this.lblTitle = new Label();
            this.SuspendLayout();

            // panelMenu
            this.panelMenu.Dock = DockStyle.Left;
            this.panelMenu.Width = 200;
            this.panelMenu.BackColor = System.Drawing.Color.LightSteelBlue;

            // lblTitle
            this.lblTitle.Text = "MunicipalityV4";
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(25, 20);
            this.lblTitle.AutoSize = true;
            this.panelMenu.Controls.Add(this.lblTitle);

            // btnReportIssues
            this.btnReportIssues.Text = "Report Issues";
            this.btnReportIssues.Location = new System.Drawing.Point(20, 80);
            this.btnReportIssues.Size = new System.Drawing.Size(160, 40);
            this.btnReportIssues.Click += new System.EventHandler(this.btnReportIssues_Click);
            this.panelMenu.Controls.Add(this.btnReportIssues);

            // btnLocalEvents
            this.btnLocalEvents.Text = "Local Events";
            this.btnLocalEvents.Location = new System.Drawing.Point(20, 140);
            this.btnLocalEvents.Size = new System.Drawing.Size(160, 40);
            this.btnLocalEvents.Click += new System.EventHandler(this.btnLocalEvents_Click);
            this.panelMenu.Controls.Add(this.btnLocalEvents);

            // btnViewReports
            this.btnViewReports.Text = "View Reports";
            this.btnViewReports.Location = new System.Drawing.Point(20, 200);
            this.btnViewReports.Size = new System.Drawing.Size(160, 40);
            this.btnViewReports.Click += new System.EventHandler(this.btnViewReports_Click);
            this.panelMenu.Controls.Add(this.btnViewReports);

            // panelMain
            this.panelMain.Dock = DockStyle.Fill;
            this.panelMain.BackColor = System.Drawing.Color.WhiteSmoke;

            // MainForm
            this.Text = "MunicipalityV4";
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelMenu);
            this.ResumeLayout(false);
        }
    }
}