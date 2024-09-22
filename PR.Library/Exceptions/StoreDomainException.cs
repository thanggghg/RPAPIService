namespace GoSell.Library.Exceptions
{
    public class StoreDomainException : Exception
    {
        public StoreDomainException(string message) : base(message)
        {
        }

        public string DomainSuggestion { get; set; }
        public bool Valid { get; set; }
        public string LocalizedMessage { get; set; }
    }
}
