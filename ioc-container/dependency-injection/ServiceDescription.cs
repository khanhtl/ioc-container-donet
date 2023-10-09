namespace DI;

public class ServiceDescription {
    public Type ServiceType { get; set; }
    public object Implementation { get; set; }
    public ServiceLifeTime ServiceLifeTime { get; set; } 

    public ServiceDescription(Type ServiceType, ServiceLifeTime serviceLifeTime)
    {
        this.ServiceType = ServiceType;
        this.ServiceLifeTime = serviceLifeTime;
    }
}