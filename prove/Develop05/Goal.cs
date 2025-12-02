
using System.Diagnostics;
using System.Drawing;
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

        string _name = inputSplit[1];
        string _description = inputSplit[2];
        int _pointValue = int.Parse(inputSplit[3]);

        if (identifier.Equals(SimpleGoal.IDENTIFIER))
        {
            return new SimpleGoal(_name, _description, _pointValue);
        }
        else if (identifier.Equals(EternalGoal.IDENTIFIER))
        {
            return new EternalGoal(_name, _description, _pointValue, int.Parse(inputSplit[4]));
        }
        else if (identifier.Equals(ChecklistGoal.IDENTIFIER))
        {
            return new ChecklistGoal(_name, _description, _pointValue, int.Parse(inputSplit[4]), int.Parse(inputSplit[5]), int.Parse(inputSplit[6]));
        }
        else
        {
            throw new InvalidOperationException($"The line of the text file could not be read: {inputString}");
        }
    }

    public virtual void Display()
    {
        // set what will go in between brackets to be an X if the goal has been completed
        string completeString;
        if (isCompleted)
        {
            completeString = "X";
        }
        else
        {
            completeString = " ";
        }

        Console.Write($"[{completeString}] {name} ({description})");
    }
    public virtual string ConvertToString()
    {
        string stringOfGoal = STRING_SEPERATOR +
            name + STRING_SEPERATOR +
            description + STRING_SEPERATOR +
            pointValue;
        return stringOfGoal;
    }
}