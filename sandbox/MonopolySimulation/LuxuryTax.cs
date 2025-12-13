
public class LuxuryTax : Space
{
    public LuxuryTax() : base("Luxury Tax")
    {
        
    }

    public override void LandOnSpace(Player currentPlayer)
    {
        Console.WriteLine($"Landed on {GetName()}");
        currentPlayer.UpdateMoney(-100, null);
    }

    public override void Display()
    {
        Console.WriteLine("Luxury Tax");
    }
}