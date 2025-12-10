
public class Chance : Space
{
    public Chance() : base("Chance")
    {
        
    }

    public override void LandOnSpace(Player currentPlayer)
    {
        UserInterface.DrawChanceCard(currentPlayer);
    }

    public override void Display()
    {
        Console.WriteLine("Chance");
    }
}