namespace DesignPatterns.Creational.Factory_Method;

public abstract class MonsterSpawner
{
    protected abstract Monster CreateMonster();

    public void spawn_tick()
    {
        var monster = CreateMonster();
        /* perform business logic to configure monster health and attack power */
        Console.WriteLine($"Spawned monster: {monster.Name}");
    }
}

public class SpiderSpawner : MonsterSpawner
{
    protected override Monster CreateMonster()
    {
        return new Spider();
    }
}

public class ZombieSpawner : MonsterSpawner
{
    protected override Monster CreateMonster()
    {
        return new Zombie();
    }
}

public abstract class Monster
{
    public string Name { get; set; }
    
    public void attack()
    {
        /* attack implementation */
    }
}

public class Spider : Monster
{
    public Spider()
    {
        base.Name = "Spider";
    }
}

public class Zombie : Monster
{
    public Zombie()
    {
        base.Name = "Zombie";
    }
}