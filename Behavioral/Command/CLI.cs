namespace DesignPatterns.Behavioral.Command;

public abstract class Choice
{
    public string Title { get; set; }

    public Choice(string title)
    {
        Title = title;
    }

    public abstract void UserInput();
    public abstract ICommand CreateCommand(TextEditor textEditor);
}

// each concrete Choice has a user_input action, and generic ICommand to feed that user_input data.
public class TwoIndexChoice<TConcreteCmd> : Choice
where TConcreteCmd : ITwoIndexCommand
{
    private int s_index { get; set; }
    private int e_index { get; set; }
    
    public TwoIndexChoice(string title) : base(title) { }

    public override void UserInput()
    {
        while (true)
        {
            Console.WriteLine("Enter the start index: ");
            var response = Utility.Parse(Console.ReadLine()!);
            if (!response.Success)
            {
                Console.WriteLine("Invalid input.");
                continue;
            }

            s_index = (int)response.Data!;
            break;
        }
        
        while (true)
        {
            Console.WriteLine("Enter the end index: ");
            var response = Utility.Parse(Console.ReadLine()!);
            if (!response.Success)
            {
                Console.WriteLine("Invalid input.");
                continue;
            }

            e_index = (int)response.Data!;
            break;
        }
    }

    public override ICommand CreateCommand(TextEditor textEditor)
    {
        return (TConcreteCmd)Activator.CreateInstance(
            typeof(TConcreteCmd), 
            new object[] {textEditor, s_index, e_index}
        )!;
    }
}

public class StringChoice<TConcreteCmd> : Choice
where TConcreteCmd : IStringCommand
{
    private string text { get; set; }
    
    public StringChoice(string title) : base(title) { }

    public override void UserInput()
    {
        while (true)
        {
            Console.WriteLine("Enter text: ");
            string? strResponse = Console.ReadLine();
            if (strResponse == null)
            {
                Console.WriteLine("Invalid null input.");
                continue;
            }

            text = strResponse;
            break;
        }
    }

    public override ICommand CreateCommand(TextEditor textEditor)
    {
        return (TConcreteCmd)Activator.CreateInstance(
            typeof(TConcreteCmd), 
            new object[] {textEditor, text}
        )!;
    }
}

public class NoInputChoice<TConcreteCmd> : Choice
where TConcreteCmd : ICommand
{
    public NoInputChoice(string title) : base(title) { }

    public override void UserInput()
    {
    }

    public override ICommand CreateCommand(TextEditor textEditor)
    {
        return (TConcreteCmd)Activator.CreateInstance(
            typeof(TConcreteCmd), 
            new object[] {textEditor}
        )!;
    }
}

public class CLIController
{
    public Choice[] Choices { get; set; }
    private readonly TextEditor _textEditor;
    
    public CLIController(TextEditor textEditor)
    {
        Choices = new Choice[]
        {
            new StringChoice<AppendTextCommand>("Append text"),
            new TwoIndexChoice<CopyCommand>("Copy"),
            new NoInputChoice<PasteCommand>("Paste"),
            new TwoIndexChoice<CutCommand>("Cut"),
            
        };
        
        _textEditor = textEditor;
    }

    public void Run()
    {
        // print current choices
        Console.WriteLine("Enter a choice: ");
        var cIndex = 1;
        foreach (var choice in Choices)
        {
            Console.WriteLine($"{cIndex}. {choice.Title}");
            cIndex++;
        }

        var response = Utility.Parse(Console.ReadLine()!);

        if (!response.Success)
        {
            Console.WriteLine("Invalid input.");
            return;
        }

        var selectedChoice = Choices[(int)response.Data! - 1];
        // now with the choice selected, we need to perform the necessary user input
        // for the corresponding action -> command
        // AppendCommand needs string user input
        // CopyCommand needs 2 index user input
        selectedChoice.UserInput();

        var command = selectedChoice.CreateCommand(_textEditor);
        command.Execute();
    }
}

public static class Utility
{
    public record ParseResponse
    {
        public bool Success { get; set; }
        public int? Data { get; set; }
    }

    public static ParseResponse Parse(string input)
    {
        if (int.TryParse(input, out int parsed))
        {
            return new ParseResponse() { Success = true, Data = parsed};
        }
        return new ParseResponse() { Success = false };
    }
}