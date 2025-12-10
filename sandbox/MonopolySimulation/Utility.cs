
public class Utility : Property
{
    private static int[] rent = [3, 10];
    
    public Utility(string _name, int _price) : base(_name, _price, "Utility")
    {
        
    }

    protected override void PayRent(Player payingPlayer)
    {
        Random random = new Random();

        int dieRoll = random.Next(0, 7) + random.Next(0, 7);

        payingPlayer.UpdateMoney(-dieRoll * rent[numOfSameTypeOwned - 1]);
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