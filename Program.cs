using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.Sql;

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
                return
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
        class AI { }
    class Query 
    {
        string connectString;
        string movieTable = "Movie";
        string genreTable = "Genre";
        string directorTable = "Director";
        string actorTable = "Actor";
        string userTable = "User";
        public string FormQuery(UserInput input, int movieID)
        {
            string SelectPt1 = "SELECT movieId FROM";
            string SelectPt2 = "WHERE ";
            string SelectPt3 = "= (";
            if (input.Title != "")
            {
                SelectPt2 = SelectPt2 + "title, ";
                SelectPt3 = SelectPt3 + input.Title + ", ";
            }
            if (input.Director != "")
            {
                SelectPt2 = SelectPt2 + "director, ";
                SelectPt3 = SelectPt3 + input.Director + ", ";
            }
            if (input.Actor != "")
            {
                SelectPt2 = SelectPt2 + "actor, ";
                SelectPt3 = SelectPt3 + input.Actor + ", ";
            }
            if (input.Genre != 0)
            {
                SelectPt2 = SelectPt2 + "genre, ";
                SelectPt3 = SelectPt3 + input.Genre + ", ";
            }
            if (input.Year != "")
            {
                SelectPt2 = SelectPt2 + "year, ";
                SelectPt3 = SelectPt3 + input.Year;
            }
            SelectPt3 = SelectPt3 + ")";
            return SelectPt1 + SelectPt2 + SelectPt3;
        }
            public List<int> SearchQuery(UserInput input)
            {
                string SelectPt1 = "SELECT movieID FROM ";
                string SelectPt2 = "WHERE ";
                string SelectPt3 = "= (";
                SqlCommand command;
                SqlDataReader reader;
            //If there is input for title search database for titles that have the input as a substring.
                if (input.Title != "")
                {
                SelectPt1 += movieTable;
                    SelectPt2 = SelectPt2  +"title LIKE '%"+input.Title+"%'";
                command= new SqlCommand(SelectPt1+SelectPt2, connection)
                }
                if (input.Director != "")
                {
                    SelectPt2 = SelectPt2 + directorTable +", ";
                    SelectPt3 = SelectPt3 + input.Director + ", ";
                }
                if (input.Actor != "")
                {
                    SelectPt2 +=  actorTable +", ";
                    SelectPt3 += input.Actor + ", ";
                }
                if (input.Genre != 0)
                {
                    SelectPt2 += genreTable +", ";
                    SelectPt3 +=  input.Genre + ", ";
                }
                if (input.Year != "")
                {
                    SelectPt2 = SelectPt2 + "year, ";
                    SelectPt3 = SelectPt3 + input.Year;
                }


            }
            String FormMovieIDQuery(List<int> movieIds ) 
            {
            string idQuery = "WHERE movieId IN (";
            foreach (int id in movieIds)
              {
                idQuery += "'" + id + "', ";
              }
            idQuery += ")";
            return idQuery;
            
            }
        }
    }
