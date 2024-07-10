using LibrarySystem.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace LibrarySystem.Models
{
	public class Admin : BaseEntity
	{
		private string username = string.Empty;
		public void AdminFunctionality(char type)
		{
			username = Auth.Login(2);
			Library.Welcome(username);
			AdminProcess();
		}
		private void AdminProcess()
		{
			bool isSuper = Library.Users.Any(u => u.UserName == username && u.IsSuper == true);
			char ch = GetMenu(isSuper);
			if (ch == '1')
			{
				Utility.ViewProfile(username);
			}
			else if (ch == '2')
			{
				Add_book();
			}
			else if (ch == '3')
			{

				Auth.LogOut();
			}
			else
			{
				AddAdmin();
			}
			AdminProcess();
		}
		private char GetMenu(bool isSuper)
		{
			char c;
			do
			{
				if (isSuper)
				{
					Console.WriteLine("1) For View Profile \n" +
									  "2) For Adding Book \n" +
									  "3) For Log Out\n" +
									  "4) For Adding Admin");
				}
				else
				{
					Console.WriteLine("1) For View Profile \n" +
									  "2) For Adding Book \n" +
									  "3) For Log Out");
				}
				c = char.Parse(Console.ReadLine());
			} while (c < '1' || c > '4');
			return c;
		}
		private void Add_book()
		{
			Book book = new Book();

			do
			{
				Console.WriteLine("Enter Book Id :");
				book.Id = Console.ReadLine();
			} while (string.IsNullOrEmpty(book.Id));

			do
			{
				Console.WriteLine("Enter Book Name :");
				book.Name = Console.ReadLine();
			} while (string.IsNullOrEmpty(book.Name));

			do
			{
				Console.WriteLine("Enter Book's Topic :");
				book.Topic = Console.ReadLine();
			} while (string.IsNullOrEmpty(book.Topic));
			do
			{
				Console.WriteLine("Enter Number Of Pages :");
				book.NumberOfPages = int.Parse(Console.ReadLine());
			} while (book.NumberOfPages<1);
			int NumberOfAuthors;
			do
			{
				Console.WriteLine("Enter Number Of Authors From [1 to 10] For This Book :");
				NumberOfAuthors = int.Parse(Console.ReadLine());
			}
			while (NumberOfAuthors < 1 || NumberOfAuthors > 10);
			for (int i = 1; i <= NumberOfAuthors; i++)
			{
				string author;
				do
				{
					Console.WriteLine($"Enter Author Number {i} : ");
					author = Console.ReadLine();
				} while (string.IsNullOrEmpty(author));
				book.Authors.Add(author);
			}
			var index = Library.Books.FindIndex(b=>b.Name==book.Name);
			if (index == -1)
			{
				Library.Books.Add(book);
			}
			else
			{
				Library.Books[index].Quantity++;
			}
		}
		private void AddAdmin()
		{
			User user = new User();
			do
			{
				Console.WriteLine("Try to enter Admin name: ");
				user.Name = Console.ReadLine();
			} while (string.IsNullOrEmpty(user.Name));

			do
			{
				Console.WriteLine("Try to enter Admin Email: ");
				user.Email = Console.ReadLine();
			} while (string.IsNullOrEmpty(user.Email));

			do
			{
				Console.WriteLine("Try to enter Admin username: ");
				user.UserName = Console.ReadLine();
				if (Library.Users.Any(username => username.UserName == user.UserName))
				{
					Console.WriteLine("InValid UserName: ");
					continue;
				}

			} while (string.IsNullOrEmpty(user.UserName));

			do
			{
				Console.WriteLine("Try to enter Admin password: ");
				user.Password = Console.ReadLine();

			} while (string.IsNullOrEmpty(user.Password));

			var isfound = Library.Users.FirstOrDefault(u => u.UserName == user.UserName || u.Email == user.Email);
			if (isfound is not null)
			{
				int stat;
				do
				{
					Console.WriteLine("User Name Or Email Should Be Unique \n" +
						"1 ) Try Again \n" +
						"2 ) For Got To The Main Page");
					stat = int.Parse(Console.ReadLine());
				} while (stat < 1 || stat > 2);
				if (stat == 1)
				{
					AddAdmin();
				}
				else
				{
					Library.Begin();
				}
			}
			user.IsAdmin = true;
			Library.Users.Add(user);
			Console.WriteLine("             Admin Added Successfully            ");

		}
	}
}
