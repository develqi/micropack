namespace Micropack.Abstraction;

public class NotFoundException : Exception
{
    private readonly string? _message;

    public NotFoundException(string? message = "NotFound...!") => _message = message;

    public override string Message => _message;
}
