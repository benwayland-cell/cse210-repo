
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
        // chanceDeck = Card.GetChanceDeck();
        // communityChestDeck = Card.GetCommunityChestDeck();
        board = Space.GetBoard();
        sizeOfBoard = board.Length;

        DisplayPlayers();
        DisplayBoard();
    }

    /* Displays the board in its current state */
    static private void DisplayBoard()
    {
        for(int index = 0; index < board.Length; index++)
        {
            Console.Write($"{index}. ");
            board[index].Display();
        }
    }

    private static void DisplayPlayers()
    {
        for(int index = 0; index < playerList.Length; index++)
        {
            Console.Write($"{index}. ");
            playerList[index].Display();
        }
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