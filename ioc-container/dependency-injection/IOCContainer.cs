namespace DI;

public class IOCContainer
{
    private static List<ServiceDescription> _serviceDescriptions;
    public static int RequestID = 1;
    public IOCContainer(List<ServiceDescription> serviceDescriptions)
    {
        _serviceDescriptions = serviceDescriptions;
    }
    public static void RemoveInstance() {
        foreach (var item in _serviceDescriptions)
        {
            if(item.ServiceLifeTime == ServiceLifeTime.Transient) {
                item.Implementation = null;
            }
        }
    }
    /// <summary>
    /// Service type: Interface or Implementation
    /// </summary>
    /// <param name="serviceType"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public object GetService(Type serviceType)
    {
        var serviceDescription = _serviceDescriptions.SingleOrDefault(x => x.ServiceType == serviceType);
        if (serviceDescription == null)
        {
            throw new Exception($"Service of type {serviceType.Name} is not registered!");
        }
        if (serviceDescription.Implementation != null)
        {
            if(!(serviceDescription.ServiceLifeTime == ServiceLifeTime.Scoped && serviceDescription.RequestID != Program.RequestID)) {
                return serviceDescription.Implementation;
            }
        }
        // if register inteface and implementation get implementation from interfact type
        var realType = serviceDescription.ImplementaionType ?? serviceDescription.ServiceType;

        if (realType.IsAbstract || realType.IsInterface)
        {
            throw new Exception($"Can not create instant from absract or interface!");
        }

        var constructorInfos = realType.GetConstructors();
        if(constructorInfos.Count() > 1) {
            throw new Exception($"Multiple constructors exception");
        }

        var constructorInfo = constructorInfos.First();
        var parameters = new object[] { };
        if (constructorInfo != null)
        {
            parameters = constructorInfo.GetParameters().Select(x => GetService(x.ParameterType)).ToArray<object>();
        }


        var implementation = Activator.CreateInstance(realType, parameters);
        if (serviceDescription.ServiceLifeTime == ServiceLifeTime.Singleton || serviceDescription.ServiceLifeTime == ServiceLifeTime.Scoped)
        {
            serviceDescription.Implementation = implementation;

        }
        serviceDescription.RequestID = Program.RequestID;
        return implementation;
    }
    public T GetService<T>()
    {
        return (T)this.GetService(typeof(T));
    }
}