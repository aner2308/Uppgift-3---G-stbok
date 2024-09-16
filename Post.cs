namespace GuestbookApp
{
    //Skapar klass med constructor för hur man skapar ett inlägg
    public class Post(string writer, string message)
    {
        public string Writer { get; set; } = writer;
        public string Message { get; set; } = message;

        //Bestämmer hur inlägget kommer att visas i konsollen
        public override string ToString()
        {
            return $"{Writer}: {Message}";
        }
    }
}