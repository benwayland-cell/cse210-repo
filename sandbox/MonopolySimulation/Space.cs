
using System.Reflection.Metadata.Ecma335;

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

    /* Returns an array of the default board */
    static public Space[] GetBoard()
    {
        Space[] board =
        {
            new StandardProperty("Test name 1", 100, "B", 2),
            new StandardProperty("Test name 2", 200, "B", 2)
        };
        return board;
    }
}