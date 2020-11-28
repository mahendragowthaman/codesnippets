using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResxTest
{
    public class BST
    {
        private Node root { get; set; }

        private Node currentRoot { get; set; }
        public Node GetTree()
        {
            return root;
        }


        public void Insert(int item)
        {
            if (root == null)
            {
                root = new Node();
                root.item = item;
            }
            else
            {
                InsertNode(item, root);
                return;

            }

        }

        public void inorder(Node _root)
        {
            if (_root == null)
            {
                return;
            }
            else
            {

                inorder(_root.leftNode); //LEFT
                Console.WriteLine(_root.item);//ROOT
                inorder(_root.rightNode);//RIGHT

            }
        }

        public void postorder(Node _root)
        {
            if (_root == null)
            {
                return;
            }
            else
            {

                postorder(_root.leftNode); //LEFT               
                postorder(_root.rightNode);//RIGHT
                Console.WriteLine(_root.item);//ROOT
            }
        }

        public void preorder(Node _root)
        {
            if (_root == null)
            {
                return;
            }
            else
            {
                Console.WriteLine(_root.item);//ROOT
                preorder(_root.leftNode); //LEFT               
                preorder(_root.rightNode);//RIGHT
            }
        }

        public Node KthLargest(Node _root, int K)
        {
            Node curr = _root;
            Node KLargest = null;

            while (curr != null)
            {
                if (curr.rightNode == null)
                {

                }
            }

            return KLargest;
        }


        private void InsertNode(int item, Node _root)
        {
            currentRoot = _root;
            while (true)
            {
                if (item < currentRoot.item)
                {
                    if (currentRoot.leftNode == null)
                    {
                        currentRoot.leftNode = new Node()
                        {
                            item = item
                        };
                        return;
                    }
                    else
                    {
                        currentRoot = currentRoot.leftNode;
                        InsertNode(item, currentRoot);
                        return;
                    }
                }
                else
                {
                    if (currentRoot.rightNode == null)
                    {
                        currentRoot.rightNode = new Node()
                        {
                            item = item
                        };
                        return;
                    }
                    else
                    {
                        currentRoot = currentRoot.rightNode;
                        InsertNode(item, currentRoot);
                        return;
                    }
                }
            }
        }

        public class Node
        {
            public int item { get; set; }
            public Node leftNode { get; set; }
            public Node rightNode { get; set; }
        }
    }


}
