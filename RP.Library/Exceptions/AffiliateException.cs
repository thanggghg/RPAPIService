namespace RP.Library.Exceptions
{
    public class AffiliateException : Exception
    {
        public int Code { get; }

        public AffiliateException()
        { }
        public AffiliateException(string message)
            : base(message)
        { }

        public AffiliateException(string message, Exception innerException)
            : base(message, innerException)
        {

        }

        public AffiliateException(int code, string message) : base(message)
        {
            Code = code;
        }
    }
}
