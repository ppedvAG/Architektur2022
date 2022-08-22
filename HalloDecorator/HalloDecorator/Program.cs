// See https://aka.ms/new-console-template for more information
using System.Security.Authentication.ExtendedProtection;

Console.WriteLine("Hello, World!");

var p1 = new Salami( new Käse(new Käse(new Pizza())));
Console.WriteLine($"{p1.Beschreibung} {p1.Preis}");

var b1 = new Salami( new Käse(new Salami(new Brot())));
Console.WriteLine($"{b1.Beschreibung} {b1.Preis}");



public class Käse : Dekorator
{
    public Käse(IComponent parent) : base(parent)
    { }

    public override string Beschreibung => _parent.Beschreibung + " Käse";

    public override decimal Preis => _parent.Preis + 2;
}

public class Salami : Dekorator
{
    public Salami(IComponent parent) : base(parent)
    { }

    public override string Beschreibung => _parent.Beschreibung + " Salami";

    public override decimal Preis => _parent.Preis + 4;
}

public abstract class Dekorator : IComponent
{
    protected IComponent _parent;

    protected Dekorator(IComponent parent)
    {
        _parent = parent;
    }
    public abstract string Beschreibung { get; }

    public abstract decimal Preis { get; }
}

public class Pizza : IComponent
{
    public string Beschreibung => "Pizza";
    public decimal Preis => 8;
}

public class Brot : IComponent
{
    public string Beschreibung => "Brot";
    public decimal Preis => 3;
}

public interface IComponent
{
    public string Beschreibung { get; }
    public decimal Preis { get; }
}