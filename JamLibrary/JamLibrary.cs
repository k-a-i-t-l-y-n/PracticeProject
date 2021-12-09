using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace PracticeProject
{
    public class UserInput
    {
        public string Director { get; set; }
        public string Actor { get; set; }
        public List<string> Genre { get; set; }
        public string Year { get; set; }

        public UserInput()
        {
            Director = "";
            Actor = "";
            Genre=new List<string>();
            Year = "";
        }
        //public bool noInput()
        //{
        //    bool empty = true;
        //    if ((this.Genre.Count()!=0) || (this.Director != "") || (this.Actor != "") || (this.Year != ""))
        //        empty = false;
        //    return empty;
        }
    }

    public class Movie
    {

        public int MovieID { get; set; }
        public string Title { get; set; }
        public string Director { get; set; }
        public List<string> Actor { get; set; }
        public List<string> Genre { get; set; }
        public string Year { get; set; }
        public string Description { get; set; }
        public string PosterLink { get; set; }
        public float Rating { get; set; }
       public Movie(moviesForList movie) 
        {
            string connectionString = @"Data Source=apmycs4.apsu.edu;Initial Catalog=khardin9CSCI4805;User ID=khardin9CSCI4805;Password=CSCI4805abc";
            SqlConnection connection = new SqlConnection(connectionString);
            MovieID = (int)movie.getMovieID();
            Rating = movie.getMovieScore();
            SqlDataReader reader;
            SqlCommand getTitle = new SqlCommand("select distinct(title), movieId from Movies where movieId in (2, 3, 5)", connection);
            SqlCommand getDirector = new SqlCommand("select distinct(directorName), Movies.movieId, Movies.title from((Directors inner join MovieDirectors on Directors.directorId = MovieDirectors.directorId) inner join Movies on MovieDirectors.movieId = Movies.movieId) where Movies.movieId in (2, 3, 5)",connection);
            SqlCommand getActor = new SqlCommand("select distinct(actorName), Movies.movieId, Movies.title from((Actors inner join MovieActors on Actors.actorId = MovieActors.actorId) inner join Movies on MovieActors.movieId = Movies.movieId) where Movies.movieId in (2, 3, 5)", connection);
            SqlCommand getGenre = new SqlCommand("select distinct(genreName), Movies.movieId, Movies.title from((Genres inner join MovieGenres on Genres.genreId = MovieGenres.genreId) inner join Movies on MovieGenres.movieId = Movies.movieId) where Movies.movieId in (2, 3, 5)", connection);
            SqlCommand getYear = new SqlCommand("select distinct(year), movieId from Movies where movieId in (2, 3, 5)", connection);
            SqlCommand getDescription = new SqlCommand("select distinct(description), movieId from Movies where movieId in (2, 3, 5)", connection);
            SqlCommand getPosterLink = new SqlCommand("select distinct(posterLink), movieId from Movies where movieId in (2, 3, 5)", connection);
           
            
            using (connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (reader = getDirector.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        this.Director = reader.GetString(0);
                    }

                }
                using (reader = getActor.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        this.Actor.Add(reader.GetString(0));
                    }

                }
                using (reader = getGenre.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        this.Genre.Add(reader.GetString(0));
                    }

                }
                using (reader = getYear.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        this.Year = reader.GetString(0);
                    }

                }
                using (reader = getDescription.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        this.Description = reader.GetString(0);
                    }

                }
                using (reader = getPosterLink.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        this.PosterLink = reader.GetString(0);
                    }

                }















            }
        }
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

       public MovieList(List<moviesForList> movies)
        {
            this.movieList = new List<Movie>();
            foreach(moviesForList movie in movies) 
            {
                this.addMovie(new Movie(movie));
            }
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
    public class Query
    {
        UserInput input;

        string connectionString = @"Data Source=apmycs4.apsu.edu;Initial Catalog=khardin9CSCI4805;User ID=khardin9CSCI4805;Password=CSCI4805abc";
        bool hasResults = false;

        public Query(UserInput input)
        {
            this.input = input;
        }
      public  List<moviesForList> SearchQuery(List<moviesForList> results)
        {
            //If there is input for title search database for titles that have the input as a substring.
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
        String FormMovieIDQuery(List<moviesForList> movieIds, string query)
        {
            int count = movieIds.Count();
            query += "AND WHERE movieId IN (";
            foreach (moviesForList id in movieIds)
            {
                query += "'" + id.getMovieID() + "'";
                count--;
                if (count > 1)
                    query += ",";

            }
            query += ")";
            return query;

        }
       
        List<moviesForList> DirectorQuery(List<moviesForList> results, bool hasResults)
        {

            string queryString= "SELECT MovieDirectors.movieID FROM (MovieDirectors inner join Directors on MovieDirectors.directorId = Directors.directorId) Where Directors.directorName = "+"'"+input.Director+"'";
            SqlConnection connection;
            List<int> tempResults = new List<int>();

            SqlDataReader reader;
            SqlCommand command;
            using (connection = new SqlConnection(connectionString))
            {
                connection.Open();
                if (hasResults == true)
                   queryString = FormMovieIDQuery(results, queryString);
                command = new SqlCommand(queryString, connection);
                using (reader = command.ExecuteReader())
                {
                    if (!reader.Read())
                        hasResults = false;
                    else
                    {
                        hasResults = true;
                        while (reader.Read())
                        {
                            tempResults.Add(reader.GetInt32(0));
                        }
                    }

                }
                connection.Close();
            }
            List<moviesForList> newResults = new List<moviesForList>();
            foreach (moviesForList movie in results)
            {
                foreach (int result in tempResults)
                {


                    if (((int)movie.getMovieID()) == result)
                    {
                        newResults.Add(movie);
                    }
                }
            }

            return newResults;
        }
        List<moviesForList> ActorQuery(List<moviesForList> results, bool hasResults)
        {
            string queryString = "SELECT MovieDirectors.movieID FROM(MovieActors inner join Actors on MovieActors.ActorId = Actors.actorId) Where Actors.actorName = "+"'"+input.Actor+"'";
           
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
                    if (!reader.Read())
                        hasResults = false;
                    else
                    {
                        hasResults = true;
                        while (reader.Read())
                        {
                            tempResults.Add(reader.GetInt32(0));
                        }
                    }
                }
                hasResults = true;
                connection.Close();
            }
            List<moviesForList> newResults = new List<moviesForList>();
            foreach (moviesForList movie in results)
            {
                foreach (int result in tempResults)
                {


                    if (((int)movie.getMovieID()) == result)
                    {
                        newResults.Add(movie);
                    }
                }
            }

            return newResults;
        }
        List<moviesForList> GenreQuery(List<moviesForList> results, bool hasResults)
        {
            string queryString = "SELECT MovieGenres.movieID FROM (MovieGenres inner join Genres on MovieGenres.genreId = Genres.genreId) Where Genres.genreName";
            SqlConnection connection;
            List<int> tempResults = new List<int>();

            SqlDataReader reader;
            SqlCommand command;
            using (connection = new SqlConnection(connectionString))
            {
                connection.Open();
                if (input.Genre.Count() == 1)
                {
                    queryString += " = '"+ input.Genre[0]+"'";
                }
                else 
                {
                    queryString += " IN (";
                    for (int i = 0; i < input.Genre.Count(); i++) {
                        queryString +="'"+ input.Genre[i]+"'";
                        if (i < input.Genre.Count() - 1)
                            queryString +=", ";
                    }
                    queryString += ")";
                }
                command = new SqlCommand(queryString, connection);
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
            List<moviesForList> newResults = new List<moviesForList>();
            foreach (moviesForList movie in results)
            {
                foreach (int result in tempResults)
                {


                    if (((int)movie.getMovieID()) == result)
                    {
                        newResults.Add(movie);
                    }
                }
            }

            return newResults;
        }
        List<moviesForList> YearQuery(List<moviesForList> results, bool hasResults)
        {
            string selectPt1 = "SELECT movieID FROM ";
            string selectPt2 =;
            string tempQueryString;
            SqlConnection connection;
            List<int> tempResults = new List<int>();

            SqlDataReader reader;
            SqlCommand command;
            using (connection = new SqlConnection(connectionString))
            {
                connection.Open();
                tempQueryString = selectPt1  + "Movies WHERE Year = " +  input.Year;
                if (hasResults == true)
                    tempQueryString = FormMovieIDQuery(results, tempQueryString);
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
            List<moviesForList> newResults = new List<moviesForList>();
            foreach (moviesForList movie in results)
            {
                foreach (int result in tempResults)
                {


                    if (((int)movie.getMovieID()) == result)
                    {
                        newResults.Add(movie);
                    }
                }
            }

            return newResults;

        }

        int GetActorId() 
        {
            int actorId = -1;
            string tempQueryString = "SELECT actorId FROM Actors WHERE actorName = " + "'" + input.Actor + "'"; 
            SqlConnection connection;
            SqlDataReader reader;
            SqlCommand command;



            using (connection = new SqlConnection(connectionString))
            {
                connection.Open();
                command = new SqlCommand((tempQueryString), connection);
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
    //class to hold the movie id's and score to send to the front end
    public class moviesForList
    {
        private float movieId;
        private float movieScore;

        public moviesForList(float movieId, float movieScore)
        {
            this.movieId = movieId;
            this.movieScore = movieScore;
        }

        public float getMovieID()
        {
            return this.movieId;
        }

        public float getMovieScore()
        {
            return this.movieScore;
        }

    }
}
