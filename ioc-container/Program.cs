
using DI;

class Program
{
    static void Main(string[] args)
    {
        var services = new ServiceCollection();
        services.AddSingleton<IRandomService,RandomService>();
        services.AddTransient<INewRandomService,NewRandomService>();
        var container = services.GetIOCContainer();

        var randomService1 = container.GetService<IRandomService>();
        var randomService2 = container.GetService<IRandomService>();

        var newRandomService1 = container.GetService<INewRandomService>();
        var newRandomService2 = container.GetService<INewRandomService>();

        randomService1.Print();
        randomService2.Print();
        System.Console.WriteLine("---------------------");
        newRandomService1.Print();
        newRandomService2.Print();


    }
}