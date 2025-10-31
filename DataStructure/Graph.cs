using System;
using System.Collections.Generic;
using System.Linq;

namespace MunicipalityV4.DataStructures
{
    public class Graph
    {
        private Dictionary<int, List<(int to, double weight)>> adj = new();

        public void AddNode(int id)
        {
            if (!adj.ContainsKey(id))
                adj[id] = new List<(int, double)>();
        }

        public void AddEdge(int from, int to, double weight = 1.0)
        {
            AddNode(from);
            AddNode(to);
            adj[from].Add((to, weight));
            adj[to].Add((from, weight));
        }

        public List<int> BFS(int start)
        {
            var res = new List<int>();
            if (!adj.ContainsKey(start)) return res;

            var q = new Queue<int>();
            var vis = new HashSet<int>();
            q.Enqueue(start);
            vis.Add(start);

            while (q.Count > 0)
            {
                var u = q.Dequeue();
                res.Add(u);
                foreach (var (v, _) in adj[u])
                {
                    if (!vis.Contains(v))
                    {
                        vis.Add(v);
                        q.Enqueue(v);
                    }
                }
            }
            return res;
        }

        public List<(int u, int v, double w)> PrimsMST()
        {
            var res = new List<(int, int, double)>();
            if (adj.Count == 0) return res;

            var keys = new Dictionary<int, double>();
            var parent = new Dictionary<int, int?>();
            var inMST = new HashSet<int>();

            foreach (var v in adj.Keys)
            {
                keys[v] = double.PositiveInfinity;
                parent[v] = null;
            }

            int start = adj.Keys.First();
            keys[start] = 0;

            while (inMST.Count < adj.Count)
            {
                int u = keys
                    .Where(kvp => !inMST.Contains(kvp.Key))
                    .OrderBy(kvp => kvp.Value)
                    .First().Key;

                inMST.Add(u);

                if (parent[u].HasValue)
                    res.Add((parent[u].Value, u, keys[u]));

                foreach (var (v, w) in adj[u])
                {
                    if (!inMST.Contains(v) && w < keys[v])
                    {
                        keys[v] = w;
                        parent[v] = u;
                    }
                }
            }

            return res;
        }
    }
}
