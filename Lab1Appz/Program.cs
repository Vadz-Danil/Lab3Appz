namespace Lab1Appz;

class Program
{
    static void Main()
    {
        List<Habitat.Habitat?> habitats = new List<Habitat.Habitat?>();
        List<Animal.Animal?> allAnimals = new List<Animal.Animal?>();
        ConsoleMenu consoleMenu = new ConsoleMenu(habitats, allAnimals);
        while (true)
        {
            consoleMenu.ShowMenu();
        }
    }
}