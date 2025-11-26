
using System.Drawing;

public class StandardProperty : Property
{
    private string color;
    private int numOfHouses = 0;
    private int propertiesNeededForMonopoly;

    public StandardProperty(string _name, int _price, string _color, int _propertiesNeededForMonopoly) : base(_name, _price)
    {
        color = _color;
        propertiesNeededForMonopoly = _propertiesNeededForMonopoly;
    }

    // private override void PayRent(Player payingPlayer)

}