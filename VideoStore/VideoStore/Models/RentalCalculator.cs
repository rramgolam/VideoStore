using System;
namespace VideoStore.Models
{
    public class RentalCalculator
    {
        public int Days { get; set; }
        public float Price { get; private set; }
        public int FrequentRentalPointsEarnt { get; private set; }

        public void CalculatePrice()
        {
            if (Days <= 2)
            {
                this.Price = 2;
            } else
            {
                this.Price = 1.5f * (this.Days - 2) + 2.0f;
            }
        }

        public void CalculateFrequenceRentalPoints()
        {
            this.FrequentRentalPointsEarnt = 1;
        }
    }
}