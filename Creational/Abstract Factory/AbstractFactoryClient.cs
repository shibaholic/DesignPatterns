namespace DesignPatterns.Creational.Abstract_Factory;

public static class AbstractFactoryClient
{
    public static void Run()
    {
        Console.WriteLine("Abstract Factory Client start");
        
        // Depending on which biome the village generation is taking place, determines what style of village is generated.
        // Plains biome results in villages with plains architecture, and so forth for snow biome and desert biome.

        VillageFactory villageFactory;
        
        // Let's use rng to determine which biome is being used.
        var rand = new Random();
        var roll = rand.Next(0, 3); // 0 = plains, 1 = snow, 2 = desert
        switch (roll)
        {
            case 0:
                villageFactory = new PlainsVillageFactory();
                break;
            case 1:
                villageFactory = new SnowVillageFactory();
                break;
            default:
                villageFactory = new DesertVillageFactory();
                break;
        }
        
        // Let's generate 1 of each structure.
        var farm = villageFactory.GenerateFarm();
        var blacksmith = villageFactory.GenerateBlacksmith();
        var road = villageFactory.GenerateRoad();
        
        // Check if they are all the biome.
        Console.WriteLine("<Object>: <Type> <Biome>");
        Console.WriteLine($"Farm: {farm.Type}, {farm.Biome}");
        Console.WriteLine($"Blacksmith: {blacksmith.Type}, {blacksmith.Biome}");
        Console.WriteLine($"Road: {road.Type}, {road.Biome}");
    }
}