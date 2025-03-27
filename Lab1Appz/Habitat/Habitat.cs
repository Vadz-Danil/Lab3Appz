namespace Lab1Appz.Habitat;

public abstract class Habitat
{
    public List<Animal.Animal> Animals { get; } = new();

    public void AddAnimal(Animal.Animal? animal)
    {
        if (animal != null)
        {
            Animals.Add(animal);
        }
    }
}