using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace GuestbookApp
{
    public class Guestbook
    {
        private List<Post> posts = [];  //Lista med alla gästboksinlägg.
        private const string FileName = "guestbook.json";

        //Funktion för att lägga till inlägg med parametrarna som användaren fyllt i.
        public void AddPost(string writer, string message)
        {
            //Kontrollerar så att inget fält har lämnats tomt.
            if (string.IsNullOrWhiteSpace(writer) || string.IsNullOrWhiteSpace(message))
            {
                Console.WriteLine("Error: Både författare och meddelande måste vara ifyllt.");
                return;
            }

            posts.Add(new Post(writer, message));
            SavePosts();
        }

        //Funktion för att ta bort ett gästboksinlägg.
        public void RemovePost()
        {

            while (true)
            {

                ShowPosts();

                Console.WriteLine("Ange numret för inlägget du vill ta bort, eller skriv 'R' för att återgå till menyn");
                string input = Console.ReadLine();

                if (input.Trim().ToUpper() == "R")
                {
                    return;
                }

                if (int.TryParse(input, out int num))
                {
                    //Kontrollerar att det finns ett inlägg med det angivna numret.
                    if (num < 0 || num >= posts.Count)
                    {

                        Console.WriteLine("Error: Det finns inget inlägg med det angivna nummret.");
                    }
                    else
                    {
                        posts.RemoveAt(num);
                        Console.WriteLine($"Inlägg nummer {num} har tagits bort.");
                        SavePosts();
                        Console.WriteLine("Tryck på valfri tangent för att återgå till menyn...");
                        Console.ReadKey();
                        return;
                    }
                }
                else
                {
                    Console.WriteLine("Error: Ogiltig inmatning. Vänligen ange en giltig siffra.");
                }

                Console.WriteLine("Vill du försöka igen? 'J/N': ");
                string tryAgain = Console.ReadLine().Trim().ToUpper();

                if (tryAgain == "N")
                {
                    return;
                }
            }

        }

        public void ShowPosts()
        {
            Console.Clear();
            if (posts.Count == 0)
            {
                Console.WriteLine("Gästboken är tom.");
            }
            else
            {
                for (int i = 0; i < posts.Count; i++)
                {
                    Console.WriteLine($"[{i}]: {posts[i]}");
                }
            }
        }

        //Konverterar om gästboksinläggen från JSON-filen tillbaka till läsbar text i listformat. 
        public void LoadPosts()
        {
            if (File.Exists(FileName))
            {
                string json = File.ReadAllText(FileName);
                posts = JsonSerializer.Deserialize<List<Post>>(json) ?? [];
            }
        }
        private void SavePosts()
        {
            string json = JsonSerializer.Serialize(posts);
            File.WriteAllText(FileName, json);
        }
    }
}