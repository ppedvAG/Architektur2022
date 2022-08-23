namespace ppedv.Garage.Model
{
    public class Location : Entity
    {
        public string Name { get; set; } = string.Empty;
        public bool Roofed { get; set; }
        public virtual ICollection<Car> Cars { get; set; } = new HashSet<Car>();
    }
}