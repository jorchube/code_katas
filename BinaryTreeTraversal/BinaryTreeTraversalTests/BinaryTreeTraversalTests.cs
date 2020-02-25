using NUnit.Framework;
using System.Collections;

using BinaryTreeTraversal;

namespace BinaryTreeTraversalTests
{
    public class Tests
    {
        BinaryTreeNode<int> root;

        [SetUp]
        public void Setup()
        {
            root = new BinaryTreeNode<int>(1);
            root.LeftNode = new BinaryTreeNode<int>(2);
            root.RightNode = new BinaryTreeNode<int>(3);
        }

        [Test]
        public void traversing_root_only_tree()
        {
            ArrayList expected = new ArrayList();
            expected.Add(1);

            ArrayList array = BinaryTreeTraverser<int>.PreOrder(new BinaryTreeNode<int>(1));

            Assert.AreEqual(expected, array);
        }

        [Test]
        public void traversing_simple_tree_pre_order()
        {
            ArrayList expected = new ArrayList();
            expected.Add(1);
            expected.Add(2);
            expected.Add(3);

            ArrayList array = BinaryTreeTraverser<int>.PreOrder(root);

            Assert.AreEqual(expected, array);
        }

        [Test]
        public void traversing_multi_level_tree_pre_order()
        {
            root.LeftNode.LeftNode = new BinaryTreeNode<int>(4);
            root.LeftNode.RightNode = new BinaryTreeNode<int>(5);
            root.RightNode.LeftNode = new BinaryTreeNode<int>(6);
            root.RightNode.RightNode = new BinaryTreeNode<int>(7);

            ArrayList expected = new ArrayList();
            expected.Add(1);
            expected.Add(2);
            expected.Add(4);
            expected.Add(5);
            expected.Add(3);
            expected.Add(6);
            expected.Add(7);

            ArrayList array = BinaryTreeTraverser<int>.PreOrder(root);

            Assert.AreEqual(expected, array);
        }

        [Test]
        public void traversing_simple_tree_in_order()
        {
            ArrayList expected = new ArrayList();
            expected.Add(2);
            expected.Add(1);
            expected.Add(3);

            ArrayList array = BinaryTreeTraverser<int>.InOrder(root);

            Assert.AreEqual(expected, array);
        }

        [Test]
        public void traversing_multi_level_tree_in_order()
        {
            root.LeftNode.LeftNode = new BinaryTreeNode<int>(4);
            root.LeftNode.RightNode = new BinaryTreeNode<int>(5);
            root.RightNode.LeftNode = new BinaryTreeNode<int>(6);
            root.RightNode.RightNode = new BinaryTreeNode<int>(7);

            ArrayList expected = new ArrayList();
            expected.Add(4);
            expected.Add(2);
            expected.Add(5);
            expected.Add(1);
            expected.Add(6);
            expected.Add(3);
            expected.Add(7);

            ArrayList array = BinaryTreeTraverser<int>.InOrder(root);

            Assert.AreEqual(expected, array);
        }

        [Test]
        public void traversing_multi_level_tree_post_order()
        {
            root.LeftNode.LeftNode = new BinaryTreeNode<int>(4);
            root.LeftNode.RightNode = new BinaryTreeNode<int>(5);
            root.RightNode.LeftNode = new BinaryTreeNode<int>(6);
            root.RightNode.RightNode = new BinaryTreeNode<int>(7);

            ArrayList expected = new ArrayList();
            expected.Add(4);
            expected.Add(5);
            expected.Add(2);
            expected.Add(6);
            expected.Add(7);
            expected.Add(3);
            expected.Add(1);

            ArrayList array = BinaryTreeTraverser<int>.PostOrder(root);

            Assert.AreEqual(expected, array);
        }

        [Test]
        public void traversing_multi_level_tree_width_first()
        {
            root.LeftNode.LeftNode = new BinaryTreeNode<int>(4);
            root.LeftNode.RightNode = new BinaryTreeNode<int>(5);
            root.RightNode.LeftNode = new BinaryTreeNode<int>(6);
            root.RightNode.RightNode = new BinaryTreeNode<int>(7);

            ArrayList expected = new ArrayList();
            expected.Add(1);
            expected.Add(2);
            expected.Add(3);
            expected.Add(4);
            expected.Add(5);
            expected.Add(6);
            expected.Add(7);

            ArrayList array = BinaryTreeTraverser<int>.WidthFirst(root);

            Assert.AreEqual(expected, array);
        }
    }
}