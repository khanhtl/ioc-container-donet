
namespace DI;

public class NewRandomService : INewRandomService
{
    private readonly Guid _guid = Guid.NewGuid();
    public void Print()
    {
        System.Console.WriteLine($"Transion: {this._guid}");
    }
}