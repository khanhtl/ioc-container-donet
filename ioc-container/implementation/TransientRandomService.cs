
namespace DI;

public class TransientRandomService : ITransientRandomService
{
    private readonly Guid _guid = Guid.NewGuid();
    public void Print()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        System.Console.WriteLine($"[RequestID: {Program.RequestID}]Transion: {this._guid}");
    }
}