namespace DesignPatterns.Structural.Decorator;

public static class DecoratorClient
{
    public static void Run()
    {
        Console.WriteLine(@"Decorator Client start\n");

        IDecorator decorator = new BaseDecorator();
        decorator = new UpperCaseDecorator(decorator);
        
        decorator.Execute("Hello World");

        decorator = new BackgroundColorDecorator(decorator, ConsoleColor.White);
        decorator = new TextColorDecorator(decorator, ConsoleColor.Black);
        
        decorator.Execute("Hello World 2");
    }
}