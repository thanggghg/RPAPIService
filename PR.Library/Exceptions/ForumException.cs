namespace GoSell.Library.Exceptions
{
    public class ForumException : Exception
    {
        public ForumException(string message) : base(message)
        {
        }

        public ForumException(string message, string messageCode) : base(message)
        {
            MessageCode = messageCode;
        }

        public string MessageCode { get; set; }
    }
}
