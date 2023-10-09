namespace DI;

public class ServiceDescription {
    public Type ServiceType { get; set; }
    public Type ImplementaionType { get; set; }
    public object Implementation { get; set; }
    public ServiceLifeTime ServiceLifeTime { get; set; } 

    public ServiceDescription(Type serviceType, ServiceLifeTime serviceLifeTime)
    {
        this.ServiceType = serviceType;
        this.ServiceLifeTime = serviceLifeTime;
    }
    public ServiceDescription(Type serviceType, Type implementaionType, ServiceLifeTime serviceLifeTime)
    {
        this.ServiceType = serviceType;
        this.ServiceLifeTime = serviceLifeTime;
        this.ImplementaionType = implementaionType;
    }
}