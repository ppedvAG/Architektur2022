using FluentAssertions;
using ppedv.Garage.Model;

namespace ppedv.Garage.Logic.CarServices.Tests
{
    public class CarManagerTests
    {
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