﻿namespace The_Book_2.Models
{
	public class Comment
	{
		public int Id { get; set; }
		public string Text { get; set; }
		public DateTime Date { get; set; }
		public string UserId { get; set; }
		public int PostId { get; set; }
	}
}
