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
    public class IndexModel : PageModel
    {
        private readonly The_Book_2.Data.The_Book_2Context _context;

        public IndexModel(The_Book_2.Data.The_Book_2Context context)
        {
            _context = context;
        }

        public IList<Topic> Topic { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Topic != null)
            {
                Topic = await _context.Topic.ToListAsync();
            }
        }
    }
}
