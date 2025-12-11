
public class Chance : Space
{
    public Chance() : base("Chance")
    {
        
    }

    public override void LandOnSpace(Player currentPlayer)
    {
        Console.WriteLine($"Landed on {GetName()}");
        UserInterface.DrawChanceCard(currentPlayer);
    }

    public override void Display()
    {
        Console.WriteLine("Chance");
    }
}