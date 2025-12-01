
public class UserInterface
{
    private static int score;

    public static void RunGoalProgram()
    {
        Console.WriteLine("Run Program");
        DisplayMenu();
    }

    private static string[] menuArray =
    {
        "Menu Options:",
        "   1. Create New Goal",
        "   2. List Goals",
        "   3. Save Goals", 
        "   4. Load Goals", 
        "   5. Record Event", 
        "   6. Quit"
    };

    public static void DisplayMenu()
    {
        foreach(string str in menuArray)
        {
            Console.WriteLine(str);
        }

        Console.Write("Select a choice from the menu: ");
    }
}