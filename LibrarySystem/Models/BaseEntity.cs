using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Models
{
	internal class BaseEntity
	{
		public string Name { get; set; } = string.Empty;
		public string UserName { get; set; }= string.Empty;
		public string Password { get; set; } = string.Empty;
		public string Email { get; set; } = string.Empty;
		//static BaseEntity(string name, string userName, string password, string email)
		//{
		//	Name = name;
		//	UserName = userName;
		//	Password = password;
		//	Email = email;
		//}
	}
}
