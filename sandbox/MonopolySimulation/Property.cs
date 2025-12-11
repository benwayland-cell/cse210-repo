
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

    public bool IsMortgaged()
    {
        return mortgaged;
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
        RunAuction(ref UserInterface.playerList);
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

    private void RunAuction(ref List<Player> playerList)
    {
        Console.WriteLine($"{GetName()} is up for auction.");

        int playerIndex = 0;
        Player currentPlayer;
        int userInput;
        int numOfPlayersConceded = 0;

        Player playerWithHighestBet = playerList[0];
        int highestBet = 0;

        while (numOfPlayersConceded < playerList.Count - 1)
        {
            currentPlayer = playerList[playerIndex];


            while (true)
            {
                Console.Clear();
                Console.WriteLine($"{currentPlayer.GetName()}, what will you bet for {GetName()}? (0 to not bet)");
                Console.WriteLine($"Highest Bet: {playerWithHighestBet.GetName()}, ${highestBet}");
                userInput = UserInterface.GetUserInputUnbounded();

                if (userInput == 0)
                {
                    numOfPlayersConceded++;
                    break;
                }
                else if (userInput > highestBet)
                {
                    highestBet = userInput;
                    playerWithHighestBet = currentPlayer;
                    numOfPlayersConceded = 0;
                    break;
                }
            }

            playerIndex = (playerIndex + 1) % playerList.Count;
        }

        Console.WriteLine($"{playerWithHighestBet.GetName()} won the auction!");
        playerWithHighestBet.AddProperty(this);
        owner = playerWithHighestBet;
        playerWithHighestBet.UpdateMoney(-price);
    }

    protected abstract void PayRent(Player payingPlayer);
    public abstract bool OwnerHasMonopoly();

    public virtual void PurchaseHouse()
    {
        Console.WriteLine($"Shouldn't purchase a house here: {GetName()}");
    }

    public virtual int GetNetWorth()
    {
        if (mortgaged)
        {
            return GetPrice() / 2;
        }
        
        return GetPrice();
    }

    /* Mortgages this property and returns its mortgage price */
    public virtual int Mortgage()
    {
        mortgaged = true;
        return price / 2;
    }

    public void UnMortgage()
    {
        if (owner is null)
        {
            return;
        }
        
        mortgaged = false;
        owner.UpdateMoney(-(int)(price / 2 * 0.1));
    }
}