
public class IncomeTax : Space
{
    public IncomeTax() : base("Income Tax")
    {
        
    }

    public override void LandOnSpace(Player currentPlayer)
    {
        Console.WriteLine("Landed on Income tax, not implemented");
    }

    public override void Display()
    {
        Console.WriteLine("Income Tax");
    }
}