using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class ShielfBook
    {
        public int id { get; set; }
        public int min_year { get; set; }
        public int max_year { get; set; }
        public List<Book> books { get; set; } = new List<Book>();
        public void AddBook(Book book)
        {
            if (!books.Any(b => b.id.Equals(book.id))) books.Add(book);
        }
        public void RemoveBook(Book book)
        {
            if (books.Any(b => b.id.Equals(book.id))) books.Remove(books.First(b => b.id.Equals(book.id)));
        }
        public Book? FindBook(int id)
        {
            if (books.Any(b => b.id.Equals(id))) return books.First(b => b.id.Equals(id));
            return null;
        }
    }
}
