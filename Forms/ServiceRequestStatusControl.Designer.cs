using System.Windows.Forms;

namespace MunicipalityV4.UserControls
{
    partial class ServiceRequestStatusControl
    {
        private Label lbl;

        private void InitializeComponent()
        {
            lbl = new Label
            {
                Dock = DockStyle.Fill,
                Text = "Service Request Status Page",
                Font = new Font("Segoe UI", 16F, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter
            };
            Controls.Add(lbl);
        }
    }
}
