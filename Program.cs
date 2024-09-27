using DesignPatterns.Behavioral.Command;
using DesignPatterns.Behavioral.State;
using DesignPatterns.Creational.Factory_Method;
using DesignPatterns.Creational.Abstract_Factory;
using DesignPatterns.Creational.Prototype;

namespace DesignPatterns;

public class Program
{
    public static void Main(string[] args)
    {
        // FactoryMethodClient.Run();
        // AbstractFactoryClient.Run();
        // PrototypeClient.Run();
        // StateClient.Run();
        CommandClient.Run();
    }
}