namespace DesignPatterns.Creational.Singleton;

public class SingletonGameState
{
    private Dictionary<string, string> _gameState;
    private readonly object _lock = new();
    
    public SingletonGameState()
    {
        // _gameState = new Dictionary<string, string>();
        _gameState = new Dictionary<string, string> {{"1", "one"}, {"2", "two"}};
    }

    public string?[] ReadGameStates(string[] gameStateKeys)
    {
        var output = new string?[gameStateKeys.Length];
        lock (_lock)
        {
            Console.WriteLine($"[{Thread.CurrentThread.ManagedThreadId}] has the lock!");
            Thread.Sleep(5000);
            for(int i = 0; i < gameStateKeys.Length; i++)
            {
                output[i] = _gameState.GetValueOrDefault(gameStateKeys[i]);
            }
        }
        
        Console.WriteLine($"[{Thread.CurrentThread.ManagedThreadId}] dropped the lock!");

        return output;
    }

    public void WriteGameStates(string[] gameStateKeys, string[] gameStateValues)
    {
        if (gameStateKeys.Length != gameStateValues.Length) throw new ArgumentException("gameStateKeys and gameStateValues count do not match");
        
        lock (_lock)
        {
            for (int i = 0; i < gameStateKeys.Length; i++)
            {
                _gameState[gameStateKeys[i]] = gameStateValues[i];
            }
        }
    }
}