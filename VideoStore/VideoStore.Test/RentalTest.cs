using NUnit.Framework;
using VideoStore.Models;

namespace VideoStore.Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void whenIAdd2DaysToRental_thenThePriceShouldBe2Pounds()
        {
            RentalCalculator rentalCalculator = new RentalCalculator();
            float expectedPrice = 2.0f;
            rentalCalculator.Days = 2;
            rentalCalculator.calculatePrice();

            Assert.AreEqual(expectedPrice, rentalCalculator.Price);
        }

        [Test]
        public void whenIAdd5DaysToMyRental_thenThePriceShouldBe6pounds50pence()
        {
            RentalCalculator rentalCalculator = new RentalCalculator();
            float expectedPrice = 6.5f;
            rentalCalculator.Days = 5;
            rentalCalculator.calculatePrice();

            Assert.AreEqual(expectedPrice, rentalCalculator.Price);
        }
    }
}