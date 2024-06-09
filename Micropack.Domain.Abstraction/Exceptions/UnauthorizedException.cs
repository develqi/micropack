namespace Micropack.Abstraction;

public class UnauthorizedException : Exception
{
    public override string Message => "Unauthorized...!";
}
