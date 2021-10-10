using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeProject
{

    class UserInput
    {
        public
        string title{ get; set; }
        string director { get; set; }
        string actor { get; set; }
        int genre { get; set; }
        string year { get; set; }
    }

    class Movie
    {
        public
        int movieID{ get; set; }
        string title { get; set; }
        string director { get; set; }
        string actor { get; set; }
        int genre { get; set; }
        string year { get; set; }
        string description { get; set; }
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
                return movie.movieID.Equals(movieId);
            });
        }
        }
        class AI { }

    }
