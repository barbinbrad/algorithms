using System;
namespace Algorithms.Trees
{
    public class RedBlackTreeNode
    {
        public RedBlackColors Color;
        public int Value { get; set; }
        public RedBlackTreeNode Parent { get; set; }
        public RedBlackTreeNode Left { get; set; }
        public RedBlackTreeNode Right { get; set; }


        public RedBlackTreeNode(int value, int height, RedBlackTreeNode parent, RedBlackTreeNode left, RedBlackTreeNode right)
        {
            this.Color = RedBlackColors.Black;
            this.Value = value;
            this.Parent = parent;
            this.Left = left;
            this.Right = right;
        }

        public bool IsRed()
        {
            return Color == RedBlackColors.Red;
        }

        public bool IsBlack()
        {
            return Color == RedBlackColors.Black;
        }

        

        public RedBlackTreeNode Sibling()
        {
            if(this.Parent.Left.Value == this.Value) 
            {
                return this.Parent.Right;
            }
            else
            {
                return this.Parent.Left;
            }
        }

        public RedBlackTreeNode GrandParent()
        {
            return this.Parent.Parent;
        }

        public bool IsLeftChild()
        {
            return this.Parent.Left.Value == this.Value;
        }

        public bool IsRightChild()
        {
            return this.Parent.Right.Value == this.Value;
        }

        public bool HasRightChild()
        {
            return this.Right != null;
        }

        public bool HasLeftChild()
        {
            return this.Left != null;
        }
    }

    public class RedBlackTree : BinarySearchTree
    {
        // Rules:
        // 1. Each node is either red or black
        // 2. Root is black
        // 3. No two red nodes in a row
        // 4. Every root to null path has same number of blacks

        public new RedBlackTreeNode Root { get; set; }
        public new int Count { get; set; }

        public RedBlackTree()
        {
            Root = null;
            Count = 0;
        }

        private bool IsRoot(RedBlackTreeNode node)
        {
            return this.Root == node;
        }

        private void RotateLeftAt(RedBlackTreeNode node)
        {
            if (node == null || node.HasRightChild() == false) return;

            var pivot = node.Right;
            var parent = node.Parent;

            bool isLeftChild = node.IsLeftChild();
            bool isRootNode = (node == this.Root);

            // Rotate
            node.Right = pivot.Left;
            pivot.Left = node;

            // Update parents
            node.Parent = pivot;
            pivot.Parent = parent;

            if (node.HasRightChild())
                node.Right.Parent = node;

            // Update the root
            if (isRootNode)
                this.Root = pivot;

            // Update the original parent's child
            if (isLeftChild)
                parent.Right = pivot;

        }

        private void RotateRightAt(RedBlackTreeNode node)
        {
            if (node == null || node.HasLeftChild() == false) return;

            var pivot = node.Left;
            var parent = node.Parent;

            bool isLeftChild = node.IsLeftChild();
            bool isRootNode = (node == this.Root);

            // Rotate
            node.Left = pivot.Right;
            pivot.Right = node;

            // Update parents
            node.Parent = pivot;
            pivot.Parent = parent;

            if (node.HasLeftChild())
                node.Left.Parent = node;

            // Update the root
            if (isRootNode)
                this.Root = pivot;

            // Update the original parent's child
            if (isLeftChild)
                parent.Left = pivot;
            else if (parent != null)
                parent.Right = pivot;

        }
    }

    public enum RedBlackColors
    {
        Red,
        Black
    }
}
