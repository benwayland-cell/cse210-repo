
public class UserInterface
{
    private static int score;

    // constants used for the menu switch case
    private const int CREATE_NEW_GOAL = 1;
    private const int LIST_GOALS = 2;
    private const int SAVE_GOALS = 3;
    private const int LOAD_GOALS = 4;
    private const int RECORD_EVENT = 5;
    private const int QUIT = 6;

    public static void RunGoalProgram()
    {
        score = 100;

        bool done = false;
        while (!done)
        {
            DisplayMenu();
            int userInput = int.Parse(Console.ReadLine());

            switch (userInput)
            {
                case CREATE_NEW_GOAL:
                    Console.WriteLine("Create new goal");
                    break;
                case LIST_GOALS:
                    Console.WriteLine("List goals");
                    break;
                case SAVE_GOALS:
                    Console.WriteLine("Save goals");
                    break;
                case LOAD_GOALS:
                    Console.WriteLine("Load goals");
                    break;
                case RECORD_EVENT:
                    Console.WriteLine("Record event");
                    break;
                case QUIT:
                    done = true;
                    break;
            }
            Thread.Sleep(1000);
        }
    }

    private static string[] menuArray =
    {
        $"You have {score} points.",
        "",
        "Menu Options:",
        $"   {CREATE_NEW_GOAL}. Create New Goal",
        $"   {LIST_GOALS}. List Goals",
        $"   {SAVE_GOALS}. Save Goals", 
        $"   {LOAD_GOALS}. Load Goals", 
        $"   {RECORD_EVENT}. Record Event", 
        $"   {QUIT}. Quit"
    };

    public static void DisplayMenu()
    {
        Console.Clear();
        foreach(string str in menuArray)
        {
            Console.WriteLine(str);
        }

        Console.Write("Select a choice from the menu: ");
    }
}