namespace Lab1Appz.Animal.Factory;

public class DogFactory : IAnimalFactory
{
    public Animal CreateAnimal(string name, bool isWild)
    {
        return new Dog(name, isWild);
    }
}