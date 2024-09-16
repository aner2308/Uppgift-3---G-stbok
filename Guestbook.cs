using System;

namespace GuestbookApp
{
    public class Guestbook
    {
        private List<Post> posts = [];


        //Funktion för att lägga till inlägg med parametrarna som användaren fyllt i.
        public void AddPost(string writer, string message)
        {
            //Kontrollerar så att inget fält har lämnats tomt.
            if(string.IsNullOrWhiteSpace(writer) || string.IsNullOrWhiteSpace(message))
            {
                Console.WriteLine("Error: Både författare och meddelande måste vara ifyllt.");
                return;
            }

            //Skriver ut författaren och meddelandet.
            Console.WriteLine($"{writer}: {message}");

            posts.Add(new Post(writer, message));
        }
    }
}