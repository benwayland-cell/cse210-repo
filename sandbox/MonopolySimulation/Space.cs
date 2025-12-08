
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
            new StandardProperty("Mediterranean Ave", 60, "Br", 2),
            new CommunityChest(),
            new StandardProperty("Baltic Ave", 60, "Br", 2),
            new StandardProperty("Test A 3", 150, "Br", 3),
            new NothingSpace("Free Parking"),
        };
        return board;
    }
}