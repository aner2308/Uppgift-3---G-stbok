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
                Console.WriteLine("Error: Both writer and message must be submitted.");
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
                Console.WriteLine("Choose the number of the post that you wish to remove, or press 'R' to return.");
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

                        Console.WriteLine("Error: No existing post with the given number.");
                    }
                    else
                    {
                        //Rensar konsollen
                        Console.Clear();
                        
                        //Tar bort inläggen på den angivna positionen i listan. (Som kommer att matcha inläggets siffra i konsollen).
                        posts.RemoveAt(num);
                        Console.WriteLine($"Post number {num} has been removed.");
                        SavePosts();
                        Console.WriteLine("Press any key to return to menu.");
                        Console.ReadKey();
                        return;
                    }
                }
                else
                {
                    //Felmeddelane vid felaktig inmatning.
                    Console.WriteLine("Error: Bad submission. Please submit an existing number.");
                }

                //Fråga om att försöka igen om man gjort fel.
                Console.WriteLine("Would you like to try again? 'Y/N': ");
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
                Console.WriteLine("The guestbook is empty...");
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