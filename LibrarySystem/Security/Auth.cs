using LibrarySystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Security
{
	public static class Auth
	{
		public static string SignUp()
		{
			User user = new User();
			do
			{
				Console.WriteLine("Try to enter your name: ");
				user.Name = Console.ReadLine();
			} while (string.IsNullOrEmpty(user.Name));

			do
			{
				Console.WriteLine("Try to enter your Email: ");
				user.Email = Console.ReadLine();
			} while (string.IsNullOrEmpty(user.Email));

			do
			{
				Console.WriteLine("Try to enter your username: ");
				user.UserName = Console.ReadLine();
				if (Library.Users.Any(username => username.UserName == user.UserName))
				{
					Console.WriteLine("InValid UserName: ");
					continue;
				}

			} while (string.IsNullOrEmpty(user.UserName));

			do
			{
				Console.WriteLine("Try to enter your password: ");
				user.Password = Console.ReadLine();

			} while (string.IsNullOrEmpty(user.Password));

			var isfound = Library.Users.FirstOrDefault(u => u.UserName == user.UserName || u.Email == user.Email);
			if (isfound is not null)
			{
				int stat;
				do
				{
					Console.WriteLine("User Name Or Email Should Be Unique \n" +
						"1 ) For Suign Up Again \n" +
						"2 ) For Got To The Main Page");
					stat = int.Parse(Console.ReadLine());
				} while (stat < 1 || stat > 2);
				if (stat == 1)
				{
					SignUp();
				}
				else
				{
					Library.Begin();
				}
			}
			Library.Users.Add(user);
			return user.UserName;
		}
		public static string Login()
		{
			string userName;
			string password;
			do
			{
				Console.WriteLine("Try to enter your username: ");
				userName = Console.ReadLine();

			} while (string.IsNullOrEmpty(userName));

			do
			{
				Console.WriteLine("Try to enter your password: ");
				password = Console.ReadLine();
			} while (string.IsNullOrEmpty(password));

			var user = Library.Users.FirstOrDefault(u => u.UserName == userName && u.Password == password);
			if (user is null)
			{
				int stat;
				do
				{
					Console.WriteLine("InCorrect UserName Or Password \n" +
						"1 ) For Log In Again \n" +
						"2 ) For Got To The Main Page");
					stat = int.Parse(Console.ReadLine());
				} while (stat < 1 || stat > 2);
				if (stat == 1)
				{
					Login();
				}
				else
				{
					Library.Begin();
				}
			}
			return user.UserName;
		}
		internal static void LogOut()
		{
			Library.Begin();
		}

	}
}
