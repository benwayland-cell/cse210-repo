
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
    public abstract void Display();

    /* Returns an array of the default board */
    static public Space[] GetBoard()
    {
        Space[] board =
        {
            new NothingSpace("Go"),
            new StandardProperty("Test name 1", 100, "A", 3),
            new StandardProperty("Test name 2", 200, "A", 3),
            new StandardProperty("Test name 3", 300, "A", 3),
            new NothingSpace("Free Parking"),
            new StandardProperty("Test name 4", 400, "B", 2),
            new StandardProperty("Test name 5", 500, "B", 2)
        };
        return board;
    }
}