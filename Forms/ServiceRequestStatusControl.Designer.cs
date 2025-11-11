using System.Windows.Forms;
using System.Drawing;

/// <summary>
/// designer fixed to aid in deleppnment of this section via help of co pilot and fixed matching pointers to functionality wth adition of comments to explain each section
/// </summary>
namespace MunicipalityV4.UserControls
{
    partial class ServiceRequestStatusControl
    {
        private TableLayoutPanel layoutRoot;
        private Panel headerPanel;
        private Label lblTitle;
        private SplitContainer mainSplit;
        private Panel leftPanel;
        private TableLayoutPanel leftInner;
        private DataGridView dgvRequests;
        private Panel searchPanel;
        private TextBox txtSearch;
        private Button btnSearch;
        private ListBox lstConnections;
        private GroupBox grpLink;
        private Label lblLinkA;
        private TextBox txtRequestA;
        private Label lblLinkB;
        private TextBox txtRequestB;
        private Button btnLinkRequests;
        private Panel rightPanel;
        private Label lblGraphTitle;
        private Panel panelGraph;
        private DataGridViewTextBoxColumn colRequestId;
        private DataGridViewTextBoxColumn colDescription;
        private DataGridViewTextBoxColumn colStatus;
        private DataGridViewTextBoxColumn colProgress;

        private void InitializeComponent()
        {
            layoutRoot = new TableLayoutPanel();
            headerPanel = new Panel();
            lblTitle = new Label();
            mainSplit = new SplitContainer();
            leftPanel = new Panel();
            leftInner = new TableLayoutPanel();
            dgvRequests = new DataGridView();
            colRequestId = new DataGridViewTextBoxColumn();
            colDescription = new DataGridViewTextBoxColumn();
            colStatus = new DataGridViewTextBoxColumn();
            colProgress = new DataGridViewTextBoxColumn();
            searchPanel = new Panel();
            txtSearch = new TextBox();
            btnSearch = new Button();
            lstConnections = new ListBox();
            grpLink = new GroupBox();
            lblLinkA = new Label();
            txtRequestA = new TextBox();
            lblLinkB = new Label();
            txtRequestB = new TextBox();
            btnLinkRequests = new Button();
            rightPanel = new Panel();
            lblGraphTitle = new Label();
            panelGraph = new Panel();

            ((System.ComponentModel.ISupportInitialize)(mainSplit)).BeginInit();
            mainSplit.Panel1.SuspendLayout();
            mainSplit.Panel2.SuspendLayout();
            mainSplit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(dgvRequests)).BeginInit();
            SuspendLayout();

            // layoutRoot
            layoutRoot.ColumnCount = 1;
            layoutRoot.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            layoutRoot.RowCount = 2;
            layoutRoot.RowStyles.Add(new RowStyle(SizeType.Absolute, 64F));
            layoutRoot.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            layoutRoot.Dock = DockStyle.Fill;
            layoutRoot.Padding = new Padding(0);

            // headerPanel
            headerPanel.BackColor = Color.FromArgb(28, 72, 128);
            headerPanel.Dock = DockStyle.Fill;
            headerPanel.Padding = new Padding(12);
            headerPanel.Controls.Add(lblTitle);
            layoutRoot.Controls.Add(headerPanel, 0, 0);

            // lblTitle
            lblTitle.Dock = DockStyle.Fill;
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Text = "Service Request Status";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;

            // mainSplit
            mainSplit.Dock = DockStyle.Fill;
            mainSplit.SplitterDistance = 920;
            mainSplit.IsSplitterFixed = false;
            mainSplit.Panel1.Padding = new Padding(12);
            mainSplit.Panel2.Padding = new Padding(12);
            layoutRoot.Controls.Add(mainSplit, 0, 1);

            // leftPanel
            leftPanel.Dock = DockStyle.Fill;
            leftPanel.BackColor = Color.WhiteSmoke;
            mainSplit.Panel1.Controls.Add(leftPanel);

            // leftInner
            leftInner.ColumnCount = 1;
            leftInner.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            leftInner.RowCount = 4;
            leftInner.RowStyles.Add(new RowStyle(SizeType.Absolute, 240F));
            leftInner.RowStyles.Add(new RowStyle(SizeType.Absolute, 56F));
            leftInner.RowStyles.Add(new RowStyle(SizeType.Absolute, 120F));
            leftInner.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            leftInner.Dock = DockStyle.Fill;
            leftPanel.Controls.Add(leftInner);

            // dgvRequests
            dgvRequests.Dock = DockStyle.Fill;
            dgvRequests.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRequests.ReadOnly = true;
            dgvRequests.AllowUserToAddRows = false;
            dgvRequests.AllowUserToDeleteRows = false;
            dgvRequests.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRequests.MultiSelect = false;
            dgvRequests.RowTemplate.Height = 28;
            dgvRequests.BorderStyle = BorderStyle.FixedSingle;
            dgvRequests.EnableHeadersVisualStyles = false;

            var headerStyle = new DataGridViewCellStyle();
            headerStyle.BackColor = Color.FromArgb(28, 72, 128);
            headerStyle.ForeColor = Color.White;
            headerStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dgvRequests.ColumnHeadersDefaultCellStyle = headerStyle;

            dgvRequests.Columns.AddRange(new DataGridViewColumn[] { colRequestId, colDescription, colStatus, colProgress });
            leftInner.Controls.Add(dgvRequests, 0, 0);

            // columns
            colRequestId.HeaderText = "Request ID";
            colRequestId.Name = "colRequestId";
            colRequestId.FillWeight = 15F;

            colDescription.HeaderText = "Description";
            colDescription.Name = "colDescription";
            colDescription.FillWeight = 55F;

            colStatus.HeaderText = "Status";
            colStatus.Name = "colStatus";
            colStatus.FillWeight = 15F;

            colProgress.HeaderText = "Progress";
            colProgress.Name = "colProgress";
            colProgress.FillWeight = 15F;

            // searchPanel
            searchPanel.Dock = DockStyle.Fill;
            searchPanel.Padding = new Padding(6);
            searchPanel.BackColor = Color.White;
            txtSearch.Font = new Font("Segoe UI", 10F);
            txtSearch.Width = 420;
            txtSearch.Location = new Point(6, 12);
            btnSearch.Text = "Search";
            btnSearch.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnSearch.BackColor = Color.FromArgb(28, 72, 128);
            btnSearch.ForeColor = Color.White;
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.FlatAppearance.BorderSize = 0;
            btnSearch.Size = new Size(100, 30);
            btnSearch.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSearch.Location = new Point(600, 10);
            btnSearch.Click += btnSearch_Click;
            searchPanel.Controls.Add(txtSearch);
            searchPanel.Controls.Add(btnSearch);
            leftInner.Controls.Add(searchPanel, 0, 1);

            // lstConnections
            lstConnections.Dock = DockStyle.Fill;
            lstConnections.BorderStyle = BorderStyle.FixedSingle;
            lstConnections.Font = new Font("Segoe UI", 10F);
            leftInner.Controls.Add(lstConnections, 0, 2);

            // grpLink
            grpLink.Dock = DockStyle.Fill;
            grpLink.Padding = new Padding(8);
            grpLink.Text = "Link Service Requests";
            grpLink.Font = new Font("Segoe UI", 10F, FontStyle.Bold);

            lblLinkA.Text = "Request A:";
            lblLinkA.AutoSize = true;
            lblLinkA.Location = new Point(12, 28);
            txtRequestA.Location = new Point(92, 24);
            txtRequestA.Size = new Size(80, 26);
            lblLinkB.Text = "Request B:";
            lblLinkB.AutoSize = true;
            lblLinkB.Location = new Point(190, 28);
            txtRequestB.Location = new Point(266, 24);
            txtRequestB.Size = new Size(80, 26);
            btnLinkRequests.Text = "Link";
            btnLinkRequests.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnLinkRequests.BackColor = Color.FromArgb(39, 174, 96);
            btnLinkRequests.ForeColor = Color.White;
            btnLinkRequests.FlatStyle = FlatStyle.Flat;
            btnLinkRequests.FlatAppearance.BorderSize = 0;
            btnLinkRequests.Size = new Size(88, 30);
            btnLinkRequests.Location = new Point(360, 22);
            btnLinkRequests.Click += btnLinkRequests_Click;

            grpLink.Controls.Add(lblLinkA);
            grpLink.Controls.Add(txtRequestA);
            grpLink.Controls.Add(lblLinkB);
            grpLink.Controls.Add(txtRequestB);
            grpLink.Controls.Add(btnLinkRequests);
            leftInner.Controls.Add(grpLink, 0, 3);

            // rightPanel
            rightPanel.Dock = DockStyle.Fill;
            rightPanel.BackColor = Color.White;
            mainSplit.Panel2.Controls.Add(rightPanel);

            // lblGraphTitle
            lblGraphTitle.Text = "Dependency Graph";
            lblGraphTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblGraphTitle.Dock = DockStyle.Top;
            lblGraphTitle.Height = 36;
            lblGraphTitle.TextAlign = ContentAlignment.MiddleCenter;
            lblGraphTitle.ForeColor = Color.FromArgb(28, 72, 128);
            rightPanel.Controls.Add(lblGraphTitle);

            // panelGraph
            panelGraph.Dock = DockStyle.Fill;
            panelGraph.BackColor = Color.WhiteSmoke;
            panelGraph.BorderStyle = BorderStyle.FixedSingle;
            panelGraph.Paint += panelGraph_Paint;
            rightPanel.Controls.Add(panelGraph);

            // ServiceRequestStatusControl
            this.BackColor = Color.FromArgb(245, 247, 250);
            this.Controls.Add(layoutRoot);
            this.Name = "ServiceRequestStatusControl";
            this.Size = new Size(1582, 861);

            mainSplit.Panel1.ResumeLayout(false);
            mainSplit.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(mainSplit)).EndInit();
            mainSplit.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(dgvRequests)).EndInit();
            ResumeLayout(false);
        }
    }
}
