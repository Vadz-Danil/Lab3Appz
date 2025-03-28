using Lab1Appz.Animal.Strategy;

namespace Lab1Appz.Animal;

public class Owl : Animal
{
    public Owl(string? name, bool isWild = false) : base(name, 2, 2, isWild)
    {
        MovementStrategy = new FlyingStrategy();
    }
}