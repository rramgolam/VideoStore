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
    }
}