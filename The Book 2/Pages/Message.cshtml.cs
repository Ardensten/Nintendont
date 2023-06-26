using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using The_Book_2.Models;

namespace The_Book_2.Pages
{
    public class MessagesModel : PageModel
    {
		public string UserId { get; set; }

		private readonly The_Book_2.Data.The_Book_2Context _context;

        public MessagesModel(The_Book_2.Data.The_Book_2Context context)
        {
			_context = context;
		}

		public IList<Message> Message { get; set; } = default!;


		public void OnGetAsync()
        {
        }
    }
}
