
public class Utility : Property
{
    public Utility(string _name, int _price) : base(_name, _price, "Utility")
    {
        
    }

    protected override void PayRent(Player payingPlayer)
    {
        Console.WriteLine("Pay rent on utility, not implemented");
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

    public override int GetNetWorth()
    {
        return GetPrice();
    }
}