
public class IncomeTax : Space
{
    public IncomeTax() : base("Income Tax")
    {
        
    }

    public override void LandOnSpace(Player currentPlayer)
    {
        currentPlayer.UpdateMoney(-200);
    }

    public override void Display()
    {
        Console.WriteLine("Income Tax");
    }
}