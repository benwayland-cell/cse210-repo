
class Program
{
    static void Main()
    {
        // Property testProperty = new StandardProperty("test name", 100, "test color", 3);
        // Console.WriteLine(testProperty.GetName());
        // Console.WriteLine();

        // Player testPlayer = new Player("test player name");

        // testProperty.LandOnSpace(testPlayer);

        // Console.WriteLine(testPlayer.GetName());
        // Console.WriteLine(testPlayer.GetMoney());
        // testPlayer.UpdateMoney(-100);
        // Console.WriteLine(testPlayer.GetMoney());
        // Console.WriteLine();

        // Card testCard1 = new Card("Test text 1", 0, 10);
        // testCard1.PlayCard(testPlayer);

        // Card testCard2 = new Card("Test text 2", 1, 10);
        // testCard2.PlayCard(testPlayer);

        // Card testCard3 = new Card("Test text 3", 2, 10);
        // testCard3.PlayCard(testPlayer);
        // Console.WriteLine();

        // Space[] testBoard = Space.GetBoard();


        // testPlayer.Display();
        // testPlayer.MoveToRelative(1);
        // testPlayer.Display();


        Player[] testPlayerArray =
        {
            new Player("Test name 1"),
            new Player("Test name 2"),
            new Player("Test name 3"),
            new Player("Test name 4")
        };

        UserInterface.MainLoop(testPlayerArray);
    }
}