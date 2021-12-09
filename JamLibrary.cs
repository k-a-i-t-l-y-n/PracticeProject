using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Windows;

namespace PracticeProject
{
    public class UserInput
    {
        public string Title { get; set; }
        public string Director { get; set; }
        public string Actor { get; set; }
        public string Genre { get; set; }
        public string Year { get; set; }

        public UserInput()
        {
            Title = "";
            Director = "";
            Actor = "";
            Genre = "";
            Year = "";
        }
    //    public bool noInput()
    //    {
    //        bool empty = true;
    //        if ((this.Genre != "") || (this.Title != "") || (this.Director != "") || (this.Actor != "") || (this.Year != ""))
    //            empty = false;
    //        return empty;
    //    }
    }

    public class Movie
    {

        public int MovieID { get; set; }
        public string Title { get; set; }
        public string Director { get; set; }
        public string Actor { get; set; }
        public string Genre { get; set; }
        public int Year { get; set; }
        public string Description { get; set; }
        public string PosterLink { get; set; }
        public float Rating { get; set; }
        //Constructor for survey movies.
        public Movie(string title, float rating, int movieId )
        {
            Title = title;
            Rating = rating;
            MovieID = movieId;
        }
       
        public Movie(moviesForList movies)
        {
            string connectionString = @"Data Source=apmycs4.apsu.edu;Initial Catalog=khardin9CSCI4805;User ID=khardin9CSCI4805;Password=CSCI4805abc";
            SqlConnection connection = new SqlConnection(connectionString);
            MovieID = (int)movies.getMovieID();
            Rating = movies.getMovieScore();
            SqlDataReader reader;
            connection.Open();
            SqlCommand getTitle = new SqlCommand("select distinct(title) from Movies where Movies.movieId = " + MovieID + ";", connection);
            SqlCommand getDirector = new SqlCommand("select distinct(directorName), Movies.movieId, Movies.title from((Directors inner join MovieDirectors on Directors.directorId = MovieDirectors.directorId) inner join Movies on MovieDirectors.movieId = Movies.movieId) where Movies.movieId = " + MovieID + ";", connection);
            SqlCommand getActor = new SqlCommand("select distinct(actorName), Movies.movieId, Movies.title from((Actors inner join MovieActors on Actors.actorId = MovieActors.actorId) inner join Movies on MovieActors.movieId = Movies.movieId) where Movies.movieId = " + MovieID + ";", connection);
            SqlCommand getGenre = new SqlCommand("select distinct(genreName), Movies.movieId, Movies.title from((Genres inner join MovieGenres on Genres.genreId = MovieGenres.genreId) inner join Movies on MovieGenres.movieId = Movies.movieId) where Movies.movieId = " + MovieID + ";", connection);
            SqlCommand getYear = new SqlCommand("select distinct(year), movieId from Movies where movieId = " + MovieID + ";", connection);
            SqlCommand getDescription = new SqlCommand("select distinct(description), movieId from Movies where Movies.movieId = " + MovieID + ";", connection);
            SqlCommand getPosterLink = new SqlCommand("select distinct(posterLink), movieId from Movies where Movies.movieId = " + MovieID + ";", connection);


            using (connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (reader = getTitle.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        this.Title = reader.GetString(0);
                    }

                }
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
                        this.Actor += reader.GetString(0) + "  ";
                    }

                }
                using (reader = getGenre.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        this.Genre = reader.GetString(0);
                    }

                }
                using (reader = getYear.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        this.Year =  reader.GetInt32(0);
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


  //  public class ErrorHandling
  //  {
  //      bool inputValid;
  //      bool listEmpty;
  //      public bool emptyList(List<Movie> movieList)
  //     {
  //          return (movieList.Count == 0);
  //      }
  //      public bool invalidInput(UserInput input)
  //      {
  //          return false;
  //     }
  //  }


    public class MovieList
    {
        private static List<Movie> movieList;

        public MovieList()
        { }
        public MovieList(List<moviesForList> movieAIList)
        {
            movieList = new List<Movie>();
            foreach (moviesForList movie in movieAIList)
            {
                this.addMovie(new Movie (movie));
            }
        }
        public void addMovie(Movie movie)
        {
            movieList.Add(movie);
        }
     //    public bool removeMovie(int movieID)
     //    {
     //        return movieList.Remove(getMovie(movieID));
     //    }
     //   public Movie getMovie(int movieId)
     //   {
     //       return movieList.Find(delegate (Movie movie)
     //       {
     //           return movie.MovieID.Equals(movieId);
     //       });
     //   }
        public List<Movie> getMovieList()
        { return movieList; }
    }

    public class Query
    {
        UserInput input;
      //  string movieTable = "Movies";
      //  string genreTable = "Genres";
      //  string directorTable = "Directors";
      //  string directorIdTable = "DirectorIds";
      //  string actorTable = "Actors";
      //  string actorIdTable = "ActorIds";
      //  string userTable = "Users";
        string connectionString = @"Data Source=apmycs4.apsu.edu;Initial Catalog=khardin9CSCI4805;User ID=khardin9CSCI4805;Password=CSCI4805abc";
        bool hasResults = false;

        public Query()
        { }

        public Query(UserInput input)
        {
            this.input = input;
        }

        public List<moviesForList> SearchQuery(List<moviesForList> results)
        {
            //If there is input for title search database for titles that have the input as a substring.
            if (input.Title != null)
            {
                results = this.TitleQuery();
            }
            if (input.Director != null)
            {
                results = this.DirectorQuery(results, hasResults);
            }
            if (input.Actor != "")
            {
                results = this.ActorQuery(results, hasResults);
            }
            if (input.Genre != null)
            {
                results = this.GenreQuery(results, hasResults);
            }

            if (input.Year != null)
            {

                results = this.YearQuery(results, hasResults);
            }
            return results;
        }

        String FormMovieIDQuery(List<moviesForList> movieIds, string query)
        {
            int count = movieIds.Count();
            query += "AND movieId IN (";
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

        //gets MovieId based on title
        public int getMovieId(string title)
        {
            string query = "select distinct(movieId) from Movies where title = " + "'" + title + "'";


            SqlConnection connection;
            SqlDataReader reader;
            SqlCommand command;

            int movieId = 0;

            using (connection = new SqlConnection(connectionString))
            {
                connection.Open();

                command = new SqlCommand(query, connection);
                using (reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        movieId = (reader.GetInt32(0));
                    }


                }
                
            }
            
            connection.Close();
            return movieId;
        }

        //This function returns a InfoMovie object based on the information gathered from the queries
        public InfoMovie getMoreMovieInfoQuery(string title)
        {
            InfoMovie infoMovie = new InfoMovie();
            
            
            string getDirector = "select directorName from ((Directors inner join MovieDirectors on Directors.directorId = MovieDirectors.directorId) inner join Movies on MovieDirectors.movieId = Movies.movieId) where Movies.title = \'" + title + "\'"; 
            string getYear = "select year from Movies where title = " + "'" + title + "'"; 
            string getActors = "select actorName from ((Actors inner join MovieActors on Actors.actorId = MovieActors.actorId) inner join Movies on MovieActors.movieId = Movies.movieId) where Movies.title = " + "'" + title + "'"; 
            string getDescription = "select description from Movies where title = " + "'" + title +"'"; 
            
            
            SqlConnection connection;
            
            List<moviesForList> results = new List<moviesForList>();

            SqlDataReader reader;
            SqlCommand command;

            using (connection = new SqlConnection(connectionString))
            {
                connection.Open();
               
                command = new SqlCommand(getDirector, connection);
                using (reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        infoMovie.Director += (reader.GetString(0));
                    }
                }

                command = new SqlCommand(getActors, connection);
                using (reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        infoMovie.Actors += (reader.GetString(0));
                    }
                }
                command = new SqlCommand(getYear, connection);
                using (reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        infoMovie.Year = (reader.GetInt32(0));
                    }
                }
                command = new SqlCommand(getDescription, connection);
                using (reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        infoMovie.Description += (reader.GetString(0));
                    }
                }

                hasResults = true;
                connection.Close();

            }
            
            
            return infoMovie;
        }
        List<moviesForList> TitleQuery()
        {
            string selectPt1 = "SELECT movieID FROM ";
            string selectPt2 = "WHERE ";
            string tempQueryString;
            SqlConnection connection;
            List<moviesForList> results = new List<moviesForList>();

            SqlDataReader reader;
            SqlCommand command;

            using (connection = new SqlConnection(connectionString))
            {
                connection.Open();
                tempQueryString = selectPt1 + "Movies" + " " + selectPt2 + "title LIKE '%" + input.Title + "%'";'
                command = new SqlCommand(tempQueryString, connection);
                using (reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        //  results.Add(reader.GetInt32(0));
                    }
                }
                hasResults = true;
                connection.Close();

            }
            return results;
        }

        //Query to get movieTitles form database that fit a certain genre

        public List<string> SurveyQuery(string genreName)
        {

            string surveyQuery = "select(Movies.title) from((Movies inner join MovieGenres on Movies.movieId = MovieGenres.movieId) inner join Genres on MovieGenres.genreId = Genres.genreId) where Genres.genreName =" + "'" + genreName + "'" + " order by rand(Movies.movieId);" ;
            Console.WriteLine(surveyQuery);
            SqlConnection connection;
            List<string> movieTitles = new List<string>();

            SqlDataReader reader;
            SqlCommand command;
            int count = 0;

            using (connection = new SqlConnection(connectionString))
            {
                connection.Open();
                command = new SqlCommand(surveyQuery, connection);
                using (reader = command.ExecuteReader())
                {
                    while (reader.Read() && count < 15)
                    {

                        //MessageBox.Show(reader.GetString(0));
                        movieTitles.Add(reader.GetString(0));
                        count++;
       
                    }
                }
                connection.Close();
            }
            return movieTitles;
        }

        List<moviesForList> DirectorQuery(List<moviesForList> results, bool hasResults)
        {

            string queryString = "SELECT MovieDirectors.movieID FROM (MovieDirectors inner join Directors on MovieDirectors.directorId = Directors.directorId) Where Directors.directorName = "+"'" + input.Director + "'";
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
            string queryString = "SELECT MovieActors.movieID FROM(MovieActors inner join Actors on MovieActors.ActorId = Actors.actorId) Where Actors.actorName = " + "'" + input.Actor + "'";

            SqlConnection connection;
            List<string> tempResults = new List<string> ();

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
                            tempResults.Add( reader.GetString(0));
                        }
                    }
                }
                hasResults = true;
                connection.Close();
            }
            
            List<moviesForList> newResults = new List<moviesForList>();
            //foreach (moviesForList movie in results)
            //{
            //    foreach (string result in tempResults)
            //    {


            //        if (((int)movie.getMovieID()) == result)
            //        {
            //            newResults.Add(movie);
            //        }
            //    }
            //}

            return newResults;
        }

        List<moviesForList> GenreQuery(List<moviesForList> results, bool hasResults)
        {
            string queryString = "SELECT MovieGenres.movieID FROM (MovieGenres inner join Genres on MovieGenres.genreId = Genres.genreId) Where Genres.genreName = " + "'" + input.Genre + "'";
            //string genres = "";

            SqlConnection connection;
            List<int> tempResults = new List<int>();

            SqlDataReader reader;
            SqlCommand command;
            using (connection = new SqlConnection(connectionString))
            {
                connection.Open();
                //if (input.Genre.Count() == 1)
                //{
                //    queryString += " = '" + input.Genre[0] + "'";
                //}
                //else
                //{
                //    queryString += " IN (";
                //    for (int i = 0; i < input.Genre.Count(); i++)
                //    {
                //        queryString += "'" + input.Genre[i] + "'";
                //        if (i < input.Genre.Count() - 1)
                //            queryString += ", ";
                //    }
                //    queryString += ")";
                //}
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
            string selectPt2 = "WHERE ";
            string tempQueryString;
            SqlConnection connection;
            List<int> tempResults = new List<int>();

            SqlDataReader reader;
            SqlCommand command;
            using (connection = new SqlConnection(connectionString))
            {
                connection.Open();
                tempQueryString = selectPt1 + "M" + " year " + selectPt2 + "'" + input.Year + "'";
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

    //     int GetActorId()
    //     {
    //         int actorId = -1;
    //         string tempQueryString = "SELECT actorId FROM Actors WHERE actorName = " + "'" + input.Actor + "'";
    //         SqlConnection connection;
    //        SqlDataReader reader;
    //         SqlCommand command;
    //         using (connection = new SqlConnection(connectionString))
    //         {
    //             connection.Open();
    //             command = new SqlCommand((tempQueryString), connection);
    //             using (reader = command.ExecuteReader())
    //             {
    //                 while (reader.Read())
    //                 {
    //                     actorId = reader.GetInt32(0);
    //                 }
    // 
    //             }
    //            connection.Close();
    //         }
    //        return actorId;
    //    }

    //    string GetGenreIds()
    //  {
    //
    //        int count = input.Genre.Count();
    //        int tempResults = 0;
    //        string genreIds = "";
    //        for (int i = input.Genre.Count() - 1; i >= 0; i--)
    //        {
    //            string tempQueryString = "SELECT genreId FROM Genres WHERE genreName = ";
    //            SqlConnection connection;
    //            SqlDataReader reader;
    //            SqlCommand command;
    //            using (connection = new SqlConnection(connectionString))
    //            {
    //                connection.Open();
    //                command = new SqlCommand((tempQueryString + "'" + input.Genre[i] + "'"), connection);
    //                using (reader = command.ExecuteReader())
    //                {
    //                    while (reader.Read())
    //                    {
    //                        tempResults = reader.GetInt32(0);
    //                    }
    //            }
    //                connection.Close();
    //            }
    //            genreIds += tempResults.ToString();
    //            if (i >= 1)
    //            {
    //                genreIds += ", ";
    //            }
    //        }
    //        return genreIds;
    //    }
    //}
    //class to hold the movie id's and score to send to the front end
    //public class moviesForList
    //{
    //    private float movieId;
    //    private float movieScore;

    //    public moviesForList(float movieId, float movieScore)
    //    {
    //        this.movieId = movieId;
    //        this.movieScore = movieScore;
    //    }

    //    public float getMovieID()
    //    {
    //        return this.movieId;
    //    }

    //    public float getMovieScore()
    //    {
    //        return this.movieScore;
    //    }

    //}
}
