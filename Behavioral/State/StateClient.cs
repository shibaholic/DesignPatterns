namespace DesignPatterns.Behavioral.State;

public static class StateClient
{
    public static void Run()
    {
        Console.WriteLine(@"State Client start\n");

        var context = new Context();
        
        // Get online
        context.BecomeOnline();
        
        // Become idle
        context.BecomeIdle();
        
        // Scheduled event occurs thus become busy
        context.BecomeBusy();
        
        // Turn on DoNotDisturb status
        context.ToggleDoNotDisturb();
        
        // Go offline
        context.BecomeOffline();
        
        // expected output:
        // Offline -> Online
        // Online -> Idle
        // Idle -> Busy
        // Busy -> DoNotDisturb
        // DoNotDisturb -> Offline
    }
}