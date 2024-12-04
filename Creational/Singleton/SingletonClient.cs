using System.Security.Authentication.ExtendedProtection;
using Microsoft.Extensions.DependencyInjection;

namespace DesignPatterns.Creational.Singleton;

public class SingletonClient
{
    public static void Run()
    {
        Console.WriteLine(@"Singleton Client start\n");
        
        // use ServiceCollection to use DI to create Singleton
        var services = new ServiceCollection();

        services.AddSingleton<SingletonGameState>();
        
        // get serviceProvider and resolve the Singleton service
        
        var serviceProvider = services.BuildServiceProvider();
        
        var gameStateService = serviceProvider.GetRequiredService<SingletonGameState>();

        // Test 1: Simple read: read the default values initialized in the Singleton constructor
        
        var input1 = new [] {"1", "2"};
        var output1 = gameStateService.ReadGameStates(input1);

        Console.WriteLine("Test 1: Simple read");
        foreach (var value in input1.Zip(output1, Tuple.Create))
        {
            Console.WriteLine(value.Item1 + ": " + value.Item2);
        }
        
        // Test 2: Simple write then read
        
        var input2_keys = new[] { "1", "3" };
        var input2_values = new[] { "ONE-ONE", "THREE" };
        
        gameStateService.WriteGameStates(input2_keys, input2_values);
        
        var input2_readAll = new[] { "1", "2", "3" };
        var output2_readAll = gameStateService.ReadGameStates(input2_readAll);
        Console.WriteLine("Test 2: Simple write then read");
        foreach (var value in input2_readAll.Zip(output2_readAll, Tuple.Create))
        {
            Console.WriteLine(value.Item1 + ": " + value.Item2);
        }
        
        // Test 3: Thread lock test read
        Thread thread1 = new(() =>
        {
            Console.WriteLine($"[{Thread.CurrentThread.ManagedThreadId}] Thread 1 starting...");
            gameStateService.ReadGameStates(input2_readAll);
            Console.WriteLine($"[{Thread.CurrentThread.ManagedThreadId}] Thread 1 finished!");
        });

        Thread thread2 = new(() =>
        {
            Console.WriteLine($"[{Thread.CurrentThread.ManagedThreadId}] Thread 2 starting...");
            Thread.Sleep(2000);
            Console.WriteLine(
                $"[{Thread.CurrentThread.ManagedThreadId}] Thread 2 waited 2 seconds. Try to get lock...");
            gameStateService.ReadGameStates(input2_readAll);
            Console.WriteLine($"[{Thread.CurrentThread.ManagedThreadId}] Thread 2 finished!");
        });
        
        thread1.Start();
        thread2.Start();
        
        thread1.Join();
        thread2.Join();

        Console.WriteLine("All threads completed.");
    }
}