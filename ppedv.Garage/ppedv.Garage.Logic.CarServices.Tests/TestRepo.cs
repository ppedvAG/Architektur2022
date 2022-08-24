using ppedv.Garage.Model;
using ppedv.Garage.Model.Contracts;

namespace ppedv.Garage.Logic.CarServices.Tests
{
    class TestUnitOfWork : IUnitOfWork
    {
        public IRepository<Car> CarRepository => throw new NotImplementedException();

        public IRepository<Driver> DriverRepository => throw new NotImplementedException();

        public IRepository<Location> LocationRepository => new TestLocationRepo();

        public int SaveAll()
        {
            throw new NotImplementedException();
        }
    }

    class TestLocationRepo : IRepository<Location>
    {
        public void Add(Location entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Location entity)
        {
            throw new NotImplementedException();
        }

        public Location? GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Location> Query()
        {
            var l1 = new Location() { Name = "L1" };
            l1.Cars.Add(new Car() { KW = 50 });
            var l2 = new Location() { Name = "L2" };
            l2.Cars.Add(new Car() { KW = 40 });
            l2.Cars.Add(new Car() { KW = 40 });
            var l3 = new Location() { Name = "L3" };
            l3.Cars.Add(new Car() { KW = 50 });
            l3.Cars.Add(new Car() { KW = 20 });
            return new[] { l1, l2, l3 }.AsQueryable();
        }

        public void Update(Location entity)
        {
            throw new NotImplementedException();
        }
    }
}