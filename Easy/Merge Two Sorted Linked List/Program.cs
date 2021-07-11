using System;

/* ----- Description ----- */
/*
Merge two sorted linked lists and return it as a sorted list. The list should be made by splicing together the nodes of the first two lists.

Example 1:
Input: l1 = [1,2,4], l2 = [1,3,4]
Output: [1,1,2,3,4,4]

Example 2:
Input: l1 = [], l2 = []
Output: []

Example 3:
Input: l1 = [], l2 = [0]
Output: [0]

Constraints:
The number of nodes in both lists is in the range [0, 50].
-100 <= Node.val <= 100
Both l1 and l2 are sorted in non-decreasing order.
*/

namespace Merge_Two_Sorted_Linked_List
{
    class Program
    {
        static void Main(string[] args)
        {
            ListNode l13 = new ListNode(4);
            ListNode l12 = new ListNode(2, l13);
            ListNode l1 = new ListNode(1, l12);

            ListNode l23 = new ListNode(4);
            ListNode l22 = new ListNode(3, l23);
            ListNode l2 = new ListNode(1, l22);
     
            var result = MergeTwoLists(l1, l2);

            while (result != null)
            {
                Console.WriteLine(result.val);
                result = result.next;
            }

            Console.ReadLine();
        }

        static ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            ListNode result = null;

            if (l1 == null && l2 == null)
            {
                return result;
            }

            while (l1 != null && l2 != null)
            {
                if (l1.val < l2.val)
                {
                    if (result == null)
                    {
                        result = new ListNode(l1.val, null);
                    }
                    else
                    {
                        AddLast(result, l1.val);
                    }

                    l1 = l1.next;
                }
                else
                {
                    if (result == null)
                    {
                        result = new ListNode(l2.val, null);
                    }
                    else
                    {
                        AddLast(result, l2.val);
                    }
                    l2 = l2.next;
                }
            }

            while (l1 != null)
            {
                if (result == null)
                {
                    result = new ListNode(l1.val, null);
                }
                else
                {
                    AddLast(result, l1.val);
                }
                l1 = l1.next;
            }
            while (l2 != null)
            {
                if (result == null)
                {
                    result = new ListNode(l2.val, null);
                }
                else
                {
                    AddLast(result, l2.val);
                }
                l2 = l2.next;
            }

            return result;
        }

        static void AddLast(ListNode result, int val)
        {
            ListNode temp = result;
            while (temp.next != null)
            {
                temp = temp.next;
            }
            temp.next = new ListNode(val, null);
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
