using Lab1Appz.Animal;
using Lab1Appz.Habitat;

namespace Lab1Appz;

public class ConsoleMenu
{
    private readonly List<Habitat.Habitat?> _habitats;
    private readonly List<Animal.Animal?> _allAnimals;

    public ConsoleMenu(List<Habitat.Habitat?> habitats,List<Animal.Animal?> allAnimals)
    {
        _habitats = habitats;
        _allAnimals = allAnimals;
    }

    public void ShowMenu()
    {
        Console.Clear();
        Console.WriteLine("Меню:");
        Console.WriteLine("1. Додати тварину");
        Console.WriteLine("2. Переглянути всіх тварин");
        Console.WriteLine("3. Годувати тварину");
        Console.WriteLine("4. Прибирати в середовищі");
        Console.WriteLine("5. Перевірити, чи щаслива тварина");
        Console.WriteLine("6. Дії з тваринами");
        Console.WriteLine("7. Видалити тварину");
        Console.WriteLine("8. Вийти");
        Console.Write("Оберіть опцію: ");
        string? choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                AddAnimal();
                break;
            case "2":
                ShowAllAnimals();
                break;
            case "3":
                FeedAnimal();
                break;
            case "4":
                CleanAnimalsInHabitat();
                break;
            case "5":
                CheckIfAnimalIsHappy();
                break;
            case "6":
                AnimalActions();
                break;
            case "7":
                RemoveAnimal();
                break;
            case "8":
                Console.WriteLine("Вихід з програми...");
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine("Невірна опція! Спробуйте знову.");
                break;
        }
    }

    private void AddAnimal()
    {
        Console.Clear();
        Console.Write("Введіть ім'я тварини: ");
        string? name = Console.ReadLine();

        Console.WriteLine("Оберіть тип тварини:");
        Console.WriteLine("1. Собака");
        Console.WriteLine("2. Сова");
        Console.WriteLine("3. Ящірка");
        string? animalChoice = Console.ReadLine();

        Animal.Animal? animal;
        switch (animalChoice)
        {
            case "1":
                animal = new Dog(name);
                break;
            case "2":
                animal = new Owl(name);
                break;
            case "3":
                animal = new Lizard(name);
                break;
            default:
                Console.WriteLine("Невірний вибір!");
                return;
        }

        animal.HungerCheckEvent += () =>
        {
            if ((DateTime.Now - animal.LastMealTime).TotalSeconds > 5)
            {
                Console.WriteLine($"{animal.Name} голодна! Потрібно її погодувати.");
            }
        };

        _allAnimals.Add(animal);
        Console.WriteLine("Оберіть середовище для тварини:");
        Console.WriteLine("1. Зоомагазин");
        Console.WriteLine("2. Дім власника");
        Console.WriteLine("3. Дика природа");
        string? habitatChoice = Console.ReadLine();

        Habitat.Habitat? selectedHabitat;
        switch (habitatChoice)
        {
            case "1":
                selectedHabitat = _habitats.Find(h => h is PetStore) ?? new PetStore();
                break;
            case "2":
                selectedHabitat = _habitats.Find(h => h is Owner) ?? new Owner();
                break;
            case "3":
                selectedHabitat = _habitats.Find(h => h is Wild) ?? new Wild();
                animal.IsWild = true;
                break;
            default:
                Console.WriteLine("Невірний вибір!");
                return;
        }

        if (!_habitats.Contains(selectedHabitat))
        {
            _habitats.Add(selectedHabitat);
        }

        selectedHabitat.AddAnimal(animal);

        Console.WriteLine($"{animal.Name} додано до {selectedHabitat.GetType().Name}.");
        Console.WriteLine("Натисніть будь-яку клавішу, щоб повернутися в меню...");
        Console.ReadKey();
    }

    private void ShowAllAnimals()
    {
        Console.Clear();
        Console.WriteLine("Всі тварини:");

        if (_habitats.Exists(h => h != null && h.Animals.Count > 0))
        {
            if (_habitats.Exists(h => h is Owner && h.Animals.Count > 0))
            {
                Console.WriteLine("\nТварини у домі власника:");
                var enumerable = _habitats.Find(h => h is Owner)?.Animals;
                if (enumerable != null)
                    foreach (var animal in enumerable)
                    {
                        Console.WriteLine($"- {animal.Name} ({animal.GetType().Name})");
                    }
            }

            if (_habitats.Exists(h => h is PetStore && h.Animals.Count > 0))
            {
                Console.WriteLine("\nТварини в зоомагазині:");
                var enumerable = _habitats.Find(h => h is PetStore)?.Animals;
                if (enumerable != null)
                    foreach (var animal in enumerable)
                    {
                        Console.WriteLine($"- {animal.Name} ({animal.GetType().Name})");
                    }
            }

            if (_habitats.Exists(h => h is Wild && h.Animals.Count > 0))
            {
                Console.WriteLine("\nДикі тварини:");
                var enumerable = _habitats.Find(h => h is Wild)?.Animals;
                if (enumerable != null)
                    foreach (var animal in enumerable)
                    {
                        Console.WriteLine($"- {animal.Name} ({animal.GetType().Name})");
                    }
            }
        }
        else
        {
            Console.WriteLine("Немає тварин для показу.");
        }

        Console.WriteLine("Натисніть будь-яку клавішу, щоб повернутися в меню...");
        Console.ReadKey();
    }

    private void FeedAnimal()
    {
        Console.Clear();
        Console.Write("Введіть ім'я тварини, яку потрібно погодувати: ");
        string? name = Console.ReadLine();

        bool animalFound = false;

        foreach (var habitat in _habitats)
        {
            if (habitat != null)
            {
                var animal = habitat.Animals.FirstOrDefault(a =>
                    a.Name != null && a.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
                if (animal != null)
                {
                    animal.Eat();
                    animalFound = true;
                    break;
                }
            }
        }

        if (!animalFound)
        {
            Console.WriteLine("Тварина не знайдена.");
        }

        Console.WriteLine("Натисніть будь-яку клавішу, щоб повернутися в меню...");
        Console.ReadKey();
    }

    private void CleanAnimalsInHabitat()
    {
        Console.Clear();
        Console.WriteLine("Оберіть середовище для прибирання:");
        Console.WriteLine("1. Зоомагазин");
        Console.WriteLine("2. Дім власника");
        Console.WriteLine("3. Дика природа");
        string? environmentChoice = Console.ReadLine();

        Habitat.Habitat? selectedHabitat;

        switch (environmentChoice)
        {
            case "1":
                selectedHabitat = _habitats.Find(h => h is PetStore);
                break;
            case "2":
                selectedHabitat = _habitats.Find(h => h is Owner);
                break;
            case "3":
                selectedHabitat = _habitats.Find(h => h is Wild);
                break;
            default:
                Console.WriteLine("Невірний вибір!");
                return;
        }

        if (selectedHabitat != null)
        {
            if (selectedHabitat is PetStore petStore)
            {
                petStore.CleanAnimals();
                Console.WriteLine("Прибирання в зоомагазині завершено.");
            }
            else if (selectedHabitat is Owner owner)
            {
                owner.CleanAnimals();
                Console.WriteLine("Прибирання у домі власника завершено.");
            }
            else if (selectedHabitat is Wild)
            {
                Console.WriteLine("Дика природа не потребує прибирання.");
            }
        }
        else
        {
            Console.WriteLine("Не знайдено середовище для прибирання.");
        }

        Console.WriteLine("Натисніть будь-яку клавішу, щоб повернутися в меню...");
        Console.ReadKey();
    }

    private void CheckIfAnimalIsHappy()
    {
        Console.Clear();
        Console.Write("Введіть ім'я тварини для перевірки: ");
        string? name = Console.ReadLine();

        bool animalFound = false;

        foreach (var habitat in _habitats)
        {
            if (habitat != null)
                foreach (var animal in habitat.Animals)
                {
                    if (animal.Name != null && animal.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
                    {
                        animalFound = true;
                        Console.WriteLine(animal.GetHappinessStatus());
                    }
                }
        }

        if (!animalFound)
        {
            Console.WriteLine("Тварина не знайдена.");
        }

        Console.WriteLine("Натисніть будь-яку клавішу, щоб повернутися в меню...");
        Console.ReadKey();
    }

    private void AnimalActions()
    {
        Console.Clear();
        Console.Write("Введіть ім'я тварини для дій: ");
        string? animalName = Console.ReadLine();

        var animal =
            _allAnimals.FirstOrDefault(a => a?.Name?.Equals(animalName, StringComparison.OrdinalIgnoreCase) == true);

        if (animal == null)
        {
            Console.WriteLine("Тварина не знайдена.");
            Console.ReadKey();
            return;
        }

        if (!animal.IsAlive)
        {
            Console.WriteLine($"{animal.Name} померла і не може виконувати жодних дій.");
            Console.ReadKey();
            return;
        }

        if (animal is Dog || animal is Lizard)
        {
            animal.Move();
        }
        else if (animal is Owl)
        {
            animal.Fly();
        }

        Console.ReadKey();
    }

    private void RemoveAnimal()
    {
        Console.Clear();
        Console.Write("Введіть ім'я тварини, яку потрібно видалити: ");
        string? name = Console.ReadLine();

        bool animalRemoved = false;

        foreach (var habitat in _habitats)
        {
            if (habitat != null)
            {
                var animalToRemove = habitat.Animals.FirstOrDefault(a =>
                    a.Name != null && a.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
                if (animalToRemove != null)
                {
                    habitat.Animals.Remove(animalToRemove);
                    _allAnimals.Remove(animalToRemove);
                    Console.WriteLine($"{animalToRemove.Name} було видалено.");
                    animalRemoved = true;
                    break;
                }
            }
        }

        if (!animalRemoved)
        {
            Console.WriteLine("Тварина не знайдена.");
        }

        Console.WriteLine("Натисніть будь-яку клавішу, щоб повернутися в меню...");
        Console.ReadKey();
    }
}