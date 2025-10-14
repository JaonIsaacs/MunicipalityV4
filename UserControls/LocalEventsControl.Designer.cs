using System.Drawing;
using System.Windows.Forms;

namespace MunicipalityV4.UserControls
{
    /// <summary>
    /// chat gpt was used to help fix opjects being pointed to related functions and data opgets as it was retuing a loading error on startup and desginer screen 
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
            lblHeader.Location = new Point(0, 0);
            lblHeader.Name = "lblHeader";
            lblHeader.Size = new Size(100, 23);
            lblHeader.TabIndex = 0;
            // 
            // gbFilters
            // 
            gbFilters.Controls.Add(cbCategory);
            gbFilters.Controls.Add(chkDateFilter);
            gbFilters.Controls.Add(dtpDate);
            gbFilters.Controls.Add(cbSortBy);
            gbFilters.Controls.Add(btnSearch);
            gbFilters.Controls.Add(btnSort);
            gbFilters.Location = new Point(0, 0);
            gbFilters.Name = "gbFilters";
            gbFilters.Size = new Size(200, 100);
            gbFilters.TabIndex = 1;
            gbFilters.TabStop = false;
            // 
            // cbCategory
            // 
            cbCategory.Location = new Point(0, 0);
            cbCategory.Name = "cbCategory";
            cbCategory.Size = new Size(121, 23);
            cbCategory.TabIndex = 0;
            // 
            // chkDateFilter
            // 
            chkDateFilter.Location = new Point(0, 0);
            chkDateFilter.Name = "chkDateFilter";
            chkDateFilter.Size = new Size(104, 24);
            chkDateFilter.TabIndex = 1;
            chkDateFilter.CheckedChanged += chkDateFilter_CheckedChanged;
            // 
            // dtpDate
            // 
            dtpDate.Location = new Point(0, 0);
            dtpDate.Name = "dtpDate";
            dtpDate.Size = new Size(200, 23);
            dtpDate.TabIndex = 2;
            // 
            // cbSortBy
            // 
            cbSortBy.Location = new Point(0, 0);
            cbSortBy.Name = "cbSortBy";
            cbSortBy.Size = new Size(121, 23);
            cbSortBy.TabIndex = 3;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(0, 0);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(75, 23);
            btnSearch.TabIndex = 4;
            btnSearch.Click += btnSearch_Click;
            // 
            // btnSort
            // 
            btnSort.Location = new Point(0, 0);
            btnSort.Name = "btnSort";
            btnSort.Size = new Size(75, 23);
            btnSort.TabIndex = 5;
            btnSort.Click += btnSort_Click;
            
            /// lvEvents
            
            lvEvents.Location = new Point(0, 0);
            lvEvents.Name = "lvEvents";
            lvEvents.Size = new Size(121, 97);
            lvEvents.TabIndex = 2;
            lvEvents.UseCompatibleStateImageBehavior = false;
            
            /// gbActions
             
            gbActions.Controls.Add(btnLike);
            gbActions.Location = new Point(0, 0);
            gbActions.Name = "gbActions";
            gbActions.Size = new Size(200, 100);
            gbActions.TabIndex = 3;
            gbActions.TabStop = false;
            
            /// btnLike
            
            btnLike.Location = new Point(0, 0);
            btnLike.Name = "btnLike";
            btnLike.Size = new Size(75, 23);
            btnLike.TabIndex = 0;
            btnLike.Click += btnLike_Click;
            
            /// LocalEventsControl
            
            BackColor = Color.WhiteSmoke;
            Controls.Add(lblHeader);
            Controls.Add(gbFilters);
            Controls.Add(lvEvents);
            Controls.Add(gbActions);
            Name = "LocalEventsControl";
            Size = new Size(700, 480);
            gbFilters.ResumeLayout(false);
            gbActions.ResumeLayout(false);
            ResumeLayout(false);
        }
    }
}
