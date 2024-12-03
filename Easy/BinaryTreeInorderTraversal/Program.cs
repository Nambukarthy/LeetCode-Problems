using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreeInorderTraversal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TreeNode root = new TreeNode(1);
            root.left = null;
            root.right = new TreeNode(2);
            root.right.left = new TreeNode(3);

            var result = InorderTraversal(root);


            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
          
            Console.ReadLine();
        }

        static List<int> result = new List<int>();
        static IList<int> InorderTraversal(TreeNode root)
        {
            if (root == null) return result;

            InorderTraversal(root.left);
            result.Add(root.val);
            InorderTraversal(root.right);

            return result;
        }
    }

    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }
}
