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



namespace The_Book_2.Pages.Posts
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
        public int TopicId { get; set; }

        public IList<Topic> Topic { get; set; } = default!;

        [BindProperty]
        public Post Post { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (Request.Query.ContainsKey("id") && int.TryParse(Request.Query["id"], out int id))
            {
                TopicId = id;
            }

            if (_context.Topic != null)
            {
                Topic = await _context.Topic.ToListAsync();
            }

        }

        public async Task<IActionResult> OnPostAsync()
        {
            Post.Date = DateTime.Now;
            Post.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            Post.TopicId = TopicId;

            _context.Post.Add(Post);
            await _context.SaveChangesAsync();

            return RedirectToPage("../Index");
        }

    }
}
