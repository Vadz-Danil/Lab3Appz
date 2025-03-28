namespace Lab1Appz.Animal.Factory;

public class OwlFactory : IAnimalFactory
{
    public Animal CreateAnimal(string name, bool isWild)
    {
        return new Owl(name, isWild);
    }
}