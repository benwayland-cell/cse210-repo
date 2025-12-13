
public class UserInterface
{
    private static Space[] board = [];
    public static List<Player> playerList = new List<Player>();
    private static Stack<Card> chanceDeck = new Stack<Card>();
    private static Stack<Card> communityChestDeck = new Stack<Card>();

    static public int GetSizeOfBoard()
    {
        return board.Count();
    }

    public static Space[] GetBoard()
    {
        return board;
    }

    public static List<Player> GetPlayerList()
    {
        return playerList;
    }

    /* The function that runs the game */
    static public void MainLoop(List<Player> _playerList)
    {
        // init data
        playerList = _playerList;
        chanceDeck = Card.GetChanceDeck();
        communityChestDeck = Card.GetCommunityChestDeck();
        board = Space.GetBoard();

        // debug code

        board[1].LandOnSpace(playerList[1]);
        // ((Property)board[9]).Mortgage();


        // loop initialization

        int currentPlayerIndex = 0;
        Player currentPlayer;

        while (playerList.Count() > 1)
        {
            currentPlayer = playerList[currentPlayerIndex];

            currentPlayer.RunTurn();

            currentPlayerIndex = (currentPlayerIndex + 1) % playerList.Count;

            Console.ReadLine();
        }

        Console.WriteLine($"\n{playerList[0].GetName()} won!");
    }

    /* Displays the board in its current state */
    public static void DisplayBoard()
    {
        for(int index = 0; index < board.Length; index++)
        {
            Console.Write($"{index}. ");
            board[index].Display();
        }
    }

    public static void DisplayPlayers()
    {
        for(int index = 0; index < playerList.Count; index++)
        {
            Console.Write($"{index}. ");
            playerList[index].Display();
        }
    }
    
    /* Draws and runs a chance card from the chanceDeck */
    public static void DrawChanceCard(Player player)
    {
        chanceDeck.Pop().PlayCard(player);

        if (chanceDeck.Count == 0)
        {
            chanceDeck = Card.GetChanceDeck();
        }
    }

    /* Draws and runs a community chest card from the community chest deck */
    public static void DrawCommunityChestCard(Player player)
    {
        communityChestDeck.Pop().PlayCard(player);

        if (communityChestDeck.Count == 0)
        {
            communityChestDeck = Card.GetCommunityChestDeck();
        }
    }

    /* Makes the given player land on the given space
    Parameters:
        givenSpace: the index of the space they want to land on
        givenPlayer: the play that will land on that space
     */
    public static void LandOnGivenSpace(int givenSpace, Player givenPlayer)
    {
        board[givenSpace].LandOnSpace(givenPlayer);
    }

    public static int GetUserInputInBounds(int startBound, int endBound)
    {
        string ? userInputString;
        int userInputInt;
        while (true)
        {
            userInputString = Console.ReadLine();


            if (Int32.TryParse(userInputString, out userInputInt))
            {
                if (startBound <= userInputInt && userInputInt <= endBound)
                {
                    return userInputInt;
                }
            }

            Console.Write($"User input invalid, Try again. ({startBound}-{endBound}) ");
            
        }
    }

    public static int GetUserInputUnbounded()
    {
        string ? userInputString;
        int userInputInt;
        while (true)
        {
            userInputString = Console.ReadLine();

            if (Int32.TryParse(userInputString, out userInputInt))
            {
                return userInputInt;
            }

            Console.Write($"User input invalid, Try again. (Input must be an integer)");
            
        }
    }

    public static int GetUserInputWithMin(int min)
    {
        string ? userInputString;
        int userInputInt;
        while (true)
        {
            userInputString = Console.ReadLine();


            if (Int32.TryParse(userInputString, out userInputInt))
            {
                if (userInputInt >= min)
                {
                    return userInputInt;
                }
            }

            Console.Write($"User input invalid, Try again. ({min}+) ");
            
        }
    }

    /* Gets a yes or a no from a user
    Return:
        true if yes
        false if no
     */
    public static bool GetYesNo()
    {
        Console.WriteLine("1. Yes");
        Console.WriteLine("2. No");
        int userInput = GetUserInputInBounds(1, 2);

        return userInput == 1;
    }

    public static string DisplayWithSpacing(string givenString, int spacingAmount)
    {
        if (givenString is null)
        {
            givenString = "";
        }
        
        string spaceString = "";

        for (int i = 0; i < spacingAmount - givenString.Count(); i++)
        {
            spaceString += " ";
        }

        return givenString + spaceString;
    }
}