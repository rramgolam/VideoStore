using System;
namespace VideoStore.Models
{
    public class RentalCalculator
    {
        public RentalCalculator(int numberOfDays, MovieCategory category)
        {
            this.Days = numberOfDays;
            this.Category = category;
        }

        public int Days { get; private set; }
        public MovieCategory Category { get; private set; }
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
            if (this.Category == MovieCategory.Regular) {
                
                if (this.Days <= 2)
                {
                    return 2;
                } else
                {
                    return 1.5f * (this.Days - 2) + 2.0f;
                }

            } else if (this.Category == MovieCategory.New) {
                return this.Days * 3;
            }
            
            return 0;
        }

    }
}