namespace DI;

public class ServiceCollection {
    private List<ServiceDescription> _serviceDescriptions = 
    new List<ServiceDescription>();
    public void AddSingleton<TService>(TService implementation) 
    {
        _serviceDescriptions.Add(new ServiceDescription(implementation, ServiceLifeTime.Singleton));
    }
    public void AddTransient<TService>(TService implementation) 
    {
        _serviceDescriptions.Add(new ServiceDescription(implementation, ServiceLifeTime.Transient));
    }

    public IOCContainer GetIOCContainer() {
        return new IOCContainer(_serviceDescriptions);
    }
}