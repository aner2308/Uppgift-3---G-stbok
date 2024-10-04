using System;

namespace GuestbookApp
{
    class Program
    {
        static void Main()
        {

            Guestbook guestbook = new();
            guestbook.LoadPosts();

            while (true)
            {
                //Rensar konsollen innan menyn skrivs ut
                Console.Clear();

                //Skriver ut menyn med menyval
                Console.WriteLine("A N T O N S  G U E S T B O O K");
                Console.WriteLine("");
                Console.WriteLine("  1. Create post");
                Console.WriteLine("  2. Remove post");
                Console.WriteLine("  3. Show all posts");
                Console.WriteLine("  4. Exit");
                Console.WriteLine("");
                Console.Write("Choose an option: ");

                //Låter användaren skriva in sitt menyval
                string choice = Console.ReadLine().Trim();

                Console.Clear();

                //Jämför användarens inmantning med en switch-sats
                switch (choice)
                {
                    case "1":
                        Console.Write("Name writer: ");
                        string writer = Console.ReadLine();
                        Console.Write("Write your message: ");
                        string message = Console.ReadLine();
                        guestbook.AddPost(writer, message);
                        break;

                    case "2":
                        guestbook.RemovePost();
                        break;

                    case "3":
                        guestbook.ShowPosts();
                        Console.WriteLine("");
                        Console.WriteLine("Press any key to return to menu.");
                        Console.ReadKey();
                        break;

                    case "4":
                        return;

                    default:
                        Console.WriteLine("Error: Option unavailable. Please try again...");
                        break;
                }
            }
        }
    }
}