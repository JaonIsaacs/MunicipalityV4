using System;
using System.Collections.Generic;
using MunicipalityV4.Models;

namespace MunicipalityV4.DataStructures
{
    public class BSTNode
    {
        public int Key;
        public ServiceRequest Value;
        public BSTNode Left, Right;
        public BSTNode(int key, ServiceRequest value) { Key = key; Value = value; }
    }

    public class BST
    {
        public BSTNode Root;

        public void Insert(int key, ServiceRequest value)
        {
            Root = InsertRec(Root, key, value);
        }

        BSTNode InsertRec(BSTNode node, int key, ServiceRequest value)
        {
            if (node == null) return new BSTNode(key, value);
            if (key < node.Key) node.Left = InsertRec(node.Left, key, value);
            else if (key > node.Key) node.Right = InsertRec(node.Right, key, value);
            else node.Value = value;
            return node;
        }

        public ServiceRequest Search(int key)
        {
            var n = Root;
            while (n != null)
            {
                if (key == n.Key) return n.Value;
                n = key < n.Key ? n.Left : n.Right;
            }
            return null;
        }

        public List<ServiceRequest> InOrder()
        {
            var list = new List<ServiceRequest>();
            InOrderRec(Root, list);
            return list;
        }

        void InOrderRec(BSTNode node, List<ServiceRequest> list)
        {
            if (node == null) return;
            InOrderRec(node.Left, list);
            list.Add(node.Value);
            InOrderRec(node.Right, list);
        }
    }
}
