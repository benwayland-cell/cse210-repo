
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
        if (owner is not null)
        {
            PayRent(currentPlayer);
            return;
        }
        
        Console.WriteLine($"Landed on {GetName()}");

        if (currentPlayer.GetMoney() <= price)
        {
            Console.WriteLine("You cannot afford this property.");
        }
        else
        {
            Console.WriteLine("Will you buy this property");
            if (UserInterface.GetYesNo())
            {
                Purchase(currentPlayer);
            }
        }
        RunAuction(UserInterface.GetPlayerList());
    }

    private void Purchase(Player purchasingPlayer)
    {
        Console.WriteLine($"Purchased by {purchasingPlayer.GetName()}, not implemented");
    }

    private void RunAuction(List<Player> playerList)
    {
        Console.WriteLine($"Run auction on {GetName()}, not implemented");
    }

    protected abstract void PayRent(Player payingPlayer);
}