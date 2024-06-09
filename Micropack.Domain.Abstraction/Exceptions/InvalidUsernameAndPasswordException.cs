namespace Micropack.Abstraction;

public class InvalidUsernameAndPasswordException : Exception
{
    public override string Message => "Invalid username and password...!";
}