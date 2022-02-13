using System.Text.Json;

namespace Micropack.ESCQRS
{
    public static class ICommandExtensions
    {
        public static string Serialize<TCommand>(this TCommand command) where TCommand : ICommand
        {
            return JsonSerializer.Serialize(command);
        }
    }
}
