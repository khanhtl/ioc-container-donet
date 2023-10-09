namespace DI;

public class ServiceCollection {
    private List<ServiceDescription> _serviceDescriptions = 
    new List<ServiceDescription>();
    public void AddSingleton<TService>() 
    {
        _serviceDescriptions.Add(new ServiceDescription(typeof(TService), ServiceLifeTime.Singleton));
    }
    public void AddTransient<TService>() 
    {
        _serviceDescriptions.Add(new ServiceDescription(typeof(TService), ServiceLifeTime.Transient));
    }

    public IOCContainer GetIOCContainer() {
        return new IOCContainer(_serviceDescriptions);
    }
}