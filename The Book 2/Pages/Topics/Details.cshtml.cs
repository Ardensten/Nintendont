using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using The_Book_2.Data;
using The_Book_2.Models;

namespace The_Book_2.Pages.Topics
{
    public class DetailsModel : PageModel
    {
        private readonly The_Book_2.Data.The_Book_2Context _context;

        public DetailsModel(The_Book_2.Data.The_Book_2Context context)
        {
            _context = context;
        }

      public Topic Topic { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Topic == null)
            {
                return NotFound();
            }

            var topic = await _context.Topic.FirstOrDefaultAsync(m => m.Id == id);
            if (topic == null)
            {
                return NotFound();
            }
            else 
            {
                Topic = topic;
            }
            return Page();
        }
    }
}
