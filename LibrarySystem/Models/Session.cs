using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Models
{
	internal class Session
	{
		public string BookName { get; set; } = string.Empty;
		public int PageNumber { get; set; }
		public bool SessionState { get; set;} = false;
	}
}
