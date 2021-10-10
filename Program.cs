using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeProject
{

    class UserInput
    {
        
      public  string Title{ get; set; }
      public  string Director { get; set; }
      public  string Actor { get; set; }
      public  int Genre { get; set; }
      public  string Year { get; set; }
    }

    class Movie
    {
 
     public  int MovieID{ get; set; }
     public  string Title { get; set; }
     public  string Director { get; set; }
     public  string Actor { get; set; }
     public  int Genre { get; set; }
     public  string Year { get; set; }
      public  string Description { get; set; }
    }
    class ErrorHandling
    {
        private
            bool inputValid;
            bool listEmpty;
        public
            bool noInput(UserInput input)
        {

        }
            bool emptyList(List<Movie> movieList)
            { 
            }
            bool invalidInput(UserInput input) 
            { 
            }  

    }
    class MovieList
    {
        private
       List<Movie> movieList;
        public
       MovieList()
        {
            this.movieList = new List<Movie>();
        }
        void addMovie(Movie movie)
        {
            this.movieList.Add(movie);
        }
        bool removeMovie(int movieID)
        {
            return movieList.Remove(getMovie(movieID));
        }
        Movie getMovie(int movieId)
        {
            return movieList.Find(delegate (Movie movie)
            {
                return movie.MovieID.Equals(movieId);
            });
           
        }
        }
        class AI { }

    }
