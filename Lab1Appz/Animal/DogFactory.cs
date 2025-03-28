namespace Lab1Appz.Animal;

public class DogFactory : IAnimalFactory
{
    public Animal CreateAnimal(string name, bool isWild)
    {
        return new Dog(name, isWild);
    }
}