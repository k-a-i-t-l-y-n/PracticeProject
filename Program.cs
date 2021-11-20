using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JamLibrary;
namespace PracticeProject
{

    class UserInput
    {    
      public  string Title{ get; set; }
      public  string Director { get; set; }
      public  string Actor { get; set; }
      public  int Genre { get; set; }
      public  string Year { get; set; }
      
        public UserInput()
        {
            Title = "";
            Director = "";
            Actor = "";
            Genre = 0;
            Year = "";
        }
        public bool noInput()
        {
            bool empty = true;
            if ((this.Genre != 0) || (this.Title != "") || (this.Director != "")||(this.Actor!="")||(this.Year!=""))
                empty = false;
            return empty;
                }
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
            bool inputValid;
            bool listEmpty;
       
    
         public bool emptyList(List<Movie> movieList)
                {
            return (movieList.Count == 0);
                }
         public bool invalidInput(UserInput input) 
                { 
                return 
                }  

    }
    class MovieList
    {
        private
       List<Movie> movieList;
      
       MovieList()
        {
            this.movieList = new List<Movie>();
        }
     public   void addMovie(Movie movie)
        {
            this.movieList.Add(movie);
        }
     public   bool removeMovie(int movieID)
        {
            return movieList.Remove(getMovie(movieID));
        }
     public   Movie getMovie(int movieId)
        {
            return movieList.Find(delegate (Movie movie)
            {
                return movie.MovieID.Equals(movieId);
            });  
        }
        }

    class Query 
    {
        string connectionString;
        string movieTable = "Movie";
        string genreTable = "Genre";
        string directorTable = "Director";
        string actorTable = "Actor";
        string userTable = "User";
        bool hasResults = false;
        public List<int> SearchQuery(UserInput input)
        {
            string selectPt1 = "SELECT movieID FROM ";
            string selectPt2 = "WHERE ";
            string tempQueryString;
            List<int> results = new List<int>();
            SqlCommand command;
            SqlDataReader reader;
            //If there is input for title search database for titles that have the input as a substring.
            if (input.Title != "")
            {
                tempQueryString = selectPt1 + movieTable + " " + selectPt2 + "title LIKE '%" + input.Title + "%'";
                command = new SqlCommand(tempQueryString, connection);
                using (reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        results.Add(reader.GetInt32(0));
                    }
                }
                hasResults = true;
            }
            if (input.Director != "" && results[0]!=-1)
            {
                tempQueryString = selectPt1 + directorTable + " " + selectPt2 + " directorName = " + input.Director;
                if (hasResults == true)
                    tempQueryString = FormMovieIDQuery(results, tempQueryString);
                command = new SqlCommand(tempQueryString, connection);
                using (reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        results.Add(reader.GetInt32(0));
                    }

                }
            }
                if (input.Actor != "" && results[0] != -1)
                {
                    tempQueryString = selectPt1 + actorTable + " actor "+ selectPt2 + input.Actor;
                    command = new SqlCommand(tempQueryString, connection);
                    using (reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            results.Add(reader.GetInt32(0));
                        }
                    }
                }
                if (input.Genre != 0 && results[0] != -1)
                {
                    tempQueryString = selectPt1 + genreTable + " " +selectPt2 + input.Genre;
                if (hasResults == true)
                   tempQueryString= FormMovieIDQuery(results, tempQueryString);
                command = new SqlCommand(tempQueryString, connection);
                using (reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        results.Add(reader.GetInt32(0));
                    }
                }
                hasResults = true;
                }

                if (input.Year != "")
                {
                    tempQueryString = selectPt1 + movieTable + " year " + selectPt2 + input.Year;
                if (hasResults == true)
                    tempQueryString = FormMovieIDQuery(results, tempQueryString);
                command = new SqlCommand(tempQueryString, connection);
                    using (reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            results.Add(reader.GetInt32(0));
                        }
                    }
                hasResults = true;
                }
            return results;
        }
            String FormMovieIDQuery(List<int> movieIds, string query ) 
            {
            query += "WHERE movieId IN (";
            foreach (int id in movieIds)
              {
                query += "'" + id + "', ";
              }
            query += ")";
            return query;
            
            }
        }
        }
