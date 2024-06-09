namespace Micropack.Abstraction;

public class NotFoundException : Exception
{
    public override string Message => "Not found object by the unique identity...!";
}