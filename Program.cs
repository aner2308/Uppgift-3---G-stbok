using System;

namespace GuestbookApp
{
    class Program
    {
        static void Main()
        {
            while (true)
            {
                //Rensar konsollen innan menyn skrivs ut
                Console.Clear();

                //Skriver ut menyn med menyval
                Console.WriteLine("Välkommen till Antons gästbok!");
                Console.WriteLine("  1. Skapa inlägg");
                Console.WriteLine("  2. Ta bort inlägg");
                Console.WriteLine("  3. Visa alla inlägg");
                Console.WriteLine("  4. Avsluta");
                Console.Write("Välj ett alternativ: ");

                //Låter användaren skriva in sitt menyval
                string choice = Console.ReadLine().Trim();

                Console.Clear();

                //Jämför användarens inmantning med en switch-sats
                switch (choice)
                {
                    case "1":
                        Console.WriteLine("Menyval 1 fungerar!");
                        break;

                    case "2":
                        Console.WriteLine("Menyval 2 fungerar!");
                        break;

                    case "3":
                        Console.WriteLine("Menyval 3 fungerar!");
                        break;

                    case "4":
                        Console.WriteLine("Menyval 4 fungerar!");
                        return;

                    default:
                        Console.WriteLine("Error: Felaktig inmatning. Försök igen...");
                        break;
                }

                Console.WriteLine("Tryck på valfri tangent för att fortsätta...");
                Console.ReadKey();
            }
        }
    }
}