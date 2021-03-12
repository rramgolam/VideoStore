using System;
using NUnit.Framework;
using VideoStore.Models;

namespace VideoStore.Test
{
    public class NewMovieRentalTest
    {
        private MovieCategory category;

        [SetUp]
        public void Setup()
        {
            category = MovieCategory.New;
        }

        [Test]
        public void whenIHaveAThreeDayRental_thenThePriceIs9Pounds() {
            int days = 3;
            RentalCalculator rentalCalculator = new RentalCalculator(days, category);
            
            Assert.AreEqual(9.0, rentalCalculator.Price);
        }

        [Test]
        public void whenIHaveA1DayRental_thenIEarn1FrequentRentalPoint() {
            int expectedPoint = 1;
            int days = 3;
            RentalCalculator rentalCalculator = new RentalCalculator(days, category);

            Assert.AreEqual(expectedPoint, rentalCalculator.FrequentRentalPointsEarnt);
        }

        [Test]
        public void whenIHave2OrMoreDaysOfRental_thenIEarn2FrequentRentalPoints() {
            int expectedPoints = 2;
            
            int days = new Random().Next(2,10);
            RentalCalculator rentalCalculator = new RentalCalculator(days, category);

            Assert.AreEqual(expectedPoints, rentalCalculator.FrequentRentalPointsEarnt);
        }
    }
}
