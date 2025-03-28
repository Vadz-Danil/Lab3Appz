namespace Lab1Appz.Animal;

public class OwlFactory : IAnimalFactory
{
    public Animal CreateAnimal(string name, bool isWild)
    {
        return new Owl(name, isWild);
    }
}