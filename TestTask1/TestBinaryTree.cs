using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task1;
using System.Collections.Generic;
using System.Collections;

namespace TestTask1
{
    [TestClass]
    public class TestBinaryTree
    {
        [TestMethod]
        public void TestDegitTreeDefault()
        {
            BinaryTree<int> tree = new BinaryTree<int>();
            tree.Add(5, null);
            tree.Add(9, null);
            tree.Add(3, null);
            tree.Add(2, null);
            var expected = true;
            Assert.AreEqual(tree.FindNode(2), expected);
        }

        [TestMethod]
        public void TestDegitTreeComparison()
        {
            BinaryTree<int> tree = new BinaryTree<int>();
            tree.Add(5, new IntComparison());
            tree.Add(9, new IntComparison());
            tree.Add(3, new IntComparison());
            tree.Add(2, new IntComparison());
            var expected =new List<int>() { 2,3,5,9};
            Assert.AreEqual(result,expected);
        }
        
    }
}
