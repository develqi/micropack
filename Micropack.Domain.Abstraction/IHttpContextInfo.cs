namespace Micropack.Abstraction;

public interface IHttpContextInfo
{
    int Port { get; init; }

    string IP { get; init; }
}

public record class HttpContextInfo(string IP, int Port = 0) : IHttpContextInfo;