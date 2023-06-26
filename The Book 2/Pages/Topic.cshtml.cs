using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using The_Book_2.Models;

namespace The_Book_2.Pages
{
    public class TopicModel : PageModel
    {
        public int TopicId { get; set; }

        private readonly The_Book_2.Data.The_Book_2Context _context;

        public TopicModel(The_Book_2.Data.The_Book_2Context context)
        {
            _context = context;
        }
        public IList<Post> Post { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (Request.Query.ContainsKey("id") && int.TryParse(Request.Query["id"], out int id))
            {
                TopicId = id;
            }

            if (_context.Post != null)
            {
                Post = await _context.Post.ToListAsync();
            }
        }
    }
}
