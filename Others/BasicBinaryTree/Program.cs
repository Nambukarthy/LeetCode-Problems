using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace BasicBinaryTree
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Binary Tree");
            Node root = null;
            root = Insert(root, 10);
            root = Insert(root, 20);
            root = Insert(root, 30);
            root = Insert(root, 40);
            root = Insert(root, 25);
            root = Insert(root, 16);
            root = Insert(root, 47);
            root = Insert(root, 56);
            root = Insert(root, 6);
            root = Insert(root, 107);
            root = Insert(root, 605);
            root = Insert(root, 25);
            root = Insert(root, 8);
            root = Insert(root, 4);
            root = Insert(root, 6);


            Console.WriteLine("\nLevel Order Traversal");
            LevelOrderTraversal(root);

            Console.WriteLine("\nIn Order Traversal");
            InOrderTraversal(root);

            Console.WriteLine("\nPre Order Traversal");
            PreOrderTraversal(root);

            Console.WriteLine("\nPost Order Traversal");
            PostOrderTraversal(root);


            //Node that needs to be removed.
            Delete(root, 605);

            Console.WriteLine("\nLevel Order Traversal");
            LevelOrderTraversal(root);

            Console.ReadLine();
        }

        private static Node Insert(Node root, int val)
        {
            if (root == null)
            {
                root = new Node(val);
                return root;
            }

            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                var temp = queue.Dequeue();

                if (temp.left == null)
                {
                    temp.left = new Node(val);
                    break;
                }
                queue.Enqueue(temp.left);

                if (temp.right == null)
                {
                    temp.right = new Node(val);
                    break;
                }
                queue.Enqueue(temp.right);
            }

            return root;
        }

        private static void LevelOrderTraversal(Node root)
        {
            if (root == null) return;

            Console.Write(root.data + " ");

            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(root);

            while (queue.Count != 0)
            {

                var temp = queue.Dequeue();
                if (temp.left != null)
                {
                    Console.Write(temp.left.data + " ");
                    queue.Enqueue(temp.left);
                }

                if (temp.right != null)
                {
                    Console.Write(temp.right.data + " ");
                    queue.Enqueue(temp.right);
                }
            }
        }

        private static void InOrderTraversal(Node root)
        {
            if (root == null) return;

            InOrderTraversal(root.left);
            Console.Write(root.data + " ");
            InOrderTraversal(root.right);
        }

        private static void PreOrderTraversal(Node root)
        {
            if (root == null) return;

            Console.Write(root.data + " ");
            PreOrderTraversal(root.left);
            PreOrderTraversal(root.right);
        }

        private static void PostOrderTraversal(Node root)
        {
            if (root == null) return;

            PostOrderTraversal(root.left);
            PostOrderTraversal(root.right);
            Console.Write(root.data + " ");
        }


        /// <summary>
        /// Here delete means assigning the last node value to the node that needs to be deleted and deleting the last node.
        /// </summary>
        /// <param name="root"></param>
        /// <param name="val"></param>
        /// <returns></returns>
        private static Node Delete(Node root, int val)
        {
            if (root == null) return null;

            if (root.data == val) return null;

            Queue<Node> q = new Queue<Node>();
            q.Enqueue(root);

            int lastValue = 0;

            Node lastNode = null;
            Node actualNode = null;


            //Finding the last node and also assigning the actual nodes(node that needs to be removed) values as last node value.
            while (q.Count != 0)
            {
                var temp = q.Dequeue();

                if (temp.data == val)
                {
                    actualNode = temp;
                }

                if (temp.left != null)
                {
                    q.Enqueue(temp.left);
                }

                if (temp.right != null)
                {
                    q.Enqueue(temp.right);
                }

                if (q.Count == 0 && temp.right == null && temp.left == null)
                {
                    lastValue = temp.data;
                    actualNode.data = temp.data;
                    lastNode = temp;

                }
            }


            //Deleting the last node as its value has been added to the node that needs to be removed.
            Queue<Node> q1 = new Queue<Node>();
            q1.Enqueue(root);

            while (q1.Count != 0)
            {
                var temp = q1.Dequeue();

                if (temp == lastNode)
                {
                    temp = null;
                    break;
                }

                if (temp.left != null)
                {
                    if (temp.left == lastNode)
                    {
                        temp.left = null;
                        break;
                    }
                    q1.Enqueue(temp.left);
                }

                if (temp.right != null)
                {
                    if (temp.right == lastNode)
                    {
                        temp.right = null;
                        break;
                    }

                    q1.Enqueue(temp.right);
                }
            }

            return root;
        }
    }


    public class Node
    {
        public int data;
        public Node left, right;

        public Node(int val)
        {
            data = val;
            left = right = null;
        }
    }
}
