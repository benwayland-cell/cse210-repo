
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
    }

    public void GetJailCard()
    {
        numOfGetOutOfJailCards ++;
    }
    
    public void AddProperty(Property propertyToAdd)
    {
        ownedProperties.Add(propertyToAdd);
    }

    // public void RemoveProperty()

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

    public void RunTurn()
    {
        Console.WriteLine($"Run {name}'s turn");
    }

    public void Display()
    {
        Console.WriteLine($"Location: {location}, Money: {money}");
    }
}