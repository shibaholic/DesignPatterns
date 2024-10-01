namespace DesignPatterns.Structural.Composite;

public interface ICommand
{
    public CLIController Pointer { get; set; }
    public void Execute();
}

public class BlankCommand : ICommand
{
    public CLIController Pointer { get; set; }
    public void Execute()
    {
        
    }
}

public class NavigationCommand : ICommand
{
    public CLIController Pointer { get; set; }
    public Element NavToElement { get; set; }

    public NavigationCommand(CLIController controller, Element navToElement)
    {
        Pointer = controller;
        NavToElement = navToElement;
    }
    
    public void Execute()
    {
        Pointer.PointAt = NavToElement;
    }
}