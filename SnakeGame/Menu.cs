namespace SnakeGame;

// display a menu with play and exit in center of console controllable with arrow keys and enter for selection
public class Menu
{
    private bool _open = true;
    private bool _selected;
    
    public Menu()
    {
        Console.CursorVisible = false;
        Loop();
    }

    private void Loop()
    {
        _selected = false;
        while (_open)
        {
            Console.Clear();
            
            Console.SetCursorPosition(Console.WindowWidth / 2 - 4, Console.WindowHeight / 2 - 1);
            Console.Write(_selected ? "Play" : "> Play");

            Console.SetCursorPosition(Console.WindowWidth / 2 - 4, Console.WindowHeight / 2 + 1);
            Console.Write(_selected ? "> Exit" : "Exit");

            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.UpArrow:
                    _selected = false;
                    break;
                case ConsoleKey.DownArrow:
                    _selected = true;
                    break;
                case ConsoleKey.Enter:
                    switch (_selected)
                    {
                        case false:
                            var game = new Game();
                            _open = false;
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