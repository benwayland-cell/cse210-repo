
public class Player
{
    private string name;
    private int location = 0;
    private int money = 1500;
    private List<Property> ownedProperties = new List<Property>();
    private int turnsInJail = 0;
    private int numOfGetOutOfJailCards = 0;

    public Player(string _name)
    {
        name = _name;
    }

    public void UpdateMoney(int amountToChange)
    {
        money += amountToChange;
    }

    public void GetJailCard()
    {
        numOfGetOutOfJailCards ++;
    }
    
    public void AddProperty(Property propertyToAdd)
    {
        ownedProperties.Add(propertyToAdd);
    }

    // public void RemoveProperty()
    
    public void RunTurn()
    {
        Console.WriteLine($"Run {name}'s turn");
    }


}