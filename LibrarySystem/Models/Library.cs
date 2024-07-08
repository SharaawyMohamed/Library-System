using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LibrarySystem.Models
{
	internal class Library
	{
		public static List<Book> Books = new List<Book>();
		public static List<User> Users = new List<User>();
		Admin admin;
		public Library()
		{
			admin = new Admin()
			{
				Name = "Sharawy Mohamed",
				Email = "sharawym275@gmail.com",
				UserName = "Sharawy_Ad",
				Password = "Pa$$w0rd"
			};
		}
		public void Begin()
		{


			#region input Choice for login or register and Validation
			char type;
			do
			{
				Console.WriteLine($"Welcome in our Library : \n" +
				$"1) For Log In \n" +
				$"2) For Sign Up\n" +
				$"3) For Continue as Admin\n");
				type = char.Parse(Console.ReadLine());

			} while (type != '1' && type != '2' && type != '3');
			#endregion

			//  Supposed Log in of register done
			if (type == '3')
			{
				Console.WriteLine("Enter Your UserName : ");
				string username = Console.ReadLine();
				if (username != admin.UserName)
				{
					Console.WriteLine("InCorrect UserName Try Again!\n-------------------------------- ");
					Begin();
				}
				Console.WriteLine("Click (1) To Add Book : \n" +
					"Click (2) To Log Out : ");
				char ch = char.Parse(Console.ReadLine());
				if (ch == '1')
				{
					Admin.Add_book();
				}
				else
				{
					// Log out
				}
			}
			else if (type == '1')
			{
				Console.WriteLine("Enter Your UserName : ");
				string username = Console.ReadLine();
				if (Users.Any(u => u.UserName == username))
				{
					// User Services
				}
				else
				{
					Console.WriteLine("InCorrect UserName Try Again!\n----------------------------------- ");
					Begin();
				}
			}
			else if (type == '2')
			{
				SignUpForUser();
			}

		}
		private void SignUpForUser()
		{
			User user=new User();
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
				if (Users.Any(username => username.UserName == user.UserName))
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

			Users.Add(user);
		}
	}
}
