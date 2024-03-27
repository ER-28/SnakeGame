namespace SnakeGame;

public class Player
{
    public List<Position> Position = [];
    public int Direction = 0;
    public int Length = 1;
    
    public Player(Position position)
    {
        Position.Add(position);
    }
    
    public void Move()
    {
        Position.Insert(0, Position[0] + new Position(Direction switch
        {
            0 => 0,
            1 => 1,
            2 => 0,
            3 => -1,
            _ => 0
        }, Direction switch
        {
            0 => -1,
            1 => 0,
            2 => 1,
            3 => 0,
            _ => 0
        }));
        
        if (Position.Count > Length)
        {
            Position.RemoveAt(Position.Count - 1);
        }
    }
}