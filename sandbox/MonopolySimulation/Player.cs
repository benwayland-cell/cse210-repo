
using System.Diagnostics;

public class Player
{
    private string name;
    private int location = 0;
    private int money = 1500;
    private List<Property> ownedProperties = new List<Property>();
    private int turnsLeftInJail = 0;
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

        if (money < 0)
        {
            InDebt();
        }
    }

    public void GetJailCard()
    {
        numOfGetOutOfJailCards ++;
    }

    public int GetTurnsLeftInJail()
    {
        return turnsLeftInJail;
    }

    public List<Property> GetOwnedProperties()
    {
        return ownedProperties;
    }

    public int GetLocation()
    {
        return location;
    }
    
    public void AddProperty(Property propertyToAdd)
    {
        ownedProperties.Add(propertyToAdd);


        // increment the amount of the same type owned
        propertyToAdd.numOfSameTypeOwned = 1;

        // check to see if there are other properties of the same type and update their numOfSameTypeOwned
        foreach(Property currentProperty in ownedProperties)
        {
            if (currentProperty.GetTypeOfProperty() == propertyToAdd.GetTypeOfProperty() && currentProperty != propertyToAdd)
            {
                propertyToAdd.numOfSameTypeOwned++;
                currentProperty.numOfSameTypeOwned = propertyToAdd.numOfSameTypeOwned;
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
        else if (location < 0)
        {
            location += sizeOfBoard;
        }
    }

    private void PassGo()
    {
        money += 200;
    }

    public void GoToJail()
    {
        location = Space.JAIL_LOCATION;
        turnsLeftInJail = 3;
    }

    public void Display()
    {
        Console.WriteLine($"Name: {name}  \tLocation: {location}  \tMoney: {money}  \tTurnsLeftInJail: {turnsLeftInJail}");
    }

    private enum PlayerMenu {RollDice, BuyHouses, TradeWithOthers,Unmortgage, ViewPLayers, ViewBoard, Debug}

    private string[] playerMenu =
    {
        "What do you want to do?",
        $"{(int)PlayerMenu.RollDice}. Roll dice",
        $"{(int)PlayerMenu.BuyHouses}. Buy houses",
        $"{(int)PlayerMenu.TradeWithOthers}. Trade with others",
        $"{(int)PlayerMenu.Unmortgage}. Unmortgage properties",
        $"{(int)PlayerMenu.ViewPLayers}. View Players",
        $"{(int)PlayerMenu.ViewBoard}. View Board"
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

            int userInput = UserInterface.GetUserInputInBounds(0, (int)PlayerMenu.Debug);

            switch (userInput)
            {
                case (int)PlayerMenu.RollDice:
                    RollDice();
                    done = true;
                    break;

                case (int)PlayerMenu.BuyHouses:
                    BuyHouses();
                    break;

                case (int)PlayerMenu.TradeWithOthers:
                    TradeWithOthers();
                    break;
                
                case (int)PlayerMenu.Unmortgage:
                    Unmortgage();
                    break;

                case (int)PlayerMenu.ViewPLayers:
                    UserInterface.DisplayPlayers();
                    break;

                case (int)PlayerMenu.ViewBoard:
                    UserInterface.DisplayBoard();
                    break;
                
                case (int)PlayerMenu.Debug:
                    Console.WriteLine("Run debug");
                    UserInterface.DrawChanceCard(this);
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

        // if the player is in jail, ask them if they want to pay to get out or use a card
        if (turnsLeftInJail > 0)
        {
            Console.WriteLine("Do you want to pay $50 to get out of jail?");
            if (UserInterface.GetYesNo())
            {
                UpdateMoney(-50);
            }
            
            else if (numOfGetOutOfJailCards > 0)
            {
                Console.WriteLine("Do you want to use your Get out of Jail Free card?");
                if (!UserInterface.GetYesNo())
                {
                    RunPlayerInJail();
                    return;
                }

                numOfGetOutOfJailCards--;
            }

            
        }
        
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

    private void RunPlayerInJail()
    {
        int dieTotal;
        if (!Roll2D6(out dieTotal))
        {
            turnsLeftInJail--;
            return;
        }

        MoveToRelative(dieTotal);
        UserInterface.LandOnGivenSpace(location, this);
    }

    private void BuyHouses()
    {
        // first get the properties with monopolies
        List<Property> propertiesWithMonopolies = new List<Property>();

        foreach(Property currentProperty in ownedProperties)
        {
            if (currentProperty.OwnerHasMonopoly())
            {
                propertiesWithMonopolies.Add(currentProperty);
            }
        }


        // display the properties with monopolies
        Console.WriteLine("Where do you want to build a house?");
        int index;
        for(index = 0; index < propertiesWithMonopolies.Count; index++)
        {
            Console.Write($"{index}. ");
            propertiesWithMonopolies[index].Display();
        }
        Console.WriteLine($"{index}. Back");

        int userInput = UserInterface.GetUserInputInBounds(0, index);

        // if they wanted to go back
        if (userInput == index)
        {
            return;
        }

        propertiesWithMonopolies[userInput].PurchaseHouse();
    }

    private void TradeWithOthers()
    {
        Console.WriteLine("Trade with others, not implemented.");
    }

    public int GetNetWorth()
    {
        int netWorth = money;

        foreach (Property currentProperty in ownedProperties)
        {
            netWorth += currentProperty.GetNetWorth();
        }

        return netWorth;
    }

    /* Get the player out of debt by mortaging houses */
    private void InDebt()
    {
        // get a list of all unmortgaged properties
        List<Property> unmortgagedProperties = new List<Property>();

        foreach (Property currentProperty in ownedProperties)
        {
            if (!currentProperty.IsMortgaged())
            {
                unmortgagedProperties.Add(currentProperty);
            }
        }

        Console.WriteLine($"Num of unmortgaged: {unmortgagedProperties.Count}");

        while (money < 0 && unmortgagedProperties.Count > 0)
        {
            // display the properties
            for (int index = 0; index < unmortgagedProperties.Count; index++)
            {
                Console.WriteLine($"{index}. ");
                unmortgagedProperties[index].Display();
            }

            Console.WriteLine("Which property to mortgage?");
            int userInput = UserInterface.GetUserInputInBounds(0, unmortgagedProperties.Count);

            money += unmortgagedProperties[userInput].Mortgage();
            unmortgagedProperties.Remove(unmortgagedProperties[userInput]);
        }

        if (money < 0)
        {
            Bankrupt();
        }
    }

    private void Bankrupt()
    {
        Console.WriteLine("Uh oh, you're still in debt");
    }

    private void Unmortgage()
    {
        // get a list of mortgaged properties
        List<Property> mortgagedProperties = new List<Property>();

        foreach (Property currentProperty in ownedProperties)
        {
            if (currentProperty.IsMortgaged())
            {
                mortgagedProperties.Add(currentProperty);
            }
        }

        int index;
        for (index = 0; index < mortgagedProperties.Count; index++)
        {
            Console.Write($"{index}. ");
            mortgagedProperties[index].Display();
        }

        Console.WriteLine("Which property do you want to unmortgage?");
        int userInput = UserInterface.GetUserInputInBounds(0, index - 1);
    }
}