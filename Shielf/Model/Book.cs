namespace Shielf.Model
{
    public class Book
    {
        public Guid id {  get; set; }
        public string name { get; set; } = "";
        public string description { get; set; } = "";
        public string author { get; set; } = "";
        public int year { get; set; }
        public ShielfBook shielf_where { get; set; } = new ShielfBook();
        public Guid shielf_id { get; set; }
        //public Book()
        //{
        //    id = Guid.NewGuid();
        //}
        public bool Added(ShielfBook shielf)
        {
            if (shielf_where != null)
            {
                shielf_where.RemoveBook(this);
            }
            if(year>=shielf.min_year && year<=shielf.max_year)
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
