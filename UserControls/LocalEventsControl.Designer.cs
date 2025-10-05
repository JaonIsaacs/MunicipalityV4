using MunicipalityV4.Services;

namespace MunicipalityV4.UserControls
{
    partial class LocalEventsControl
    {
        private System.ComponentModel.IContainer components = null;
        private ListBox listEvents;
        private ListBox listRecommendations;
        private ComboBox cmbCategory;
        private DateTimePicker datePicker;
        private Button btnSearch;
        private Label lblEvents;
        private Label lblRecommendations;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            listEvents = new ListBox();
            listRecommendations = new ListBox();
            cmbCategory = new ComboBox();
            datePicker = new DateTimePicker();
            btnSearch = new Button();
            lblEvents = new Label();
            lblRecommendations = new Label();

            this.SuspendLayout();

            lblEvents.Text = "Upcoming Events:";
            lblEvents.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            lblEvents.Location = new System.Drawing.Point(20, 20);

            listEvents.Location = new System.Drawing.Point(20, 60);
            listEvents.Size = new System.Drawing.Size(500, 200);

            cmbCategory.Location = new System.Drawing.Point(20, 280);
            cmbCategory.Width = 200;
            cmbCategory.Items.AddRange(EventService.GetCategories().ToArray());

            datePicker.Location = new System.Drawing.Point(240, 280);
            datePicker.Width = 200;
            datePicker.ShowCheckBox = true;

            btnSearch.Text = "Search";
            btnSearch.Location = new System.Drawing.Point(460, 278);
            btnSearch.Click += new System.EventHandler(this.BtnSearch_Click);

            lblRecommendations.Text = "Recommended for You:";
            lblRecommendations.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            lblRecommendations.Location = new System.Drawing.Point(20, 330);

            listRecommendations.Location = new System.Drawing.Point(20, 370);
            listRecommendations.Size = new System.Drawing.Size(500, 150);

            this.Controls.Add(lblEvents);
            this.Controls.Add(listEvents);
            this.Controls.Add(cmbCategory);
            this.Controls.Add(datePicker);
            this.Controls.Add(btnSearch);
            this.Controls.Add(lblRecommendations);
            this.Controls.Add(listRecommendations);

            this.Dock = DockStyle.Fill;
            this.ResumeLayout(false);
        }
    }
}

