using NUnit.Framework;
using VideoStore.Models;
using System;

namespace VideoStore.Test
{
    public class RegularMovieRentalTest
    {
        private MovieCategory category;

        [SetUp]
        public void Setup()
        {
            category = MovieCategory.Regular;
        }

        [Test]
        public void whenIHave2DayRental_thenThePriceShouldBe2Pounds()
        {
            float expectedPrice = 2.0f;

            int days = 2;
            Rental rentalCalculator = new Rental(days, category);

            Assert.AreEqual(expectedPrice, rentalCalculator.Price);
        }

        [Test]
        public void whenIHaveA5DayRental_thenThePriceShouldBe6pounds50pence()
        {
            float expectedPrice = 6.5f;

            int days = 5;
            Rental rentalCalculator = new Rental(days, category);

            Assert.AreEqual(expectedPrice, rentalCalculator.Price);
        }

        [Test]
        public void whenIHaveAnNDayRental_thenMyFrequentRentalPointsEarntWillBe1()
        {
            int expectedPoints = 1;

            int days = new Random().Next(1, 10);
            Rental rentalCalculator = new Rental(days, category);
            
            Assert.AreEqual(expectedPoints, rentalCalculator.FrequentRentalPointsEarnt);
        }

        [Test]
        public void whenIHave2Rentals_thenMyFrequentRentalPointsEarntWillBe2()
        {
            int expectedPoints = 2;

            Rental firstRentalCalculator = new Rental(new Random().Next(1, 10), category);
            Rental secondRentalCalculator = new Rental(new Random().Next(1, 10), category);

            Assert.AreEqual(expectedPoints, firstRentalCalculator.FrequentRentalPointsEarnt
                + secondRentalCalculator.FrequentRentalPointsEarnt);
        }
    }
}