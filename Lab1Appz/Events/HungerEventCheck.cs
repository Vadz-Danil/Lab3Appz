namespace Lab1Appz.Events;

public class HungerEventCheck : EventArgs
{
    public string AnimalName { get; }
    public double SecondsSinceLastMeal { get; }

    public HungerEventCheck(string animalName, double secondsSinceLastMeal)
    {
        AnimalName = animalName;
        SecondsSinceLastMeal = secondsSinceLastMeal;
    }
    
}