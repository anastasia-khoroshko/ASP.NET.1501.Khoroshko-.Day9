using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public class Book : IEquatable<Book>, IComparable<Book>
    {
        public string ISBN { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public int Copy { get; set; }
        public int Pages { get; set; }

        public override bool Equals(object obj)
        {
            if (!(obj is Book))
                return false;
            return Equals((Book)obj);
        }

        public bool Equals(Book book)
        {
            if (Object.Equals(book, null)) throw new ArgumentNullException("Can not equals null book");
            if (this.ISBN != book.ISBN) return false;
            if (this.Title != book.Title) return false;
            if (this.Author != book.Author) return false;
            if (this.Copy != book.Copy) return false;
            if (this.Pages != book.Pages) return false;
            return true;
        }

        public static bool operator ==(Book book1,Book book2)
        {
            if (Object.Equals(book1, null)|| Object.Equals(book2,null)) 
                throw new ArgumentNullException("Can not equals null book");
            return book1.Equals(book2);
        }

        public static bool operator !=(Book book1,Book book2)
        {
            if (Object.Equals(book1, null) || Object.Equals(book2, null))
                throw new ArgumentNullException("Can not equals null book");
            return !book1.Equals(book2);
        }

        public override string ToString()
        {
            return String.Format("Author: {0}" + Environment.NewLine + "Title:{1}" + Environment.NewLine + "Copy{2}" +
                Environment.NewLine + "Pages:{3}" + Environment.NewLine + "ISBN:{4}", this.Author, this.Title, this.Copy,
                this.Pages, this.ISBN);
        }

        public override int GetHashCode()
        {
            return this.ISBN.GetHashCode();
        }

        public int CompareTo(Book other)
        {
            if (!Equals(other,null))
            {
                return this.Title.CompareTo(other.Title);
            }
            else throw new ArgumentException("Object is not a book"); 
        }
    }

}
