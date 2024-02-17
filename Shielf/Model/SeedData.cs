using Microsoft.EntityFrameworkCore;
using Shielf.Data;

namespace Shielf.Model
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ShielfContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ShielfContext>>()))
            {
                // Look for any movies.
                if (context.Book.Any())
                {
                    return;   // DB has been seeded
                }
                context.Book.AddRange(
                    new Book
                    {
                        name = "Harry Potter",
                        author = "J. K. Rowling",
                        description = "Harry Potter and the Half-Blood Prince is a fantasy novel written by British author J. K. Rowling and the sixth and penultimate novel in the Harry Potter series. Set during Harry Potter's sixth year at Hogwarts, the novel explores the past of the boy wizard's nemesis, Lord Voldemort, and Harry's preparations for the final battle against Voldemort alongside his headmaster and mentor Albus Dumbledore.",
                        year = 2005
                    }
                    );
                context.SaveChanges(); 
            }
        }
    }
}
