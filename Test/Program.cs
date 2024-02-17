using Test;

List<ShielfBook> shielves = new List<ShielfBook> { };
int index = 0;
void AddBook(Book book)
{
    foreach (ShielfBook shilef in shielves)
    {
        if (book.Added(shilef))
        {
            shilef.AddBook(book);
            return;
        }
    }
    ShielfBook shielfBook = new ShielfBook();
    shielfBook.id = index++;
    shielfBook.max_year = book.year+50;
    shielfBook.min_year = book.year-50;
    book.Added(shielfBook);
    shielves.Add(shielfBook);
}

Book? GetBook(int id)
{
    foreach (ShielfBook shilef in shielves)
    {
        if (shilef.FindBook(id) != null) return shilef.FindBook(id);
    }
    return null;
}

IEnumerable<Book>? GetShielf(int min_year, int max_year)
{
    foreach (ShielfBook sh in shielves)
    {
        if (sh.min_year<=min_year && sh.max_year>=max_year) return sh.books;
    }
    return null;
}
void UpdateBook(Book book)
{
    Book? b = GetBook(book.id);
    if (b!=null)
    {
        //DeleteBook(b);
        AddBook(book);
    }
}

Book b1 = new Book();
b1.id = 0;
b1.name = "Tom";
b1.author = "Block";
b1.year = 1977;
AddBook(b1);
Book b2 = new Book();
b2.id = 1;
b2.name = "Aka";
b2.author = "Sld";
b2.year = 1890;
AddBook(b2);
GetShielf(1840, 1900);
Book b3 =  new Book();
b3 = b2;
b3.year = 1665;
UpdateBook(b3);