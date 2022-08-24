namespace ppedv.Garage.Model.Contracts.Infrastructure
{
    public interface ICarRepository : IRepository<Car>
    {
        IEnumerable<Car> GetAllRedCars();
    }
}
