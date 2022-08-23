using AutoFixture;
using FluentAssertions;
using ppedv.Garage.Model;

namespace ppedv.Garage.Data.EfCore.Tests
{
    public partial class EfContextTests
    {
        [Fact]
        public void Can_create_DB()
        {
            const string testConString = "Server=(localdb)\\mssqllocaldb;Database=Garage_DEV_CreateTest;Trusted_Connection=true";
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

        [Fact]
        public void Can_insert_and_read_car_AutoFix()
        {
            var fix = new Fixture();
            fix.Behaviors.Add(new OmitOnRecursionBehavior());
            fix.Customizations.Add(new PropertyNameOmitter(nameof(Entity.Id)));
            var car = fix.Create<Car>();

            using (var con = new EfContext())
            {
                con.Cars.Add(car);
                con.SaveChanges();
            }

            using (var con = new EfContext())
            {
                var loaded = con.Find<Car>(car.Id);
                loaded.Should().NotBeNull();
                loaded.Should().BeEquivalentTo(car, x => x.IgnoringCyclicReferences());
            }
        }

        [Fact]
        public void Delete_car_should_not_delete_Location()
        {
            var car = new Car();
            var loc = new Location();
            car.Location = loc;

            using (var con = new EfContext()) //insert car with location
            {
                con.Cars.Add(car);
                con.SaveChanges();
            }

            using (var con = new EfContext()) //delete car
            {
                var loaded = con.Find<Car>(car.Id);
                con.Remove(loaded);
                con.SaveChanges();
            }

            using (var con = new EfContext()) //verify loc still exists 
            {
                var loaded = con.Find<Location>(loc.Id);
                loaded.Should().NotBeNull();
            }
        }

        [Fact]
        public void Delete_location_should_set_cars_location_NULL()
        {
            var car = new Car();
            var loc = new Location();
            car.Location = loc;

            using (var con = new EfContext()) //insert car with location
            {
                con.Cars.Add(car);
                con.SaveChanges();
            }

            using (var con = new EfContext()) //delete loc
            {
                var loaded = con.Find<Location>(loc.Id);
                con.Remove(loaded);
                con.SaveChanges();
            }

            using (var con = new EfContext()) //verify car still exists 
            {
                var loaded = con.Find<Car>(car.Id);
                loaded.Should().NotBeNull();
                loaded.Location.Should().BeNull();
            }
        }
    }
}