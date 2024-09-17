using System;
using System.IO.Enumeration;
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
            if(string.IsNullOrWhiteSpace(writer) || string.IsNullOrWhiteSpace(message))
            {
                Console.WriteLine("Error: Både författare och meddelande måste vara ifyllt.");
                return;
            }

            posts.Add(new Post(writer, message));
            SavePosts();
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