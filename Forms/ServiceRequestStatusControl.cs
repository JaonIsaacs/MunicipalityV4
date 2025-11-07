using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using MunicipalityV4.Models;
using ModelRequest = MunicipalityV4.Models.ServiceRequest;

namespace MunicipalityV4.UserControls
{
    public partial class ServiceRequestStatusControl : UserControl
    {
        private BinarySearchTree<ModelRequest> _requestTree;
        private SimpleGraph<int> _requestGraph;
        private Dictionary<int, Point> _nodePositions;
        private Random _rand;

        public ServiceRequestStatusControl()
        {
            InitializeComponent();
            _requestTree = new BinarySearchTree<ModelRequest>(r => r.Id);
            _requestGraph = new SimpleGraph<int>();
            _nodePositions = new Dictionary<int, Point>();
            _rand = new Random();

            SeedData();
            LoadRequestsToGrid();
        }

        // 🧱 Sample data - adapted to project ServiceRequest signature
        private void SeedData()
        {
            _requestTree.Insert(new ModelRequest(1001, "Pothole on Main St", "Pothole near the intersection", RequestStatus.InProgress, 2));
            _requestTree.Insert(new ModelRequest(1002, "Broken Street Light", "Lamp post not lighting", RequestStatus.Completed, 3));
            _requestTree.Insert(new ModelRequest(1003, "Water Leak on 4th Ave", "Underground leak causing pooling", RequestStatus.Submitted, 1));
            _requestTree.Insert(new ModelRequest(1004, "Garbage Collection Delay", "Missed collection for two days", RequestStatus.InProgress, 2));
            _requestTree.Insert(new ModelRequest(1005, "Park Maintenance", "General park upkeep", RequestStatus.Completed, 4));

            // Add some sample dependencies (graph stores request IDs)
            _requestGraph.AddEdge(1003, 1001); // Water leak -> pothole fix
            _requestGraph.AddEdge(1003, 1004); // Water leak -> garbage collection
        }

        // 🧾 Load data from tree to grid (adapted to ModelRequest fields)
        private void LoadRequestsToGrid()
        {
            if (dgvRequests.Rows.Count > 0)
                dgvRequests.Rows.Clear();

            var list = new List<ModelRequest>();
            _requestTree.InOrderTraversal(list);

            foreach (var req in list)
            {
                dgvRequests.Rows.Add(req.Id, req.Title, req.Status.ToString(), req.Priority);
            }
        }

        // 🔍 Search functionality
        private void btnSearch_Click(object sender, EventArgs e)
        {
            lstConnections.Items.Clear();

            if (int.TryParse(txtSearch.Text, out int id))
            {
                var result = _requestTree.Search(id);
                if (result != null)
                {
                    var connected = _requestGraph.GetConnections(id);
                    if (connected.Count > 0)
                    {
                        lstConnections.Items.Add($"Request {id} connections:");
                        foreach (var c in connected)
                        {
                            var found = _requestTree.Search(c);
                            lstConnections.Items.Add($"➡️ {c}: {found?.Title ?? "Unknown"} ({found?.Status.ToString() ?? "N/A"})");
                        }
                    }
                    else
                    {
                        lstConnections.Items.Add("No dependencies found for this request.");
                    }
                }
                else
                {
                    MessageBox.Show("No service request found with that ID.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid numeric ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            panelGraph.Invalidate();
        }

        // 🔗 Link two requests (uses IDs)
        private void btnLinkRequests_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtRequestA.Text, out int idA) && int.TryParse(txtRequestB.Text, out int idB))
            {
                if (_requestTree.Search(idA) != null && _requestTree.Search(idB) != null)
                {
                    _requestGraph.AddEdge(idA, idB);
                    MessageBox.Show($"Linked Request {idA} → Request {idB} successfully!",
                        "Linked", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    panelGraph.Invalidate();
                }
                else
                {
                    MessageBox.Show("One or both Request IDs do not exist.", "Invalid IDs", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Please enter valid numeric IDs.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 🧭 Draw the dependency graph (stable circular layout)
        private void panelGraph_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            int width = panelGraph.Width;
            int height = panelGraph.Height;

            if (width < 150 || height < 150)
                return;

            // Compute deterministic circle layout so nodes don't jump every repaint
            _nodePositions.Clear();
            var nodes = _requestGraph.GetNodes().OrderBy(n => n).ToList();
            int count = Math.Max(1, nodes.Count);
            int radius = Math.Min(width, height) / 2 - 60;
            Point center = new Point(width / 2, height / 2);

            for (int i = 0; i < nodes.Count; i++)
            {
                double angle = 2 * Math.PI * i / count;
                int x = center.X + (int)(radius * Math.Cos(angle));
                int y = center.Y + (int)(radius * Math.Sin(angle));
                _nodePositions[nodes[i]] = new Point(x, y);
            }

            using var pen = new Pen(Color.Gray, 2);
            using var nodeBrush = new SolidBrush(Color.FromArgb(45, 110, 180));
            using var textBrush = new SolidBrush(Color.White);
            using var font = new Font("Segoe UI", 9, FontStyle.Bold);

            // Draw connections
            foreach (var node in nodes)
            {
                var connections = _requestGraph.GetConnections(node);
                foreach (var target in connections)
                {
                    if (_nodePositions.ContainsKey(target))
                    {
                        Point p1 = _nodePositions[node];
                        Point p2 = _nodePositions[target];
                        g.DrawLine(pen, p1, p2);
                    }
                }
            }

            // Draw nodes
            foreach (var node in nodes)
            {
                Point p = _nodePositions[node];
                Rectangle rect = new Rectangle(p.X - 25, p.Y - 25, 50, 50);
                g.FillEllipse(nodeBrush, rect);
                g.DrawEllipse(Pens.DarkBlue, rect);

                string label = node.ToString();
                SizeF textSize = g.MeasureString(label, font);
                g.DrawString(label, font, textBrush,
                    p.X - textSize.Width / 2, p.Y - textSize.Height / 2);
            }
        }
    }

    // ==============================
    // Binary Search Tree using key selector (no IComparable requirement)
    // ==============================
    public class BinarySearchTree<T>
    {
        private class Node
        {
            public T Data;
            public Node Left;
            public Node Right;
            public int Height;
            public Node(T data) { Data = data; Height = 1; }
        }

        private Node root;
        private readonly Func<T, int> _keySelector;
        public int Count { get; private set; }

        public BinarySearchTree(Func<T, int> keySelector)
        {
            _keySelector = keySelector ?? throw new ArgumentNullException(nameof(keySelector));
        }

        public void Clear()
        {
            root = null;
            Count = 0;
        }

        public void Insert(T data)
        {
            root = InsertRec(root, data);
        }

        private Node InsertRec(Node node, T data)
        {
            if (node == null)
            {
                Count++;
                return new Node(data);
            }

            int key = _keySelector(data);
            int nodeKey = _keySelector(node.Data);
            if (key < nodeKey)
                node.Left = InsertRec(node.Left, data);
            else if (key > nodeKey)
                node.Right = InsertRec(node.Right, data);
            else
                return node; // duplicate id, ignore

            UpdateHeight(node);
            return Balance(node);
        }

        public T Search(int id)
        {
            return SearchRec(root, id);
        }

        private T SearchRec(Node node, int id)
        {
            if (node == null) return default;
            int nodeKey = _keySelector(node.Data);
            if (nodeKey == id) return node.Data;
            if (id < nodeKey) return SearchRec(node.Left, id);
            return SearchRec(node.Right, id);
        }

        public void InOrderTraversal(List<T> list)
        {
            list.Clear();
            InOrderRec(root, list);
        }

        private void InOrderRec(Node node, List<T> list)
        {
            if (node == null) return;
            InOrderRec(node.Left, list);
            list.Add(node.Data);
            InOrderRec(node.Right, list);
        }

        // AVL helpers
        private int Height(Node node) => node?.Height ?? 0;

        private void UpdateHeight(Node node)
        {
            node.Height = 1 + Math.Max(Height(node.Left), Height(node.Right));
        }

        private int GetBalance(Node node)
        {
            if (node == null) return 0;
            return Height(node.Left) - Height(node.Right);
        }

        private Node RightRotate(Node y)
        {
            Node x = y.Left;
            Node T2 = x.Right;

            x.Right = y;
            y.Left = T2;

            UpdateHeight(y);
            UpdateHeight(x);

            return x;
        }

        private Node LeftRotate(Node x)
        {
            Node y = x.Right;
            Node T2 = y.Left;

            y.Left = x;
            x.Right = T2;

            UpdateHeight(x);
            UpdateHeight(y);

            return y;
        }

        private Node Balance(Node node)
        {
            int balance = GetBalance(node);

            // Left heavy
            if (balance > 1)
            {
                if (GetBalance(node.Left) < 0)
                    node.Left = LeftRotate(node.Left);
                return RightRotate(node);
            }

            // Right heavy
            if (balance < -1)
            {
                if (GetBalance(node.Right) > 0)
                    node.Right = RightRotate(node.Right);
                return LeftRotate(node);
            }

            return node;
        }
    }

    // ==============================
    // Small directed graph implementation (renamed to avoid project Graph collisions)
    // ==============================
    public class SimpleGraph<T>
    {
        private readonly Dictionary<T, List<T>> _adjacencyList = new();

        public void AddNode(T node)
        {
            if (!_adjacencyList.ContainsKey(node))
                _adjacencyList[node] = new List<T>();
        }

        public void AddEdge(T from, T to)
        {
            AddNode(from);
            AddNode(to);

            if (!_adjacencyList[from].Contains(to))
                _adjacencyList[from].Add(to);
        }

        public List<T> GetConnections(T node)
        {
            return _adjacencyList.ContainsKey(node)
                ? new List<T>(_adjacencyList[node])
                : new List<T>();
        }

        public IEnumerable<T> GetNodes() => _adjacencyList.Keys;
    }
}
