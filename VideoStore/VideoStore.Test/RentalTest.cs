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
        public void whenIAdd2DaysToRental_thenThePriceShouldBe2Pounds()
        {
            RentalCalculator rentalCalculator = new RentalCalculator();
            float expectedPrice = 2.0f;
            rentalCalculator.Days = 2;
            rentalCalculator.CalculatePrice();

            Assert.AreEqual(expectedPrice, rentalCalculator.Price);
        }

        [Test]
        public void whenIAdd5DaysToMyRental_thenThePriceShouldBe6pounds50pence()
        {
            RentalCalculator rentalCalculator = new RentalCalculator();
            float expectedPrice = 6.5f;
            rentalCalculator.Days = 5;
            rentalCalculator.CalculatePrice();

            Assert.AreEqual(expectedPrice, rentalCalculator.Price);
        }

        [Test]
        public void whenIAddNDaysToRental_thenMyFrequentRentalPointsEarntWillBe1()
        {
            RentalCalculator rentalCalculator = new RentalCalculator();
            int expectedPoints = 1;
            Random randomDay = new Random();
            rentalCalculator.Days = randomDay.Next(1,10);
            rentalCalculator.CalculateFrequenceRentalPoints();

            Assert.AreEqual(expectedPoints, rentalCalculator.FrequentRentalPointsEarnt);
        }

        [Test]
        public void whenIHave2Rentals_thenMyFrequentRentalPointsEarntWillBe2()
        {
            RentalCalculator firstRentalCalculator = new RentalCalculator();
            RentalCalculator secondRentalCalculator = new RentalCalculator();

            int expectedPoints = 2;

            Random randomDay = new Random();
            firstRentalCalculator.Days = randomDay.Next(1, 10);
            secondRentalCalculator.Days = randomDay.Next(1, 10);

            firstRentalCalculator.CalculateFrequenceRentalPoints();
            secondRentalCalculator.CalculateFrequenceRentalPoints();

            Assert.AreEqual(expectedPoints, firstRentalCalculator.FrequentRentalPointsEarnt + firstRentalCalculator.FrequentRentalPointsEarnt);
        }
    }
}