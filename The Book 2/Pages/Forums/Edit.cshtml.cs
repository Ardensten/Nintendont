using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using The_Book_2.Data;
using The_Book_2.Models;

namespace The_Book_2.Pages.Forums
{
    public class EditModel : PageModel
    {
        private readonly The_Book_2.Data.The_Book_2Context _context;

        public EditModel(The_Book_2.Data.The_Book_2Context context)
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

            var forum =  await _context.Forum.FirstOrDefaultAsync(m => m.Id == id);
            if (forum == null)
            {
                return NotFound();
            }
            Forum = forum;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Forum).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ForumExists(Forum.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ForumExists(int id)
        {
          return (_context.Forum?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
