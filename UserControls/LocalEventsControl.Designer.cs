using System.Drawing;
using System.Windows.Forms;

namespace MunicipalityV4.UserControls
{
    /// <summary>
    /// 
    /// 
    /// 
    /// 
    /// 
    /// ChatGPT was used to help fix objects being pointed to related functions and data objects 
    /// as it was returning a loading error on startup and designer screen.
    /// 
    /// 
    /// 
    /// 
    /// </summary>
    partial class LocalEventsControl
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblHeader;
        private ComboBox cbCategory;
        private CheckBox chkDateFilter;
        private DateTimePicker dtpDate;
        private ComboBox cbSortBy;
        private Button btnSearch;
        private Button btnSort;
        private Button btnLike;
        private ListView lvEvents;
        private GroupBox gbFilters;
        private GroupBox gbActions;

        /// <summary>
        /// Designer method used to initialize and organize controls visually.
        /// </summary>
        private void InitializeComponent()
        {
            lblHeader = new Label();
            gbFilters = new GroupBox();
            cbCategory = new ComboBox();
            chkDateFilter = new CheckBox();
            dtpDate = new DateTimePicker();
            cbSortBy = new ComboBox();
            btnSearch = new Button();
            btnSort = new Button();
            lvEvents = new ListView();
            gbActions = new GroupBox();
            btnLike = new Button();
            gbFilters.SuspendLayout();
            gbActions.SuspendLayout();
            SuspendLayout();
            // 
            // lblHeader
            // 
            lblHeader.AutoSize = true;
            lblHeader.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblHeader.ForeColor = Color.FromArgb(30, 30, 30);
            lblHeader.Location = new Point(20, 15);
            lblHeader.Name = "lblHeader";
            lblHeader.Size = new Size(267, 30);
            lblHeader.TabIndex = 0;
            lblHeader.Text = "🏛️ Local Events & Notices";
            // 
            // gbFilters
            // 
            gbFilters.Controls.Add(cbCategory);
            gbFilters.Controls.Add(chkDateFilter);
            gbFilters.Controls.Add(dtpDate);
            gbFilters.Controls.Add(cbSortBy);
            gbFilters.Controls.Add(btnSearch);
            gbFilters.Controls.Add(btnSort);
            gbFilters.Font = new Font("Segoe UI", 10F);
            gbFilters.Location = new Point(20, 60);
            gbFilters.Name = "gbFilters";
            gbFilters.Padding = new Padding(10);
            gbFilters.Size = new Size(650, 100);
            gbFilters.TabIndex = 1;
            gbFilters.TabStop = false;
            gbFilters.Text = "Search and Filter";
            // 
            // cbCategory
            // 
            cbCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cbCategory.Location = new Point(20, 35);
            cbCategory.Name = "cbCategory";
            cbCategory.Size = new Size(150, 25);
            cbCategory.TabIndex = 0;
            // 
            // chkDateFilter
            // 
            chkDateFilter.AutoSize = true;
            chkDateFilter.Location = new Point(190, 38);
            chkDateFilter.Name = "chkDateFilter";
            chkDateFilter.Size = new Size(110, 23);
            chkDateFilter.TabIndex = 1;
            chkDateFilter.Text = "Filter by Date";
            chkDateFilter.CheckedChanged += chkDateFilter_CheckedChanged;
            // 
            // dtpDate
            // 
            dtpDate.Enabled = false;
            dtpDate.Location = new Point(300, 35);
            dtpDate.Name = "dtpDate";
            dtpDate.Size = new Size(160, 25);
            dtpDate.TabIndex = 2;
            dtpDate.ValueChanged += dtpDate_ValueChanged;
            // 
            // cbSortBy
            // 
            cbSortBy.DropDownStyle = ComboBoxStyle.DropDownList;
            cbSortBy.Items.AddRange(new object[] { "Date", "Category", "Name" });
            cbSortBy.Location = new Point(480, 35);
            cbSortBy.Name = "cbSortBy";
            cbSortBy.Size = new Size(120, 25);
            cbSortBy.TabIndex = 3;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.FromArgb(0, 122, 204);
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.ForeColor = Color.White;
            btnSearch.Location = new Point(20, 70);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(100, 28);
            btnSearch.TabIndex = 4;
            btnSearch.Text = "🔍 Search";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // btnSort
            // 
            btnSort.BackColor = Color.FromArgb(40, 167, 69);
            btnSort.FlatStyle = FlatStyle.Flat;
            btnSort.ForeColor = Color.White;
            btnSort.Location = new Point(130, 70);
            btnSort.Name = "btnSort";
            btnSort.Size = new Size(100, 28);
            btnSort.TabIndex = 5;
            btnSort.Text = "⬆️ Sort";
            btnSort.UseVisualStyleBackColor = false;
            btnSort.Click += btnSort_Click;
            // 
            // lvEvents
            // 
            lvEvents.FullRowSelect = true;
            lvEvents.GridLines = true;
            lvEvents.Location = new Point(20, 180);
            lvEvents.Name = "lvEvents";
            lvEvents.Size = new Size(650, 220);
            lvEvents.TabIndex = 2;
            lvEvents.UseCompatibleStateImageBehavior = false;
            lvEvents.View = View.Details;
            // 
            // gbActions
            // 
            gbActions.Controls.Add(btnLike);
            gbActions.Font = new Font("Segoe UI", 10F);
            gbActions.Location = new Point(20, 410);
            gbActions.Name = "gbActions";
            gbActions.Size = new Size(650, 60);
            gbActions.TabIndex = 3;
            gbActions.TabStop = false;
            gbActions.Text = "User Actions";
            // 
            // btnLike
            // 
            btnLike.BackColor = Color.FromArgb(255, 99, 71);
            btnLike.FlatStyle = FlatStyle.Flat;
            btnLike.ForeColor = Color.White;
            btnLike.Location = new Point(20, 25);
            btnLike.Name = "btnLike";
            btnLike.Size = new Size(130, 28);
            btnLike.TabIndex = 0;
            btnLike.Text = "Like Event";
            btnLike.UseVisualStyleBackColor = false;
            btnLike.Click += btnLike_Click;
            // 
            // LocalEventsControl
            // 
            BackColor = Color.WhiteSmoke;
            Controls.Add(lblHeader);
            Controls.Add(gbFilters);
            Controls.Add(lvEvents);
            Controls.Add(gbActions);
            Name = "LocalEventsControl";
            Size = new Size(1305, 847);
            gbFilters.ResumeLayout(false);
            gbFilters.PerformLayout();
            gbActions.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
