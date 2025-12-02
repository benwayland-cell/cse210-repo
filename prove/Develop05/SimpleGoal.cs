
public class SimpleGoal : Goal
{
    public SimpleGoal(string _name, string _description, int _pointValue) : base(_name, _description, _pointValue){}

    public override void CompleteGoal()
    {
        throw new NotImplementedException();
    }


    /* Uses user input to make a new SimpleGoal */
    public static SimpleGoal New()
    {
        string _name = GetNameFromUser();
        string _description = GetDescriptionFromUser();
        int _pointValue = GetPointValueFromUser();

        return new SimpleGoal(_name, _description, _pointValue);
    }

    public override void Display()
    {
        // set what will go in between brackets to be an X if the goal has been completed
        string completeString;
        if (GetIsCompleted())
        {
            completeString = "X";
        }
        else
        {
            completeString = " ";
        }

        Console.WriteLine($"[{completeString}] {GetName()} ({GetDescription()})");
    }

    public override string ConvertToString()
    {
        throw new NotImplementedException();
    }

}