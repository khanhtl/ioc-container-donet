
namespace DI;

public class RandomService : IRandomService
{
    private readonly Guid _guid = Guid.NewGuid();
    public void Print()
    {
        System.Console.WriteLine($"Singleton: {this._guid}");
    }
}