using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using The_Book_2.Models;

namespace The_Book_2.Pages
{
    public class PostModel : PageModel
    {
        public int PostId { get; set; }

        private readonly The_Book_2.Data.The_Book_2Context _context;

        public PostModel(The_Book_2.Data.The_Book_2Context context)
        {
            _context = context;
        }
        public IList<Comment> Comment { get; set; } = default!;
        public IList<Post> Posts { get; set; }

        public async Task OnGetAsync()
        {
            if (Request.Query.ContainsKey("id") && int.TryParse(Request.Query["id"], out int id))
            {
                PostId = id;

                Posts = await _context.Post.Where(p => p.Id == PostId).ToListAsync();

                Comment = await _context.Comment.Where(c => c.PostId == PostId).ToListAsync();

            }
        }


    }
}
