using System;
using NUnit.Framework;
using VideoStore.Models;

namespace VideoStore.Test
{
    public class NewMovieRentalTest
    {

        [Test]
        public void whenIHaveAThreeDayRental_thenThePriceIs9Pounds() {
            int days = 3;
            RentalCalculator rentalCalculator = new RentalCalculator(days);
            
            Assert.AreEqual(9.0, rentalCalculator.Price);
        }

    }
}
