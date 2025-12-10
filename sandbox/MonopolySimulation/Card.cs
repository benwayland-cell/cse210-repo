
public enum CardType {GoToLocation, UpdateMoney, GoToRelative, GoToJail, GoToRailroad, GetFromAllPlayers, GeneralRepairs, StreetRepairs}

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
                GoToRailroad(player);
                break;
            
            case CardType.GetFromAllPlayers:
                GetFromAllPlayers(player, otherData);
                break;
            
        }
    }

    public static List<Card> GetChanceDeck()
    {
        throw new NotImplementedException();
    }

    public static List<Card> GetCommunityChestDeck()
    {
        throw new NotImplementedException();
    }

    private void GoToRailroad(Player player)
    {
        // find the nearest railroad
        int locationToGoTo = Space.RAILROAD_LOCATIONS[0];
        foreach (int railroadLocation in Space.RAILROAD_LOCATIONS)
        {
            if (player.GetLocation() < railroadLocation)
            {
                locationToGoTo = railroadLocation;
                break;
            }
        }

        // go to the location
        player.MoveToAbsolute(locationToGoTo);
        
        Property railroad = (Property)UserInterface.GetBoard()[locationToGoTo];
        Player ? railroadOwner = railroad.GetOwner();

        // if the railroad is owned by someone else
        if (railroadOwner is not null && railroadOwner != player)
        {
            // we have to pay double rent, so just land on it one more time
            railroad.LandOnSpace(player);
        }

        railroad.LandOnSpace(player);
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
}