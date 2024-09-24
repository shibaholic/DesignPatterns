namespace DesignPatterns.Creational.Factory_Method;

public static class FactoryMethodClient
{
    public static void Run()
    {
        Console.WriteLine("Factory Method Client start");
        
        // let's create a monster spawner with a 50/50 chance of being either for Spider or Zombie
        MonsterSpawner spawner;
        
        var rand = new Random();
        var roll = rand.Next(0, 2);
        if (roll == 0)
        {
            spawner = new SpiderSpawner();
        }
        else
        {
            spawner = new ZombieSpawner();
        }
        
        // test out spawner tick
        spawner.spawn_tick();
    }
}