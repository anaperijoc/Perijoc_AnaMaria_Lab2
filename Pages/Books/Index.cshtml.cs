using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AnaMaria_Perijoc_Lab2.Data;
using AnaMaria_Perijoc_Lab2.Models;

namespace AnaMaria_Perijoc_Lab2.Pages.Books
{
    public class IndexModel : PageModel
    {
        private readonly AnaMaria_Perijoc_Lab2.Data.AnaMaria_Perijoc_Lab2Context _context;

        public IndexModel(AnaMaria_Perijoc_Lab2.Data.AnaMaria_Perijoc_Lab2Context context)
        {
            _context = context;
        }

        public IList<Book> Book { get; set; } = default!;
        public BookData BookD { get; set; }
        public int BookID { get; set; }
        public int CategoryID { get; set; }

        public async Task OnGetAsync(int? id, int? categoryID)
        {
            BookD = new BookData();
            BookD.Books = await _context.Book
                .Include(b => b.Publisher)
                .Include(b => b.Author)
                .Include(b => b.BookCategories)
                    .ThenInclude(bc => bc.Category)
                .AsNoTracking()
                .OrderBy(b => b.Title)
                .ToListAsync();

            if (id != null)
            {
                BookID = id.Value;
                var book = BookD.Books
                    .Where(i => i.ID == id.Value).SingleOrDefault();
                if (book != null)
                {
                    BookD.Categories = book.BookCategories.Select(s => s.Category);
                }
            }
        }
    }
}