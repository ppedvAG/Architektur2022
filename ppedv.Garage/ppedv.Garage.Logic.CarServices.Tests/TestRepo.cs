using ppedv.Garage.Model;
using ppedv.Garage.Model.Contracts;

namespace ppedv.Garage.Logic.CarServices.Tests
{
    class TestRepo : IRepository
    {
        public void Add<T>(T entity) where T : Entity
        {
            throw new NotImplementedException();
        }

        public void Delete<T>(T entity) where T : Entity
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> Query<T>() where T : Entity
        {
            if (typeof(T) == typeof(Location))
            {
                var l1 = new Location() { Name = "L1" };
                l1.Cars.Add(new Car() { KW = 50 });
                var l2 = new Location() { Name = "L2" };
                l2.Cars.Add(new Car() { KW = 40 });
                l2.Cars.Add(new Car() { KW = 40 });
                var l3 = new Location() { Name = "L3" };
                l3.Cars.Add(new Car() { KW = 50 });
                l3.Cars.Add(new Car() { KW = 20 });
                return new[] { l1, l2, l3 }.Cast<T>().AsQueryable();
            }
            throw new NotImplementedException();
        }

        public T GetById<T>(int id) where T : Entity
        {
            throw new NotImplementedException();
        }

        public int SaveAll()
        {
            throw new NotImplementedException();
        }

        public void Update<T>(T entity) where T : Entity
        {
            throw new NotImplementedException();
        }
    }
}