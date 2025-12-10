
public abstract class Property : Space
{
    private int price;
    private Player ? owner;
    private string type;
    public int numOfSameTypeOwned = 0;
    private bool mortgaged = false;

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

    /* Runs through landing on a property.
    If they player landing owns it, do nothing
    If the property is owned and the landing player does not own it, make them pay rent
    If it is unowned, ask if they will buy it
     */
    public override void LandOnSpace(Player currentPlayer)
    {
        if (owner == currentPlayer || mortgaged)
        {
            return;
        }
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
                return;
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
    public abstract bool OwnerHasMonopoly();

    public virtual void PurchaseHouse()
    {
        Console.WriteLine($"Shouldn't purchase a house here: {GetName()}");
    }

    public virtual int GetNetWorth()
    {
        return GetPrice();
    }
}