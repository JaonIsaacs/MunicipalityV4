using System;
using System.Linq;
using System.Windows.Forms;
using MunicipalityV4.Services;

namespace MunicipalityV4.UserControls
{
    public partial class LocalEventsControl : UserControl
    {
        public LocalEventsControl()
        {
            InitializeComponent();
            LoadEvents();
        }

        private void LoadEvents()
        {
            listEvents.Items.Clear();
            foreach (var ev in EventService.GetUpcoming())
            {
                listEvents.Items.Add($"{ev.Title} | {ev.Category} | {ev.Date.ToShortDateString()}");
            }
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            listEvents.Items.Clear();
            var results = EventService.SearchEvents(
                cmbCategory.Text,
                datePicker.Checked ? datePicker.Value.Date : null
            );

            foreach (var ev in results)
                listEvents.Items.Add($"{ev.Title} | {ev.Category} | {ev.Date.ToShortDateString()}");

            listRecommendations.Items.Clear();
            foreach (var ev in EventService.GetRecommendations())
                listRecommendations.Items.Add($"{ev.Title} - Recommended");
        }
    }
}
