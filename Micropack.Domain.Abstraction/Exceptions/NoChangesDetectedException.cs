namespace Micropack.Abstraction;

public class NoChangesDetectedException : Exception
{
    public override string Message => "No changes detected...!";
}