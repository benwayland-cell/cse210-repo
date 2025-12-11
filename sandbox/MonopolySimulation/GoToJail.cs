
public class GoToJail : Space
{
    public GoToJail() : base("Go to Jail")
    {
        
    }

    public override void LandOnSpace(Player currentPlayer)
    {
        Console.WriteLine($"Landed on {GetName()}");
        currentPlayer.GoToJail();
    }

    public override void Display()
    {
        Console.WriteLine("Go to Jail");
    }
}