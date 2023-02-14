using System;
using System.Collections.Generic;

namespace linkedList
{
    class Node
    {
        public int value { get; set; }
        public Node sibling { get; set; } = null;
    }

    class Program
    {
        static List<Node> mergedList = new List<Node>();
        static void Main(string[] args)
        {
            List<Node> listA = new List<Node>();
            List<Node> listB = new List<Node>();

            listA.Add(new Node { value = 1, sibling = new Node { value = 2 } });
            listB.Add(new Node { value = 3, sibling = new Node { value = 4 } });

            foo(listA[0], listB[0]);

            mergedList.ForEach(e => Console.Write($"{e.value} ,"));

        }

// works for merging, but if the result has to be sorted then a quicksort
        private static void foo(Node nodeA, Node nodeB)
        {
            if(nodeA.value <= nodeB.value)
            {
                mergedList.Add(nodeA);
                mergedList.Add(nodeB);
            }
            else{
                mergedList.Add(nodeB);
                mergedList.Add(nodeA);
            }

            if(nodeA.sibling != null && nodeB.sibling != null)
            {
                foo(nodeA.sibling, nodeB.sibling);
            }

        }

        
    }


}
