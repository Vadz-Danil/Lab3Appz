namespace Lab1Appz.Animal.Factory;

public class LizzardFactory : IAnimalFactory
{
    public Animal CreateAnimal(string name, bool isWild)
    {
        return new Lizard(name, isWild);
    }
}