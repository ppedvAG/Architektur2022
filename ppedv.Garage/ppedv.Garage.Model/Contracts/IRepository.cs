namespace ppedv.Garage.Model.Contracts
{

    public interface ICarRepository : IRepository<Car>
    {
        IEnumerable<Car> GetAllRedCars();
    }

    public interface IRepository<T> where T : Entity
    {
        IQueryable<T> Query();
        T? GetById(int id);

        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
    }

    public interface IUnitOfWork
    {
        public ICarRepository CarRepository { get; }
        public IRepository<Driver> DriverRepository { get; }
        public IRepository<Location> LocationRepository { get; }
        int SaveAll();
    }
}
