
public abstract class Property : Space
{
    private int price;
    private Player ? owner;
    private int numOfSameTypeOwned = 0;

    public Property(string _name, int _price) : base(_name)
    {
        price = _price;
        owner = null;
    }

    protected int GetPrice()
    {
        return price;
    }

    public Player ? GetOwner()
    {
        return owner;
    }

    public override void LandOnSpace(Player currentPlayer)
    {
        Console.WriteLine("Landed on space");
    }

    private void Purchase(Player purchasingPlayer)
    {
        throw new NotImplementedException();
    }

    private void RunAuction(Player[] playerList)
    {
        throw new NotImplementedException();
    }

    protected abstract void PayRent(Player payingPlayer);
}