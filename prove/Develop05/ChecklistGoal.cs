
using System.Data.Common;

public class ChecklistGoal : Goal
{
    public const string IDENTIFIER = "ChecklistGoal";
    
    private int numNeededToFullyComplete;
    private int bonusPointValue;
    private int timesCompleted;

    public ChecklistGoal(string _name, string _description, int _pointValue, int _numNeededToFullyComplete, int _bonusPointValue)
        : base(_name, _description, _pointValue)
    {
        numNeededToFullyComplete = _numNeededToFullyComplete;
        bonusPointValue = _bonusPointValue;
        timesCompleted = 0;
    }

    public ChecklistGoal(string _name, string _description, int _pointValue, int _numNeededToFullyComplete, int _bonusPointValue, int _timesCompleted)
        : base(_name, _description, _pointValue)
    {
        numNeededToFullyComplete = _numNeededToFullyComplete;
        bonusPointValue = _bonusPointValue;
        timesCompleted = _timesCompleted;
    }

    public override int CompleteGoal()
    {
        if (GetIsCompleted())
        {
            return 0;
        }
        
        timesCompleted++;

        if (timesCompleted == numNeededToFullyComplete)
        {
            Complete();
            return bonusPointValue;
        }

        return GetPointValue();
    }

    public override string ConvertToString()
    {
        string stringOfGoal =  IDENTIFIER + base.ConvertToString() + STRING_SEPERATOR +
        numNeededToFullyComplete + STRING_SEPERATOR +
        bonusPointValue + STRING_SEPERATOR +
        timesCompleted;

        return stringOfGoal;
    }

    public override void Display()
    {
        base.Display();

        Console.WriteLine($" -- Currently completed: {timesCompleted}/{numNeededToFullyComplete}");
    }

    public static ChecklistGoal New()
    {
        string _name = GetNameFromUser();
        string _description = GetDescriptionFromUser();
        int _pointValue = GetPointValueFromUser();

        Console.Write("How many times will you do this until it is completed? ");
        int _numNeededToFullyComplete = UserInterface.GetUserInputUnbounded();

        Console.Write("What is the bonus value you will get for completing this goal? ");
        int _bonusPointValue = UserInterface.GetUserInputUnbounded();

        return new ChecklistGoal(_name, _description, _pointValue, _numNeededToFullyComplete, _bonusPointValue);
    }
}