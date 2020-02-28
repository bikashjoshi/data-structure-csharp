using Common;
using System;
using System.Diagnostics;
using System.Linq;

namespace ConsoleTestApp.specs
{
    public class TreeTraversalSpecs
    {
        public static void Validate<T>() where T : BinaryTree<int>, ITreeTraversal<int>, new()
        {
            Console.WriteLine(Environment.NewLine + "******************** RUNNING TREE TRAVERSAL VALIDATION ********************");
            var mainTree = Activator.CreateInstance<T>();
            mainTree.RootItem = 20;
            mainTree.AttachLeft(10);

            var rightChildTree = Activator.CreateInstance<T>();
            rightChildTree.RootItem = 40;
            rightChildTree.AttachLeft(30);
            rightChildTree.AttachRight(50);
            
            mainTree.AttachRightSubtree(rightChildTree);

            var items = mainTree.GetItems(TreeTraversal.InOrder).ToList();
            Debug.Assert(items.Count == 5);
            Debug.Assert(items[0] == 10);
            Debug.Assert(items[1] == 20);
            Debug.Assert(items[2] == 30);
            Debug.Assert(items[3] == 40);
            Debug.Assert(items[4] == 50);

            items = mainTree.GetItems(TreeTraversal.PreOrder).ToList();
            Debug.Assert(items.Count == 5);
            Debug.Assert(items[0] == 20);
            Debug.Assert(items[1] == 10);
            Debug.Assert(items[2] == 40);
            Debug.Assert(items[3] == 30);
            Debug.Assert(items[4] == 50);

            items = mainTree.GetItems(TreeTraversal.PostOrder).ToList();
            Debug.Assert(items.Count == 5);
            Debug.Assert(items[0] == 10);
            Debug.Assert(items[1] == 30);
            Debug.Assert(items[2] == 50);
            Debug.Assert(items[3] == 40);
            Debug.Assert(items[4] == 20);

            items = mainTree.GetItems(TreeTraversal.ReverseInOrder).ToList();
            Debug.Assert(items.Count == 5);
            Debug.Assert(items[0] == 50);
            Debug.Assert(items[1] == 40);
            Debug.Assert(items[2] == 30);
            Debug.Assert(items[3] == 20);
            Debug.Assert(items[4] == 10);

            Console.WriteLine("******************** COMPLETED ********************");            
        }
    }
}
