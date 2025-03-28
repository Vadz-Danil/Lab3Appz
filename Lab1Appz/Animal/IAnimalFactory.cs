namespace Lab1Appz.Animal;

public interface IAnimalFactory
{
    Animal CreateAnimal(string name,bool isWild);
}