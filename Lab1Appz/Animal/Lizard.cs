using Lab1Appz.Animal.Strategy;

namespace Lab1Appz.Animal;

public class Lizard : Animal
{
    public Lizard(string? name, bool isWild = false) : base(name, 4, 0, isWild)
    {
        MovementStrategy = new WalkingStrategy();
    }
}