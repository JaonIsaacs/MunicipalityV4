using System;
using System.Windows.Forms;
using MunicipalityV4.UserControls;

namespace MunicipalityV4.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        // ==========================
        // Navigation Button Handlers
        // ==========================

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            LoadControl(new DashboardControl());
        }

        private void btnReportIssue_Click(object sender, EventArgs e)
        {
            LoadControl(new ReportIssueControl());
        }

        private void btnLocalEvents_Click(object sender, EventArgs e)
        {
            LoadControl(new LocalEventsControl());
        }

        private void btnServiceRequests_Click(object sender, EventArgs e)
        {
            LoadControl(new ServiceRequestStatusControl());
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void logoBox_Click(object sender, EventArgs e)
        {
            LoadControl(new DashboardControl());
        }

        // ==========================
        // Load a UserControl dynamically
        // ==========================
        public void LoadControl(UserControl control)
        {
            mainPanel.Controls.Clear();
            control.Dock = DockStyle.Fill;
            mainPanel.Controls.Add(control);
        }
    }
}
