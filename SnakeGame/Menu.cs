namespace SnakeGame;

// display a menu with play and exit in center of console controllable with arrow keys and enter for selection
public class Menu
{
    private bool open = true;
    private bool selected;
    
    public Menu()
    {
        Console.CursorVisible = false;
        Loop();
    }

    private void Loop()
    {
        selected = false;
        while (open)
        {
            Console.Clear();
            
            Console.SetCursorPosition(Console.WindowWidth / 2 - 4, Console.WindowHeight / 2 - 1);
            Console.Write(selected ? "Play" : "> Play");

            Console.SetCursorPosition(Console.WindowWidth / 2 - 4, Console.WindowHeight / 2 + 1);
            Console.Write(selected ? "> Exit" : "Exit");

            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.UpArrow:
                    selected = false;
                    break;
                case ConsoleKey.DownArrow:
                    selected = true;
                    break;
                case ConsoleKey.Enter:
                    switch (selected)
                    {
                        case false:
                            var game = new Game();
                            open = false;
                            break;
                        case true:
                            Environment.Exit(0);
                            break;
                    }
                    break;
            }
        }
    }
    
    
}