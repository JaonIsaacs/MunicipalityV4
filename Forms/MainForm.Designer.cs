namespace MunicipalityV4.Forms
{
    /// <summary>
    /// attepmt to update the main form with navigation panel and main content area
    /// </summary>
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private Panel mainPanel;
        private Panel navPanel;
        private Button btnReportIssue;
        private Button btnLocalEvents;
        private Label lblTitle;
        private PictureBox logoBox;

        private void InitializeComponent()
        {
            mainPanel = new Panel();
            logoLabel = new Label();
            navPanel = new Panel();
            btnLocalEvents = new Button();
            btnReportIssue = new Button();
            logoBox = new PictureBox();
            lblTitle = new Label();
            mainPanel.SuspendLayout();
            navPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)logoBox).BeginInit();
            SuspendLayout();
            
            mainPanel.BackColor = Color.FromArgb(245, 247, 250);
            mainPanel.Controls.Add(logoLabel);
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.Location = new Point(200, 0);
            mainPanel.Name = "mainPanel";
            mainPanel.Size = new Size(884, 661);
            mainPanel.TabIndex = 0;
            
            ///unsed logotable from previous frame work
            logoLabel.AutoSize = true;
            logoLabel.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            logoLabel.ForeColor = Color.FromArgb(33, 37, 41);
            logoLabel.Location = new Point(20, 20);
            logoLabel.Name = "logoLabel";
            logoLabel.Size = new Size(257, 37);
            logoLabel.TabIndex = 0;
            logoLabel.Text = "🏛️ MunicipalityV4";
            
          ///nav 
            navPanel.BackColor = Color.FromArgb(35, 40, 45);
            navPanel.Controls.Add(btnLocalEvents);
            navPanel.Controls.Add(logoBox);
            navPanel.Controls.Add(btnReportIssue);
            navPanel.Controls.Add(lblTitle);
            navPanel.Dock = DockStyle.Left;
            navPanel.Location = new Point(0, 0);
            navPanel.Name = "navPanel";
            navPanel.Padding = new Padding(10);
            navPanel.Size = new Size(200, 661);
            navPanel.TabIndex = 1;
             
            /// LocalEvents
            
            btnLocalEvents.BackColor = Color.FromArgb(45, 110, 180);
            btnLocalEvents.Dock = DockStyle.Top;
            btnLocalEvents.FlatAppearance.BorderSize = 0;
            btnLocalEvents.FlatStyle = FlatStyle.Flat;
            btnLocalEvents.Font = new Font("Segoe UI", 11F);
            btnLocalEvents.ForeColor = Color.White;
            btnLocalEvents.Location = new Point(10, 110);
            btnLocalEvents.Margin = new Padding(5);
            btnLocalEvents.Name = "btnLocalEvents";
            btnLocalEvents.Size = new Size(180, 50);
            btnLocalEvents.TabIndex = 0;
            btnLocalEvents.Text = "Local Events";
            btnLocalEvents.UseVisualStyleBackColor = false;
            btnLocalEvents.Click += btnLocalEvents_Click;
             
            /// part one ReportIssue
           
            btnReportIssue.BackColor = Color.FromArgb(45, 110, 180);
            btnReportIssue.Dock = DockStyle.Top;
            btnReportIssue.FlatAppearance.BorderSize = 0;
            btnReportIssue.FlatStyle = FlatStyle.Flat;
            btnReportIssue.Font = new Font("Segoe UI", 11F);
            btnReportIssue.ForeColor = Color.White;
            btnReportIssue.Location = new Point(10, 60);
            btnReportIssue.Margin = new Padding(5);
            btnReportIssue.Name = "btnReportIssue";
            btnReportIssue.Size = new Size(180, 50);
            btnReportIssue.TabIndex = 1;
            btnReportIssue.Text = "Report Issue";
            btnReportIssue.UseVisualStyleBackColor = false;
            btnReportIssue.Click += btnReportIssue_Click;
            
            logoBox.Location = new Point(51, 168);
            logoBox.Name = "logoBox";
            logoBox.Size = new Size(100, 50);
            logoBox.TabIndex = 2;
            logoBox.TabStop = false;
            logoBox.Click += logoBox_Click;
            
           
            lblTitle.Dock = DockStyle.Top;
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(10, 10);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(180, 50);
            lblTitle.TabIndex = 3;
            lblTitle.Text = "MunicipalityV4";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
             
            /// MainForm
             
            ClientSize = new Size(1084, 661);
            Controls.Add(mainPanel);
            Controls.Add(navPanel);
            Font = new Font("Segoe UI", 10F);
            MinimumSize = new Size(1100, 700);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MunicipalityV4";
            mainPanel.ResumeLayout(false);
            mainPanel.PerformLayout();
            navPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)logoBox).EndInit();
            ResumeLayout(false);
        }
        private Label logoLabel;
    }
}
