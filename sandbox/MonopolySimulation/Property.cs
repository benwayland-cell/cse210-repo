
public abstract class Property : Space
{
    private int price;
    // private Player owner;
    private int numOfSameTypeOwned;

    public Property(string _name, int _price) : base(_name)
    {
        price = _price;
        // owner = null;
        numOfSameTypeOwned = 0;
    }

    public override void LandOnSpace()
    {
        Console.WriteLine("Landed on space");
    }

    // private void Purchase(Player purchasingPlayer)

    // private void RunAuction(Player[] playerList)

    // private abstract void PayRent(Player payingPlayer);
}