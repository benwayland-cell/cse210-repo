
public class IncomeTax : Space
{
    public IncomeTax() : base("Income Tax")
    {
        
    }

    public override void LandOnSpace(Player currentPlayer)
    {
        Console.WriteLine($"Landed on {GetName()}");
        currentPlayer.UpdateMoney(-200);
    }

    public override void Display()
    {
        Console.WriteLine("Income Tax");
    }
}