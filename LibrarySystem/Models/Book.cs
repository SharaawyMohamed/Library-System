using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Models
{
	internal class Book
	{
		public string Id { get; set; } = string.Empty;
		public string Name { get; set; } = string.Empty;
		public List<string> Authors { get; set; }= new List<string>();
		public int Quantity { get; set; }

	}
}
