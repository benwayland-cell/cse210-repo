
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

    public void UpdateMoney(int amountToChange, Player ? debtor)
    {
        money += amountToChange;

        if (money < 0)
        {
            InDebt(debtor);
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

    public void RemoveProperty(Property propertyToRemove)
    {
        ownedProperties.Remove(propertyToRemove);
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
        while (!done && money >= 0) // the money >= 0 is used to immediately end a player's turn if they are bankrupt
        {
            Console.WriteLine($"\n{name}'s turn:");
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
                    location = 7;
                    UserInterface.GetBoard()[location].LandOnSpace(this);
                    // new Card("test text", CardType.GoToLocation, Space.GO_LOCATION).PlayCard(this);
                    done = true;
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
                UpdateMoney(-50, null);
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
            else
            {
                RunPlayerInJail();
                return;
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
        Console.WriteLine("Ran");
        int dieTotal;
        bool rolledDoubles = !Roll2D6(out dieTotal);
        if (rolledDoubles)
        {
            turnsLeftInJail--;
            Console.WriteLine("Didn't roll doubles");
            return;
        }

        MoveToRelative(dieTotal);
        Console.WriteLine($"Location {location}, Rolled doubles");
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
        Console.Clear();

        // get who to trade with
        Console.WriteLine($"{GetName()} who will you trade with?");
        UserInterface.DisplayPlayers();

        int userInput = UserInterface.GetUserInputInBounds(0, UserInterface.playerList.Count - 1);
        Player playerToTradeWith = UserInterface.playerList[userInput];

        Player[] tradingPlayers = {this, playerToTradeWith};
        int[] moneyToGive = new int[2];
        List<Property>[] propertiesToGive = new List<Property>[2];

        // get what the players will trade
        for (int index = 0; index < 2; index++)
        {
            Console.Clear();
            // get the money they will trade
            Player currentPlayer = tradingPlayers[index];
            List<Property> propertiesOwnedByCurrentPlayer = currentPlayer.GetOwnedProperties();
            Console.WriteLine($"{currentPlayer.GetName()} how much money will you give?");
            moneyToGive[index] = UserInterface.GetUserInputWithMin(0);

            // get the properties they will trade
            List<Property> currentPropertiesToGive = new List<Property>();
            
            while (true)
            {
                // display owned properties
                Console.WriteLine($"Properties owned by {currentPlayer.GetName()}:");
                for (int propertyIndex = 0; propertyIndex < propertiesOwnedByCurrentPlayer.Count; propertyIndex++)
                {
                    Console.Write($"{propertyIndex}. ");
                    propertiesOwnedByCurrentPlayer[propertyIndex].Display();
                }

                // display properties the player will give
                Console.WriteLine($"\nProperties {currentPlayer.GetName()} will trade:");
                for (int propertyIndex = 0; propertyIndex < currentPropertiesToGive.Count; propertyIndex++)
                {
                    Console.Write($"{propertyIndex}. ");
                    currentPropertiesToGive[propertyIndex].Display();
                }
                Console.WriteLine();

                // get what property to give
                Console.WriteLine($"{currentPlayer.GetName()} which property will you give? (-1 to stop)");
                userInput = UserInterface.GetUserInputInBounds(-1, propertiesOwnedByCurrentPlayer.Count);
                if (userInput == -1) {break;}
                Property propertyToGive = propertiesOwnedByCurrentPlayer[userInput];
                
                // check if they have already given propertyToGive
                bool alreadyGaveProperty = false;
                foreach (Property currentProperty in currentPropertiesToGive)
                {
                    if (currentProperty.GetName() == propertyToGive.GetName())
                    {
                        alreadyGaveProperty = true;
                        break;
                    }
                }

                if (!alreadyGaveProperty)
                {
                    currentPropertiesToGive.Add(propertyToGive);
                }
                
            }

            propertiesToGive[index] = currentPropertiesToGive;
        }

        // ask for consent from other player
        Console.Clear();
        Console.WriteLine($"{playerToTradeWith.GetName()} do you agree to this?");
        if (!UserInterface.GetYesNo())
        {
            return;
        }

        // trade money and property
        for (int index = 0; index < 2; index++)
        {
            Player currentPlayer = tradingPlayers[index];
            Player otherPlayer = tradingPlayers[(index + 1) % 2];

            // give property
            foreach (Property currentProperty in propertiesToGive[index])
            {
                currentPlayer.RemoveProperty(currentProperty);
                otherPlayer.AddProperty(currentProperty);
                currentProperty.SetOwner(otherPlayer);
            }

            // give money
            currentPlayer.UpdateMoney(-moneyToGive[index], otherPlayer);
            otherPlayer.UpdateMoney(moneyToGive[index], currentPlayer);
        }
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

    /* Get the player out of debt by mortaging houses
    Parameters:
        debtor: the person we are in debt to
    */
    private void InDebt(Player ? debtor)
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

        // Console.WriteLine($"Num of unmortgaged: {unmortgagedProperties.Count}");

        while (money < 0 && unmortgagedProperties.Count > 0)
        {
            // display the properties
            for (int index = 0; index < unmortgagedProperties.Count; index++)
            {
                Console.Write($"{index}. ");
                unmortgagedProperties[index].Display();
            }

            Console.WriteLine($"Debt: {money}");
            Console.WriteLine("Which property to mortgage?");
            int userInput = UserInterface.GetUserInputInBounds(0, unmortgagedProperties.Count);

            int moneyToGet = unmortgagedProperties[userInput].Mortgage();
            money += moneyToGet;
            unmortgagedProperties.Remove(unmortgagedProperties[userInput]);
        }

        if (money < 0)
        {
            Bankrupt(debtor);
        }
    }

    // give the debtor all assets when bankrupt
    private void Bankrupt(Player ? debtor)
    {
        Console.WriteLine($"{GetName()} is bankrupt.");
        if (debtor is null)
        {
            return;
        }

        foreach (Property currentProperty in ownedProperties)
        {
            debtor.AddProperty(currentProperty);
            currentProperty.SetOwner(debtor);
        }
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