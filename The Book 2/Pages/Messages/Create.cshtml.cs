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

namespace The_Book_2.Pages.Messages
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
        public int MessageId { get; set; }

        //[BindProperty]
        //public Message Message { get; set; } 

        public IList<Message> Message { get; set; } = default!;
        
        public async Task OnGetAsync()
        {
            if (Request.Query.ContainsKey("id") && int.TryParse(Request.Query["id"], out int id))
            {
                MessageId = id;
            }

            if (_context.Message != null)
            {
                Message = await _context.Message.ToListAsync();
            }
        }

        //public async Task<IActionResult> OnPostAsync()
        //{
        //    Message.Date = DateTime.Now;
        //    Message.SenderId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        //    _context.Message.Add(Message);
        //    await _context.SaveChangesAsync();

        //    return RedirectToPage("./Index");
        //}
    }
}
