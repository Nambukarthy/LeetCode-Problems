using System;
/* ----- Description ----- */
/*
Given the head of a sorted linked list, delete all duplicates such that each element appears only once. Return the linked list sorted as well.

Example 1:
Input: head = [1,1,2]
Output: [1,2]

Example 2:
Input: head = [1,1,2,3,3]
Output: [1,2,3]
 
Constraints:
The number of nodes in the list is in the range [0, 300].
-100 <= Node.val <= 100
The list is guaranteed to be sorted in ascending order.
*/

namespace RemoveDuplicatesFromSortedList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ListNode node5 = new ListNode(3, null);
            ListNode node4 = new ListNode(3, node5);
            ListNode node3 = new ListNode(2, node4);
            ListNode node2 = new ListNode(1, node3);
            ListNode head = new ListNode(1, node2);

            //PrintNodeValues(DeleteDuplicatesWithAuxiliaryLinkedList(head));
            PrintNodeValues(DeleteDuplicates(head));
            Console.ReadLine();
        }

        #region Not an optimal solution

        static ListNode result;
        static ListNode DeleteDuplicatesWithAuxiliaryLinkedList(ListNode head)
        {
            if (head == null) return null;

            while (head != null)
            {
                if (head.next != null && head.next.val == head.val)
                {
                    head = head.next;
                    continue;
                }

                AddNode(head);
                head = head.next;
            }
            return result;
        }

        static void AddNode(ListNode node)
        {
            if (result == null)
                result = new ListNode(node.val, null);
            else
            {
                var temp = result;
                while (temp.next != null)
                {
                    temp = temp.next;
                }
                temp.next = new ListNode(node.val);
            }
        }
        #endregion

        #region Ideal Solution        
        static ListNode DeleteDuplicates(ListNode head)
        {
            if (head == null) return null;
            if (head.next == null) return head;

            ListNode temp = head;
            while (temp.next != null)
            {
                if (temp.next.val == temp.val)
                    temp.next = temp.next.next;
                else
                    temp = temp.next;
            }

            return head;
        }
        #endregion

        static void PrintNodeValues(ListNode head)
        {
            while (head != null)
            {
                Console.WriteLine(head.val);
                head = head.next;
            }
        }
    }

    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }
}
