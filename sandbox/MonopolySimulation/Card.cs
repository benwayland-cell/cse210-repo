
public enum CardType {GoToLocation, UpdateMoney, GoToRelative, GoToJail, GoToRailroad, GoToUtility, GetFromAllPlayers, GeneralRepairs, StreetRepairs, GetOutOfJailFree}

public class Card
{
    // text displayed to the user
    string text;
    // the method it will run
    CardType cardType;
    // other data that the card will use when run
    // e.g. 50 if the card says to pay 50
    int otherData;

    public Card(string _text, CardType _cardType, int _otherData) 
    {
        text = _text;
        cardType = _cardType;
        otherData = _otherData;
    }

    public void PlayCard(Player player)
    {
        Console.WriteLine(text);
        
        switch (cardType)
        {
            case CardType.GoToLocation:
                player.MoveToAbsolute(otherData);
                UserInterface.GetBoard()[otherData].LandOnSpace(player);
                break;

            case CardType.UpdateMoney:
                player.UpdateMoney(otherData);
                break;

            case CardType.GoToRelative:
                player.MoveToRelative(otherData);
                UserInterface.GetBoard()[otherData].LandOnSpace(player);
                break;
            
            case CardType.GoToJail:
                player.GoToJail();
                break;
            
            case CardType.GoToRailroad:
                GoToNearest(player, Space.RAILROAD_LOCATIONS);
                break;

            case CardType.GoToUtility:
                GoToNearest(player, Space.UTILITY_LOCATIONS);
                break;
            
            case CardType.GetFromAllPlayers:
                GetFromAllPlayers(player, otherData);
                break;
            
            case CardType.GeneralRepairs:
                PayPerHouse(player, 25, 100);
                break;
            
            case CardType.StreetRepairs:
                PayPerHouse(player, 40, 115);
                break;

            case CardType.GetOutOfJailFree:
                player.GetJailCard();
                break;
        }
    }

    private void GoToNearest(Player player, int[] locations)
    {
        // find the nearest railroad
        int locationToGoTo = locations[0];
        foreach (int currentLocation in locations)
        {
            if (player.GetLocation() < currentLocation)
            {
                locationToGoTo = currentLocation;
                break;
            }
        }

        // go to the location
        player.MoveToAbsolute(locationToGoTo);
        
        Property spaceToGoTo = (Property)UserInterface.GetBoard()[locationToGoTo];
        Player ? spaceToGoToOwner = spaceToGoTo.GetOwner();

        // if the railroad is owned by someone else
        if (spaceToGoToOwner is not null && spaceToGoToOwner != player)
        {
            // we have to pay double rent, so just land on it one more time
            spaceToGoTo.LandOnSpace(player);
        }

        spaceToGoTo.LandOnSpace(player);
    }

    private void GetFromAllPlayers(Player player, int amount)
    {
        List<Player> playerList = UserInterface.GetPlayerList();

        foreach (Player currentPlayer in playerList)
        {
            currentPlayer.UpdateMoney(-amount);
        }

        player.UpdateMoney(amount * playerList.Count);
    }

    private void PayPerHouse(Player player, int costPerHouse, int costPerHotel)
    {
        int totalToPay = 0;

        foreach (Property currentProperty in player.GetOwnedProperties())
        {
            try
            {
                int houseNum = ((StandardProperty)currentProperty).GetNumOfHouses();
                if (houseNum < 5)
                {
                    totalToPay += costPerHouse * houseNum;
                }
                else
                {
                    totalToPay += costPerHotel;
                }
            }
            catch
            {
                
            }
        }
    }

    public static List<Card> GetChanceDeck()
    {
        List<Card> chanceDeck = new List<Card>
        {
            new Card("Advance to Boardwalk.", CardType.GoToLocation, Space.BOARDWALK_LOCATION),
            new Card("Advance to Go (Collect $200).", CardType.GoToLocation, Space.GO_LOCATION),
            new Card("Advance to Illinois Avenue. If you pass Go, collect $200", CardType.GoToLocation, Space.ILLINOIS_AVE_LOCATION),
            new Card("Advance to St. Charles Place. If you pass Go, collect $200", CardType.GoToLocation, Space.ST_CHARLES_PLACE_LOCATION),
            new Card("Advance to the nearest Railroad. If unowned, you may buy it from the Bank. If owned, pay wonder twice the rental to which they are otherwise entitled.", CardType.GoToRailroad, 0),
            new Card("Advance to the nearest Railroad. If unowned, you may buy it from the Bank. If owned, pay wonder twice the rental to which they are otherwise entitled.", CardType.GoToRailroad, 0),
            new Card("Advance token to nearest Utility. If unowned, you may buy it from the Bank. If owned, throw dice and pay owner a total ten times amount thrown.", CardType.GoToUtility, 0),
            new Card("Bank pays you dividend of $50.", CardType.UpdateMoney, 50),
            new Card("Get Out of Jail Free.", CardType.GetOutOfJailFree, Space.BOARDWALK_LOCATION),
            new Card("Go Back 3 Spaces.", CardType.GoToRelative, -3),
            new Card("Go to Jail. Go directly to Jail, do not pass Go, do not collect $200.", CardType.GoToJail, 0),
            new Card("Make general repairs on all your property. For each house pay $25. For each hotel pay $100.", CardType.GeneralRepairs, 0),
            new Card("Speeding fine $15.", CardType.UpdateMoney, -15),
            new Card("Take a trip to Reading Railroad. If you pass Go, collect $200.", CardType.GoToLocation, Space.READING_RAILROAD_LOCATION),
            new Card("You have been elected Chairman of the Board. Pay each player $50.", CardType.GetFromAllPlayers, -50),
            new Card("Your building loan matures. Collect $150", CardType.UpdateMoney, 150)
            
        };
        return chanceDeck;
    }

    public static List<Card> GetCommunityChestDeck()
    {
        List<Card> communityChestDeck = new List<Card>
        {
            new Card("Advance to Go (Collect $200)", CardType.GoToLocation, Space.GO_LOCATION),
            new Card("Bank error in your favor. Collect $200", CardType.UpdateMoney, 200),
            new Card("Doctor’s fee. Pay $50", CardType.UpdateMoney, -50),
            new Card("From sale of stock you get $50", CardType.UpdateMoney, 50),
            new Card("Get Out of Jail Free", CardType.GetOutOfJailFree, 0),
            new Card("Go to Jail. Go directly to jail, do not pass Go, do not collect $200", CardType.GoToJail, 0),
            new Card("Holiday fund matures. Receive $100", CardType.UpdateMoney, 100),
            new Card("Income tax refund. Collect $20", CardType.UpdateMoney, 20),
            new Card("It is your birthday. Collect $10 from every player", CardType.GetFromAllPlayers, 10),
            new Card("Life insurance matures. Collect $100", CardType.UpdateMoney, 100),
            new Card("Pay hospital fees of $100", CardType.UpdateMoney, -100),
            new Card("Pay school fees of $50", CardType.UpdateMoney, -50),
            new Card("Receive $25 consultancy fee", CardType.UpdateMoney, 25),
            new Card("You are assessed for street repair. $40 per house. $115 per hotel", CardType.StreetRepairs, 0),
            new Card("You have won second prize in a beauty contest. Collect $10", CardType.UpdateMoney, 10),
            new Card("You inherit $100", CardType.UpdateMoney, 100)
        };
        return communityChestDeck;
    }
}