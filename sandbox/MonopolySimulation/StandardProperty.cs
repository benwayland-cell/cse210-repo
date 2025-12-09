
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
            $"Name: {GetName()}  \tPrice: {GetPrice()}  \tColor: {GetTypeOfProperty()} " + 
            $"\tOwner: {GetOwner()}  \tNumOfHouses: {numOfHouses}  \tNumOfSameTypeOwned: {numOfSameTypeOwned}");
    }

    private string DisplayWithSpacing(string givenString, int spacingAmount)
    {
        string spaceString = "";

        for (int i = 0; i < spacingAmount - givenString.Count(); i++)
        {
            spaceString += " ";
        }

        return givenString + spaceString;
    }
}