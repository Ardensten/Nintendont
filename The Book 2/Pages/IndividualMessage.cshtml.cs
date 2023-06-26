using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using The_Book_2.Models;

namespace The_Book_2.Pages
{
    public class IndividualMessageModel : PageModel
    {
		public int MessageId { get; set; }

		private readonly The_Book_2.Data.The_Book_2Context _context;

		public IndividualMessageModel(The_Book_2.Data.The_Book_2Context context)
		{
			_context = context;
		}

		public IList<Message> Message { get; set; }


		public async Task OnGetAsync()
        {
			if (Request.Query.ContainsKey("id") && int.TryParse(Request.Query["id"], out int id))
			{
				MessageId = id;

				Message = await _context.Message.Where(m => m.Id == MessageId).ToListAsync();
			}
		}
    }
}
