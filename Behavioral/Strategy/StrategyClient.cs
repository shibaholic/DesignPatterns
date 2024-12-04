using System.Security.Authentication.ExtendedProtection;
using Microsoft.Extensions.DependencyInjection;

namespace DesignPatterns.Behavioral.Strategy;

public class StrategyClient
{
    public static void Run()
    {
        Console.WriteLine(@"Strategy Client start\n");
        
        // use ServiceCollection to use DI
        var services = new ServiceCollection();

        // strategy
        services.AddScoped<PostOfficeDelivery>();
        services.AddScoped<HomeDelivery>();

        // strategy factory. Converts string deliveryType to IDeliveryStrategy DI service.
        services.AddScoped<DeliveryFactory>();
        
        // processor that executes the delivery strategy
        services.AddScoped<DeliveryProcessor>();
        
        var serviceProvider = services.BuildServiceProvider();
        
        // 1. imagine this is the start of a request that makes a home delivery
        
        var deliveryProcessor = serviceProvider.GetRequiredService<DeliveryProcessor>();

        var request1_deliveryType = "HomeDelivery";
        var request1_address = "1 Apple Street";
        
        deliveryProcessor.ProcessDelivery(request1_deliveryType, request1_address);
        
        // 2. second request
        
        var request2_deliveryType = "PostOfficeDelivery";
        var request2_address = "2 Apple Street";
        
        deliveryProcessor.ProcessDelivery(request2_deliveryType, request2_address);
        
    }
}