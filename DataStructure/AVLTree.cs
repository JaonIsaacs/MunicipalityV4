using System;
using System.Collections.Generic;
using MunicipalityV4.Models;

namespace MunicipalityV4.DataStructures
{
    public class AVLNode
    {
        public int Key;
        public ServiceRequest Value;
        public AVLNode Left, Right;
        public int Height;
        public AVLNode(int key, ServiceRequest value) { Key = key; Value = value; Height = 1; }
    }

    public class AVLTree
    {
        public AVLNode Root;

        int Height(AVLNode n) => n?.Height ?? 0;
        int Balance(AVLNode n) => n == null ? 0 : Height(n.Left) - Height(n.Right);

        AVLNode RightRotate(AVLNode y)
        {
            var x = y.Left;
            var T2 = x.Right;
            x.Right = y;
            y.Left = T2;
            y.Height = Math.Max(Height(y.Left), Height(y.Right)) + 1;
            x.Height = Math.Max(Height(x.Left), Height(x.Right)) + 1;
            return x;
        }

        AVLNode LeftRotate(AVLNode x)
        {
            var y = x.Right;
            var T2 = y.Left;
            y.Left = x;
            x.Right = T2;
            x.Height = Math.Max(Height(x.Left), Height(x.Right)) + 1;
            y.Height = Math.Max(Height(y.Left), Height(y.Right)) + 1;
            return y;
        }

        public void Insert(int key, ServiceRequest value) => Root = InsertRec(Root, key, value);

        AVLNode InsertRec(AVLNode node, int key, ServiceRequest value)
        {
            if (node == null) return new AVLNode(key, value);
            if (key < node.Key) node.Left = InsertRec(node.Left, key, value);
            else if (key > node.Key) node.Right = InsertRec(node.Right, key, value);
            else { node.Value = value; return node; }

            node.Height = 1 + Math.Max(Height(node.Left), Height(node.Right));
            int balance = Balance(node);

            if (balance > 1 && key < node.Left.Key) return RightRotate(node);
            if (balance < -1 && key > node.Right.Key) return LeftRotate(node);
            if (balance > 1 && key > node.Left.Key)
            {
                node.Left = LeftRotate(node.Left);
                return RightRotate(node);
            }
            if (balance < -1 && key < node.Right.Key)
            {
                node.Right = RightRotate(node.Right);
                return LeftRotate(node);
            }
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

        void InOrderRec(AVLNode node, List<ServiceRequest> list)
        {
            if (node == null) return;
            InOrderRec(node.Left, list);
            list.Add(node.Value);
            InOrderRec(node.Right, list);
        }
    }
}
