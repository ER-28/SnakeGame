namespace SnakeGame;

public class Position(int x, int y)
{
    public int X { get; set; } = x;
    public int Y { get; set; } = y;

    public static Position operator +(Position a, Position b)
    {
        return new Position(a.X + b.X, a.Y + b.Y);
    }
    
    public static bool operator ==(Position a, Position b)
    {
        return a.X == b.X && a.Y == b.Y;
    }

    public static bool operator !=(Position a, Position b)
    {
        return !(a == b);
    }
}