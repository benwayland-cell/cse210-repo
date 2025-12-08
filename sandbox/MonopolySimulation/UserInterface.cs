
using System.Reflection.Metadata;

public class UserInterface
{
    private static Space[] board;
    private static Player[] playerList;
    private static List<Card> chanceDeck;
    private static List<Card> communityChestDeck;

    private static int sizeOfBoard;

    static public int GetSizeOfBoard()
    {
        return sizeOfBoard;
    }

    /* The function that runs the game */
    static public void MainLoop(Player[] _playerList)
    {
        // init data
        playerList = _playerList;
        chanceDeck = Card.GetChanceDeck();
        communityChestDeck = Card.GetCommunityChestDeck();
        board = Space.GetBoard();
        sizeOfBoard = board.Length;

    }

    /*  */
    static private void DisplayBoard()
    {
        throw new NotImplementedException();
    }
    
    /* Draws and runs a chance card from the chanceDeck */
    public static void DrawChanceCard()
    {
        throw new NotImplementedException();
    }

    /* Draws and runs a community chest card from the community chest deck */
    public static void DrawCommunityChestCard()
    {
        throw new NotImplementedException();
    }
}