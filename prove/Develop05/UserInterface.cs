
public class UserInterface
{
    private static int score;


    public static void RunGoalProgram()
    {
        score = 100;

        bool done = false;
        while (!done)
        {
            DisplayMainMenu();
            int userInput = int.Parse(Console.ReadLine());

            switch (userInput)
            {
                case CREATE_NEW_GOAL:
                    CreateNewGoal();
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

    // constants used for the menu switch case
    private const int CREATE_NEW_GOAL = 1;
    private const int LIST_GOALS = 2;
    private const int SAVE_GOALS = 3;
    private const int LOAD_GOALS = 4;
    private const int RECORD_EVENT = 5;
    private const int QUIT = 6;

    private static string[] mainMenuArray =
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

    private static void CreateNewGoal()
    {
        Console.WriteLine();
        DisplayGoalCreationMenu();

        int userInput = int.Parse(Console.ReadLine());

        switch (userInput)
        {
            case SIMPLE_GOAL:
                Console.WriteLine("Run simple goal");
                break;

            case ETERNAL_GOAL:
                Console.WriteLine("Run eternal goal");
                break;
                
            case CHECKLIST_GOAL:
                Console.WriteLine("Run checklist goal");
                break;
        }
    }

    /* Displays the main menu */
    private static void DisplayMainMenu()
    {
        Console.Clear();
        foreach(string str in mainMenuArray)
        {
            Console.WriteLine(str);
        }

        Console.Write("Select a choice from the menu: ");
    }

    // consts used for the goal creation switch case
    private const int SIMPLE_GOAL = 1;
    private const int ETERNAL_GOAL = 2;
    private const int CHECKLIST_GOAL = 3;

    private static string[] goalCreationMenuArray =
    {
        "The types of Goals are:",
        $"   {SIMPLE_GOAL}.Simple Goal",
        $"   {ETERNAL_GOAL}.Eternal Goal",
        $"   {CHECKLIST_GOAL}.Checklist Goal"
    };

    private static void DisplayGoalCreationMenu()
    {
        foreach(string str in goalCreationMenuArray)
        {
            Console.WriteLine(str);
        }
        Console.Write("Which type of goal would you like to create? ");
    }
}