using FluentAssertions;
using Moq;
using ppedv.Garage.Model;
using ppedv.Garage.Model.Contracts;

namespace ppedv.Garage.Logic.CarServices.Tests
{
    public class CarManagerTests
    {
        [Fact]
        public void GetLocationWithFastesCars_no_Locations_in_DB_returns_null()
        {
            var mock = new Mock<IRepository>();
            mock.Setup(x => x.GetAll<Location>()).Returns(() => new List<Location>());
            var cm = new CarManager(mock.Object);

            var result = cm.GetLocationWithFastesCars();

            result.Should().BeNull();
        }

        [Fact]
        public void GetLocationWithFastesCars_3_locations_L2_has_fastest_cars()
        {
            var cm = new CarManager(new TestRepo());

            var result = cm.GetLocationWithFastesCars();

            result.Name.Should().Be("L2");
        }

        [Fact]
        public void GetLocationWithFastesCars_3_locations_L2_has_fastest_cars_moq()
        {
            var mock = new Mock<IRepository>();
            mock.Setup(x => x.GetAll<Location>()).Returns(() =>
            {
                var l1 = new Location() { Name = "L1" };
                l1.Cars.Add(new Car() { KW = 50 });
                var l2 = new Location() { Name = "L2" };
                l2.Cars.Add(new Car() { KW = 40 });
                l2.Cars.Add(new Car() { KW = 40 });
                var l3 = new Location() { Name = "L3" };
                l3.Cars.Add(new Car() { KW = 50 });
                l3.Cars.Add(new Car() { KW = 20 });
                return new[] { l1, l2, l3 };
            });
            var cm = new CarManager(mock.Object);

            var result = cm.GetLocationWithFastesCars();

            result.Name.Should().Be("L2");
            mock.Verify(x => x.GetAll<Car>(), Times.Never);
        }

        [Fact]
        public void GetLocationWithFastesCars_2_Locations_have_same_KW_sum_then_BuildDate_()
        {
            var mock = new Mock<IRepository>();
            mock.Setup(x => x.GetAll<Location>()).Returns(() =>
            {
                var l1 = new Location() { Name = "L1" };
                l1.Cars.Add(new Car() { KW = 50, BuiltDate = DateTime.Now.AddDays(-10) });
                var l2 = new Location() { Name = "L2" };
                l2.Cars.Add(new Car() { KW = 50, BuiltDate = DateTime.Now.AddDays(-5) });
                var l3 = new Location() { Name = "L3" };
                l3.Cars.Add(new Car() { KW = 50, BuiltDate = DateTime.Now.AddDays(-10) });
                return new[] { l1, l2, l3 };
            });
            var cm = new CarManager(mock.Object);

            var result = cm.GetLocationWithFastesCars();

            result.Name.Should().Be("L2");
            mock.Verify(x => x.GetAll<Car>(), Times.Never);
        }


        [Fact]
        public void CheckColor_car_null_throws_NullRefEx()
        {
            var cm = new CarManager(null);

            Action act = () => cm.CheckColor(null, new List<string>());

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void CheckColor_allowedColor_null_throws_NullRefEx()
        {
            var cm = new CarManager(null);
            var car = new Car() { Color = "green" };

            Action act = () => cm.CheckColor(car, null);

            act.Should().Throw<ArgumentNullException>();
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        public void CheckColor_carColor_null_or_empty_throws_ArgEx(string carColor)
        {
            var cm = new CarManager(null);
            var car = new Car() { Color = carColor };

            Action act = () => cm.CheckColor(car, null);

            act.Should().Throw<ArgumentException>();
        }

        [Theory]
        [InlineData("blue")]
        [InlineData("red")]
        [InlineData("Red")]
        [InlineData("green")]
        public void CheckColor_all_ok(string carColor)
        {
            var cm = new CarManager(null);
            var colors = new[] { "blue", "red", "green" };
            var car = new Car() { Color = carColor };

            cm.CheckColor(car, colors).Should().BeTrue();
        }

        [Theory]
        [InlineData("blue")]
        [InlineData("red")]
        [InlineData("green")]
        public void CheckColor_all_not_ok(string carColor)
        {
            var cm = new CarManager(null);
            var colors = new[] { "", "pink", "yellow" };
            var car = new Car() { Color = carColor };

            cm.CheckColor(car, colors).Should().BeFalse();
        }
    }
}