using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2;

namespace Task1
{
    public class IntComparison:IComparer<int>
    {

        public int Compare(int x, int y)
        {
            if (Equals(x, y)) return 0;
            if (x > y) return 1;
            return -1;
        }
    }

    public class BookComparison:IComparer<Book>
    {
        public int Compare(Book x, Book y)
        {
            if (!Equals(x, null) && !Equals(y, null))
                return x.ISBN.CompareTo(y.ISBN);
            else throw new ArgumentNullException();
        }
    }

    public class CustomStringComparison:IComparer<string>
    {

        public int Compare(string x, string y)
        {
            if (!Equals(x, null) && !Equals(y, null))
                return x.First().CompareTo(y.First());
            else throw new ArgumentNullException();
        }
    }
}
