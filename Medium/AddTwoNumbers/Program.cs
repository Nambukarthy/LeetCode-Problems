using System;

/* ----- Description ----- */
/* 
You are given two non-empty linked lists representing two non-negative integers. The digits are stored in reverse order, and each of their nodes contains a single digit. Add the two numbers and return the sum as a linked list.

You may assume the two numbers do not contain any leading zero, except the number 0 itself.

Example 1:
Input: l1 = [2,4,3], l2 = [5,6,4]
Output: [7,0,8]
Explanation: 342 + 465 = 807.

Example 2:
Input: l1 = [0], l2 = [0]
Output: [0]

Example 3:
Input: l1 = [9,9,9,9,9,9,9], l2 = [9,9,9,9]
Output: [8,9,9,9,0,0,0,1]

Constraints:
The number of nodes in each linked list is in the range [1, 100].
0 <= Node.val <= 9
It is guaranteed that the list represents a number that does not have leading zeros.
*/

namespace AddTwoNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            MyLinkedList l1 = new MyLinkedList();
            l1.Add(2);
            l1.Add(4);
            l1.Add(3);

            MyLinkedList l2 = new MyLinkedList();
            l2.Add(5);
            l2.Add(6);
            l2.Add(4);

            var result = AddTwoNumbers(l1.Head, l2.Head);

            Console.WriteLine("Result");
            while (result != null)
            {   
                Console.WriteLine(result.val);
                result = result.next;
            }

            Console.ReadLine();
        }

        static ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            MyLinkedList l3 = new MyLinkedList();          
            bool isTwoDigit = false;

            while (l1 != null && l2 != null)
            {
                int val = l1.val + l2.val;

                if (isTwoDigit)
                {
                    val = val + 1;
                    isTwoDigit = false;
                }

                if (val > 9)
                {
                    val = val - 10;
                    isTwoDigit = true;
                }
                else
                {
                    isTwoDigit = false;
                }

                l3.Add(val);

                if (isTwoDigit && l1.next == null && l2.next == null)
                    l3.Add(1);

                l1 = l1.next;
                l2 = l2.next;
            }

            while (l1 != null)
            {
                int val = l1.val;

                if (isTwoDigit)
                {
                    val = val + 1;
                    isTwoDigit = false;
                }

                if (val > 9)
                {
                    val = val - 10;
                    isTwoDigit = true;
                }
                else
                {
                    isTwoDigit = false;
                }

                l3.Add(val);

                if (isTwoDigit && l1.next == null)
                    l3.Add(1);

                l1 = l1.next;              
            }

            while (l2 != null)
            {
                int val = l2.val;

                if (isTwoDigit)
                {
                    val = val + 1;
                    isTwoDigit = false;
                }

                if (val > 9)
                {
                    val = val - 10;
                    isTwoDigit = true;
                }
                else
                {
                    isTwoDigit = false;
                }

                l3.Add(val);

                if (isTwoDigit && l2.next == null)
                    l3.Add(1);

                l2 = l2.next;
            }

            return l3.Head;
        }       
    }

    public class MyLinkedList
    {
        public ListNode Head;

        public void Add(int val)
        {
            if (Head == null)
            {
                Head = new ListNode(val);               
            }
            else
            {
                var temp = Head;
                while (temp.next != null)
                {
                    temp = temp.next;
                }

                temp.next = new ListNode(val);
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
