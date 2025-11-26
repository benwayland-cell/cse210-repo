
public abstract class Property : Space
{
    private int price;
    // private Player owner;
    private int numOfSameTypeOwned;

    public Property(string _name, int _price) : base(_name)
    {
        price = _price;
    }

    public override void LandOnSpace()
    {
        Console.WriteLine("Landed on space");
    }

    // public void Purchase(Player purchasingPlayer)

    // public void RunAuction(Player[] playerList)

    // public void PayRent(Player payingPlayer)
}