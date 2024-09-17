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

//Funktion för att ta bort ett gästboksinlägg.
        public void RemovePost(int index)
        {

            //Kontrollerar att det finns ett inlägg med det angivna numret.
            if (index < 0 || index >= posts.Count)
            {
                Console.WriteLine("Error: Det finns inget inlägg med det angivna nummret.");
                return;
            }

            posts.RemoveAt(index);
            SavePosts();
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