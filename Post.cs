namespace GuestbookApp
{
    public class Post(string writer, string message)
    {
        public string Writer { get; set; } = writer;
        public string Message { get; set; } = message;

        public override string ToString()
        {
            return $"{Writer}: {Message}";
        }
    }
}