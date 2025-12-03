
using System.Runtime.CompilerServices;

public class Card
{
    // text displayed to the user
    string text;
    // the method it will run
    int cardMethodKey;
    // other data that the card will use when run
    // e.g. 50 if the card says to pay 50
    int otherData;

    // Constants used for determining what method we will use
    private const int GO_TO_LOCATION = 0;
    private const int RECIEVE_MONEY = 1;
    private const int LOSE_MONEY = 2;


    public Card(string _text, int _cardMethodKey, int _otherData) 
    {
        text = _text;
        cardMethodKey = _cardMethodKey;
        otherData = _otherData;
    }

    public void PlayCard(Player player)
    {
        switch (cardMethodKey)
        {
            case GO_TO_LOCATION:
                Console.WriteLine($"Go to location {otherData}.");
                break;
            case RECIEVE_MONEY:
                Console.WriteLine($"Recieve ${otherData}.");
                break;
            case LOSE_MONEY:
                Console.WriteLine($"You lose ${otherData}.");
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
}