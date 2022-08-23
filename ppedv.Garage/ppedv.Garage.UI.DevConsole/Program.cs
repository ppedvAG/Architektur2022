using Autofac;
using ppedv.Garage.Data.EfCore;
using ppedv.Garage.Logic.CarServices;
using ppedv.Garage.Model;
using ppedv.Garage.Model.Contracts;
using System.Reflection;

Console.WriteLine("*** Garage v0.1 ***");

//DI per Hand
//var cm = new CarManager(new ppedv.Garage.Data.EfCore.EfRepository());

//DI per AutoFac
var builder = new ContainerBuilder();
builder.RegisterType<EfRepository>().As<IRepository>();
var cont = builder.Build();

var cm = new CarManager(cont.Resolve<IRepository>());

//DI per Reflection
//var path = @"C:\Users\Fred\source\repos\ppedvAG\Architektur2022\ppedv.Garage\ppedv.Garage.Data.EfCore\bin\Debug\net6.0\ppedv.Garage.Data.EfCore.dll";
//var ass = Assembly.LoadFrom(path);
//var typeMitRepo = ass.GetTypes().FirstOrDefault(x => x.GetInterfaces().Contains(typeof(IRepository)));
//var repo = Activator.CreateInstance(typeMitRepo);
//var cm = new CarManager((IRepository)repo);

var bestLoc = cm.GetLocationWithFastesCars();
Console.WriteLine($"Best Location: {(bestLoc == null ? "nix" : bestLoc.Name)}");

foreach (var car in cm.Repository.GetAll<Car>())
{
    //Console.WriteLine($"{car.Manufacturer} {car.Model} {car.KW}KW {car.Color}");
    Console.WriteLine($"{car.Manufacturer} {car.KW}KW ");
    foreach (var drv in car.Drivers)
    {
        Console.WriteLine($"\t {drv.Name}");
    }
}