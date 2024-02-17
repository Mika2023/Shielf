using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shielf.Model;

namespace Shielf.Data
{
    public class ShielfContext : DbContext
    {
        public ShielfContext (DbContextOptions<ShielfContext> options)
            : base(options)
        {
        }

        public DbSet<Shielf.Model.ShielfBook> ShielfBook { get; set; } = default!;
        public DbSet<Shielf.Model.Book> Book { get; set; } = default!;
    }
}
