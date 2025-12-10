
public class Jail : Space
{
    public Jail() : base("Jail")
    {
        
    }

    public override void LandOnSpace(Player currentPlayer)
    {
        Console.WriteLine("Just visiting Jail");
    }

    public override void Display()
    {
        Console.WriteLine("Jail");
    }
}