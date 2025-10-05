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

        public void LoadControl(UserControl control)
        {
            panelMain.Controls.Clear();
            control.Dock = DockStyle.Fill;
            panelMain.Controls.Add(control);
        }

        private void btnReportIssues_Click(object sender, EventArgs e)
        {
            LoadControl(new ReportIssueControl());
        }

        private void btnLocalEvents_Click(object sender, EventArgs e)
        {
            LoadControl(new LocalEventsControl());
        }

        private void btnViewReports_Click(object sender, EventArgs e)
        {
            LoadControl(new ViewReportsControl());
        }
    }
}