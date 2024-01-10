
namespace DI;

public class RandomService : IRandomService
{
    private readonly ISingletonRandomService _singletonService;
    private readonly ITransientRandomService _transientService1;
    private readonly ITransientRandomService _transientService2;
    private readonly IScopedRandomService _scopedService1;
    private readonly IScopedRandomService _scopedService2;

    public RandomService(
        ISingletonRandomService singletonService, 
        ITransientRandomService transientService1, 
        ITransientRandomService transientService2,
        IScopedRandomService scopedService1,
        IScopedRandomService scopedService2
        )
    {
        _singletonService = singletonService;
        _transientService1 = transientService1;
        _transientService2 = transientService2;
        _scopedService1 = scopedService1;
        _scopedService2 = scopedService2;
    }
    public void Print()
    {
        _singletonService.Print();
        
        _transientService1.Print();
        _transientService2.Print();

        _scopedService1.Print();
        _scopedService2.Print();
    }
}