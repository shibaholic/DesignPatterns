namespace DesignPatterns.Behavioral.Command;



public static class CommandClient
{
    public static void Run()
    {
        // TODO: proper error handling
        Console.WriteLine(@"Command Client start\n");

        // create the TextEditor
        var myTextEditor = new TextEditor();

        var cli = new CLIController(myTextEditor);

        while (true)
        {
            Console.WriteLine("");
            Console.WriteLine($"Text: {myTextEditor.Text}");
            Console.WriteLine($"Clipboard: {myTextEditor.Clipboard}");
            cli.Run();
            // reset the CLI choices to default
            cli = new CLIController(myTextEditor);
        }
    }
}