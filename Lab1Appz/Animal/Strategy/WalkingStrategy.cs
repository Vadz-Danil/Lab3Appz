namespace Lab1Appz.Animal.Strategy;

public class WalkingStrategy : IMovementStrategy
{
    public void Move(Animal animal)
    {
        if (!animal.IsAlive)
        {
            Console.WriteLine($"{animal.Name} померла і не може рухатись.");
            return;
        }
        if ((DateTime.Now - animal.LastMealTime).TotalSeconds > 8)
        {
            Console.WriteLine($"{animal.Name} дуже голодна та не може рухатись, але може повзати та ходити.");
        }
        else
        {
            Console.WriteLine($"{animal.Name} ходить.");
        }
        animal.CheckHunger();
    }
}