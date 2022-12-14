using Autofac;
using ppedv.Garage.Data.EfCore;
using ppedv.Garage.Logic.CarServices;
using ppedv.Garage.Model;
using ppedv.Garage.Model.Contracts.Infrastructure;
using System.ComponentModel;
using System.Reflection;

Console.WriteLine("*** Garage v0.1 ***");

//DI per Hand
//var cm = new CarManager(new ppedv.Garage.Data.EfCore.EfUnitOfWork());

//DI per Reflection
//var path = @"C:\Users\Fred\source\repos\ppedvAG\Architektur2022\ppedv.Garage\ppedv.Garage.Data.EfCore\bin\Debug\net6.0\ppedv.Garage.Data.EfCore.dll";
//var ass = Assembly.LoadFrom(path);
//var typeMitRepo = ass.GetTypes().FirstOrDefault(x => x.GetInterfaces().Contains(typeof(IUnitOfWork)));
//var repo = Activator.CreateInstance(typeMitRepo);
//var cm = new CarManager((IUnitOfWork)repo);

//DI per AutoFac
var builder = new ContainerBuilder();
builder.RegisterType<EfUnitOfWork>().As<IUnitOfWork>();
builder.RegisterType<CarManager>().As<ICarManager>();
var cont = builder.Build();


ICarManager cm = cont.Resolve<ICarManager>();
IUnitOfWork uow = cont.Resolve<IUnitOfWork>();

var bestLoc = cm.GetLocationWithFastesCars();
Console.WriteLine($"Best Location: {(bestLoc == null ? "nix" : bestLoc.Name)}");

foreach (var car in uow.CarRepository.Query().Where(x => x.KW > 1).ToList())
{
    //Console.WriteLine($"{car.Manufacturer} {car.Model} {car.KW}KW {car.Color}");
    Console.WriteLine($"{car.Manufacturer} {car.KW}KW ");
    foreach (var drv in car.Drivers)
    {
        Console.WriteLine($"\t {drv.Name}");
    }
}