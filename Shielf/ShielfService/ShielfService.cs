using Microsoft.Extensions.DependencyInjection;
using Shielf.Model;
using System.Security.Cryptography;

namespace Shielf.ShielfService
{
    public static class MyExtentionShielf
    {
        public static IServiceCollection AddMyService(this IServiceCollection services)
        {
            services.AddSingleton<IServiceShielf,ShielfService>();

            return services;
        }
    }
    public class ShielfService : IServiceShielf
    {
        public static List<ShielfBook> shielves {  get; set; } = new List<ShielfBook> { };

        public void AddBook(Book book)
        {
            foreach(ShielfBook shilef in shielves)
            {
                if (book.Added(shilef))
                {
                    shilef.AddBook(book);
                    return;
                }
            }
            ShielfBook shielfBook = new ShielfBook();
            shielfBook.max_year = book.year+50;
            shielfBook.min_year = book.year-50;
            book.Added(shielfBook);
            shielves.Add(shielfBook);
        }

        public Book? GetBookById(Guid id)
        {
            foreach (ShielfBook shilef in shielves)
            {
                if (shilef.FindBook(id) != null) return shilef.FindBook(id);
            }
            return null;
        }

        public Book? GetBookByName(string name, string author)
        {
            foreach (ShielfBook shilef in shielves)
            {
                if (shilef.FindBook(name,author) != null) return shilef.FindBook(name,author);
            }
            return null;
        }

        public IEnumerable<Book>? GetShielf(int min_year, int max_year)
        {
            foreach(ShielfBook sh in shielves)
            {
                if (sh.min_year<=min_year && sh.max_year>=max_year) return sh.books;
            }
            return null;
        }

        public void UpdateBook(Book book)
        {
            Book? b = GetBookById(book.id);
            if(b!=null)
            {
                AddBook(book);
            }
        }
    }
}
