
public class RailRoad : Property
{
    public RailRoad(string _name, int _price) : base(_name, _price)
    {
        
    }

    protected override void PayRent(Player payingPlayer)
    {
        throw new NotImplementedException();
    }

    public override void Display()
    {
        throw new NotImplementedException();
    }
}