using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class BinaryTree<TItem> : IEnumerable<TItem>
    {
        private class Node<TValue>
        {
            public TValue Value { get; set; }
            public Node<TValue> Left { get; set; }
            public Node<TValue> Right { get; set; }
            public Node(TValue value)
            {
                Value = value;
            }
        }

        private Node<TItem> root;
        public BinaryTree() { }
        public BinaryTree(ICollection<TItem> collection, IComparer<TItem> comparer)
        {
            foreach (TItem elem in collection)
                Add(elem, comparer);
        }

        //private class Adapter:IComparer<TItem>
        //{
        //    Func<TItem, TItem, int> comparer;
        //    public Adapter(Func<TItem, TItem, int> comparer)
        //    {
        //        this.comparer = comparer;
        //    }
        //    public int CompareNode(TItem x, TItem y)
        //    {
        //        return comparer(x,y);
        //    }
        //}

        //public void Add(TItem elem, Func<TItem, TItem, int> comparer)
        //{
        //    Adapter adapter = new Adapter(comparer);
        //    Add(elem, adapter);
        //}
         

        public void Add(TItem elem, IComparer<TItem> comparer)
        {
            if (elem == null) throw new ArgumentNullException();
            if (comparer == null) comparer = Comparer<TItem>.Default;
            var node = new Node<TItem>(elem);
            if (root == null)
                root = node;
            else
            {
                try
                {
                    Node<TItem> current = root, parent = null;
                    while (current != null)
                    {
                        parent = current;
                        if (comparer.Compare(elem, current.Value) > 0) current = current.Right;
                        else current = current.Left;
                    }

                    if (comparer.Compare(elem, parent.Value) > 0) parent.Right = node;
                    else parent.Left = node;
                }
                catch(Exception ex)
                {
                    throw new ArgumentException("Comparer for this type don't exist!");
                }
            }
        }


        public IEnumerable<TItem> PreOrder()
        {
            if (root == null) yield break;
            var stack = new Stack<Node<TItem>>();
            stack.Push(root);
            while (stack.Count > 0)
            {
                var node = stack.Pop();
                yield return node.Value;
                if (node.Right != null) stack.Push(node.Right);
                if (node.Left != null) stack.Push(node.Left);
                
            }
        }

        public IEnumerable<TItem> PostOrder()
        {
            if (root == null) yield break;
            var stack = new Stack<Node<TItem>>();
            var node = root;
            while (stack.Count > 0 || node != null)
            {
                if (node == null)
                {
                    node = stack.Pop();
                    if (stack.Count > 0 && node.Right == stack.Peek())
                    {
                        stack.Pop();
                        stack.Push(node);
                        node = node.Right;
                    }
                    else { yield return node.Value; node = null; }
                }
                else
                {
                    if (node.Right != null) stack.Push(node.Right);
                    stack.Push(node);
                    node = node.Left;
                }

            }
        }

        public IEnumerable<TItem> InOrder()
        {
            if (root == null) yield break;
            var stack = new Stack<Node<TItem>>();
            Node<TItem> node = root;
            while (stack.Count > 0 || node != null)
            {
                if (node == null)
                {
                    node = stack.Pop();
                    yield return node.Value;
                    node = node.Right;
                }
                else
                {
                    stack.Push(node);
                    node = node.Left;
                }

            }
        }
               
        public bool FindNode( TItem elem)
        {
            if (root == null || elem == null) throw new ArgumentException();
            Node<TItem> node = root;
            while(node!=null)
            {
                if (Equals(node.Value,elem)) return true;
                if (Comparer<TItem>.Default.Compare(elem, node.Value) > 0) node = node.Right;
                else node = node.Left;
            }
            return false;
        }

        public void Remove(TItem value)
        {
            if (value == null) throw new ArgumentNullException("value");
            if (root == null) return;

            Node<TItem> current = root, parent = null;
            int result;
            do
            {
                result = Comparer<TItem>.Default.Compare(value,current.Value);
                if (result < 0) { parent = current; current = current.Left; }
                else if (result > 0) { parent = current; current = current.Right; }                
            }
            while (result != 0);

            if (current.Right == null)
            {
                if (current == root) root = current.Left;
                else
                {
                    result = Comparer<TItem>.Default.Compare(current.Value,parent.Value);
                    if (result < 0) parent.Left = current.Left;
                    else parent.Right = current.Left;
                }
            }
            else if (current.Right.Left == null)
            {
                current.Right.Left = current.Left;
                if (current == root) root = current.Right;
                else
                {
                    result = Comparer<TItem>.Default.Compare(current.Value, parent.Value);
                    if (result < 0) parent.Left = current.Right;
                    else parent.Right = current.Right;
                }
            }
            else
            {
                Node<TItem> min = current.Right.Left, prev = current.Right;
                while (min.Left != null)
                {
                    prev = min;
                    min = min.Left;
                }
                prev.Left = min.Right;
                min.Left = current.Left;
                min.Right = current.Right;

                if (current == root) root = min;
                else
                {
                    result = Comparer<TItem>.Default.Compare(current.Value, parent.Value);
                    if (result < 0) parent.Left = min;
                    else parent.Right = min;
                }
            }
        }
        public IEnumerator<TItem> GetEnumerator()
        {
            return InOrder().GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }
    }
}
