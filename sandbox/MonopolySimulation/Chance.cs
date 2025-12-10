
public class Chance : Space
{
    public Chance() : base("Chance")
    {
        
    }

    public override void LandOnSpace(Player currentPlayer)
    {
        Console.WriteLine("Land on chance, not implemented");
    }

    public override void Display()
    {
        Console.WriteLine("Chance");
    }
}