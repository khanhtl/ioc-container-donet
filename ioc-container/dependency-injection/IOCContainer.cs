namespace DI;

public class IOCContainer
{
    private List<ServiceDescription> _serviceDescriptions;
    public IOCContainer(List<ServiceDescription> serviceDescriptions)
    {
        _serviceDescriptions = serviceDescriptions;
    }
    public object GetService(Type serviceType)
    {
        var serviceDescription = _serviceDescriptions
        .SingleOrDefault(x => x.ServiceType == serviceType);
        if (serviceDescription == null)
        {
            throw new Exception($"Service of type {serviceType.Name} is not registered!");
        }

        if (serviceDescription.Implementation != null)
        {
            return serviceDescription.Implementation;
        }

        var realType = serviceDescription.ImplementaionType ?? serviceDescription.ServiceType;

        if (realType.IsAbstract || realType.IsInterface)
        {
            throw new Exception($"Can not create instant from absract or interface!");
        }

        var constructorInfo = realType.GetConstructors().First();
        var parameters = new object[] { };
        if (constructorInfo != null)
        {
            parameters = constructorInfo.GetParameters()
        .Select(x => GetService(x.ParameterType)).ToArray<object>();
        }


        var implementation = Activator.CreateInstance(realType, parameters);
        if (serviceDescription.ServiceLifeTime == ServiceLifeTime.Singleton)
        {
            serviceDescription.Implementation = implementation;
        }

        return implementation;
    }
    public T GetService<T>()
    {
        return (T)this.GetService(typeof(T));
    }
}