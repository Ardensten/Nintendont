using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using The_Book_2.Models;

namespace The_Book_2.Pages
{
    public class ForumModel : PageModel
    {
        public int Id { get; set; }

        private readonly The_Book_2.Data.The_Book_2Context _context;

        public ForumModel(The_Book_2.Data.The_Book_2Context context)
        {
            _context = context;
        }
        public IList<Topic> Topic { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (Request.Query.ContainsKey("id") && int.TryParse(Request.Query["id"], out int id))
            {
                Id = id;
            }

            if (_context.Topic != null)
            {
                Topic = await _context.Topic.ToListAsync();
            }
        }
    }
}
