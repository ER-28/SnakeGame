namespace SnakeGame;

public class Rock
{
    private Position _position;
    
    public Position Position
    {
        get => _position;
        set => _position = value;
    }
    
    public Rock()
    {
        Random random = new();
        
        _position = new Position(random.Next(Game.Map.Width), random.Next(Game.Map.Height));
    }
}