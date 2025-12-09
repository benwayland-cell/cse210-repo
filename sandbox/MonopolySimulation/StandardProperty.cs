
using System.Drawing;

public class StandardProperty : Property
{
    private int numOfHouses = 0;
    private int propertiesNeededForMonopoly;

    private int pricePerHouse;
    private int[] rent;

    public StandardProperty(string _name, int _price, string _type, int _propertiesNeededForMonopoly, int _pricePerHouse, int[] _rent) : base(_name, _price, _type)
    {
        propertiesNeededForMonopoly = _propertiesNeededForMonopoly;
        pricePerHouse = _pricePerHouse;
        rent = _rent;
    }

    protected override void PayRent(Player payingPlayer)
    {
        Console.WriteLine($"{payingPlayer.GetName()} pay {GetPrice()}, not implemented");
    }

    public override void Display()
    {
        Console.WriteLine(
            $"Name: {DisplayWithSpacing(GetName(), 20)}  Price: {DisplayWithSpacing(GetPrice().ToString(), 4)}  Color: {DisplayWithSpacing(GetTypeOfProperty(), 10)} " + 
            $"Owner: {GetOwner()}\t  NumOfHouses: {DisplayWithSpacing(numOfHouses.ToString(), 2)}  NumOfSameTypeOwned: {DisplayWithSpacing(numOfSameTypeOwned.ToString(), 2)}");
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
}