using System;
namespace VideoStore.Models
{
    public abstract class Movie {
        abstract public float calculatePrice(int days);
    }

    public class RegularMovie : Movie
    {
        public override float calculatePrice(int days)
        {
            if (days <= 2)
            {
                return 2;
            } else
            {
                return 1.5f * (days - 2) + 2.0f;
            }
        }
    }

    public class NewMovie : Movie
    {
        public override float calculatePrice(int days)
        {
            return days * 3;
        }
    }

    public class ChildrenMovie : Movie
    {
        public override float calculatePrice(int days)
        {
            throw new NotImplementedException();
        }
    }

    public static class MovieFactory {

        public static Movie Build(MovieCategory category) {
            
            switch(category) {
                case MovieCategory.Regular:
                    return new RegularMovie();
                case MovieCategory.New:
                    return new NewMovie();
                case MovieCategory.Children:
                    return new ChildrenMovie();
                default:
                    break;
            }
            return null;
        }

    }

    public class RentalCalculator
    {
        public RentalCalculator(int numberOfDays, MovieCategory category)
        {
            this.Days = numberOfDays;
            this.Category = category;

            movie = MovieFactory.Build(category);    
        }

        private Movie movie { get; }
        public int Days { get; private set; }
        public MovieCategory Category { get; private set; }
        public float Price {
            get {
                return movie.calculatePrice(this.Days);
            }
        }

        public int FrequentRentalPointsEarnt {
            get { 
                return calculateFrequentRentalPoints();                
            }
        }

        private int calculateFrequentRentalPoints() {
            if (this.Days >= 2 && this.Category == MovieCategory.New) {
                return 2;
            }
            return 1;
        }

    }
}