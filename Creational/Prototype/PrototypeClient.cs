using DesignPatterns.Creational.Factory_Method;

namespace DesignPatterns.Creational.Prototype;

public static class PrototypeClient
{
    public static void Run()
    {
        Console.WriteLine(@"Prototype Client start\n");
        
        // First: demonstrate cloning (deep copy) on the PurchaseLogic class
        Console.WriteLine("First: demonstrate cloning (deep copy) on the PurchaseLogic class");
        List<Rule> firstRules = new List<Rule> { new(id:"rule1", logic:"VeryLogical") };
        var firstPL = new PurchaseLogic("first", firstRules);
        var clonedFirstPL = firstPL.Clone();

        // if we change firstPL's rule1, it will not change the clonedFirstPL's rule1
        firstPL.rules[0].logic = "NotLogical";
        Console.WriteLine($"firstPL rule1's logic: {firstPL.rules[0].logic}");
        Console.WriteLine($"clonedFirstPL rule1's logic: {clonedFirstPL.rules[0].logic}");

        // expected print outcome:
        // firstPL rule1's logic: NotLogical
        // clonedFirstPL rule1's logic: VeryLogical

        Console.WriteLine();

        // Second: demonstrate cloning (deep copy) on the AmazonPurchaseLogic subclass
        Console.WriteLine("Second: demonstrate cloning (deep copy) on the AmazonPurchaseLogic subclass");
        List<Rule> secondRules = new List<Rule> { new(id:"rule2", logic:"VeryLogical") };
        var amazonPL = new AmazonPurchaseLogic("second", secondRules);
        var clonedAmazonPL = amazonPL.Clone();

        // if we change amazonPL's rule2, it will not change the clonedAmazonPL's rule1
        amazonPL.rules[0].logic = "NotLogical";
        Console.WriteLine($"amazonPL rule2's logic: {amazonPL.rules[0].logic}");
        Console.WriteLine($"clonedAmazonPL rule2's logic: {clonedAmazonPL.rules[0].logic}");

        // expected print outcomes:
        // amazonPL rule2's logic: NotLogical
        // clonedAmazonPL rule2's logic: VeryLogical

        Console.WriteLine();

        // Third: demonstate the use of a Dictionary<TKey, TValue> to store Prototypes
        // and simply clone them instead of constructing them from scratch (which may be computationally expensive)
        Console.WriteLine("Third: use a repository to store PurchaseLogic so we avoid the computationally expensive process of constructing them from scratch");
        var repository = new Dictionary<string, PurchaseLogic>();
        repository.Add(firstPL.id, firstPL);
        repository.Add(amazonPL.id , amazonPL);

        // make a clone of firstPL from the repository
        var thirdPL = repository["first"].Clone();

        // change thirdPL
        thirdPL.rules[0].logic = "NullString";
        Console.WriteLine($"repository firstPL rule1's logic: {repository["first"].rules[0].logic}");
        Console.WriteLine($"thirdPL rule1's logic: {thirdPL.rules[0].logic}");

        // expected prinbt outcome:
        // repository firstPL rule1's logic: NotLogical
        // thirdPL rule1's logic: NullString
    }
}