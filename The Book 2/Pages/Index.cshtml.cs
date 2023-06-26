using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using The_Book_2.Models;

namespace The_Book_2.Pages
{
	public class IndexModel : PageModel
	{
        private readonly The_Book_2.Data.The_Book_2Context _context;

        public IndexModel(The_Book_2.Data.The_Book_2Context context)
        {
            _context = context;
        }

        public IList<Forum> Forum { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Forum != null)
            {
                Forum = await _context.Forum.ToListAsync();
            }
        }
    }
}