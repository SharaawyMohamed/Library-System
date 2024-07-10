using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Models
{
	internal class Session:Book
	{
		public int CurrentPage { get; set; }
		public string Username { get; set; } = string.Empty;
		public DateTime time { get; set; } = DateTime.Now;

	}
}
