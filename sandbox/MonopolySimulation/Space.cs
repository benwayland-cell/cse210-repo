
public abstract class Space
{
    private string _name;

    public Space(string name)
    {
        _name = name;
    }

    public abstract void LandOnSpace();
}