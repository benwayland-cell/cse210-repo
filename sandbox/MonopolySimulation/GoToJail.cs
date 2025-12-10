
public class GoToJail : Space
{
    public GoToJail() : base("Go to Jail")
    {
        
    }

    public override void LandOnSpace(Player currentPlayer)
    {
        currentPlayer.GoToJail();
    }

    public override void Display()
    {
        throw new NotImplementedException();
    }
}