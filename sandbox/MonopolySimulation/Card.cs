
public enum CardType {GoToLocation, UpdateMoney, GoToRelative, GoToJail, GoToRailroad, GoToUtility, GetFromAllPlayers, GeneralRepairs, StreetRepairs}

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

    public static List<Card> GetChanceDeck()
    {
        throw new NotImplementedException();
    }

    public static List<Card> GetCommunityChestDeck()
    {
        throw new NotImplementedException();
    }
}