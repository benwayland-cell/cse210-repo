
public class RailRoad : Property
{
    private static int[] rent = [25, 50, 100, 200];
    
    public RailRoad(string _name, int _price) : base(_name, _price, "Railroad")
    {
        
    }

    protected override void PayRent(Player payingPlayer)
    {
        payingPlayer.UpdateMoney(-rent[numOfSameTypeOwned - 1]);
    }

    public override void Display()
    {
        Console.WriteLine(GetName());
    }

    public override bool OwnerHasMonopoly()
    {
        return false;
    }
}