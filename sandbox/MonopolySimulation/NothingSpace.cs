
public class NothingSpace : Space
{
    public NothingSpace(string _name) : base (_name)
    {
        
    }

    public override void LandOnSpace(Player currentPlayer)
    {
        // do nothing
        Console.WriteLine("Landed on an empty space");
    }
}