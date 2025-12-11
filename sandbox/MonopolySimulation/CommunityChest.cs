
public class CommunityChest : Space
{
    public CommunityChest() : base("Community Chest")
    {
        
    }

    public override void LandOnSpace(Player currentPlayer)
    {
        Console.WriteLine($"Landed on {GetName()}");
        UserInterface.DrawCommunityChestCard(currentPlayer);
    }

    public override void Display()
    {
        Console.WriteLine("Community Chest");
    }
}