
using System.Diagnostics;
using System.Numerics;
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

    public List<Property> GetOwnedProperties()
    {
        return ownedProperties;
    }
    
    public void AddProperty(Property propertyToAdd)
    {
        ownedProperties.Add(propertyToAdd);


        // increment the amount of the same type owned
        propertyToAdd.numOfSameTypeOwned = 1;

        // check to see if there are other properties of the same type and update their numOfSameTypeOwned
        foreach(Property currentProperty in ownedProperties)
        {
            if (currentProperty.GetTypeOfProperty() == propertyToAdd.GetTypeOfProperty())
            {
                currentProperty.numOfSameTypeOwned = ++propertyToAdd.numOfSameTypeOwned;
            }
        }
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

    public void GoToJail()
    {
        Console.WriteLine("Go to Jail, not implemented.");
    }

    public void Display()
    {
        Console.WriteLine($"Name: {name}  \tLocation: {location}  \tMoney: {money}");
    }

    private const int ROLL_DICE = 1;
    private const int BUY_HOUSES = 2;
    private const int TRADE_WITH_OTHERS = 3;
    private const int VIEW_PLAYERS = 4;
    private const int VIEW_BOARD = 5;
    private const int DEBUG = 6;

    private string[] playerMenu =
    {
        "What do you want to do?",
        $"{ROLL_DICE}. Roll dice",
        $"{BUY_HOUSES}. Buy houses",
        $"{TRADE_WITH_OTHERS}. Trade with others",
        $"{VIEW_PLAYERS}. View Players",
        $"{VIEW_BOARD}. View Board"
    };

    public void RunTurn()
    {
        Console.Clear();
        Console.WriteLine($"{name}'s turn:");
        Console.WriteLine($"Location: {location}");
        Console.WriteLine($"Money: {money}\n");


        bool done = false;
        while (!done)
        {
            foreach (string line in playerMenu)
            {
                Console.WriteLine(line);
            }

            int userInput = UserInterface.GetUserInputInBounds(ROLL_DICE, DEBUG);

            switch (userInput)
            {
                case ROLL_DICE:
                    RollDice();
                    done = true;
                    break;

                case BUY_HOUSES:
                    BuyHouses();
                    break;

                case TRADE_WITH_OTHERS:
                    TradeWithOthers();
                    break;
                
                case VIEW_PLAYERS:
                    UserInterface.DisplayPlayers();
                    break;

                case VIEW_BOARD:
                    UserInterface.DisplayBoard();
                    break;
                
                case DEBUG:
                    Console.WriteLine("Run debug");
                    break;

            }
            Console.WriteLine();
        }
    }

    /* Rolls dice and moves the player by that much */
    private void RollDice()
    {
        bool rolledDoubles;
        int dieTotal;
        int timesDoubleHaveBeenRolled = 0;
        
        do
        {
            rolledDoubles = Roll2D6(out dieTotal);
            Console.WriteLine($"You rolled: {dieTotal}");

            MoveToRelative(dieTotal);
            Console.WriteLine($"Location {location}, Doubles: {rolledDoubles}");
            UserInterface.LandOnGivenSpace(location, this);


            if (rolledDoubles)
            {  
                timesDoubleHaveBeenRolled++;
                if (timesDoubleHaveBeenRolled == 3)
                {
                    GoToJail();
                    break;
                }
            }

        } while (rolledDoubles);
    }

    /* Rolls 2d6.
    Parameters:
        total: the number that will be changed as a result of this function to be 2d6
    Return:
        If we rolled doubles
     */
    private bool Roll2D6(out int total)
    {
        Random random = new Random();
        int die1 = random.Next(1, 7);
        int die2 = random.Next(1, 7);
        total = die1 + die2;
        return die1 == die2;
    }

    private void BuyHouses()
    {
        Console.WriteLine("Buy houses, not implemented.");
    }

    private void TradeWithOthers()
    {
        Console.WriteLine("Trade with others, not implemented.");
    }
}