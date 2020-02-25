using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace BinaryTreeTraversal
{
    public class BinaryTreeTraverser<T>
    {
        public static ArrayList PreOrder(BinaryTreeNode<T> node)
        {
            ArrayList result = new ArrayList();

            result.Add(node.Value);

            if (node.LeftNode != null) {
                AppendArrayList(result, PreOrder(node.LeftNode));
            }

            if (node.RightNode != null) {
                AppendArrayList(result, PreOrder(node.RightNode));
            }

            return result;
        }

        public static ArrayList InOrder(BinaryTreeNode<T> node)
        {
            ArrayList result = new ArrayList();

            if (node.LeftNode != null) {
                AppendArrayList(result, InOrder(node.LeftNode));
            }

            result.Add(node.Value);

            if (node.RightNode != null) {
                AppendArrayList(result, InOrder(node.RightNode));
            }

            return result;
        }

        public static ArrayList PostOrder(BinaryTreeNode<T> node)
        {
            ArrayList result = new ArrayList();

            if (node.LeftNode != null) {
                AppendArrayList(result, PostOrder(node.LeftNode));
            }

            if (node.RightNode != null) {
                AppendArrayList(result, PostOrder(node.RightNode));
            }

            result.Add(node.Value);

            return result;
        }

        public static ArrayList WidthFirst(BinaryTreeNode<T> node)
        {
            ArrayList result = new ArrayList();

            if (node == null) {
                return result;
            }

            result.Add(node.Value);

            AppendArrayList(result, WidthFirstChildren(node));

            return result;
        }

        static ArrayList WidthFirstChildren(BinaryTreeNode<T> node)
        {
            ArrayList result = new ArrayList();

            if (node.LeftNode != null) {
                result.Add(node.LeftNode.Value);
            }

            if (node.RightNode != null) {
                result.Add(node.RightNode.Value);
            }

            if (node.LeftNode != null) {
                AppendArrayList(result, WidthFirstChildren(node.LeftNode));
            }

            if (node.RightNode != null) {
                AppendArrayList(result, WidthFirstChildren(node.RightNode));
            }

            return result;
        }

        private static void AppendArrayList(ArrayList append_to, ArrayList appended)
        {
            foreach (T elem in appended) {
                append_to.Add(elem);
            }
        }
    }
}
