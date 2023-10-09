
using DI;

class Program
{
    static void Main(string[] args)
    {
        var services = new ServiceCollection();
        services.AddSingleton(new RandomGuid());
        services.AddTransient(new OtherRandomGuid());
        var container = services.GetIOCContainer();

        var firstRandom = container.GetService<RandomGuid>();
        var secondRandom = container.GetService<RandomGuid>();

        var thirdRandom = container.GetService<OtherRandomGuid>();
        var fourthRandom = container.GetService<OtherRandomGuid>();

        Console.WriteLine(firstRandom.Random);
        Console.WriteLine(secondRandom.Random);
        System.Console.WriteLine("------------------------------");
        Console.WriteLine(thirdRandom.Random);
        Console.WriteLine(fourthRandom.Random);

    }
}