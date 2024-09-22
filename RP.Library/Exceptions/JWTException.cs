namespace RP.Library.Exceptions;
public class JWTException : Exception
{
    public JWTException()
    { }
    public JWTException(string message)
        : base(message)
    { }

    public JWTException(string message, Exception innerException)
        : base(message, innerException)
    {

    }
}
