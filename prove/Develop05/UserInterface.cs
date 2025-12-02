
public class UserInterface
{
    private static int score;
    private static List<Goal> goals;

    public static int GetUserInputInBounds(int startBound, int endBound)
    {
        string userInputString;
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
        string userInputString;
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


    public static void RunGoalProgram()
    {
        score = 0;
        goals = new List<Goal>();


        bool done = false;
        while (!done)
        {
            DisplayMainMenu();
            int userInput = GetUserInputInBounds(CREATE_NEW_GOAL, QUIT);

            switch (userInput)
            {
                case CREATE_NEW_GOAL:
                    CreateNewGoal();
                    break;

                case LIST_GOALS:
                    ListGoals();
                    Console.ReadLine();
                    break;

                case SAVE_GOALS:
                    SaveGoals();
                    break;

                case LOAD_GOALS:
                    LoadGoals();
                    break;

                case RECORD_EVENT:
                    RecordEvent();
                    break;

                case QUIT:
                    done = true;
                    break;
            }
            Thread.Sleep(1000);
        }
    }

    // constants used for the main menu switch case
    private const int CREATE_NEW_GOAL = 1;
    private const int LIST_GOALS = 2;
    private const int SAVE_GOALS = 3;
    private const int LOAD_GOALS = 4;
    private const int RECORD_EVENT = 5;
    private const int QUIT = 6;

    private static string[] mainMenuArray =
    {
        "Menu Options:",
        $"   {CREATE_NEW_GOAL}. Create New Goal",
        $"   {LIST_GOALS}. List Goals",
        $"   {SAVE_GOALS}. Save Goals", 
        $"   {LOAD_GOALS}. Load Goals", 
        $"   {RECORD_EVENT}. Record Event", 
        $"   {QUIT}. Quit"
    };

    /* Displays the main menu */
    private static void DisplayMainMenu()
    {
        Console.Clear();
        Console.WriteLine($"You have {score} points.\n");
        foreach(string str in mainMenuArray)
        {
            Console.WriteLine(str);
        }

        Console.Write("Select a choice from the menu: ");
    }

    private static void CreateNewGoal()
    {
        Console.WriteLine();
        DisplayGoalCreationMenu();

        int userInput = GetUserInputInBounds(SIMPLE_GOAL, CHECKLIST_GOAL);

        switch (userInput)
        {
            case SIMPLE_GOAL:
                Console.WriteLine();
                goals.Add(SimpleGoal.New());
                break;

            case ETERNAL_GOAL:
                Console.WriteLine("Run eternal goal");
                break;

            case CHECKLIST_GOAL:
                Console.WriteLine("Run checklist goal");
                break;
        }
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

    private static void ListGoals()
    {
        Console.WriteLine("\nThe Goals are:");
        for (int index = 0; index < goals.Count; index++)
        {
            Console.Write($"{index + 1}. ");
            goals[index].Display();
        }
    }

    private static void SaveGoals()
    {
        Console.WriteLine("\nGive the filename of where to save the goals. ");
        string filename = Console.ReadLine();

        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            outputFile.WriteLine(score);

            foreach (Goal goal in goals)
            {
                outputFile.WriteLine(goal.ConvertToString());
            }
        }
    }

    private static void LoadGoals()
    {
        goals = new List<Goal>();

        Console.WriteLine("Give the name of the file to read from. ");
        string filename = Console.ReadLine();

        string[] lines = System.IO.File.ReadAllLines(filename);

        score = int.Parse(lines[0]);

        for (int index = 1; index < lines.Length; index++ )
        {
            goals.Add(Goal.ConvertStringToGoal(lines[index]));
        }
    }

    public static void RecordEvent()
    {
        ListGoals();

        Console.Write("\nWhich Goal did you complete? ");
        int userInput = GetUserInputInBounds(1, goals.Count);

        score += goals[userInput - 1].CompleteGoal();
    }
}