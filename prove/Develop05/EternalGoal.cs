
public class EternalGoal : Goal
{
    public const string IDENTIFIER = "EternalGoal";
    
    private int timesCompleted;

    public EternalGoal(string _name, string _description, int _pointValue) : base(_name, _description, _pointValue)
    {
        timesCompleted = 0;
    }

    public EternalGoal(string _name, string _description, int _pointValue, int _timesCompleted) : base(_name, _description, _pointValue)
    {
        timesCompleted = _timesCompleted;
    }

    public override int CompleteGoal()
    {
        timesCompleted++;
        return GetPointValue();
    }

    public override void Display()
    {
        base.Display();
        Console.WriteLine($" -- Times Completed: {timesCompleted}");
    }

    public override string ConvertToString()
    {
        string stringOfGoal = IDENTIFIER + base.ConvertToString() + STRING_SEPERATOR +
        timesCompleted;

        return stringOfGoal;
    }

    public static EternalGoal New()
    {
        string _name = GetNameFromUser();
        string _description = GetDescriptionFromUser();
        int _pointValue = GetPointValueFromUser();

        return new EternalGoal(_name, _description, _pointValue);
    }
}