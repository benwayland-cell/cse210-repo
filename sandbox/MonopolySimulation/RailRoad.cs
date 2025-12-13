
public class RailRoad : Property
{
    private static int[] rent = [25, 50, 100, 200];
    
    public RailRoad(string _name, int _price) : base(_name, _price, "Railroad")
    {
        
    }

    protected override void PayRent(Player payingPlayer)
    {
        payingPlayer.UpdateMoney(-rent[numOfSameTypeOwned - 1], GetOwner());
    }

    public override void Display()
    {
        Player ? ownerToDisplay = GetOwner();
        string ownerName = "";
        if (ownerToDisplay is not null)
        {
            ownerName = ownerToDisplay.GetName();
        }
        
        Console.WriteLine(
            $"Name: {UserInterface.DisplayWithSpacing(GetName(), 20)}  Price: {UserInterface.DisplayWithSpacing(GetPrice().ToString(), 4)}  " + 
            $"Owner: {UserInterface.DisplayWithSpacing(ownerName, 40)}\t  NumOfSameTypeOwned: {UserInterface.DisplayWithSpacing(numOfSameTypeOwned.ToString(), 2)}  M: {IsMortgaged().ToString()[0]}");
    }

    public override bool OwnerHasMonopoly()
    {
        return false;
    }
}