using System;
using System.Collections.Generic;

namespace Algorithms.Trees
{
    public class TreeNode
    {
        public TreeNode(int value) => Value = value;
        public int Value { get; }
        public TreeNode? Left { get; set; }
        public TreeNode? Right { get; set; }
    }

    public class BinarySearchTree
    {
        public TreeNode? Root;
        public int Count { get; private set; }

        public BinarySearchTree()
        {
            Root = null;
            Count = 0;
        }


        public void Add(int value)
        {
            if (Root is null)
            {
                Root = new TreeNode(value);
            }
            else
            {
                Add(Root, value);
            }

            Count++;
        }

        private void Add(TreeNode node, int value)
        {

            if (value < node.Value)
            {
                if (node.Left != null)
                {
                    Add(node.Left, value);
                }
                else
                {
                    var newNode = new TreeNode(value);
                    node.Left = newNode;
                }
            }
            else
            {
                if (node.Right != null)
                {
                    Add(node.Right, value);
                }
                else
                {
                    var newNode = new TreeNode(value);
                    node.Right = newNode;
                }
            }           
        }

        public bool Remove(TreeNode? parent, TreeNode? node, int value)
        {
            if (node is null || parent is null)
            {
                return false;
            }

            if (node.Value > value)
            {
                return Remove(node, node.Left, value);
            }
            else if (node.Value < value)
            {
                return Remove(node, node.Right, value);
            }
            else
            {
                TreeNode replacement;

                if (node.Left == null || node.Right == null)
                {
                    replacement = node.Left ?? node.Right;
                }

                else
                {
                    var predecessor = Max(node.Left);

                    Remove(Root, Root, predecessor.Value);

                    replacement = new TreeNode(predecessor.Value)
                    {
                        Left = node.Left,
                        Right = node.Right,
                    };
                }

                if (node == Root)
                {
                    Root = replacement;
                }
                else if (parent.Left == node)
                {
                    parent.Left = replacement;
                }
                else
                {
                    parent.Right = replacement;
                }

                return true;
            }
        }

        public bool Remove(int value)
        {
            if (Root == null)
            {
                return false;
            }

            bool result = Remove(Root, Root, value);
            if (result)
            {
                Count--;
            }

            return result;
        }

        public TreeNode? Search(TreeNode? node, int value)
        {
            if (node == null)
            {
                return default;
            }

            if (value < node.Value)
            {
                return Search(node.Left, value);
            }
            else if (value > node.Value)
            {
                return Search(node.Right, value);
            }
            else
            {
                return node;
            }
        }

        public TreeNode Max()
        {
            if (Root is null)
            {
                return default;
            }

            return Max(Root);
        }

        public TreeNode Max(TreeNode node)
        {
            if (node.Right == null) return node;

            return Max(node.Right);
        }

        public TreeNode Min()
        {
            if (Root is null)
            {
                return default;
            }

            return Min(Root);
        }

        public TreeNode Min(TreeNode node)
        {
            if (node.Left == null) return node;

            return Min(node.Left);
        }

        public List<int> ToList(TreeNode? node)
        {
            if(node == null) return new List<int>();

            var result = new List<int>();
            result.AddRange(this.ToList(node.Left));
            result.Add(node.Value);
            result.AddRange(this.ToList(node.Right));
            return result;
        }
    }
}
