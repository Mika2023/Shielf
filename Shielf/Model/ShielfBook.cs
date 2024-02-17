namespace Shielf.Model
{
    public class ShielfBook
    {
        public Guid id { get; set; }
        public int min_year { get; set; }
        public int max_year { get; set; }
        public List<Book> books { get; set; } = new List<Book>();
        //public ShielfBook() {
        //    id = Guid.NewGuid();
        //}
        public void AddBook(Book book)
        {
            if (!books.Any(b => b.id.Equals(book.id)))
            {
                books.Add(book);
            }
        }
        public void RemoveBook(Book book)
        {
            if (books.Any(b => b.id.Equals(book.id)))
            {
                books.Remove(books.First(b => b.id.Equals(book.id)));
            }
        }
        public Book? FindBook(Guid id)
        {
            if(books.Any(b=>b.id.Equals(id))) return books.First(b => b.id.Equals(id));
            return null;
        }
        public Book? FindBook(string name, string author)
        {
            if (books.Any(b => b.name==name&&b.author==author)) return books.First(b => b.name==name&&b.author==author);
            return null;
        }
    }
}
