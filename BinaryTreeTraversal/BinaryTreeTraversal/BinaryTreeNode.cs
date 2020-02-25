namespace BinaryTreeTraversal
{
    public class BinaryTreeNode<T>
    {
        private BinaryTreeNode<T> _left_node;
        private BinaryTreeNode<T> _right_node;
        private T _element;

        public BinaryTreeNode(T element)
        {
            this._element = element;
        }

        public T Value => this._element;

        public BinaryTreeNode<T> RightNode
        {
            get => this._right_node;
            set => this._right_node = value;
        }

        public BinaryTreeNode<T> LeftNode
        {
            get => this._left_node;
            set => this._left_node = value;
        }
    }
}
