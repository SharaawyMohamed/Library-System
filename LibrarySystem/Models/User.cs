using LibrarySystem.Security;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Models
{
	public class User : BaseEntity
	{
		private string username = string.Empty;
		public void UserFunctionality(char type)
		{
			if (type == '1')
			{
				username = Auth.Login();
			}
			else
			{
				username = Auth.SignUp();
			}
			Library.Welcome(username);
			UserMenu();

		}
		private void UserMenu()
		{
			int selected;
			while (true)
			{
				do
				{
					Console.WriteLine($"Menu:");
					Console.WriteLine($"1) View Profile\n" +
						$"2) List & Select Form MyReading History\n" +
						$"3) List & Select From Available Books\n" +
						$"4) For Get New Book To Read\n" +
						$"5) Log Out \n");
					selected = int.Parse(Console.ReadLine());
				} while (selected < 1 || selected > 5);
				if (selected == 1)
				{
					Utility.ViewProfile(username);
				}
				else if (selected == 2)
				{
					ReadingHistory();
				}
				else if (selected == 3)
				{
					UserReading();
				}
				else if (selected == 4)
				{
					AvailableBooks();
				}
				else
				{
					Auth.LogOut();
				}
			}
		}
		private void ReadingHistory()
		{
			var userReading = Library.Sessions.Where(user => user.Username == username).Select(user => user).OrderByDescending(t => t.time).ToList();
			int it = 0;
			Console.WriteLine("Sessions History:\n ");
			foreach (var i in userReading)
			{
				++it;
				Console.WriteLine($"BookName: {i.Name}\n" + $"Topic: {i.Topic}\n" + $"History: {i.time}\n" +
					$"----------------------------");
			}
			Console.WriteLine($"1) For Begin Reading From History\n" +
				$"2) For Back Menu");
			int ch;
			do
			{
				Console.WriteLine("Enter Number: ");
				ch = int.Parse(Console.ReadLine());
			} while (ch > 2 || ch < 1);
			if (ch == 2)
			{
				UserMenu();
			}
			else
			{
				UserReading();
			}

		}
		private void UserReading()
		{
			var userReading = Library.Sessions.Where(user => user.Username == username).Select(user => user).ToList();
			int it = 0;
			foreach (var session in userReading)
			{
				Console.WriteLine($"Session Number: {++it}\n" +
					$"Session Name: {session.Name}\n" +
					$"Session Topic: {session.Topic}\n" +
					$"Session History: {session.time}\n" +
					$"---------------------------------\n");
			}
			Console.WriteLine($"Which Book to Read :\n" +
				$"Enter Number From [1 to {it}]: ");
			int bookNum;
			do
			{
				Console.WriteLine("Enter Book Number To Read: ");
				bookNum = int.Parse(Console.ReadLine());
			} while (bookNum < 1 || bookNum > it);

			var bookData = userReading[bookNum - 1];
			Console.WriteLine($"Name: {bookData.Name}\n" +
				$"Topic: {bookData.Topic}\n" +
				$"Current Page: {bookData.CurrentPage}/{bookData.NumberOfPages}");
			Tuple<int, int> lastedit = FlipPages(bookData.CurrentPage, bookData.NumberOfPages, bookData.Name, bookData.Topic);

			int index = Library.Sessions.IndexOf(bookData);
			Library.Sessions[index].CurrentPage = lastedit.Item1;
			Library.Sessions[index].time = DateTime.Now;
		}
		private void AvailableBooks()
		{
			var availableBooks = from book in Library.Books
								 where !Library.Sessions.Any(session => session.Name == book.Name && book.Quantity > 0)
								 select new Book
								 {
									 Id = book.Id,
									 Name = book.Name,
									 Authors = book.Authors,
									 Quantity = book.Quantity
								 };
			if (availableBooks is null)
			{
				Console.WriteLine("No Books Until Now!");
				return;
			}
			Console.WriteLine("New Books: \n");
			foreach (var book in availableBooks)
			{
				Console.WriteLine($"Id: {book.Id}\n" +
					$"Name: {book.Name}");
				Console.Write("Authors: { ");
				foreach (var x in book.Authors) { Console.Write($"{x}, "); }
				Console.WriteLine(" }");
				Console.WriteLine($"Quantity: {book.Quantity}");
			}

			Console.WriteLine("---------------------------------------");

			int typ;
			do
			{
				Console.WriteLine($"1) For Get New Book:\n" +
								$"2) For Back To Menu:");
				typ = int.Parse(Console.ReadLine());
			} while (typ < 1 || typ > 2);
			if (typ == 1)
			{
				SelectBook(availableBooks);
			}
		}
		private void SelectBook(IEnumerable<Book> books)
		{
			string id;
			do
			{
				Console.WriteLine("Try To Enter Correct Book ID From The Previous Available Books:");
				id = Console.ReadLine();
			} while (!books.Any(i => i.Id == id));
			var newbook = books.FirstOrDefault(b => b.Id == id);
			var session = new Session()
			{
				Id=newbook.Id,
				Name = newbook.Name,
				NumberOfPages = newbook.NumberOfPages,
				Authors=newbook.Authors,
				Topic=newbook.Topic,
				CurrentPage=0,
				Username=username,
				time=DateTime.Now
			};
			Library.Sessions.Add(session);
			Console.WriteLine("Book Added To your Session Successfully");
		}
		private static Tuple<int, int> FlipPages(int cur, int all, string bookname, string topic)
		{
			int num = 0;
			while (num != 3)
			{
				Console.WriteLine("Menu:\n" +
					"1 : Next Page\n" +
					"2 : Previous Page\n" +
					"3 : Stop Reading ");
				num = int.Parse(Console.ReadLine());

				if (num == 1)
				{
					cur %= all;
					cur++;

					if (cur == all)
					{
						Console.WriteLine($"Congratulations For Finishing {bookname}\n" +
							$"The next page will mark the beginning of reading this book again.");
					}
				}
				else if (num == 2)
				{
					cur = (cur == 0) ? all : cur - 1;
				}
				Console.WriteLine($"Current Page: {cur}/{all}\n" +
					$"Topic: {topic}");
			}
			return Tuple.Create(cur, all);
		}
	}
}
