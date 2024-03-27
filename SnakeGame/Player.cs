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
        
        CheckCollision();
    }

    private void CheckCollision()
    {
        if (Position[0].X < 0 || Position[0].X >= Game.Map.Width || Position[0].Y < 0 || Position[0].Y >= Game.Map.Height)
        {
            Game.GameLoop = false;
        }
            
        if (Position.Skip(1).Any(position => position == Position[0]))
        {
            Game.GameLoop = false;
        }
    }
}