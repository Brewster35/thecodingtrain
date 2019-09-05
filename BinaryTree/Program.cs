using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{

    class Tree
    {
        private Node root;

        public void AddNode(int value)
        {
            if (root == null)
            {
                // create and populate the root node
                root = new Node()
                {
                    value = value
                };
            }
            else
            {
                this.root.AddSubnode(value);
            }
        }

        public void Traverse()
        {
            this.Inorder(root);
        }
        private void Inorder(Node node)
        {
            if (node == null)
            {
                return;
            }

            this.Inorder(node.left);

            Console.WriteLine(node.value);

            this.Inorder(node.right);
        }

        public void Exists(int value)
        {
            if (root.Find(value) != null)
            {
                Console.WriteLine("Value {0} appears in the tree", value);
            }
            else
            {
                Console.WriteLine("Value {0} is not in the tree", value);
            }
        }
    }

    class Node
    {
        public int value;
        public Node left;
        public Node right;

        public void AddSubnode(int _value)
        {
            if (this.value > _value &&
                this.left == null)
            {
                this.left = new Node()
                {
                    value = _value
                };
            }
            else if (this.value > _value &&
                    this.left != null)
            {
                this.left.AddSubnode(_value);
            }

            if (this.value < _value &&
                this.right == null)
            {
                this.right = new Node()
                {
                    value = _value
                };
            }
            else if (this.value < _value &&
                    this.right != null)
            {
                this.right.AddSubnode(_value);
            }
        }

        public Node Find(int value)
        {
            if (this.value == value)
            {
                return this;
            }

            if (this.value > value &&
                this.left != null)
            {
                return this.left.Find(value);
            }

            if (this.value < value &&
                this.right != null)
            {
                return this.right.Find(value);
            }

            return (Node)null;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Tree tree = new Tree();

            tree.AddNode(7);
            tree.AddNode(10);
            tree.AddNode(3);
            tree.AddNode(8);
            tree.AddNode(1);
            tree.AddNode(41);
            tree.AddNode(29);

            // tree.Exists(9);
            tree.Traverse();

            Console.ReadLine();
        }
    }
}
