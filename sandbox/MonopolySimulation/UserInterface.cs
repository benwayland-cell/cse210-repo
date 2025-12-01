
using System.Reflection.Metadata;

public class UserInterface
{
    private static Space[] board;
    private static Player[] playerList;
    // private List<Card> chanceDeck
    // private List<Card> communityChestDeck

    static public void MainLoop(Player[] _playerList)
    {
        // init data
        playerList = _playerList;
        // List<Card> chanceDeck = Card.GetChanceDeck();
        // List<Card> communityChestDeck = Card.GetCommunityChestDeck();
        // board = Space.GetBoard();

    }

    static private void DisplayBoard()
    {
        
    }
    
}