namespace ppedv.Garage.Model
{
    public class Car : Entity
    {
        public string Manufacturer { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public int KW { get; set; }
        public DateTime BuiltDate { get; set; }
        public string? Color { get; set; }

        public virtual Location? Location { get; set; }
        public virtual ICollection<Driver> Drivers { get; set; } = new HashSet<Driver>();
    }
}