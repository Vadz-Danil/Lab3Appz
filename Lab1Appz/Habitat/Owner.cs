namespace Lab1Appz.Habitat;

public class Owner : Habitat
{
    public void CleanAnimals()
    {
        Console.WriteLine("Хазяїн прибирає за тваринами.");
        foreach (var animal in Animals)
        {
            animal.Clean();
        }
    }
    
}