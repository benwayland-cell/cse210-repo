
class Program
{
    static void Main()
    {
        
        List<Player> playerList= new List<Player>();

        string ? userInput;
        while (true)
        {
            Console.Clear();
            Console.WriteLine("CurrentPlayers:");
            // display the list of players
            foreach (Player player in playerList)
            {
                Console.WriteLine(player.GetName());
            }

            // get the name of the next player
            Console.WriteLine("\nWhat is the name of the next player? (\"done\" if done)");
            userInput = Console.ReadLine();

            // check for null and "done"
            if (userInput is null) userInput = "done";
            if (userInput == "done") break;

            // Add the player to the list
            playerList.Add(new Player(userInput));
            Console.WriteLine();

        }

        Console.WriteLine("Playing game");

        UserInterface.MainLoop(playerList);
    }
}