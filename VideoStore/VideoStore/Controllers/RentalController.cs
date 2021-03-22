using System;
using Microsoft.AspNetCore.Mvc;

namespace VideoStore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RentalController
    {
        [HttpGet]
        [Route("calculate")]
        public ActionResult<CalculatedRental> Calculate() {
            CalculatedRental calculatedRental = new CalculatedRental();
            calculatedRental.Price = 0.0f;
            calculatedRental.FrequentRentalPoints = 0;

            return calculatedRental;
        } 
        
    }

    public class CalculatedRental {

        public float? Price { get; set; }
        public int? FrequentRentalPoints { get; set; }

    }
}
