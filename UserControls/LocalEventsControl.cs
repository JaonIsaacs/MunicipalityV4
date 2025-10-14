using System;
using System.Linq;
using System.Windows.Forms;
using MunicipalityV4.Services;
using MunicipalityV4.Models;

namespace MunicipalityV4.UserControls
{

    public partial class LocalEventsControl : UserControl
    {
        private readonly EventService _eventService = new();

        public LocalEventsControl()
        {
            InitializeComponent();
            LoadCategories();
            LoadEvents(_eventService.GetAll());
        }

        private void LoadCategories()
        {
            cbCategory.Items.Clear();
            cbCategory.Items.Add("All");
            foreach (var cat in _eventService.GetCategories())
                cbCategory.Items.Add(cat);
            cbCategory.SelectedIndex = 0;
        }

        private void LoadEvents(IEnumerable<LocalEvent> eventsList)
        {
            lvEvents.Items.Clear();
            foreach (var ev in eventsList)
            {
                var item = new ListViewItem(ev.Title);
                item.SubItems.Add(ev.Category);
                item.SubItems.Add(ev.Location);
                item.SubItems.Add(ev.Date.ToString("dd MMM yyyy"));
                item.SubItems.Add(ev.Popularity.ToString());
                lvEvents.Items.Add(item);
            }
        }
        /// <summary>
        /// search button click event to filter events based on category and date
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string selectedCategory = cbCategory.SelectedItem.ToString() == "All" ? null : cbCategory.SelectedItem.ToString();
            DateTime? selectedDate = chkDateFilter.Checked ? dtpDate.Value : null;
            LoadEvents(_eventService.Filter(selectedCategory, selectedDate));
        }
        /// <summary>
        /// sort functionality based on criteria selected in combobo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSort_Click(object sender, EventArgs e)
        {
            string criteria = cbSortBy.SelectedItem?.ToString() ?? "Date";
            LoadEvents(_eventService.Sort(criteria));
        }

        private void btnLike_Click(object sender, EventArgs e)
        {
            if (lvEvents.SelectedItems.Count == 0)
            {
                MessageBox.Show("Select an event first!");
                return;
            }

            string title = lvEvents.SelectedItems[0].Text;
            var ev = _eventService.GetAll().FirstOrDefault(x => x.Title == title);

            if (ev != null)
            {
                _eventService.IncreasePopularity(ev);
                LoadEvents(_eventService.GetAll());
                MessageBox.Show($"You liked '{ev.Title}' Total Likes: {ev.Popularity}");
            }
        }
        /// <summary>
        /// placeholder for  date change event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void chkDateFilter_CheckedChanged(object sender, EventArgs e)
        {
            dtpDate.Enabled = chkDateFilter.Checked;
        }

    }
}
