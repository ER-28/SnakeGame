namespace SnakeGame;

public class Chrono
{
    public DateTime StartTime;
    public DateTime EndTime;
    
    public Chrono()
    {
        StartTime = DateTime.Now;
    }
    
    public void Update()
    {
        EndTime = DateTime.Now;
    }
    
    public void PrintTime()
    {
        Console.WriteLine("Time: " + (EndTime - StartTime).TotalSeconds + "s");
    }
}