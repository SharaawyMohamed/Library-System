using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LibrarySystem.Models
{
	public static class Library
	{
		internal static List<Book> Books = new List<Book>();
		internal static List<Session> Sessions = new List<Session>(){new Session()
			{
			  Name="NutShell",
			  Topic="C# & .Net",
			  NumberOfPages=5,
			  CurrentPage=1,
			  Username="SH"

			}};
		internal static List<User> Users = new List<User>()
		{
			new User()
			{
				Name="Sharawy",
				Email="sharawy@gmail.com",
				UserName="SH",
				Password="Pa$$w0rd",
				IsAdmin=false,
			},
			new User()
			{
				Name="Ammar",
				Email="Ammar@gmail.com",
				UserName="AM",
				Password="Pa$$w0rd",
				IsAdmin=true,
				IsSuper=true
			}
		};

		internal static void Begin()
		{


			#region input Choice for login or register and Validation
			char type;
			do
			{
				Console.WriteLine($"Welcome in our Library : \n" +
				$"1) For Continue as Admin\n" +
				$"2) For Continue As User\n");
				type = char.Parse(Console.ReadLine());

			} while (!(type == '1' || type == '2'));
			#endregion

			//  Supposed Log in of register done
			if (type == '1')
			{
				Admin admin = new Admin();
				admin.AdminFunctionality(Registration(1));

			}
			else
			{
				User user = new User();
				user.UserFunctionality(Registration());
			}
		}
		internal static void Welcome(string username)
		{
			Console.WriteLine($"Hello {username}");
		}
		private static char Registration(int type = 2)
		{
			char c;
			do
			{

				Console.WriteLine($"1) For Log In");
				if (type == 2)
					Console.WriteLine("2) For Sign Up");
				c = char.Parse(Console.ReadLine());
			} while (!((c=='1')|| (c=='2' && type==2)));
			return c;
		}
	}
}
