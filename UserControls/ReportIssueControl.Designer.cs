namespace MunicipalityV4.UserControls
{
    partial class ReportIssueControl
    {
        private System.Windows.Forms.Button btnClear;
        private System.ComponentModel.IContainer components = null;
        private TextBox txtLocation;
        private ComboBox cmbCategory;
        private TextBox txtDescription;
        private TextBox txtAttachment;
        private Button btnAttach;
        private Button btnSubmit;
        private ProgressBar progressBar;
        private Label lblStatus;
        private Label lblTitle;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            btnClear = new Button();
            txtLocation = new TextBox();
            cmbCategory = new ComboBox();
            txtDescription = new TextBox();
            txtAttachment = new TextBox();
            btnAttach = new Button();
            btnSubmit = new Button();
            progressBar = new ProgressBar();
            lblStatus = new Label();
            lblTitle = new Label();
            SuspendLayout();
            // 
            // btnClear
            // 
            btnClear.Location = new Point(380, 300);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(75, 30);
            btnClear.TabIndex = 0;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            // 
            // txtLocation
            // 
            txtLocation.Location = new Point(20, 70);
            txtLocation.Name = "txtLocation";
            txtLocation.PlaceholderText = "Enter location";
            txtLocation.Size = new Size(250, 23);
            txtLocation.TabIndex = 2;
            // 
            // cmbCategory
            // 
            cmbCategory.Items.AddRange(new object[] { "Sanitation", "Infrastructure", "Safety", "Other" });
            cmbCategory.Location = new Point(20, 110);
            cmbCategory.Name = "cmbCategory";
            cmbCategory.Size = new Size(250, 23);
            cmbCategory.TabIndex = 3;
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(20, 150);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(350, 100);
            txtDescription.TabIndex = 4;
            // 
            // txtAttachment
            // 
            txtAttachment.Location = new Point(20, 270);
            txtAttachment.Name = "txtAttachment";
            txtAttachment.ReadOnly = true;
            txtAttachment.Size = new Size(250, 23);
            txtAttachment.TabIndex = 5;
            // 
            // btnAttach
            // 
            btnAttach.Location = new Point(280, 268);
            btnAttach.Name = "btnAttach";
            btnAttach.Size = new Size(75, 23);
            btnAttach.TabIndex = 6;
            btnAttach.Text = "Attach File";
            btnAttach.Click += BtnAttach_Click;
            // 
            // btnSubmit
            // 
            btnSubmit.Location = new Point(20, 320);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(75, 23);
            btnSubmit.TabIndex = 7;
            btnSubmit.Text = "Submit";
            btnSubmit.Click += BtnSubmit_Click;
            // 
            // progressBar
            // 
            progressBar.Location = new Point(20, 360);
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(350, 23);
            progressBar.TabIndex = 8;
            // 
            // lblStatus
            // 
            lblStatus.Location = new Point(20, 390);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(350, 23);
            lblStatus.TabIndex = 9;
            // 
            // lblTitle
            // 
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.Location = new Point(20, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(100, 23);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "Report an Issue";
            // 
            // ReportIssueControl
            // 
            Controls.Add(btnClear);
            Controls.Add(lblTitle);
            Controls.Add(txtLocation);
            Controls.Add(cmbCategory);
            Controls.Add(txtDescription);
            Controls.Add(txtAttachment);
            Controls.Add(btnAttach);
            Controls.Add(btnSubmit);
            Controls.Add(progressBar);
            Controls.Add(lblStatus);
            Name = "ReportIssueControl";
            Size = new Size(607, 747);
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
