using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class Book
    {
        public int id { get; set; }
        public string name { get; set; } = "";
        public string description { get; set; } = "";
        public string author { get; set; } = "";
        public int year { get; set; }
        public ShielfBook shielf_where { get; set; } = new ShielfBook();
        public int shielf_id { get; set; }
        public bool Added(ShielfBook shielf)
        {
            if (shielf_where != null)
            {
                shielf_where.RemoveBook(this);
            }
            if (year>=shielf.min_year && year<=shielf.max_year)
            {
                shielf_where = shielf;
                shielf_id = shielf.id;
                shielf.AddBook(this);
                return true;
            }
            return false;
        }
    }
}
