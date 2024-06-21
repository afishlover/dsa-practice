using LinkedListPractice.SinglyLinkedListImplementation;

namespace LinkedListPractice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var singlyLinkedList = new SinglyLinkedList<int>();
            singlyLinkedList.Head = new Node<int> { Data = -1 };

            for (int i = 1; i < 10; i++)
            {
                singlyLinkedList.AddLast(i);
            }


            Console.WriteLine(singlyLinkedList.ToString());
            singlyLinkedList.InsertBeforeNode(0, singlyLinkedList.GetNodeByIndex(9));
            Console.WriteLine(singlyLinkedList.ToString());
            singlyLinkedList.DeleteByIndex(9);
            Console.WriteLine(singlyLinkedList.ToString());
            singlyLinkedList.InsertManyAtIndex(3, new int[] { -100, 1, 2, 3, 4, -500 });
            Console.WriteLine(singlyLinkedList.ToString());
        }
    }
}
