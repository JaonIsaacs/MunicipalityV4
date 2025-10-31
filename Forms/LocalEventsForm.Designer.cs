namespace MunicipalityV4.Forms
{
    partial class LocalEventsForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblEvents;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblEvents = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblEvents
            // 
            this.lblEvents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblEvents.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblEvents.Location = new System.Drawing.Point(0, 0);
            this.lblEvents.Name = "lblEvents";
            this.lblEvents.Size = new System.Drawing.Size(800, 450);
            this.lblEvents.TabIndex = 0;
            this.lblEvents.Text = "Local Events Page";
            this.lblEvents.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LocalEventsForm
            // 
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblEvents);
            this.Name = "LocalEventsForm";
            this.Text = "Local Events";
            this.ResumeLayout(false);
        }
    }
}
