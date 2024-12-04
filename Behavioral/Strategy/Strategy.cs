using Microsoft.Extensions.DependencyInjection;

namespace DesignPatterns.Behavioral.Strategy;

public interface IDeliveryStrategy
{
    void OrderDelivery(string address);
}

public class HomeDelivery: IDeliveryStrategy
{
    // private readonly ILogger<IDeliveryStrategy> _logger;
    
    public HomeDelivery()
    {
        // various DI services
    }

    public void OrderDelivery(string address)
    {
        Console.WriteLine($"Home delivering to {address}!");
    }
}

public class PostOfficeDelivery: IDeliveryStrategy
{
    public PostOfficeDelivery()
    {
        // various DI services
    }
    
    public void OrderDelivery(string address)
    {
        Console.WriteLine($"Post Office delivering to {address}!");
    }
}

public class DeliveryProcessor
{
    private readonly DeliveryFactory _deliveryFactory;

    public DeliveryProcessor(DeliveryFactory deliveryFactory)
    {
        _deliveryFactory = deliveryFactory;
    }

    public void ProcessDelivery(string deliveryType, string address)
    {
        var deliveryStrategy = _deliveryFactory.CreateDeliveryStrategy(deliveryType);
        deliveryStrategy.OrderDelivery(address);
    }
}
    
public class DeliveryFactory
{
    private readonly IServiceProvider _serviceProvider;

    public DeliveryFactory(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public IDeliveryStrategy CreateDeliveryStrategy(string deliveryType)
    {
        return deliveryType switch
        {
            "HomeDelivery" => _serviceProvider.GetRequiredService<HomeDelivery>(),
            "PostOfficeDelivery" => _serviceProvider.GetRequiredService<PostOfficeDelivery>(),
            _ => throw new ArgumentException("Invalid delivery type")
        };
    }
}