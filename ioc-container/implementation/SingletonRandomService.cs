
namespace DI;

public class SingletonRandomService : ISingletonRandomService
{
    private readonly Guid _guid = Guid.NewGuid();
    public void Print()
    {
        System.Console.WriteLine($"[RequestID: {Program.RequestID}]Singleton: {this._guid}");
    }
}