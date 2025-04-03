namespace Lab1Appz.Animal.Factory;

public interface IAnimalFactory
{
    Animal CreateAnimal(string name,bool isWild);
}