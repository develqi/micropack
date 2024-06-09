namespace Micropack.Abstraction;

public class CascadeDeleteException : Exception
{
    public override string Message => "Cascade delete occurred...!";
}
