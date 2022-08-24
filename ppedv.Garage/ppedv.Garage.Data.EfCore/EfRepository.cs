using ppedv.Garage.Model;
using ppedv.Garage.Model.Contracts;

namespace ppedv.Garage.Data.EfCore
{
    public class EfUnitOfWork : IUnitOfWork
    {
        public ICarRepository CarRepository => new EfCarRepository(_context);

        public IRepository<Driver> DriverRepository => new EfRepository<Driver>(_context);

        public IRepository<Location> LocationRepository => new EfRepository<Location>(_context);

        public int SaveAll()
        {
            return _context.SaveChanges();
        }

        readonly EfContext _context = new();
    }

    public class EfCarRepository : EfRepository<Car>, ICarRepository
    {
        public EfCarRepository(EfContext context) : base(context)
        { }

        public IEnumerable<Car> GetAllRedCars()
        {
            return _context.Cars.Where(x => x.Color == "red");
        }
    }

    public class EfRepository<T> : IRepository<T> where T : Entity
    {
        protected readonly EfContext _context;

        public EfRepository(EfContext efContext)
        {
            _context = efContext;
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public IQueryable<T> Query()
        {
            return _context.Set<T>();
        }

        public T? GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }
    }
}
