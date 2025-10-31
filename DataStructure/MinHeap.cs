using System;
using System.Collections.Generic;
using MunicipalityV4.Models;

namespace MunicipalityV4.DataStructures
{
    public class MinHeap
    {
        private List<ServiceRequest> heap = new List<ServiceRequest>();
        public int Count => heap.Count;

        public void Insert(ServiceRequest r)
        {
            heap.Add(r);
            int i = heap.Count - 1;
            while (i > 0 && heap[(i - 1) / 2].Priority > heap[i].Priority)
            {
                var tmp = heap[(i - 1) / 2];
                heap[(i - 1) / 2] = heap[i];
                heap[i] = tmp;
                i = (i - 1) / 2;
            }
        }

        public ServiceRequest PopMin()
        {
            if (heap.Count == 0) return null;
            var root = heap[0];
            heap[0] = heap[heap.Count - 1];
            heap.RemoveAt(heap.Count - 1);
            Heapify(0);
            return root;
        }

        void Heapify(int i)
        {
            int l = 2 * i + 1, r = 2 * i + 2, smallest = i;
            if (l < heap.Count && heap[l].Priority < heap[smallest].Priority) smallest = l;
            if (r < heap.Count && heap[r].Priority < heap[smallest].Priority) smallest = r;
            if (smallest != i)
            {
                var tmp = heap[i];
                heap[i] = heap[smallest];
                heap[smallest] = tmp;
                Heapify(smallest);
            }
        }

        public List<ServiceRequest> ToList() => new List<ServiceRequest>(heap);
    }
}
