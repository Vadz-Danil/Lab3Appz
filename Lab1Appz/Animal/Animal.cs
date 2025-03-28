using Lab1Appz.Animal.Strategy;
using Lab1Appz.Events;

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

    private Timer _hungerCheckTimer;
    public IMovementStrategy? MovementStrategy { get; set; }
    protected Animal(string? name, int legs = 0,int wings = 0,bool isWild = false)
    {
        Name = name;
        Legs = legs;
        Wings = wings;
        LastMealTime = DateTime.Now;
        IsWild = isWild;
        _hungerCheckTimer = new Timer(5000);
        _hungerCheckTimer.Elapsed += OnHungerCheck;
        _hungerCheckTimer.AutoReset = true;
        _hungerCheckTimer.Start();
    }
    public event EventHandler<HungerEventCheck>? HungerCheckEvent;
    private void OnHungerCheck(object? sender, ElapsedEventArgs e)
    {
        if (sender == null) throw new ArgumentNullException(nameof(sender));
        double secondsSinceLastMeal = (DateTime.Now - LastMealTime).TotalSeconds;
        if (secondsSinceLastMeal > 5 && IsAlive)
        {
            HungerCheckEvent?.Invoke(this,new HungerEventCheck(Name ?? "Безіменна тварина",secondsSinceLastMeal));
        }
    }
    public void StopHungerCheck()
    {
        _hungerCheckTimer.Stop();
        _hungerCheckTimer.Dispose();
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
            StopHungerCheck();
        }
    }

    public void Move()
    {
        MovementStrategy?.Move(this);
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