namespace ppedv.Garage.Model
{
    public class Driver : Entity
    {
        public string Name { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
        public virtual ICollection<Car> Cars { get; set; } = new HashSet<Car>();
    }
}