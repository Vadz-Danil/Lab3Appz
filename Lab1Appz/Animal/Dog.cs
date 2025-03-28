using Lab1Appz.Animal.Strategy;

namespace Lab1Appz.Animal;

public class Dog : Animal
{
    public Dog(string? name, bool isWild = false) : base(name, 4, 0, isWild)
    {
        MovementStrategy = new WalkingStrategy();
    }
}