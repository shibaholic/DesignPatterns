namespace DesignPatterns.Structural.Composite;

public class CompositeClient
{
    public static void Run()
    {
        Console.WriteLine(@"Composite Client start\n");

        var root = new Navigation(
            title: "root node",
            elements:
            [
                new SmallText(title: "SmallText", text: "first small text"),
                new BigText(title: "BigText", header: "BigTextHeader", content: "second big text content"),
                new Navigation(
                    title: "MyDirectory", elements:
                    [
                        new SmallText(title: "Another SmallText", text: "first small text again"),
                        new BigText(title: "My Big Story", header: "My Big Story",
                            content: "And then the world was saved and lived happily ever after.")
                    ]
                )
            ]
        );

        var cliController = new CLIController(root);

        while (true)
        {
            cliController.Display();
            //Thread.Sleep(1000);

            // reset cliController if we ended on a leaf node
            if (cliController.PointAt.Children == null)
            {
                cliController.Display();
                cliController.PointAt = root;
                Console.WriteLine("");
            }
        }
        
    }
}