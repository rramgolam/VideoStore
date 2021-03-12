using System;
namespace VideoStore.Models
{
    public class RentalCalculator
    {
        public int Days { get; set; }
        public float Price { get; private set; }
    }
}