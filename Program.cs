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
                Console.WriteLine("Välkommen till Antons gästbok!");
                Console.WriteLine("");
                Console.WriteLine("  1. Skapa inlägg");
                Console.WriteLine("  2. Ta bort inlägg");
                Console.WriteLine("  3. Visa alla inlägg");
                Console.WriteLine("  4. Avsluta");
                Console.WriteLine("");
                Console.Write("Välj ett alternativ: ");

                //Låter användaren skriva in sitt menyval
                string choice = Console.ReadLine().Trim();

                Console.Clear();

                //Jämför användarens inmantning med en switch-sats
                switch (choice)
                {
                    case "1":
                        Console.Write("Namnge författare: ");
                        string writer = Console.ReadLine();
                        Console.Write("Skriv ditt meddelande: ");
                        string message = Console.ReadLine();
                        guestbook.AddPost(writer, message);
                        break;

                    case "2":
                        guestbook.RemovePost();
                        break;

                    case "3":
                        guestbook.ShowPosts();
                        Console.WriteLine("");
                        Console.WriteLine("Tryck på valfri tangent för att gå tillbaka till menyn...");
                        Console.ReadKey();
                        break;

                    case "4":
                        return;

                    default:
                        Console.WriteLine("Error: Felaktig inmatning. Försök igen...");
                        break;
                }
            }
        }
    }
}