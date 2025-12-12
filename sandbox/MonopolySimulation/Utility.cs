
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