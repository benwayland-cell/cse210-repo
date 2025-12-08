
using System.Diagnostics;
using System.Reflection;

public class Player
{
    private string name;
    private int location = 0;
    private int money = 1500;
    private List<Property> ownedProperties = new List<Property>();
    private int turnsInJail = 0;
    private int numOfGetOutOfJailCards = 0;

    public Player(string _name)
    {
        name = _name;
    }

    public string GetName()
    {
        return name;
    }

    public int GetMoney()
    {
        return money;
    }

    public void UpdateMoney(int amountToChange)
    {
        money += amountToChange;

        // need to implement going below 0
    }

    public void GetJailCard()
    {
        numOfGetOutOfJailCards ++;
    }
    
    public void AddProperty(Property propertyToAdd)
    {
        ownedProperties.Add(propertyToAdd);
    }

    public void RemoveProperty()
    {
        throw new NotImplementedException();
    }

    /* Moves the player to the index given and checks if they passed go.
    Parameters:
        locationToMoveTo: The absolute location to move to
    */
    public void MoveToAbsolute(int locationToMoveTo)
    {
        Debug.Assert(locationToMoveTo >= 0 && locationToMoveTo < UserInterface.GetSizeOfBoard());
        
        // if moving to locationToMoveTo makes us loop around the board
        if (locationToMoveTo <= location)
        {
            PassGo();
        }
        // move there
        location = locationToMoveTo;
    }

    /* Moves the player this spaces forward relative to where they were.
    Parameters:
        distanceToMove: how far we will move the player
     */
     public void MoveToRelative(int distanceToMove)
    {
        int sizeOfBoard = UserInterface.GetSizeOfBoard();
        
        // move by the distanceToMove
        location += distanceToMove;

        // check if we have looped
        if (location > sizeOfBoard)
        {
            location -= sizeOfBoard;
            PassGo();
        }
    }

    private void PassGo()
    {
        money += 200;
    }

    public void Display()
    {
        Console.WriteLine($"Name: {name}  \tLocation: {location}  \tMoney: {money}");
    }

    private const int ROLL_DICE = 1;
    private const int BUY_HOUSES = 2;
    private const int TRADE_WITH_OTHERS = 3;

    private string[] playerMenu =
    {
        "What do you want to do?",
        $"{ROLL_DICE}. Roll dice",
        $"{BUY_HOUSES}. Buy houses",
        $"{TRADE_WITH_OTHERS}. Trade with others"
    };

    public void RunTurn()
    {
        Console.Clear();
        Console.WriteLine($"{name}'s turn:");
        Console.WriteLine($"Location: {location}");
        Console.WriteLine($"Money: {money}\n");

        foreach (string line in playerMenu)
        {
            Console.WriteLine(line);
        }

        int userInput = UserInterface.GetUserInputInBounds(ROLL_DICE, TRADE_WITH_OTHERS);

        switch (userInput)
        {
            case ROLL_DICE:
                Console.WriteLine("Roll Dice");
                break;

            case BUY_HOUSES:
                Console.WriteLine("Buy houses");
                break;

            case TRADE_WITH_OTHERS:
                Console.WriteLine("Trade with others");
                break;

        }
        Console.WriteLine();

    }

}