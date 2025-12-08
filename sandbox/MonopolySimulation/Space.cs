
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
            // new CommunityChest(),
            new StandardProperty("Baltic Ave", 60, "Br", 2),
            // new IncomeTax(),
            // new RailRoad("Reading Railroad", 200),
            new StandardProperty("Oriental Ave", 100, "Lb", 3),
            // new Chance(),
            new StandardProperty("Vermont Ave", 100, "Lb", 3),
            new StandardProperty("Connecticut Ave", 120, "Lb", 3),

            // new Jail(),
            new StandardProperty("St. Charles Place", 140, "P", 3),
            // new Utility("Electric company", 150),
            new StandardProperty("States Ave", 140, "P", 3),
            new StandardProperty("Virginia Ave", 160, "P", 3),
            // new RailRoad("Pennsylvania RailRoad", 200),
            new StandardProperty("St. James Place", 180, "O", 3),
            // new CommunityChest(),
            new StandardProperty("Tennesse Ave", 180, "O", 3),
            new StandardProperty("New York Ave", 200, "O", 3),

            new NothingSpace("Free Parking"),
            new StandardProperty("Kentucky Ave", 220, "R", 3),
            // new Chance(),
            new StandardProperty("Indiana Ave", 220, "R", 3),
            new StandardProperty("Illinois Ave", 240, "R", 3),
            // new RailRoad("B & O Railroad", 200),
            new StandardProperty("Atlantic Ave", 260, "Y", 3),
            new StandardProperty("Ventnor Ave", 260, "Y", 3),
            // new Utility("Water Works", 150),
            new StandardProperty("Marvin Gardens", 280, "Y", 3),

            // new GoToJail(),
            new StandardProperty("Pacific Ave", 300, "G", 3),
            new StandardProperty("N. Carolina Ave", 300, "G", 3),
            // new CommunityChest(),
            new StandardProperty("Pennsylvania Ave", 320, "G", 3),
            // new RailRoad("Short Line", 200),
            // new Chance(),
            new StandardProperty("Park Place", 350, "B", 3),
            // new LuxuryTax(),
            new StandardProperty("Boardwalk", 400, "B", 3),
            
        };
        return board;
    }
}