namespace DesignPatterns.Creational.Abstract_Factory;

public interface VillageFactory
{
    public Farm GenerateFarm();
    public Blacksmith GenerateBlacksmith();
    public Road GenerateRoad();
}

public class PlainsVillageFactory : VillageFactory
{
    public Farm GenerateFarm()
    {
        return new PlainsFarm();
    }
    public Blacksmith GenerateBlacksmith()
    {
        return new PlainsBlacksmith();
    }
    public Road GenerateRoad()
    {
        return new PlainsRoad();
    }
}

public class SnowVillageFactory : VillageFactory
{
    public Farm GenerateFarm()
    {
        return new SnowFarm();
    }
    public Blacksmith GenerateBlacksmith()
    {
        return new SnowBlacksmith();
    }
    public Road GenerateRoad()
    {
        return new SnowRoad();
    }
}

public class DesertVillageFactory : VillageFactory
{
    public Farm GenerateFarm()
    {
        return new DesertFarm();
    }
    public Blacksmith GenerateBlacksmith()
    {
        return new DesertBlacksmith();
    }
    public Road GenerateRoad()
    {
        return new DesertRoad();
    }
}

public abstract class Structure
{
    public string Type { get; set; }
    public string Biome { get; set; }
}

public class Farm : Structure
{
    protected Farm()
    {
        Type = "Farm";
    }
}

public class PlainsFarm : Farm
{
    public PlainsFarm() : base()
    {
        Biome = "Plains";
    }
}

public class SnowFarm : Farm
{
    public SnowFarm() : base()
    {
        Biome = "Snow";
    }
}

public class DesertFarm : Farm
{
    public DesertFarm() : base()
    {
        Biome = "Desert";
    }
}


public class Blacksmith : Structure
{
    protected Blacksmith()
    {
        Type = "Blacksmith";
    }
}

public class PlainsBlacksmith : Blacksmith
{
    public PlainsBlacksmith() : base()
    {
        Biome = "Plains";
    }
}

public class SnowBlacksmith : Blacksmith
{
    public SnowBlacksmith() : base()
    {
        Biome = "Snow";
    }
}

public class DesertBlacksmith : Blacksmith
{
    public DesertBlacksmith() : base()
    {
        Biome = "Desert";
    }
}


public class Road : Structure
{
    protected Road()
    {
        Type = "Road";
    }
}

public class PlainsRoad : Road
{
    public PlainsRoad() : base()
    {
        Biome = "Plains";
    }
}

public class SnowRoad : Road
{
    public SnowRoad() : base()
    {
        Biome = "Snow";
    }
}

public class DesertRoad : Road
{
    public DesertRoad() : base()
    {
        Biome = "Desert";
    }
}