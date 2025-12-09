
using System.Drawing;

public class StandardProperty : Property
{
    private string color;
    private int numOfHouses = 0;
    private int propertiesNeededForMonopoly;

    private int pricePerHouse;
    private int[] rent;

    public StandardProperty(string _name, int _price, string _color, int _propertiesNeededForMonopoly, int _pricePerHouse, int[] _rent) : base(_name, _price)
    {
        color = _color;
        propertiesNeededForMonopoly = _propertiesNeededForMonopoly;
        pricePerHouse = _pricePerHouse;
        rent = _rent;
    }

    protected override void PayRent(Player payingPlayer)
    {
        Console.WriteLine($"{payingPlayer.GetName()} pay {GetPrice()}");
    }

    public override void Display()
    {
        Console.WriteLine(
            $"Name: {GetName()}  \tPrice: {GetPrice()}  \tColor: {color} " + 
            $"\tOwner: {GetOwner()}  \tNumOfHouses: {numOfHouses}  \tNumOfSameTypeOwned: {GetNumOfSameTypeOwned()}");
    }

}