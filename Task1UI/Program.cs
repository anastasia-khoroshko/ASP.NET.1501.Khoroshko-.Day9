using PrimerPoint;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1;
using Task2;

namespace Task1UI
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaryTree<int> tree = new BinaryTree<int>();
            tree.Add(5,null);
            tree.Add(9,null);
            tree.Add(3, null);
            tree.Add(2, null);
            var res = tree.FindNode(2);
            var io = tree.InOrder();
            var pro = tree.PreOrder();
            var po = tree.PostOrder();
            tree.Remove(2);
            BinaryTree<int> tree1 = new BinaryTree<int>();
            tree.Add(5, new IntComparison());
            tree.Add(9, new IntComparison());
            tree.Add(3, new IntComparison());
            tree.Add(2, new IntComparison());
            var res1 = tree.FindNode(2);
            var io1 = tree.InOrder();
            var pro1 = tree.PreOrder();
            var po1 = tree.PostOrder();
            BinaryTree<Book> books = new BinaryTree<Book>();
            books.Add(new Book()
                {
                    ISBN = "1525-514-D",
                    Author = "W.Shakespeare",
                    Title = "Hamlet",
                    Copy = 12899,
                    Pages = 852
                },null);
            books.Add(new Book()
            {
                ISBN = "12368-5251-X",
                Author = "M.Mitchel",
                Title = "Gone with the Wind",
                Copy = 189635,
                Pages = 785
            },null);
            books.Add(new Book()
            {
                ISBN = "11589-258-1",
                Author = "J.London",
                Title = "The House of Pride",
                Copy = 5852,
                Pages = 892
            }, null);
            books.Add(new Book()
                {
                    ISBN = "25893-22-22-1",
                    Author = "R.Kipling",
                    Title = "Captains Courageous",
                    Copy = 60987,
                    Pages = 688
                }, null);
            var result = books.FindNode(new Book()
                {
                    ISBN = "25893-22-22-1",
                    Author = "R.Kipling",
                    Title = "Captains Courageous",
                    Copy = 60987,
                    Pages = 688
                });

            BinaryTree<Book> bookTree = new BinaryTree<Book>();
            bookTree.Add(new Book()
            {
                ISBN = "1525-514-D",
                Author = "W.Shakespeare",
                Title = "Hamlet",
                Copy = 12899,
                Pages = 852
            }, new BookComparison());
            bookTree.Add(new Book()
            {
                ISBN = "12368-5251-X",
                Author = "M.Mitchel",
                Title = "Gone with the Wind",
                Copy = 189635,
                Pages = 785
            }, new BookComparison());
            bookTree.Add(new Book()
            {
                ISBN = "11589-258-1",
                Author = "J.London",
                Title = "The House of Pride",
                Copy = 5852,
                Pages = 892
            }, new BookComparison());
            bookTree.Add(new Book()
            {
                ISBN = "25893-22-22-1",
                Author = "R.Kipling",
                Title = "Captains Courageous",
                Copy = 60987,
                Pages = 688
            }, new BookComparison());

            BinaryTree<string> stringTree = new BinaryTree<string>();
            stringTree.Add("free",new CustomStringComparison());
            stringTree.Add("tree", new CustomStringComparison());
            stringTree.Add("apple", new CustomStringComparison());
            stringTree.Add("root", new CustomStringComparison());
            stringTree.Add("node", new CustomStringComparison());
            var resSearch = stringTree.FindNode("node");
            var resIO = stringTree.InOrder();
            var resPrO = stringTree.PreOrder();
            var resPO = stringTree.PostOrder();
            BinaryTree<string> stringTreeD = new BinaryTree<string>();
            stringTreeD.Add("free",null);
            stringTreeD.Add("tree", null);
            stringTreeD.Add("apple", null);
            stringTreeD.Add("root", null);
            stringTreeD.Add("node",null);
            //BinaryTree<Point> points = new BinaryTree<Point>();
            //points.Add(new Point(1, 1), null);
            //points.Add(new Point(2, 2), null);
        }
    }
}
