namespace SnakeGame;

public class Game
{
    public static Map Map = new(40, 15);
    public static bool GameLoop = true;
    public static Player Player = new (Map.GetRandomPosition());
    
    public Game()
    {
        Console.CursorVisible = false;
        Loop();
    }

    private static void Loop()
    {
        while (GameLoop)
        {
            Map.Draw();
            Player.Move();

            if (Player.Position[0] == Map.Fruit.Position)
            {
                Player.Length++;
                Map.NewFruit();
            }
            
            if (Player.Position[0].X < 0 || Player.Position[0].X >= Map.Width || Player.Position[0].Y < 0 || Player.Position[0].Y >= Map.Height)
            {
                GameLoop = false;
            }
            
            if (Player.Position.Skip(1).Any(position => position == Player.Position[0]))
            {
                GameLoop = false;
            }
            
            if (Console.KeyAvailable)
            {
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
            
            Thread.Sleep(200);
        }
    }
}