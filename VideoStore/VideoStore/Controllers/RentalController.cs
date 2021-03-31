using System;
using Microsoft.AspNetCore.Mvc;
using VideoStore.Models;

namespace VideoStore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RentalController
    {
        [HttpGet]
        [Route("calculate")]
        public ActionResult<CalculatedRental> Calculate(
            [FromQuery] int rentalDays,
            [FromQuery] string movieCategory
        ) {

            MovieCategory category;
            if (Enum.TryParse<MovieCategory>(movieCategory, out category)) {
                Rental calculator = new Rental(rentalDays, category); 
                return new CalculatedRental(calculator.Price, calculator.FrequentRentalPointsEarnt);
            } 
            return new CalculatedRental();
        } 
        
    }

    public class CalculatedRental {
        public CalculatedRental()
        {
            this.Price = 0.0f;
            this.FrequentRentalPoints = 0;
        }

        public CalculatedRental(float price, int frequentRentalPoints) 
        {
            this.Price = price;
            this.FrequentRentalPoints = frequentRentalPoints;
        }

        public float Price { get; set; }
        public int FrequentRentalPoints { get; set; }

    }
}
