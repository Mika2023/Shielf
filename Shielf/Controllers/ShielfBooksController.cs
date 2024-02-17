using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Shielf.Data;
using Shielf.Model;

namespace Shielf.Controllers
{
    public class ShielfBooksController : Controller
    {
        private readonly ShielfContext _context;

        public ShielfBooksController(ShielfContext context)
        {
            _context = context;
        }

        // GET: ShielfBooks
        public async Task<IActionResult> Index()
        {
              return _context.ShielfBook != null ? 
                          View(await _context.ShielfBook.ToListAsync()) :
                          Problem("Entity set 'ShielfContext.ShielfBook'  is null.");
        }

        // GET: ShielfBooks/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.ShielfBook == null)
            {
                return NotFound();
            }

            var shielfBook = await _context.Book
                .Where(m => m.shielf_id == id).ToListAsync();
            if (shielfBook == null)
            {
                return NotFound();
            }

            return View(shielfBook);
        }

        // GET: ShielfBooks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ShielfBooks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,name,author,description,year")] Book shielfBook)
        {
            if (ModelState.IsValid)
            {
                shielfBook.id = Guid.NewGuid();
                AddBook(shielfBook);
                _context.Add(shielfBook);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(shielfBook);
        }
        public void AddBook(Book shielfBook)
        {
            List<ShielfBook> shielves = _context.ShielfBook.ToList();
            if (shielves!=null)
            {
                int f = 0;
                foreach (ShielfBook s in shielves)
                {
                    if (shielfBook.Added(s))
                    {
                        f = 1;
                        break;
                    }
                }
                if (f == 0)
                {
                    ShielfBook shielf = new ShielfBook();
                    shielf.id = Guid.NewGuid();
                    shielf.max_year = shielfBook.year+50;
                    shielf.min_year = shielfBook.year-50;
                    shielfBook.Added(shielf);
                    _context.Add(shielf);
                    _context.SaveChanges();
                }
                
            }
            
        }
        // GET: ShielfBooks/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.Book == null)
            {
                return NotFound();
            }

            var shielfBook = await _context.Book.FindAsync(id);
            if (shielfBook == null)
            {
                return NotFound();
            }
            return View(shielfBook);
        }

        // POST: ShielfBooks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("id,name,author,description,year")] Book shielfBook)
        {
            if (id != shielfBook.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    Book? book = await _context.Book.FindAsync(shielfBook.id) as Book;
                    if (book != null && book.year!=shielfBook.year)
                    {
                        book.name = shielfBook.name;
                        book.author = shielfBook.author;
                        book.description = shielfBook.description;
                        book.year = shielfBook.year;
                        AddBook(book);
                        _context.Update(book);
                    }
                    
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShielfBookExists(shielfBook.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(shielfBook);
        }

        // GET: ShielfBooks/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.Book == null)
            {
                return NotFound();
            }

            var shielfBook = await _context.Book
                .FirstOrDefaultAsync(m => m.id == id);
            if (shielfBook == null)
            {
                return NotFound();
            }

            return View(shielfBook);
        }

        // POST: ShielfBooks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.Book == null)
            {
                return Problem("Entity set 'ShielfContext.Book'  is null.");
            }
            var shielfBook = await _context.Book.FindAsync(id);
            if (shielfBook != null)
            {
                _context.Book.Remove(shielfBook);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShielfBookExists(Guid id)
        {
          return (_context.Book?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
