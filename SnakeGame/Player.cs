namespace SnakeGame;

public class Player
{
    public readonly List<Position> Position = [];
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
        
        if (Position[0].X < 0)
        {
            Position[0] = new Position(Game.Map.Width - 1, Position[0].Y);
        }
        else if (Position[0].X >= Game.Map.Width)
        {
            Position[0] = new Position(0, Position[0].Y);
        }
        else if (Position[0].Y < 0)
        {
            Position[0] = new Position(Position[0].X, Game.Map.Height - 1);
        }
        else if (Position[0].Y >= Game.Map.Height)
        {
            Position[0] = new Position(Position[0].X, 0);
        }
        
        CheckSelfCollision();
    }
    
    public void CheckSelfCollision()
    {
        // SELF COLLISION
        for (var i = 1; i < Position.Count; i++)
        {
            if (Position[0] == Position[i])
            {
                Game.GameLoop = false;
            }
        }

        // FRUIT COLLISION
        if (Position[0] == Game.Map.Fruit.Position)
        {
            Length++;
            Game.Count++;
            if (Game.Count == 4)
            {
                Game.Map.Rocks.Add(new Rock());
                Game.Count = 0;
            }
            Game.Map.NewFruit();
        }
        
        
        // ROCK COLLISION
        if (Game.Map.Rocks.Any(rock => rock.Position == Position[0]))
        {
            Length--;
            Position.RemoveAt(Position.Count - 1);
            if (Length <= 0)
            {
                Game.GameLoop = false;
            }
            // Game.GameLoop = false;
        }
    }
}