using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Models
{
	internal class Session
	{
		public string Topic { get; set; } = string.Empty;
		public string BookName { get; set; } = string.Empty;
		public int CurrentPage { get; set; }
		public int NumberOfPages { get; set; }
		public string Username { get; set; } = string.Empty;
		public DateTime time { get; set; } = DateTime.Now;

	}
}
