namespace DI;

public class ServiceDescription {
    public Type ServiceType { get; set; }
    public object Implementation { get; set; }
    public ServiceLifeTime ServiceLifeTime { get; set; } 

    public ServiceDescription(object implementation, ServiceLifeTime serviceLifeTime)
    {
        this.ServiceType = implementation.GetType();
        this.Implementation = implementation;
        this.ServiceLifeTime = serviceLifeTime;
    }
}