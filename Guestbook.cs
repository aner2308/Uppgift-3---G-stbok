using System.Text.Json;

namespace GuestbookApp
{
    public class Guestbook
    {
        private List<Post> posts = [];  //Lista med alla gästboksinlägg.
        private const string PostsFile = "guestbook.json";

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

            //Rensar konsollen
            Console.Clear();

            while (true)
            {

                //Visar alla inlägg i terminalen
                ShowPosts();

                Console.WriteLine("");
                Console.WriteLine("Ange numret för inlägget du vill ta bort, eller skriv 'R' för att återgå till menyn.");
                string input = Console.ReadLine();

                //Tar en tillbaka till menyn om man väljer "R".
                if (input.Trim().ToUpper() == "R")
                {
                    return;
                }

                //Kontrollerar om man har angett en siffra.
                if (int.TryParse(input, out int num))
                {
                    //Kontrollerar att det finns ett inlägg med det angivna numret.
                    if (num < 0 || num >= posts.Count)
                    {

                        Console.WriteLine("Error: Det finns inget inlägg med det angivna nummret.");
                    }
                    else
                    {
                        //Tar bort inläggen på den angivna positionen i listan. (Som kommer att matcha inläggets siffra i konsollen).
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
                    //Felmeddelane vid felaktig inmatning.
                    Console.WriteLine("Error: Ogiltig inmatning. Vänligen ange en giltig siffra.");
                }

                //Fråga om att försöka igen om man gjort fel.
                Console.WriteLine("Vill du försöka igen? 'J/N': ");
                string tryAgain = Console.ReadLine().Trim().ToUpper();

                //Bryter while-loopen om man väljer "N" och tar en tillbaka till huvudmenyn.
                if (tryAgain == "N")
                {
                    return;
                }
            }

        }

        //Funktion för att visa alla inlägg
        public void ShowPosts()
        {

            //Rensar konsollen
            Console.Clear();

            //Kontrollerar om det finns några inlägg
            if (posts.Count == 0)
            {
                Console.WriteLine("Gästboken är tom.");
            }
            else
            {
                //Loopar igenom inläggen och skriver ut dom med ID(siffra) först.
                for (int i = 0; i < posts.Count; i++)
                {
                    Console.WriteLine($"[{i}]: {posts[i]}");
                }
            }
        }

        //Konverterar om gästboksinläggen från JSON-filen tillbaka till läsbar text i listformat. 
        public void LoadPosts()
        {
            if (File.Exists(PostsFile))
            {
                string json = File.ReadAllText(PostsFile);
                posts = JsonSerializer.Deserialize<List<Post>>(json) ?? [];
            }
        }

        //Konverterar posts-listan till JSON format och sparar den i min fil.
        private void SavePosts()
        {
            string json = JsonSerializer.Serialize(posts);
            File.WriteAllText(PostsFile, json);
        }
    }
}