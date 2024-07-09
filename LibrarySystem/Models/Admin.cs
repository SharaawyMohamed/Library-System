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

		public static void AdminFunctionality(char type)
		{
			string username = default;
			if (type == '1')
			{
				username = Auth.Login();
			}
			else 
			{
				username = Auth.SignUp();
			}
			
			Library.Welcome(username);
			AdminProcess(username);
		}
		private static void AdminProcess(string username)
		{
			char ch = GetMenue();
			if (ch == '1')
			{
				Utility.ViewProfile(username);
			}
			else if (ch == '2')
			{
				Add_book();
			}
			else
			{
				Auth.LogOut();
			}
			AdminProcess(username);
		}
		private static char GetMenue()
		{
			char c;
			do
			{
				Console.WriteLine("1) For View Profile \n" +
				"2) For Adding Book \n" +
				"3) For Log Out");
				c = char.Parse(Console.ReadLine());
			} while (c < '1' || c > '3');
			return c;
		}
		private static void Add_book()
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
			Library.Books.Add(book);
		}
	}
}
