using NUnit.Framework;
using VideoStore.Models;
using System;

namespace VideoStore.Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void whenIHave2DayRental_thenThePriceShouldBe2Pounds()
        {
            float expectedPrice = 2.0f;

            int days = 2;
            RentalCalculator rentalCalculator = new RentalCalculator(days);

            Assert.AreEqual(expectedPrice, rentalCalculator.Price);
        }

        [Test]
        public void whenIHaveA5DayRental_thenThePriceShouldBe6pounds50pence()
        {
            float expectedPrice = 6.5f;

            int days = 5;
            RentalCalculator rentalCalculator = new RentalCalculator(days);

            Assert.AreEqual(expectedPrice, rentalCalculator.Price);
        }

        [Test]
        public void whenIHaveAnNDayRental_thenMyFrequentRentalPointsEarntWillBe1()
        {
            int expectedPoints = 1;

            int days = new Random().Next(1, 10);
            RentalCalculator rentalCalculator = new RentalCalculator(days);
            
            Assert.AreEqual(expectedPoints, rentalCalculator.FrequentRentalPointsEarnt);
        }

        [Test]
        public void whenIHave2Rentals_thenMyFrequentRentalPointsEarntWillBe2()
        {
            int expectedPoints = 2;

            RentalCalculator firstRentalCalculator = new RentalCalculator(new Random().Next(1, 10));
            RentalCalculator secondRentalCalculator = new RentalCalculator(new Random().Next(1, 10));

            Assert.AreEqual(expectedPoints, firstRentalCalculator.FrequentRentalPointsEarnt
                + secondRentalCalculator.FrequentRentalPointsEarnt);
        }
    }
}