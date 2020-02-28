using System;
using System.Collections.Generic;

namespace Common
{
    public abstract class BinaryTreeBase<T> : ITreeTraversal<T>
    {
        protected TreeNode<T> _root;

        public BinaryTreeBase()
        {

        }

        public BinaryTreeBase(T rootItem)
        {
            _root = new TreeNode<T> { Item = rootItem };
        }

        public bool IsEmpty
        {
            get { return _root == null; }
        }

        public void MakeEmpty()
        {
            _root = null;
        }

        public T RootItem
        {
            get
            {
                if (_root == null)
                {
                    throw new ArgumentNullException(nameof(_root));
                }

                return _root.Item;
            }
            set
            {
                _root = new TreeNode<T> { Item = value };
            }
        }

        public IEnumerable<T> GetItems(TreeTraversal treeTraversal)
        {
            switch (treeTraversal)
            {
                case TreeTraversal.InOrder:
                    return InOrder(_root);
                case TreeTraversal.PreOrder:
                    return PreOrder(_root);
                case TreeTraversal.PostOrder:
                    return PostOrder(_root);
                case TreeTraversal.ReverseInOrder:
                    return ReverseInOrder(_root);
                default:
                    throw new NotSupportedException($"{treeTraversal} is not supported.");
            }
        }

        private IEnumerable<T> PreOrder(TreeNode<T> treeNode)
        {
            if (treeNode != null)
            {
                yield return treeNode.Item;

                foreach (var item in PreOrder(treeNode.LeftChild))
                {
                    yield return item;
                }

                foreach (var item in PreOrder(treeNode.RightChild))
                {
                    yield return item;
                }
            }
        }

        private IEnumerable<T> InOrder(TreeNode<T> treeNode)
        {
            if (treeNode != null)
            {
                foreach (var item in InOrder(treeNode.LeftChild))
                {
                    yield return item;
                }

                yield return treeNode.Item;

                foreach (var item in InOrder(treeNode.RightChild))
                {
                    yield return item;
                }
            }
        }

        private IEnumerable<T> ReverseInOrder(TreeNode<T> treeNode)
        {
            if (treeNode != null)
            {
                foreach (var item in ReverseInOrder(treeNode.RightChild))
                {
                    yield return item;
                }

                yield return treeNode.Item;

                foreach (var item in ReverseInOrder(treeNode.LeftChild))
                {
                    yield return item;
                }
            }
        }

        private IEnumerable<T> PostOrder(TreeNode<T> treeNode)
        {
            if (treeNode != null)
            {
                foreach (var item in PostOrder(treeNode.LeftChild))
                {
                    yield return item;
                }

                foreach (var item in PostOrder(treeNode.RightChild))
                {
                    yield return item;
                }

                yield return treeNode.Item;
            }
        }
    }
}
