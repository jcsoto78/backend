using System;
using System.Collections.Generic;
using System.Linq;

// find max sumSubTree
namespace maxSumTree
{
    // represent a tree node as a recursive data estructure

    class Node {

        public int value { get; set; }
        public List<Node> children { get; set; } = new List<Node>();

    }

    class Program
    {
        private static Stack<Node> stack = new Stack<Node>();
        private static int bestSum = 0;
        static void Main(string[] args)
        {
            // tree representation

            Node root =  new Node{
                value = 4,
            };
            root.children.Add(new Node{
                value = 2,
            });
            root.children.Add(new Node{
                value = 1,
                children = new List<Node>{new Node{value = 5}, new Node{value = 6}}
            });
            root.children.Add(new Node{
                value = 3,
                children = new List<Node>{new Node{value = 7}}
            });

            foo(root);

            Console.WriteLine($"{bestSum}");
        }

        private static void foo(Node node){

            stack.Push(node);
            // keep copy of stack
            Stack<Node> stackBackup = new Stack<Node>(stack);

            foreach (Node element in node.children)
            {
                if(stack.Count < 1)
                    stack = new Stack<Node>(stackBackup);
                
                foo(element);
            }

            // leaf node
            if(node.children.Count < 1){
                int branchSum = stack.Select(e => e.value).Sum();
                bestSum = Math.Max(branchSum, bestSum);
                stack.Clear();
            }
        }
    }
}
