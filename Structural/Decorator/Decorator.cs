namespace DesignPatterns.Structural.Decorator;

public interface IDecorator
{
    public void Execute(string message);
}

// the base of the stack of decorators
public class BaseDecorator : IDecorator
{
    public void Execute(string message)
    {
        Console.WriteLine(message);
    }
}

public abstract class ConcreteDecorator: IDecorator {
    protected readonly IDecorator Decorator;

    public ConcreteDecorator(IDecorator decorator)
    {
        Decorator = decorator;
    }

    public abstract void Execute(string message);
}

public class UpperCaseDecorator : ConcreteDecorator
{
    public UpperCaseDecorator(IDecorator decorator) : base(decorator)
    {
        
    }

    public override void Execute(string message)
    {
        message = message.ToUpper();
        base.Decorator.Execute(message);
    }
}

public class BackgroundColorDecorator : ConcreteDecorator
{
    private readonly ConsoleColor _color;
    public BackgroundColorDecorator(IDecorator decorator, ConsoleColor color) : base(decorator)
    {
        _color = color;
    }

    public override void Execute(string message)
    {
        Console.BackgroundColor = _color;
        base.Decorator.Execute(message);
    }
}

public class TextColorDecorator : ConcreteDecorator
{
    private readonly ConsoleColor _color;
    public TextColorDecorator(IDecorator decorator, ConsoleColor color) : base(decorator)
    {
        _color = color;
    }

    public override void Execute(string message)
    {
        Console.ForegroundColor = _color;
        base.Decorator.Execute(message);
    }
}
