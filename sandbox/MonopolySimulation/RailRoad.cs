
public class RailRoad : Property
{
    public RailRoad(string _name, int _price) : base(_name, _price, "Railroad")
    {
        
    }

    protected override void PayRent(Player payingPlayer)
    {
        Console.WriteLine("Pay rent on railroad, not implemented");
    }

    public override void Display()
    {
        Console.WriteLine(GetName());
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