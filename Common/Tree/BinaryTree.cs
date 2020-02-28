using System;

namespace Common
{
    public class BinaryTree<T> : BinaryTreeBase<T>
    {
        public BinaryTree()
            : base()
        {

        }

        public BinaryTree(T rootItem)
            : base(rootItem)
        {

        }

        public BinaryTree(TreeNode<T> rootItem)
        {
            _root = rootItem;
        }

        public BinaryTree(T rootItem, BinaryTree<T> leftTree, BinaryTree<T> rightTree)
            : this(rootItem)
        {
            AttachLeftSubtree(leftTree);
            AttachRightSubtree(rightTree);
        }

        public void AttachLeft(T item)
        {
            if (!IsEmpty && _root.LeftChild == null)
            {
                _root.LeftChild = new TreeNode<T> { Item = item };
            }
        }

        public void AttachRight(T item)
        {
            if (!IsEmpty && _root.RightChild == null)
            {
                _root.RightChild = new TreeNode<T> { Item = item };
            }
        }

        public void AttachLeftSubtree(BinaryTree<T> tree)
        {
            InitSubtree(tree, true);
        }

        public void AttachRightSubtree(BinaryTree<T> tree)
        {
            InitSubtree(tree, false);
        }

        public BinaryTree<T> DetachLeftSubtree()
        {
            if (IsEmpty)
            {
                throw new ArgumentNullException(nameof(_root));
            }

            var leftTree = new BinaryTree<T>(_root.LeftChild);
            _root.LeftChild = null;
            return leftTree;
        }

        public BinaryTree<T> DetachRightSubtree()
        {
            if (IsEmpty)
            {
                throw new ArgumentNullException(nameof(_root));
            }

            var rightTree = new BinaryTree<T>(_root.RightChild);
            _root.RightChild = null;
            return rightTree;
        }

        private void InitSubtree(BinaryTree<T> tree, bool attachLeft)
        {
            if (IsEmpty)
            {
                throw new ArgumentNullException(nameof(_root));
            }

            var child = attachLeft ? _root.LeftChild : _root.RightChild;
            if (child != null)
            {
                throw new ArgumentException("Child already exists. Cannot overwrite exisitng subtree unless it is deleted first.");
            }

            if (attachLeft)
                _root.LeftChild = tree._root;
            else
                _root.RightChild = tree._root;

            tree.MakeEmpty();
        }
    }
}
