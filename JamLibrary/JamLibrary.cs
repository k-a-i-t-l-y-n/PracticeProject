using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.SqlTypes;
namespace JamLibrary
{
    public class UserInput
    {
        public string Title { get; set; }
        public string Director { get; set; }
        public string Actor { get; set; }
        public List<string> Genre { get; set; }
        public string Year { get; set; }

        public UserInput()
        {
            Title = "";
            Director = "";
            Actor = "";
            Genre=new List<string>();
            Year = "";
        }
        public bool noInput()
        {
            bool empty = true;
            if ((this.Genre.Count()!=0) || (this.Title != "") || (this.Director != "") || (this.Actor != "") || (this.Year != ""))
                empty = false;
            return empty;
        }
    }

    public class Movie
    {

        public int MovieID { get; set; }
        public string Title { get; set; }
        public string Director { get; set; }
        public string Actor { get; set; }
        public int Genre { get; set; }
        public string Year { get; set; }
        public string Description { get; set; }
    }
    public class ErrorHandling
    {
        bool inputValid;
        bool listEmpty;


        public bool emptyList(List<Movie> movieList)
        {
            return (movieList.Count == 0);
        }
        public bool invalidInput(UserInput input)
        {
            return false;
        }

    }
    public class MovieList
    {
        private
       List<Movie> movieList;

        MovieList()
        {
            this.movieList = new List<Movie>();
        }
        public void addMovie(Movie movie)
        {
            this.movieList.Add(movie);
        }
        public bool removeMovie(int movieID)
        {
            return movieList.Remove(getMovie(movieID));
        }
        public Movie getMovie(int movieId)
        {
            return movieList.Find(delegate (Movie movie)
            {
                return movie.MovieID.Equals(movieId);
            });
        }
    }
    class AI { }
    public class Query
    {
        UserInput input;
        string movieTable = "Movies";
        string genreTable = "Genres";
        string directorTable = "Directors";
        string directorIdTable = "DirectorIds";
        string actorTable = "Actors";
        string actorIdTable = "ActorIds";
        string userTable = "Users";
        string connectionString = @"Data Source=apmycs4.apsu.edu;Initial Catalog=khardin9CSCI4805;User ID=khardin9CSCI4805;Password=CSCI4805abc";
        bool hasResults = false;

        public Query(string movieTable)
        {
            this.movieTable = movieTable;
        }
        public Query(UserInput input)
        {
            this.input = input;
        }
        public List<int> SearchQuery(UserInput input)
        {
            List<int> results = new List<int>();
            //If there is input for title search database for titles that have the input as a substring.
            if (input.Title != "")
            {
                results = this.TitleQuery();
            }
            if (input.Director != "")
            {
                results = this.DirectorQuery( results, hasResults);
            }
            if (input.Actor != "")
            {
                results = this.ActorQuery( results, hasResults);
            }
            if (input.Genre.Count() != 0)
            {
              results=  this.GenreQuery(results, hasResults);
            }

            if (input.Year != "")
            {

                results = this.YearQuery( results, hasResults);
            }
            return results;
        }
        String FormMovieIDQuery(List<int> movieIds, string query)
        {
            int count = movieIds.Count();
            query += "AND WHERE movieId IN (";
            foreach (int id in movieIds)
            {
                query += "'" + id + "'";
                count--;
                if (count > 1)
                    query += ",";

            }
            query += ")";
            return query;

        }
        List<int> TitleQuery()
        {
            string selectPt1 = "SELECT movieID FROM ";
            string selectPt2 = "WHERE ";
            string tempQueryString;
            SqlConnection connection;
            List<int> results = new List<int>();

            SqlDataReader reader;
            SqlCommand command;

            using (connection = new SqlConnection(connectionString))
            {
                connection.Open();
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
                connection.Close();

            }
            return results;
        }
        List<int> DirectorQuery( List<int> results, bool hasResults)
        {

            string queryString= "SELECT movieID FROM MovieDirectors Where DirectorId = ";
            SqlConnection connection;
            List<int> tempResults = new List<int>();

            SqlDataReader reader;
            SqlCommand command;
            using (connection = new SqlConnection(connectionString))
            {
                connection.Open();
                queryString += GetDirectorId() ;
                if (hasResults == true)
                   queryString = FormMovieIDQuery(results, queryString);
                command = new SqlCommand(queryString, connection);
                using (reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        tempResults.Add(reader.GetInt32(0));
                    }

                }
                hasResults = true;
                connection.Close();
            }
            return tempResults;
        }
        List<int> ActorQuery( List<int> results, bool hasResults)
        {
            string queryString = "SELECT movieID FROM MovieActors Where ActorId = ";
           
            SqlConnection connection;
            List<int> tempResults = new List<int>();

            SqlDataReader reader;
            SqlCommand command;
            using (connection = new SqlConnection(connectionString))
            {
                connection.Open();
                queryString += GetActorId();
                if (hasResults == true)
                queryString = FormMovieIDQuery(results, queryString);
                command = new SqlCommand(queryString, connection);
                using (reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        tempResults.Add(reader.GetInt32(0));
                    }
                }
                hasResults = true;
                connection.Close();
            }
            return tempResults;
        }
        List<int> GenreQuery( List<int> results, bool hasResults)
        {
            string selectPt1 = "SELECT movieID FROM ";
            string selectPt2 = "WHERE ";
            string tempQueryString;
            SqlConnection connection;
            List<int> tempResults = new List<int>();

            SqlDataReader reader;
            SqlCommand command;
            string genIds=GetGenreIds();
            using (connection = new SqlConnection(connectionString))
            {
                connection.Open();
                if (input.Genre.Count() == 1)
                {
                    tempQueryString = selectPt1 +  "MovieGenres " + selectPt2 + " genreId = " + genIds;
                }
                else 
                {
                    tempQueryString = selectPt1 + "MovieGenres " + selectPt2 + " genreId IN (" + genIds+")";
                }
                command = new SqlCommand(tempQueryString, connection);
                if (hasResults == true)
                    tempQueryString = FormMovieIDQuery(results, tempQueryString);
                Console.WriteLine(tempQueryString);
                command = new SqlCommand(tempQueryString, connection);
                using (reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        tempResults.Add(reader.GetInt32(0));
                    }
                }
                hasResults = true;
                connection.Close();
            }
            return tempResults;
        }
        List<int> YearQuery(List<int> results, bool hasResults)
        {
            string selectPt1 = "SELECT movieID FROM ";
            string selectPt2 = "WHERE ";
            string tempQueryString;
            SqlConnection connection;
            List<int> tempResults = new List<int>();

            SqlDataReader reader;
            SqlCommand command;
            using (connection = new SqlConnection(connectionString))
            {
                connection.Open();
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
                connection.Close();
            }
            return tempResults;

        }
       int GetDirectorId() 
        {
            int directorId=-1;
            string tempQueryString = "SELECT directorId FROM Directors WHERE directorName = " + input.Director; ;
            SqlConnection connection;
            SqlDataReader reader;
            SqlCommand command;



            using (connection = new SqlConnection(connectionString))
            {
                connection.Open();
                command = new SqlCommand((tempQueryString + "'" + input.Director + "'"), connection);
                using (reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        directorId = reader.GetInt32(0);
                    }

                }
                connection.Close();
            }
            return directorId;
        }
        int GetActorId() 
        {
            int actorId = -1;
            string tempQueryString = "SELECT actorId FROM Actors WHERE actorName = " + input.Actor; 
            SqlConnection connection;
            SqlDataReader reader;
            SqlCommand command;



            using (connection = new SqlConnection(connectionString))
            {
                connection.Open();
                command = new SqlCommand((tempQueryString + "'" + input.Director + "'"), connection);
                using (reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        actorId = reader.GetInt32(0);
                    }

                }
                connection.Close();
            }
            return actorId;
        }
             string GetGenreIds()

        {
           
            int count = input.Genre.Count();
            int tempResults = 0;
            string genreIds = "";
            for (int i=input.Genre.Count()-1; i>=0;i--) 
            {
                string tempQueryString = "SELECT genreId FROM Genres WHERE genreName = ";
                SqlConnection connection;
                SqlDataReader reader;
                SqlCommand command;
                
          
          
            using (connection = new SqlConnection(connectionString))
            {
                connection.Open();
                command = new SqlCommand((tempQueryString + "'" + input.Genre[i] + "'"), connection);
                using (reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        tempResults = reader.GetInt32(0);
                    }

                }
                connection.Close();
            }
                genreIds +=tempResults.ToString();
                
                if (i >= 1 )
                {
                    genreIds += ", ";
                }
            }
            return genreIds;
        }
    }
}
