
public abstract class Space
{
    private string name;

    public Space(string _name)
    {
        name = _name;
    }

    public string GetName()
    {
        return name;
    }

    public abstract void LandOnSpace(Player currentPlayer);
}