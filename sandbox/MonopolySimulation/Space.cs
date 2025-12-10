
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

    public const int JAIL_LOCATION = 10;
    public static int[] RAILROAD_LOCATIONS = [5, 15, 25, 35];

    /* Returns an array of the default board */
    static public Space[] GetBoard()
    {
        Space[] board =
        {
            new NothingSpace("Go"),
            new StandardProperty("Mediterranean Ave", 60, "Brown", 2, 50, [2, 10, 30, 90, 160, 250]),
            new CommunityChest(),
            new StandardProperty("Baltic Ave", 60, "Brown", 2, 50, [4, 20, 60, 180, 320, 450]),
            new IncomeTax(),
            new RailRoad("Reading Railroad", 200),
            new StandardProperty("Oriental Ave", 100, "Light Blue", 3, 50, [6, 30, 90, 270, 400, 550]),
            new Chance(),
            new StandardProperty("Vermont Ave", 100, "Light Blue", 3, 50, [6, 30, 90, 270, 400, 550]),
            new StandardProperty("Connecticut Ave", 120, "Light Blue", 3, 50, [8, 40, 100, 300, 450, 600]),

            new Jail(),
            new StandardProperty("St. Charles Place", 140, "Pink", 3, 100, [10, 50, 150, 450, 625, 750]),
            new Utility("Electric Company", 150),
            new StandardProperty("States Ave", 140, "Pink", 3, 100, [10, 50, 150, 450, 625, 750]),
            new StandardProperty("Virginia Ave", 160, "Pink", 3, 100, [12, 60, 180, 500, 700, 900]),
            new RailRoad("Pennsylvania Railroad", 200),
            new StandardProperty("St. James Place", 180, "Orange", 3, 100, [14, 70, 200, 550, 750, 950]),
            new CommunityChest(),
            new StandardProperty("Tennessee Ave", 180, "Orange", 3, 100, [14, 70, 200, 550, 750, 950]),
            new StandardProperty("New York Ave", 200, "Orange", 3, 100, [16, 80, 220, 600, 800, 1000]),

            new NothingSpace("Free Parking"),
            new StandardProperty("Kentucky Ave", 220, "Red", 3, 150, [18, 90, 250, 700, 875, 1050]),
            new Chance(),
            new StandardProperty("Indiana Ave", 220, "Red", 3, 150, [18, 90, 250, 700, 875, 1050]),
            new StandardProperty("Illinois Ave", 240, "Red", 3, 150, [20, 100, 300, 750, 925, 1100]),
            new RailRoad("B&O Railroad", 200),
            new StandardProperty("Atlantic Ave", 260, "Yellow", 3, 150, [22, 110, 330, 800, 975, 1150]),
            new StandardProperty("Ventnor Ave", 260, "Yellow", 3, 150, [22, 110, 330, 800, 975, 1150]),
            new Utility("Water works", 150),
            new StandardProperty("Marvin Gardens", 280, "Yellow", 3, 150, [24, 120, 360, 850, 1025, 1200]),

            new GoToJail(),
            new StandardProperty("Pacific Ave", 300, "Green", 3, 200, [26, 130, 390, 900, 1100, 1275]),
            new StandardProperty("North Carolina Ave", 300, "Green", 3, 200, [26, 130, 390, 900, 1100, 1275]),
            new CommunityChest(),
            new StandardProperty("Pennsylvania Ave", 320, "Green", 3, 200, [28, 150, 450, 1000, 1200, 1400]),
            new RailRoad("Short Line", 200),
            new Chance(),
            new StandardProperty("Park Place", 350, "Dark Blue", 2, 200, [35, 175, 500, 1100, 1300, 1500]),
            new LuxuryTax(),
            new StandardProperty("Boardwalk", 400, "Dark Blue", 2, 200, [50, 200, 600, 1400, 1700, 2000])
        };

        return board;
    }
}