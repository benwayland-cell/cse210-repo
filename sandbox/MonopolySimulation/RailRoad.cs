
public class RailRoad : Property
{
    public RailRoad(string _name, int _price) : base(_name, _price, "Railroad")
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

    public override bool OwnerHasMonopoly()
    {
        return false;
    }

    public override void PurchaseHouse()
    {
        throw new NotImplementedException();
    }
}