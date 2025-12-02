
using System.Diagnostics;
using System.Runtime;

public abstract class Goal
{
    private string name;
    private string description;
    private bool isCompleted = false;
    private int pointValue;

    protected const string STRING_SEPERATOR = "~|~";

    public Goal(string _name, string _description, int _pointValue)
    {
        name = _name;
        description = _description;
        pointValue = _pointValue;
    }

    protected string GetName()
    {
        return name;
    }
    protected string GetDescription()
    {
        return description;
    }
    protected bool GetIsCompleted()
    {
        return isCompleted;
    }
    protected int GetPointValue()
    {
        return pointValue;
    }
    protected void Complete()
    {
        isCompleted = true;
    }

    public abstract int CompleteGoal();
    public abstract void Display();
    public abstract string ConvertToString();

    protected static string GetNameFromUser()
    {
        Console.Write("What is the name of your goal? ");
        return Console.ReadLine();
    }

    protected static string GetDescriptionFromUser()
    {
        Console.Write("What is a short description of it? ");
        return Console.ReadLine();
    }

    protected static int GetPointValueFromUser()
    {
        Console.Write("What is the amount of points associated with this goal? ");
        return UserInterface.GetUserInputUnbounded();
    }

    public static Goal ConvertStringToGoal(string inputString)
    {
        string[] inputSplit = inputString.Split(STRING_SEPERATOR);
        string identifier = inputSplit[0];

        if (identifier.Equals("SimpleGoal"))
        {
            return new SimpleGoal(inputSplit[1], inputSplit[2], int.Parse(inputSplit[3]));
        }
        else
        {
            throw new InvalidOperationException($"The line of the text file could not be read: {inputString}");
        }
    }
}