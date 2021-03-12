using System;
namespace VideoStore.Models
{
    public class RentalCalculator
    {
        public RentalCalculator(int numberOfDays)
        {
            this.Days = numberOfDays;

        }

        public int Days { get; set; }

        public float Price {
            get {
                return calculatePrice();
            }
        }

        public int FrequentRentalPointsEarnt {
            get { return 1; }
        }

        private float calculatePrice()
        {
            if (Days <= 2)
            {
                return 2;
            } else
            {
                return 1.5f * (this.Days - 2) + 2.0f;
            }
        }

    }
}