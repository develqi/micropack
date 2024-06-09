namespace Micropack.Abstraction;

public class RateLimitingException : Exception
{
    public override string Message => "Rate limiting...!";
}
