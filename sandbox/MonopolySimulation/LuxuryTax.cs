
public class LuxuryTax : Space
{
    public LuxuryTax() : base("Luxury Tax")
    {
        
    }

    public override void LandOnSpace(Player currentPlayer)
    {
        Console.WriteLine("Land on Luxury Tax, not implemented");
    }

    public override void Display()
    {
        Console.WriteLine("Luxury Tax");
    }
}