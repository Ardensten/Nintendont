using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using The_Book_2.Data;
using The_Book_2.Models;

namespace The_Book_2.Pages.Topics
{
    public class CreateModel : PageModel
    {
        private readonly The_Book_2.Data.The_Book_2Context _context;

        public CreateModel(The_Book_2.Data.The_Book_2Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Topic Topic { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Topic == null || Topic == null)
            {
                return Page();
            }

            _context.Topic.Add(Topic);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
