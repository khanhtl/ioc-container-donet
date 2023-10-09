namespace DI;

public class IOCContainer
{
    private List<ServiceDescription> _serviceDescriptions;
    public IOCContainer(List<ServiceDescription> serviceDescriptions)
    {
        _serviceDescriptions = serviceDescriptions;
    }
    public T GetService<T>()
    {
        var serviceDescription = _serviceDescriptions
        .SingleOrDefault(x => x.ServiceType == typeof(T));
        if (serviceDescription == null)
        {
            throw new Exception($"Service of type {typeof(T).Name} is not registered!");
        }

        if (serviceDescription.Implementation != null)
        {
            return (T)serviceDescription.Implementation;
        }

        var type = serviceDescription.ImplementaionType ?? serviceDescription.ServiceType;

        var implementation = (T)Activator.CreateInstance(type);
        if (serviceDescription.ServiceLifeTime == ServiceLifeTime.Singleton)
        {
            serviceDescription.Implementation = implementation;
        }

        return implementation;
    }
}