
public abstract class Property : Space
{
    private int price;
    private Player ? owner;
    private string type;
    public int numOfSameTypeOwned = 0;

    public Property(string _name, int _price, string _type) : base(_name)
    {
        price = _price;
        owner = null;
        type = _type;
    }

    public int GetPrice()
    {
        return price;
    }

    public Player ? GetOwner()
    {
        return owner;
    }

    public string GetTypeOfProperty()
    {
        return type;
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
        // Take the money from the player
        purchasingPlayer.UpdateMoney(-price);
        // Give them the property
        purchasingPlayer.AddProperty(this);
        // set the owner
        owner = purchasingPlayer;
    }

    private void RunAuction(List<Player> playerList)
    {
        Console.WriteLine($"Run auction on {GetName()}, not implemented");
    }

    protected abstract void PayRent(Player payingPlayer);
}