namespace Lab1Appz.Habitat;

public class PetStore : Habitat
{
    public void CleanAnimals()
    {
        Console.WriteLine("Прибираємо у зоомагазині.");
        foreach (var animal in Animals)
        {
            animal.Clean();
        }
    }
}