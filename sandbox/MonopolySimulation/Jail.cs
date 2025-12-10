
public class Jail : Space
{
    public Jail() : base("Jail")
    {
        
    }

    public override void LandOnSpace(Player currentPlayer)
    {
        Console.WriteLine("Landed on Jail, not implemented");
    }

    public override void Display()
    {
        Console.WriteLine("Jail");
    }
}