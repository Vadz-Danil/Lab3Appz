namespace Lab1Appz.Animal;
using System.Timers;

public abstract class Animal
{
    public string? Name { get; }
    public int Legs { get; protected set; }
    public int Wings { get; }
    public int MealsPerDay{get; private set;}
    public DateTime LastMealTime { get; private set; }
    public bool IsAlive { get; set; } = true;
    public bool IsWild {get; set;}
    private bool IsCleaned {get; set;}

    public event Action? HungerCheckEvent;

    private Timer _hungerCheckTimer;
    protected Animal(string? name, int legs = 0,int wings = 0,bool isWild = false)
    {
        Name = name;
        Legs = legs;
        Wings = wings;
        LastMealTime = DateTime.Now;
        IsWild = isWild;
        _hungerCheckTimer = new Timer(10000);
        _hungerCheckTimer.Elapsed += OnHungerCheck;
        _hungerCheckTimer.AutoReset = true;
        _hungerCheckTimer.Start();
    }
    private void OnHungerCheck(object? sender, ElapsedEventArgs e)
    {
        if (sender == null) throw new ArgumentNullException(nameof(sender));
        if ((DateTime.Now - LastMealTime).TotalSeconds > 5)
        {
            HungerCheckEvent?.Invoke();
        }
    }

    public void Eat()
    {
        if (!IsAlive)
        {
            Console.WriteLine($"{Name} померла і не може їсти.");
            return;
        }
        if (MealsPerDay < 5)
        {
            MealsPerDay++;
            LastMealTime = DateTime.Now;
            Console.WriteLine($"{Name} поїла. Всього разів поїла: {MealsPerDay}.");
        }
        else
        {
            Console.WriteLine($"{Name} не може їсти більш ніж 5 разів на день!");
        }
        CheckHunger();
    }

    public void CheckHunger()
    {
        if ((DateTime.Now - LastMealTime).TotalSeconds > 24)
        {
            IsAlive = false;
        }
    }

    public void Move()
    {
        if (!IsAlive)
        {
            Console.WriteLine($"{Name} померла і не може рухатись.");
            return;
        }

        if ((DateTime.Now - LastMealTime).TotalSeconds > 8)
        {
            Console.WriteLine($"{Name} дуже голодна та не може рухатись,але може повзати та ходити.");
        }
        else
        {
            Console.WriteLine($"{Name} рухається.");
        }
        CheckHunger();
    }

    public void Fly()
    {
        if (!IsAlive)
        {
            Console.WriteLine($"{Name} померла і не може літати.");
            return;
        }

        if ((DateTime.Now - LastMealTime).TotalSeconds > 8)
        {
            Console.WriteLine($"{Name} дуже голодна і не може літати.");
        }
        else if (Wings > 0)
        {
            Console.WriteLine($"{Name} літає.");
        }
        CheckHunger();
    }

    public void Clean()
    {
        IsCleaned = true;
        Console.WriteLine($"{Name} тепер чиста.");
    }
    public string GetHappinessStatus()
    {
        if (IsWild)
        {
            return $"{Name} щасливий в дикій природі!";
        }
        
        if (IsCleaned)
        {
            return $"{Name} щасливе, оскільки поприбирали.";
        }
        return $"{Name} не щасливе, бо не прибрали.";
    }
}