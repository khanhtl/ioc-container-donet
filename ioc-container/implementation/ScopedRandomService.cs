
namespace DI;

public class ScopedRandomService : IScopedRandomService
{
    private readonly Guid _guid = Guid.NewGuid();
    public void Print()
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        System.Console.WriteLine($"[RequestID: {Program.RequestID}]Scoped: {this._guid}");
    }
}