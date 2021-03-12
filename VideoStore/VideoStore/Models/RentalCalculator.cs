using System;
namespace VideoStore.Models
{
    public abstract class MovieCalculator {
        abstract public float calculatePrice(int days);
        abstract public int calculateFrequentRentalPoints(int days);
    }

    public class RegularMovieCalculator : MovieCalculator
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

        public override int calculateFrequentRentalPoints(int days)
        {
            return 1;
        }
    }

    public class NewMovieCalculator : MovieCalculator
    {
        public override float calculatePrice(int days)
        {
            return days * 3;
        }
        public override int calculateFrequentRentalPoints(int days)
        {
            if (days >= 2) {
                return 2;
            }
            return 1;
        }
    }

    public class ChildrenMovieCalculator : MovieCalculator
    {
        public override float calculatePrice(int days)
        {
            throw new NotImplementedException();
        }
        public override int calculateFrequentRentalPoints(int days)
        {
            throw new NotImplementedException();
        }
    }

    public static class MovieCalculatorFactory {

        public static MovieCalculator Build(MovieCategory category) {
            
            switch(category) {
                case MovieCategory.Regular:
                    return new RegularMovieCalculator();
                case MovieCategory.New:
                    return new NewMovieCalculator();
                case MovieCategory.Children:
                    return new ChildrenMovieCalculator();
                default:
                    break;
            }
            return null;
        }

    }

    public class Rental
    {
        public Rental(int numberOfDays, MovieCategory category)
        {
            this.Days = numberOfDays;
            this.Category = category;

            movie = MovieCalculatorFactory.Build(category);    
        }

        private MovieCalculator movie { get; }
        public int Days { get; private set; }
        public MovieCategory Category { get; private set; }
        public float Price {
            get {
                return movie.calculatePrice(this.Days);
            }
        }

        public int FrequentRentalPointsEarnt {
            get { 
                return movie.calculateFrequentRentalPoints(this.Days);                
            }
        }

    }
}