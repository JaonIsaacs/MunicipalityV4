using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using MunicipalityV4.Models;
using MunicipalityV4.DataStructures;

namespace MunicipalityV4.Forms
{
    public class ServiceRequestStatusForm : Form
    {
        private DataGridView dgvRequests;
        private TreeView treeRequests;
        private ListBox lbHeap;
        private TextBox txtSearchId, txtGraphOutput;
        private Button btnSearch, btnAddSample, btnPopHeap, btnBFS, btnMST;

        private BST bst = new();
        private AVLTree avl = new();
        private MinHeap heap = new();
        private Graph graph = new();
        private Dictionary<int, ServiceRequest> allRequests = new();

        public ServiceRequestStatusForm()
        {
            Text = "Service Request Status";
            Width = 1000;
            Height = 700;
            InitializeComponents();
        }

        void InitializeComponents()
        {
            dgvRequests = new DataGridView { Left = 10, Top = 10, Width = 560, Height = 300, ReadOnly = true, AutoGenerateColumns = false };
            dgvRequests.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "ID", DataPropertyName = "Id", Width = 60 });
            dgvRequests.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Title", DataPropertyName = "Title", Width = 180 });
            dgvRequests.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Status", DataPropertyName = "Status", Width = 120 });
            dgvRequests.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Priority", DataPropertyName = "Priority", Width = 80 });

            treeRequests = new TreeView { Left = 10, Top = 320, Width = 560, Height = 300 };
            lbHeap = new ListBox { Left = 580, Top = 10, Width = 200, Height = 300 };

            txtSearchId = new TextBox { Left = 580, Top = 330, Width = 120 };
            btnSearch = new Button { Left = 710, Top = 328, Text = "Track by ID", Width = 90 };
            btnSearch.Click += BtnSearch_Click;

            btnAddSample = new Button { Left = 580, Top = 360, Text = "Add Sample Data", Width = 220 };
            btnAddSample.Click += BtnAddSample_Click;

            btnPopHeap = new Button { Left = 580, Top = 400, Text = "Pop Top Priority", Width = 220 };
            btnPopHeap.Click += BtnPopHeap_Click;

            btnBFS = new Button { Left = 580, Top = 440, Text = "Graph BFS (from ID)", Width = 220 };
            btnBFS.Click += BtnBFS_Click;

            btnMST = new Button { Left = 580, Top = 480, Text = "Compute MST", Width = 220 };
            btnMST.Click += BtnMST_Click;

            txtGraphOutput = new TextBox { Left = 800, Top = 10, Width = 170, Height = 600, Multiline = true, ScrollBars = ScrollBars.Vertical };

            Controls.AddRange(new Control[] { dgvRequests, treeRequests, lbHeap, txtSearchId, btnSearch, btnAddSample, btnPopHeap, btnBFS, btnMST, txtGraphOutput });

            RefreshUI();
        }

        void BtnSearch_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtSearchId.Text.Trim(), out int id))
            {
                MessageBox.Show("Enter a numeric ID");
                return;
            }

            var r = avl.Search(id) ?? bst.Search(id);
            if (r == null) MessageBox.Show($"No request with ID {id}");
            else MessageBox.Show($"Found: {r}\\nStatus: {r.Status}\\nPriority: {r.Priority}");
        }

        void BtnAddSample_Click(object sender, EventArgs e)
        {
            AddSampleData();
            RefreshUI();
        }

        void BtnPopHeap_Click(object sender, EventArgs e)
        {
            var top = heap.PopMin();
            if (top == null) MessageBox.Show("Heap empty");
            else MessageBox.Show($"Popped top priority: {top}");
            RefreshUI();
        }

        void BtnBFS_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtSearchId.Text.Trim(), out int id))
            {
                MessageBox.Show("Enter start ID for BFS");
                return;
            }

            var order = graph.BFS(id);
            txtGraphOutput.Text = "BFS order:\\r\\n" + string.Join(" -> ", order);
        }

        void BtnMST_Click(object sender, EventArgs e)
        {
            var edges = graph.PrimsMST();
            txtGraphOutput.Text = "MST edges:\\r\\n" + string.Join("\\r\\n", edges.Select(e => $"{e.u} - {e.v} (w={e.w})"));
        }

        void AddSampleData()
        {
            var rand = new Random();
            for (int i = 1; i <= 10; i++)
            {
                var r = new ServiceRequest(i, $"Request {i}", $"Description {i}", (RequestStatus)rand.Next(0, 5), rand.Next(1, 10));
                AddRequest(r);
            }

            graph = new Graph();
            foreach (var id in allRequests.Keys) graph.AddNode(id);
            graph.AddEdge(1, 2, 1); graph.AddEdge(1, 3, 2); graph.AddEdge(2, 4, 1.5); graph.AddEdge(3, 5, 2.2);
            graph.AddEdge(6, 7, 0.5); graph.AddEdge(7, 8, 1.1); graph.AddEdge(8, 9, 0.9); graph.AddEdge(9, 10, 1.3);
        }

        void AddRequest(ServiceRequest r)
        {
            allRequests[r.Id] = r;
            bst.Insert(r.Id, r);
            avl.Insert(r.Id, r);
            heap.Insert(r);
        }

        void RefreshUI()
        {
            dgvRequests.DataSource = null;
            dgvRequests.DataSource = allRequests.Values
                .Select(x => new { x.Id, x.Title, Status = x.Status.ToString(), x.Priority })
                .OrderBy(x => x.Id).ToList();

            treeRequests.Nodes.Clear();
            var list = bst.InOrder();
            var root = new TreeNode("In-order (BST)");
            foreach (var r in list) root.Nodes.Add(new TreeNode($"[{r.Id}] {r.Title} - {r.Status}"));
            treeRequests.Nodes.Add(root);
            treeRequests.ExpandAll();

            lbHeap.Items.Clear();
            foreach (var h in heap.ToList().OrderBy(x => x.Priority))
                lbHeap.Items.Add($"[{h.Id}] {h.Title} (P={h.Priority})");
        }
    }
}
