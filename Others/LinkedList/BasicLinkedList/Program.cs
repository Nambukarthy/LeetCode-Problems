using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {                      
            MyLinkedList<string> myLinkedList = new MyLinkedList<string>();
            myLinkedList.AddLast("Namakkal");
            myLinkedList.AddLast("Erode");
            myLinkedList.AddLast("Coimbatore");
            myLinkedList.AddLast("Pallakad");
            var node = myLinkedList.Find("Coimbatore");
            myLinkedList.AddBefore("Avinashi", node);
            var node1 = myLinkedList.Find("Namakkal");
            myLinkedList.AddAfter("Tiruchengode", node1);
            var node2 = myLinkedList.Find("Coimbatore");
            myLinkedList.AddAfter("Pothanoor", node2);
        
            myLinkedList.Remove("Erode");
            myLinkedList.RemoveFirst();
            myLinkedList.RemoveLast();

            while (myLinkedList.Head != null)
            {
                Console.WriteLine(myLinkedList.Head.Value);
                myLinkedList.Head = myLinkedList.Head.Next;
            }

            Console.ReadLine();
        }
    }

    class MyLinkedList<T>
    {              
        public MyLinkedListNode<T> Head { get; set; }
        public void AddLast(T value)
        {
            if (Head == null)
            {
                Head = new MyLinkedListNode<T>(value);
            }
            else
            {
                var temp = Head;
                while (temp.Next != null)
                {
                    temp = temp.Next;
                }
                temp.Next = new MyLinkedListNode<T>(value);
            }
        }

        public void AddFirst(T value)
        {
            if (Head == null)
            {
                Head = new MyLinkedListNode<T>(value);
            }
            else
            {
                var temp = Head;
                Head = new MyLinkedListNode<T>(value);
                Head.Next = temp;
            }
        }

        public void AddAfter(T value, MyLinkedListNode<T> node)
        {
            try
            {
                if (Head == node)
                {
                    Head.Next = new MyLinkedListNode<T>(value, node.Next);
                }
                else
                {
                    var temp = Head;
                    while (temp.Next != null)
                    {
                        if (temp == node)
                        {
                            var result = new MyLinkedListNode<T>(value, node.Next);
                            temp.Next = result;
                            break;
                        }
                        temp = temp.Next;
                    }
                }
            }
            catch (Exception)
            {
                throw new Exception("Node is not in the linked list");
            }
        }

        public void AddBefore(T value, MyLinkedListNode<T> node)
        {
            try
            {
                if (Head == node)
                {
                    Head = new MyLinkedListNode<T>(value, node);
                }
                else
                {
                    var temp = Head;
                    while (temp.Next != null)
                    {                        
                        if (temp.Next == node)
                        {
                            var result = new MyLinkedListNode<T>(value, node);
                            temp.Next = result;                   
                            break;
                        }
                        temp = temp.Next;
                    }
                }                
            }
            catch (Exception)
            {
                throw new Exception("Node is not in the linked list");
            }           
        }

        public MyLinkedListNode<T> Find(T value)
        {
            var temp = Head;
            if (EqualityComparer<T>.Default.Equals(temp.Value, value)) return temp;

            while (temp.Next != null)
            {
                temp = temp.Next;
                if (EqualityComparer<T>.Default.Equals(temp.Value, value)) return temp;
            }

            return null;
        }

        public MyLinkedListNode<T> Remove(T value)
        {
            var temp = Head;

            if (EqualityComparer<T>.Default.Equals(temp.Value, value)) return temp = temp.Next;           

            while (temp != null)
            {                
                if (EqualityComparer<T>.Default.Equals(temp.Next.Value, value))
                {                    
                    temp.Next = temp.Next.Next;
                    break;
                }

                temp = temp.Next;
            }

            return null;
        }

        public MyLinkedListNode<T> RemoveFirst()
        {
            if (Head == null) return null;

            var temp = Head;
            Head = Head.Next;

            return temp;
        }

        public MyLinkedListNode<T> RemoveLast()
        {
            if (Head == null || Head.Next == null) return Head = null;

            var temp = Head;
            while (temp.Next != null)
            {                   
                if (temp.Next.Next == null)
                {
                    var result = temp.Next.Next;
                    temp.Next = null;
                    return result;
                }

                temp = temp.Next;                
            }

            return null;
        }

        public bool Contains(T value)
        {
            var temp = Head;

            while (temp != null)
            {
                if (temp.Value.ToString().Contains(value.ToString())) return true;

                temp = temp.Next;
            }

            return false;
        }
    }

    class MyLinkedListNode<T>
    {
        public T Value { get; set; }
        public MyLinkedListNode<T> Next { get; set; }

        public MyLinkedListNode(T value, MyLinkedListNode<T> next = null)
        {
            Value = value;
            Next = next;
        }
    }    
}
