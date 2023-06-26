using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using The_Book_2.Areas.Identity.Data;
using The_Book_2.Data;
using The_Book_2.Models;

namespace The_Book_2.Pages.Comments
{
    public class CreateModel : PageModel
    {
        private readonly UserManager<The_Book_2User> _userManager;
        private readonly The_Book_2.Data.The_Book_2Context _context;

        public CreateModel(UserManager<The_Book_2User> userManager, The_Book_2.Data.The_Book_2Context context)
        {
            _userManager = userManager;
            _context = context;
        }

        [BindProperty]
        public int PostId { get; set; }
        public IList<Post> Post { get; set; } = default!;

        [BindProperty]
        public Comment Comment { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (Request.Query.ContainsKey("id") && int.TryParse(Request.Query["id"], out int id))
            {
                PostId = id;
            }

            if (_context.Post != null)
            {
                Post = await _context.Post.ToListAsync();
            }
        }
        public async Task<IActionResult> OnPostAsync()
        {
            Comment.Date = DateTime.Now;
            Comment.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            Comment.PostId = PostId;

            _context.Comment.Add(Comment);
            await _context.SaveChangesAsync();

            return RedirectToPage("../Index");
        }
    }
}
