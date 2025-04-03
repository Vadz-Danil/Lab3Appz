namespace Lab1Appz.Animal.Strategy;

public class FlyingStrategy : IMovementStrategy
{
    public void Move(Animal animal)
    {
        if (!animal.IsAlive)
        {
            Console.WriteLine($"{animal.Name} померла і не може літати.");
            return;
        }

        if ((DateTime.Now - animal.LastMealTime).TotalSeconds > 8)
        {
            Console.WriteLine($"{animal.Name} дуже голодна і не може літати.");
        }
        else if (animal.Wings > 0)
        {
            Console.WriteLine($"{animal.Name} літає.");
        }
        animal.CheckHunger();
    }
}