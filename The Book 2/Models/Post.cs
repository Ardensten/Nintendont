namespace The_Book_2.Models
{
	public class Post
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string Text { get; set; }
		public DateTime Date { get; set; }
		public string UserId { get; set; }
		public int TopicId { get; set; }
	}
}
