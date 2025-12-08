
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

    static public void MainLoop(Player[] _playerList)
    {
        // init data
        playerList = _playerList;
        chanceDeck = Card.GetChanceDeck();
        communityChestDeck = Card.GetCommunityChestDeck();
        board = Space.GetBoard();
        sizeOfBoard = board.Length;

    }

    static private void DisplayBoard()
    {
        throw new NotImplementedException();
    }
    
    public static void DrawChanceCard()
    {
        throw new NotImplementedException();
    }

    public static void DrawCommunityChestCard()
    {
        throw new NotImplementedException();
    }
}