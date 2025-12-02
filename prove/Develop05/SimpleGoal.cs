
public class SimpleGoal : Goal
{
    public const string IDENTIFIER = "SimpleGoal";

    public SimpleGoal(string _name, string _description, int _pointValue) : base(_name, _description, _pointValue){}

    public override int CompleteGoal()
    {
        if (GetIsCompleted())
        {
            return 0;
        }

        Complete();
        return GetPointValue();
    }

    public override void Display()
    {
        base.Display();
        Console.WriteLine();
    }

    /* Uses user input to make a new SimpleGoal */
    public static SimpleGoal New()
    {
        string _name = GetNameFromUser();
        string _description = GetDescriptionFromUser();
        int _pointValue = GetPointValueFromUser();

        return new SimpleGoal(_name, _description, _pointValue);
    }

    /* Returns a string in the format:
    SimpleGoal name description pointValue
     */
    public override string ConvertToString()
    {
        string stringOfGoal = IDENTIFIER + base.ConvertToString();
        return stringOfGoal;
    }

}