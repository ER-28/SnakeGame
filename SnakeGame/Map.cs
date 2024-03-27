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
        for (int y = 0; y < Height + 2; y++)
        {
            for (int x = 0; x < Width + 2; x++)
            {
                if (y == 0 || y == Height + 1)
                {
                    Console.Write(" # ");
                }
                else if (x == 0 || x == Width + 1)
                {
                    Console.Write(" # ");
                }
                else if (Fruit.Position.X == x - 1 && Fruit.Position.Y == y - 1)
                {
                    Console.Write("  o");
                }
                else if (Game.Player.Position.Any(position => position.X == x - 1 && position.Y == y - 1))
                {
                    Console.Write("  \u2587");
                }
                else
                {
                    Console.Write("   ");
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

    public Position GetCenterPosition()
    {
        return new Position(Width / 2, Height / 2);
    }
}