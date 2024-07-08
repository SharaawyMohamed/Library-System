using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace LibrarySystem.Models
{
	internal class Admin : BaseEntity
	{

		public static void Add_book()
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
