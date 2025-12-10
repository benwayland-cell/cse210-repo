
class Program
{
    static void Main()
    {
        List<Player> testPlayerArray = new List<Player>
        {
            new Player("Test name 1"),
            new Player("Test name 2"),
            // new Player("Test name 3"),
            // new Player("Test name 4")
        };

        UserInterface.MainLoop(testPlayerArray);
    }
}