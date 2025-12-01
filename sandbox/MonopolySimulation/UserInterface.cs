
using System.Reflection.Metadata;

public class UserInterface
{
    private static Space[] board;
    private static Player[] playerList;
    // private List<Card> chanceDeck
    // private List<Card> communityChestDeck

    private static int sizeOfBoard;

    static public int GetSizeOfBoard()
    {
        return sizeOfBoard;
    }

    static public void MainLoop(Player[] _playerList)
    {
        // init data
        playerList = _playerList;
        // List<Card> chanceDeck = Card.GetChanceDeck();
        // List<Card> communityChestDeck = Card.GetCommunityChestDeck();
        board = Space.GetBoard();
        sizeOfBoard = board.Length;

    }

    static private void DisplayBoard()
    {
        
    }
    
}