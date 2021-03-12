using System;
namespace VideoStore.Models
{
    public class RentalCalculator
    {
        public int Days { get; set; }
        public float Price { get; private set; }

        public void calculatePrice()
        {
            this.Price = 2.0f;
        }
    }
}