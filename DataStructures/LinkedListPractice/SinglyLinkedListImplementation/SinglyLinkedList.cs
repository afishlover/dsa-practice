using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListPractice.SinglyLinkedListImplementation
{
    public class SinglyLinkedList<T>
    {
        public Node<T> Head { get; set; }

        // Get the size of the list
        public int Size()
        {
            var result = 0;
            var start = Head;
            while (start != null)
            {
                result++;
                if (start.Next == null)
                {
                    break;
                }
                else
                {
                    start = start.Next;
                }
            }
            Console.WriteLine($"This list has size of {result}");
            return result;
        }
        
        // Add multiple element at index
        public int InsertManyAtIndex(int index, params T[] dataNode)
        {
            if (Head == null)
            {
                return -1;
            }

            if (index < 0  || index >= Size()) 
            {
                return -1;
            }

            var start = Head;
            Node<T> prevNode = null;
            var counter = 0;
            while (start != null && counter < index)
            {
                counter++;
                prevNode = start;
                start = start.Next;
            }

            foreach (var data in dataNode)
            {
                InsertAfterNode(data, prevNode);
            }

            return 1;

        }

        // Delete at specific index
        public int DeleteByIndex(int index)
        {
            if (Head == null)
            {
                return -1;
            }

            if (index < 0 || index >= Size())
            {
                return -1;
            }

            if (index == 0)
            {
                Head = Head.Next;
                return 1;
            }

            var start = Head;
            var counter = 0;
            Node<T> prevNode = null;

            while (start != null && counter < index)
            {
                prevNode = start;
                start = start.Next;
                counter++;
            }

            if (start == null)
            {
                return -1;
            }

            prevNode.Next = start.Next;
            start = null;

            return 1;
        }

        // Get node at specific index
        public Node<T> GetNodeByIndex(int index)
        {
            Node<T>? result = null;
            if (index >= Size())
            {
                return null;
            }

            var start = Head;
            var counter = 0;

            while (start != null)
            {
                if (counter == index)
                {
                    result = start;
                }
                counter++;
                start = start.Next;
            }
            return result;
        }

        // Insert a new node before a specific node
        public void InsertBeforeNode(T data, Node<T> node)
        {
            if (Head == null)
            {
                return;
            }

            if (node == null)
            {
                return;
            }

            if (node.Equals(Head))
            {
                AddFirst(data);
                return;
            }

            var start = Head;
            while (start != null)
            {
                if (node.Equals(start.Next))
                {
                    var newNode = new Node<T> { Data = data };
                    newNode.Next = node;
                    start.Next = newNode;
                    break;
                }
                start = start.Next;
            }
        }

        // Insert a new node after a specific node
        public void InsertAfterNode(T data, Node<T> node)
        {
            if (Head == null)
            {
                return;
            }

            if (node == null)
            {
                return;
            }

            var start = Head;
            while (start != null)
            {
                if (start.Equals(node))
                {
                    var newNode = new Node<T> { Data = data };
                    newNode.Next = start.Next;
                    start.Next = newNode;
                    return;
                }
                start = start.Next;
            }
        }

        // Add new node at the begining of the list
        public void AddFirst(T data)
        {
            var newHead = new Node<T> { Data = data };
            newHead.Next = Head;
            Head = newHead;
        }

        // Add new node at the end of the list
        public void AddLast(T data)
        {
            if (Head == null)
            {
                Head = new Node<T> { Data = data };
                return;
            }

            var start = Head;
            while (start != null)
            {
                if (start.Next == null)
                {
                    start.Next = new Node<T> { Data = data };
                    break;
                }
                else
                {
                    start = start.Next;
                }
            }
        }

        public override string ToString()
        {
            var result = new List<T>();

            if (Head == null)
            {
                return "[]";
            }

            var start = Head;
            while (start != null)
            {
                result.Add(start.Data);
                start = start.Next;
            }

            return $"[{string.Join(", ", result.ToArray())}]";
        }
    }
}
