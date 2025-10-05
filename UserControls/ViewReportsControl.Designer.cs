namespace MunicipalityV4.UserControls
{
    partial class ViewReportsControl
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ListBox lstReports;
        private System.Windows.Forms.RichTextBox rtbDetails;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUndo;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Button btnUpdateStatus;
        private System.Windows.Forms.Label lblReports;
        private System.Windows.Forms.Label lblDetails;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lstReports = new System.Windows.Forms.ListBox();
            this.rtbDetails = new System.Windows.Forms.RichTextBox();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUndo = new System.Windows.Forms.Button();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.btnUpdateStatus = new System.Windows.Forms.Button();
            this.lblReports = new System.Windows.Forms.Label();
            this.lblDetails = new System.Windows.Forms.Label();

            this.SuspendLayout();

            // Reports
            this.lblReports.Text = "Submitted Reports";
            this.lblReports.Location = new System.Drawing.Point(20, 20);
            this.lstReports.Location = new System.Drawing.Point(20, 50);
            this.lstReports.Size = new System.Drawing.Size(380, 460);
            this.lstReports.SelectedIndexChanged += new System.EventHandler(this.LstReports_SelectedIndexChanged);

            // Details
            this.lblDetails.Text = "Details";
            this.lblDetails.Location = new System.Drawing.Point(420, 20);
            this.rtbDetails.Location = new System.Drawing.Point(420, 50);
            this.rtbDetails.Size = new System.Drawing.Size(540, 300);
            this.rtbDetails.ReadOnly = true;

            // Buttons and status
            this.btnEdit.Text = "Edit";
            this.btnEdit.Location = new System.Drawing.Point(420, 370);
            this.btnEdit.Click += new System.EventHandler(this.BtnEdit_Click);

            this.btnDelete.Text = "Delete";
            this.btnDelete.Location = new System.Drawing.Point(500, 370);
            this.btnDelete.Click += new System.EventHandler(this.BtnDelete_Click);

            this.btnUndo.Text = "Undo Delete";
            this.btnUndo.Location = new System.Drawing.Point(580, 370);
            this.btnUndo.Click += new System.EventHandler(this.BtnUndo_Click);

            this.cmbStatus.Location = new System.Drawing.Point(420, 420);
            this.cmbStatus.Size = new System.Drawing.Size(160, 25);
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.Items.AddRange(new object[] { "Pending", "In Progress", "Resolved" });

            this.btnUpdateStatus.Text = "Update Status";
            this.btnUpdateStatus.Location = new System.Drawing.Point(600, 420);
            this.btnUpdateStatus.Click += new System.EventHandler(this.BtnUpdateStatus_Click);

            // Add controls
            this.Controls.Add(this.lblReports);
            this.Controls.Add(this.lstReports);
            this.Controls.Add(this.lblDetails);
            this.Controls.Add(this.rtbDetails);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUndo);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.btnUpdateStatus);

            this.Size = new System.Drawing.Size(980, 520);
            this.ResumeLayout(false);
        }
    }
}
