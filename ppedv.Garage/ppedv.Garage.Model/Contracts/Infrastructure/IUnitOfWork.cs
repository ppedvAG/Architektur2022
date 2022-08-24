namespace ppedv.Garage.Model.Contracts.Infrastructure
{
    public interface IUnitOfWork
    {
        public ICarRepository CarRepository { get; }
        public IRepository<Driver> DriverRepository { get; }
        public IRepository<Location> LocationRepository { get; }
        int SaveAll();
    }
}
