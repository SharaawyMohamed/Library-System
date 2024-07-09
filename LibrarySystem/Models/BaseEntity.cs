using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Models
{
	public class BaseEntity
	{
		public string Name { get; set; } = string.Empty;
		public string UserName { get; set; }= string.Empty;
		public string Password { get; set; } = string.Empty;
		public string Email { get; set; } = string.Empty;
		public bool IsAdmin { get; set; } = false;
		
	}
}
