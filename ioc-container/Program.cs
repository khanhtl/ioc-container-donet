
using DI;

class Program
{
    public static int RequestID = 1;
    public static int CurrRequestID = 1;
    static void Main(string[] args)
    {
        var services = new ServiceCollection();
        services.AddSingleton<ISingletonRandomService,SingletonRandomService>();
        services.AddTransient<ITransientRandomService,TransientRandomService>();
        services.AddScoped<IScopedRandomService,ScopedRandomService>();
        


        services.AddTransient<IRandomService, RandomService>();
        var container = services.GetIOCContainer();

        var randomService1 = container.GetService<IRandomService>();
        var randomService2 = container.GetService<IRandomService>();

        while (true)
        {
            
            // singletonService1.Print();
            // singletonService2.Print();

            // Console.WriteLine("---------------------");
            // transientService1.Print();
            // transientService2.Print();

            // Console.WriteLine("---------------------");
            randomService1.Print();

            Console.WriteLine("---------------------");
            randomService2.Print();

            RequestID +=1;
            var cmd = System.Console.ReadLine();
            if(cmd == "exit") {
                break;
            } else {
                randomService1 = container.GetService<IRandomService>();
                randomService2 = container.GetService<IRandomService>();
            }
        }

        
    }
}