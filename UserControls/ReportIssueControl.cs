using System;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;
using MunicipalityV4.Models;
using MunicipalityV4.Services;

namespace MunicipalityV4.UserControls
{
    public partial class ReportIssueControl : UserControl
    {
        private Issue _editingIssue = null;

        public ReportIssueControl()
        {
            InitializeComponent();
            HookEvents();
            UpdateProgressBar();
        }

        private void HookEvents()
        {
            txtLocation.TextChanged += (s, e) => UpdateProgressBar();
            cmbCategory.SelectedIndexChanged += (s, e) => UpdateProgressBar();
            txtDescription.TextChanged += (s, e) => UpdateProgressBar();

            // these two must match the designer event wiring:
            btnAttach.Click += BtnAttach_Click;
            btnSubmit.Click += BtnSubmit_Click;
            btnClear.Click += BtnClear_Click;
        }

        private void BtnAttach_Click(object sender, EventArgs e)
        {
            using var dlg = new OpenFileDialog { Multiselect = false };
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                txtAttachment.Text = dlg.FileName;
            }
            UpdateProgressBar();
        }

        private void BtnSubmit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtLocation.Text) || cmbCategory.SelectedItem == null)
            {
                MessageBox.Show("Please provide Location and Category before submitting.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_editingIssue == null)
            {
                var issue = new Issue
                {
                    Location = txtLocation.Text.Trim(),
                    Category = cmbCategory.SelectedItem.ToString(),
                    Description = txtDescription.Text.Trim(),
                    SubmittedAt = DateTime.Now,
                    Attachments = new List<string>()
                };

                if (!string.IsNullOrWhiteSpace(txtAttachment.Text))
                    issue.Attachments.Add(txtAttachment.Text.Trim());

                IssueService.AddIssue(issue);
                MessageBox.Show("Report submitted. Thank you!", "Submitted", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // edit existing issue and persist with UpdateIssue
                _editingIssue.Location = txtLocation.Text.Trim();
                _editingIssue.Category = cmbCategory.SelectedItem.ToString();
                _editingIssue.Description = txtDescription.Text.Trim();
                _editingIssue.Attachments = new List<string>();
                if (!string.IsNullOrWhiteSpace(txtAttachment.Text))
                    _editingIssue.Attachments.Add(txtAttachment.Text.Trim());

                var ok = IssueService.UpdateIssue(_editingIssue);
                if (ok) MessageBox.Show("Report updated.", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else MessageBox.Show("Update failed - item not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                _editingIssue = null;
            }

            ClearForm();
            UpdateProgressBar();
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
            UpdateProgressBar();
        }

        public void LoadIssueForEdit(Issue issue)
        {
            if (issue == null) return;
            _editingIssue = issue;
            txtLocation.Text = issue.Location;
            cmbCategory.SelectedItem = issue.Category;
            txtDescription.Text = issue.Description;
            txtAttachment.Text = issue.Attachments != null && issue.Attachments.Count > 0 ? issue.Attachments[0] : string.Empty;
            UpdateProgressBar();
        }

        private void ClearForm()
        {
            txtLocation.Clear();
            cmbCategory.SelectedIndex = -1;
            txtDescription.Clear();
            txtAttachment.Clear();
            _editingIssue = null;
        }

        private void UpdateProgressBar()
        {
            int filled = 0;
            if (!string.IsNullOrWhiteSpace(txtLocation.Text)) filled++;
            if (cmbCategory.SelectedItem != null) filled++;
            if (!string.IsNullOrWhiteSpace(txtDescription.Text)) filled++;
            if (!string.IsNullOrWhiteSpace(txtAttachment.Text)) filled++;

            progressBar.Value = Math.Min(100, filled * 25);
            lblStatus.Text = progressBar.Value == 100 ? "Ready to submit" : $"Progress: {progressBar.Value}%";
        }
    }
}

