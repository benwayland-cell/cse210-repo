
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

    public int GetPrice()
    {
        return price;
    }

    public Player ? GetOwner()
    {
        return owner;
    }

    public int GetNumOfSameTypeOwned()
    {
        return numOfSameTypeOwned;
    }

    public override void LandOnSpace(Player currentPlayer)
    {
        Console.WriteLine($"Landed on {GetName()}, not implemented");
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