namespace Common
{
    public class TreeNode<T>
    {
        public T Item { get; set; }

        public TreeNode<T> LeftChild { get; set; }

        public TreeNode<T> RightChild { get; set; }
    }
}
