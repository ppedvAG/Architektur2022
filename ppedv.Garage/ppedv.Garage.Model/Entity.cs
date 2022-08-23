namespace ppedv.Garage.Model
{
    public abstract class Entity
    {
        public int Id { get; set; }
        public DateTime Modified { get; set; }
        public DateTime Create { get; set; }
    }
}