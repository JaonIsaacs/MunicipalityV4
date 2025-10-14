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

        private void btnReportIssue_Click(object sender, EventArgs e)
        {
            LoadControl(new ReportIssueControl());
        }

        private void btnLocalEvents_Click(object sender, EventArgs e)
        {
            LoadControl(new LocalEventsControl());
        }

        public void LoadControl(UserControl control)
        {
            mainPanel.Controls.Clear();
            control.Dock = DockStyle.Fill;
            mainPanel.Controls.Add(control);
        }

        private void logoBox_Click(object sender, EventArgs e)
        {

        }
    }
}
