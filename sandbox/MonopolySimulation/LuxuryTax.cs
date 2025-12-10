
public class LuxuryTax : Space
{
    public LuxuryTax() : base("Luxury Tax")
    {
        
    }

    public override void LandOnSpace(Player currentPlayer)
    {
        currentPlayer.UpdateMoney(-100);
    }

    public override void Display()
    {
        Console.WriteLine("Luxury Tax");
    }
}