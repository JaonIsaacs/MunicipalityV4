using System;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MunicipalityV4.Models;
using MunicipalityV4.Services;
using MunicipalityV4.Forms;

namespace MunicipalityV4.UserControls
{
    public partial class ViewReportsControl : UserControl
    {
        private Issue _selected = null;

        public ViewReportsControl()
        {
            InitializeComponent();
            LoadReports();
        }

        private void LoadReports()
        {
            lstReports.Items.Clear();
            var issues = IssueService.GetAllIssues().OrderByDescending(i => i.SubmittedAt);
            foreach (var i in issues) lstReports.Items.Add(i);
        }

        private void LstReports_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstReports.SelectedItem is Issue issue)
            {
                _selected = issue;
                DisplayDetails(issue);
                cmbStatus.SelectedItem = issue.Status;
            }
            else
            {
                _selected = null;
                rtbDetails.Clear();
            }
        }
        /// <summary>
        /// display issue details in text box
        /// </summary>
        /// <param name="issue"></param>
        private void DisplayDetails(Issue issue)
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Location: {issue.Location}");
            sb.AppendLine($"Category: {issue.Category}");
            sb.AppendLine($"Submitted: {issue.SubmittedAt:g}");
            sb.AppendLine($"Status: {issue.Status}");
            sb.AppendLine();
            sb.AppendLine("Description:");
            sb.AppendLine(issue.Description);
            sb.AppendLine();
            sb.AppendLine("Attachments:");
            if (issue.Attachments != null && issue.Attachments.Count > 0)
                foreach (var a in issue.Attachments) sb.AppendLine(a);
            else sb.AppendLine("None");

            rtbDetails.Text = sb.ToString();
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (_selected == null) return;

            /// load ReportIssueControl and pass issue for editing
            var main = this.FindForm() as MainForm;
            if (main != null)
            {
                var reportCtrl = new ReportIssueControl();
                reportCtrl.LoadIssueForEdit(_selected);
                main.LoadControl(reportCtrl); /// uses public LoadControl
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (_selected == null) return;
            var confirm = MessageBox.Show("Delete this report?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm != DialogResult.Yes) return;

            var ok = IssueService.DeleteIssue(_selected.Id); /// uses Guid
            if (ok)
            {
                LoadReports();
                rtbDetails.Clear();
                _selected = null;
            }
            else
            {
                MessageBox.Show("Delete failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// undo last delete action 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnUndo_Click(object sender, EventArgs e)
        {
            var ok = IssueService.UndoDelete();
            if (ok)
            {
                LoadReports();
                MessageBox.Show("Last deleted report restored.", "Undo Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No deleted reports to restore.", "Undo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// upadte field status
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnUpdateStatus_Click(object sender, EventArgs e)
        {
            if (_selected == null) return;
            if (cmbStatus.SelectedItem == null) return;

            _selected.Status = cmbStatus.SelectedItem.ToString();
            var ok = IssueService.UpdateIssue(_selected);
            if (ok)
            {
                LoadReports();
                DisplayDetails(_selected);
            }
            else
            {
                MessageBox.Show("Failed to update status.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
