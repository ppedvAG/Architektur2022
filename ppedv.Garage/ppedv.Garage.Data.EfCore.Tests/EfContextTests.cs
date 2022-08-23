using ppedv.Garage.Model;

namespace ppedv.Garage.Data.EfCore.Tests
{
    public class EfContextTests
    {
        [Fact]
        public void Can_create_DB()
        {
            var testConString = "Server=(localdb)\\mssqllocaldb;Database=Garage_DEV_CreateTest;Trusted_Connection=true";
            using var con = new EfContext(testConString);
            con.Database.EnsureDeleted();

            var result = con.Database.EnsureCreated();

            Assert.True(result);
        }

        [Fact]
        public void Can_insert_and_read_car()
        {
            var car = new Car() { Manufacturer = $"Baudi_{Guid.NewGuid()}" };
            using (var con = new EfContext())
            {
                con.Cars.Add(car);
                var result = con.SaveChanges();

                Assert.Equal(1, result);
            }

            using (var con = new EfContext())
            {
                var loaded = con.Find<Car>(car.Id);
                Assert.NotNull(loaded);
                Assert.Equal(car.Manufacturer, loaded.Manufacturer);
            }
        }

        [Fact]
        public void Can_update_car()
        {
            var car = new Car() { Manufacturer = $"Baudi_{Guid.NewGuid()}" };
            string newManu = $"FauWe_{Guid.NewGuid()}";
            using (var con = new EfContext()) //insert test car
            {
                con.Cars.Add(car);
                var result = con.SaveChanges();
                Assert.Equal(1, result);
            }

            using (var con = new EfContext()) //update car
            {
                var loaded = con.Find<Car>(car.Id);
                loaded.Manufacturer = newManu;
                var result = con.SaveChanges();
                Assert.Equal(1, result);
            }

            using (var con = new EfContext()) //read and verify
            {
                var loaded = con.Find<Car>(car.Id);
                Assert.NotNull(loaded);
                Assert.Equal(newManu, loaded.Manufacturer);
            }
        }

        [Fact]
        public void Can_delete_car()
        {
            var car = new Car() { Manufacturer = $"Baudi_{Guid.NewGuid()}" };
            using (var con = new EfContext()) //insert test car
            {
                con.Cars.Add(car);
                var result = con.SaveChanges();
                Assert.Equal(1, result);
            }

            using (var con = new EfContext()) //delete car
            {
                var loaded = con.Find<Car>(car.Id);
                con.Remove(loaded);
                var result = con.SaveChanges();
                Assert.Equal(1, result);
            }

            using (var con = new EfContext()) //read and verify
            {
                var loaded = con.Find<Car>(car.Id);
                Assert.Null(loaded);
            }
        }
    }
}