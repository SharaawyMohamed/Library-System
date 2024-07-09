using LibrarySystem.Security;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Models
{
	public class User : BaseEntity
	{

		public static void UserFunctionality(char type)
		{
			string username;
			if (type == '1')
			{
				username = Auth.Login();
			}
			else
			{
				username = Auth.SignUp();
			}
			Library.Welcome(username);
			UserMenu(username);

		}
		private static void UserMenu(string username)
		{
			int selected;
			while (true)
			{
				do
				{
					Console.WriteLine($"Menu:");
					Console.WriteLine($"1) View Profile\n" +
						$"2) List & Select Form MyReading History\n" +
						$"3) List & Select From Avaliable Books\n" +
						$"4) Log Out \n");
					selected = int.Parse(Console.ReadLine());
				} while (selected < 1 || selected > 4);
				if (selected == 1)
				{
					Utility.ViewProfile(username);
				}
				else if (selected == 2)
				{
					ReadingHistory(username);
				}
				else if (selected == 3)
				{
					UserReading(username);
				}
				else
				{
					Auth.LogOut();
				}
			}
		}
		private static void ReadingHistory(string username)
		{
			var userReading = Library.Sessions.Where(user => user.Username == username).Select(user => user).OrderByDescending(t => t.time).ToList();
			int it = 0;
			Console.WriteLine("Sessions History:\n ");
			foreach (var i in userReading)
			{
				++it;
				Console.WriteLine($"BookName: {i.BookName}\n" + $"Topic: {i.Topic}\n" + $"History: {i.time}\n" +
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
				UserMenu(username);
			}
			else
			{
				UserReading(username);
			}

		}
		private static void UserReading(string username)
		{
			var userReading = Library.Sessions.Where(user => user.Username == username).Select(user => user).ToList();
			int it = 0;
			foreach (var session in userReading)
			{
				Console.WriteLine($"Session Number: {++it}\n" +
					$"Session Name: {session.BookName}\n" +
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
			Console.WriteLine($"Name: {bookData.BookName}\n" +
				$"Topic: {bookData.Topic}\n" +
				$"Current Page: {bookData.CurrentPage}/{bookData.NumberOfPages}");
			Tuple<int, int> lastedit = FlipPages(bookData.CurrentPage, bookData.NumberOfPages, bookData.BookName, bookData.Topic);

			int index = Library.Sessions.IndexOf(bookData);
			Library.Sessions[index].CurrentPage = lastedit.Item1;
			Library.Sessions[index].time = DateTime.Now;
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
