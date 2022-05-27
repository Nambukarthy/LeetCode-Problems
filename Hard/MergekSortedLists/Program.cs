using System;
using System.Collections.Generic;
/* ----- Description ----- */
/*
You are given an array of k linked-lists lists, each linked-list is sorted in ascending order.
Merge all the linked-lists into one sorted linked-list and return it.

Example 1:
Input: lists = [[1,4,5],[1,3,4],[2,6]]
Output: [1,1,2,3,4,4,5,6]
Explanation: The linked-lists are:
[
  1->4->5,
  1->3->4,
  2->6
]
merging them into one sorted list:
1->1->2->3->4->4->5->6

Example 2:
Input: lists = []
Output: []

Example 3:
Input: lists = [[]]
Output: []

Constraints:
k == lists.length
0 <= k <= 10^4
0 <= lists[i].length <= 500
-10^4 <= lists[i][j] <= 10^4
lists[i] is sorted in ascending order.
The sum of lists[i].length won't exceed 10^4.
*/


/* --- Still one test case is failing which need to be fixed. --- */
namespace MergekSortedLists
{
    class Program
    {
        static void Main(string[] args)
        {          
            ListNode l13 = new ListNode(5);
            ListNode l12 = new ListNode(4, l13);
            ListNode l1 = new ListNode(1, l12);

            ListNode l23 = new ListNode(4);
            ListNode l22 = new ListNode(3, l23);
            ListNode l2 = new ListNode(1, l22);

            ListNode l31 = new ListNode(6);
            ListNode l3 = new ListNode(2, l31);

            ListNode l42 = new ListNode(9);
            ListNode l41 = new ListNode(8, l42);
            ListNode l4 = new ListNode(4, l41);

            //ListNode[] input = new ListNode[] { l1, l2, l3, l4 };

            //ListNode[] input = new ListNode[] { };

            ListNode[] input = new ListNode[] { l1, };
            var result = MergeKLists(input);

            while (result != null)
            {
                Console.WriteLine(result.val);
                result = result.next;
            }

            Console.ReadLine();
        }

        static ListNode MergeKLists(ListNode[] lists)
        {
            ListNode TempList = null;
            ListNode MergedList = null;
            ListNode CurrentList = null;

            if (lists.Length == 0)
            {               
                return MergedList;
            }

            if (lists.Length == 1)
            {
                return lists[0];
            }

            foreach (var item in lists)
            {
                if (MergedList == null)
                {
                    MergedList = item;
                    CurrentList = null;
                    continue;
                }

                CurrentList = item;

                if (MergedList == null || CurrentList == null) continue;

                while (MergedList != null && CurrentList != null)
                {
                    if (MergedList.val <= CurrentList.val)
                    {
                        if (TempList == null)
                        {
                            TempList = new ListNode(MergedList.val, null);
                        }
                        else
                        {
                            AddLast(TempList, MergedList.val);
                        }

                        MergedList = MergedList.next;
                    }
                    else
                    {
                        if (TempList == null)
                        {
                            TempList = new ListNode(CurrentList.val, null);
                        }
                        else
                        {
                            AddLast(TempList, CurrentList.val);
                        }
                        CurrentList = CurrentList.next;
                    }
                }

                while (MergedList != null)
                {                   
                    AddLast(TempList, MergedList.val);                   
                    MergedList = MergedList.next;
                }

                while (CurrentList != null)
                {                   
                    AddLast(TempList, CurrentList.val);                    
                    CurrentList = CurrentList.next;
                }

                MergedList = TempList;
                TempList = null;              
            }
            return MergedList;
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

    class ListNode
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
