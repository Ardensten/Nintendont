namespace The_Book_2.Models
{
	public class Message
	{
		public int Id { get; set; }
		public string Topic { get; set; }
		public string Text { get; set; }
        public DateTime Date { get; set; }
        public string SenderId { get; set; }
		public string ReceiverId { get; set; }
	}
}
