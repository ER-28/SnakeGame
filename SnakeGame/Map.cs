namespace SnakeGame;

public class Map
{
    public int Width { get; }
    public int Height { get; }
    public Fruit Fruit { get; set; }

    public Map(int width, int height)
    {
        Width = width;
        Height = height;
        Fruit = new Fruit(GetRandomPosition());
    }
    
    public void NewFruit()
    {
        Fruit = new Fruit(GetRandomPosition());
    }
    
    public void Draw()
    {
        Console.Clear();
        
        for (int y = 0; y < Height; y++)
        {
            for (int x = 0; x < Width; x++)
            {
                if (y == 0 || y == Height - 1 || x == 0 || x == Width - 1)
                {
                    Console.Write("#");
                }
                else if (Fruit.Position.X == x && Fruit.Position.Y == y)
                {
                    Console.Write("o");
                }
                else if (Game.Player.Position.Any(position => position.X == x && position.Y == y))
                {
                    Console.Write("\u2587");
                }
                else
                {
                    Console.Write(" ");
                }
            }
            
            Console.WriteLine();
        }
    }

    public Position GetRandomPosition()
    {
        Random random = new();
        
        return new Position(random.Next(Width), random.Next(Height));
    }
}