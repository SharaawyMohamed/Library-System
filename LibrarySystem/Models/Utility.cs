using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Models
{
	internal static class Utility
	{
		public static void ViewProfile(string username)
		{
			var user = Library.Users.FirstOrDefault(u => u.UserName == username);
			Console.WriteLine($"Name: {user.Name}\n" +
				$"Email: {user.Email}\nUserName: {user.UserName}");
		}
	}
}
