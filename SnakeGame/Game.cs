namespace SnakeGame;

public class Game
{
    public static Map Map = new(40, 15);
    public static bool GameLoop = true;
    public static Player Player = new (Map.GetCenterPosition());
    public static Chrono Chrono = new();
    public static int Count = 0;
    
    public Game()
    {
        Console.CursorVisible = false;
        Loop();
    }

    private void Loop()
    {
        while (GameLoop)
        {
            Console.Clear();
            
            Chrono.PrintTime();
            Console.WriteLine("Score: " + ((Player.Length - 1) * 100));
            
            Map.Draw();
            Player.Move();
            
            HandleInput();
            
            Chrono.Update();
            Thread.Sleep(200);
        }
    }
    
    public void HandleInput()
    {
        if (!Console.KeyAvailable) return;
        
        var key = Console
            .ReadKey(intercept: true)
            .Key;
                
        Player.Direction = key switch 
        {
            ConsoleKey.Z => 0,
            ConsoleKey.D => 1,
            ConsoleKey.S => 2,
            ConsoleKey.Q => 3,
            _ => Player.Direction
        };
                
        if (key == ConsoleKey.Escape)
        {
            GameLoop = false;
        }
    }
}