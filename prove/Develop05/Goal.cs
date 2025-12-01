
public abstract class Goal
{
    private bool isCompleted = false;
    private int pointValue;

    public Goal(int _pointValue)
    {
        pointValue = _pointValue;
    }

    public int GetPointValue()
    {
        return pointValue;
    }

    public abstract void CompleteGoal();
}