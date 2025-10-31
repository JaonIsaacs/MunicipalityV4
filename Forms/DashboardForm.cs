using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MunicipalityV4.Forms
{
    public partial class DashboardForm : Form
    {
        public DashboardForm()
        {
            Text = "Dashboard";
            BackColor = Color.White;
            var lbl = new Label
            {
                Text = "Welcome to MunicipalityV4 Dashboard!",
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter
            };
            Controls.Add(lbl);
        }
    }
}

