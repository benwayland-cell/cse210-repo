
using System.Drawing;

public class StandardProperty : Property
{
    private int numOfHouses = 0;
    private int propertiesNeededForMonopoly;

    private int pricePerHouse;
    private int[] rent;

    public int GetNumOfHouses()
    {
        return numOfHouses;
    }

    public int GetPricePerHouse()
    {
        return pricePerHouse;
    }

    public StandardProperty(string _name, int _price, string _type, int _propertiesNeededForMonopoly, int _pricePerHouse, int[] _rent) : base(_name, _price, _type)
    {
        propertiesNeededForMonopoly = _propertiesNeededForMonopoly;
        pricePerHouse = _pricePerHouse;
        rent = _rent;
    }

    protected override void PayRent(Player payingPlayer)
    {
        int rentToPay = rent[numOfHouses];
        payingPlayer.UpdateMoney(-rentToPay);
    }

    public override void Display()
    {
        Player ? ownerToDisplay = GetOwner();
        string ownerName = "";
        if (ownerToDisplay is not null)
        {
            ownerName = ownerToDisplay.GetName();
        }
        
        Console.WriteLine(
            $"Name: {DisplayWithSpacing(GetName(), 20)}  Price: {DisplayWithSpacing(GetPrice().ToString(), 4)}  Color: {DisplayWithSpacing(GetTypeOfProperty(), 15)} " + 
            $"Owner: {DisplayWithSpacing(ownerName, 20)}\t  NumOfHouses: {DisplayWithSpacing(numOfHouses.ToString(), 2)}  NumOfSameTypeOwned: {DisplayWithSpacing(numOfSameTypeOwned.ToString(), 2)}  M: {IsMortgaged().ToString()[0]}");
    }

    private string DisplayWithSpacing(string givenString, int spacingAmount)
    {
        if (givenString is null)
        {
            givenString = "";
        }
        
        string spaceString = "";

        for (int i = 0; i < spacingAmount - givenString.Count(); i++)
        {
            spaceString += " ";
        }

        return givenString + spaceString;
    }

    public override bool OwnerHasMonopoly()
    {
        Player ? currentOwner = GetOwner();
        if (currentOwner is null)
        {
            return false;
        }

        int totalOfSameType = 1;
        foreach (Property currentProperty in currentOwner.GetOwnedProperties())
        {
            if (currentProperty.GetTypeOfProperty() == GetTypeOfProperty())
            {
                totalOfSameType++;
                if (totalOfSameType == propertiesNeededForMonopoly)
                {
                    return true;
                }
            }
        }

        return false;
    }

    public override void PurchaseHouse()
    {
        Player ? currentOwner = GetOwner();
        if (currentOwner is null) {return;}
        
        currentOwner.UpdateMoney(-pricePerHouse);
        numOfHouses++;

        if (numOfHouses > 5)
        {
            numOfHouses = 5;
        }
    }

    public override int GetNetWorth()
    {
        if (IsMortgaged())
        {
            return GetPrice() / 2;
        }
        
        return GetPrice() + pricePerHouse * numOfHouses;
    }

    public override int Mortgage()
    {
        int mortgagePrice = base.Mortgage() + (pricePerHouse * numOfHouses) / 2;

        numOfHouses = 0;

        return mortgagePrice;
    }
}