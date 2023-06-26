using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using The_Book_2.Data;
using The_Book_2.Models;

namespace The_Book_2.Pages.Forums
{
    public class DeleteModel : PageModel
    {
        private readonly The_Book_2.Data.The_Book_2Context _context;

        public DeleteModel(The_Book_2.Data.The_Book_2Context context)
        {
            _context = context;
        }

        [BindProperty]
      public Forum Forum { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Forum == null)
            {
                return NotFound();
            }

            var forum = await _context.Forum.FirstOrDefaultAsync(m => m.Id == id);

            if (forum == null)
            {
                return NotFound();
            }
            else 
            {
                Forum = forum;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Forum == null)
            {
                return NotFound();
            }
            var forum = await _context.Forum.FindAsync(id);

            if (forum != null)
            {
                Forum = forum;
                _context.Forum.Remove(Forum);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
