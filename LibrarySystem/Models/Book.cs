using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Models
{
	internal class Book
	{
		public string Id { get; set; }
		public string Name { get; set; } = string.Empty;
		public int NumberOfPages { get; set; } = 0;
		public List<string> Authors { get; set; } = new List<string>();
		public int Quantity { get; set; } = 1;
		public string Topic { get; set; } = string.Empty;
	}
}
