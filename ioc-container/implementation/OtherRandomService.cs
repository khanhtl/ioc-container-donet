
namespace DI;

public class OtherRandomService : IOtherRandomService
{
    private readonly IRandomService _randomService;
    private readonly INewRandomService _newRandomService;
    public OtherRandomService(IRandomService randomService, INewRandomService newRandomService)
    {
        _randomService = randomService;
        _newRandomService = newRandomService;
    }
    private readonly Guid _guid = Guid.NewGuid();
    public void Print()
    {
        _randomService.Print();
        _newRandomService.Print();
    }
}