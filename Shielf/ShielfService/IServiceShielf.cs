using Shielf.Model;

namespace Shielf.ShielfService
{
    public interface IServiceShielf
    {
        public Book? GetBookById(Guid id);
        public Book? GetBookByName(string name, string author);
        public IEnumerable<Book>? GetShielf(int min_year, int max_year);
        public void AddBook(Book book);
        public void UpdateBook(Book book);
    }
}
