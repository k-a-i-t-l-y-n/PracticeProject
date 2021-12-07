using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace PracticeProject
{
    public class Backend
    {
        public MovieList GetMovieList(UserInput input)
        {
            Query query = new Query(input);
            AI ai = new AI();
            List<moviesForList> resultList = ai.runAI();

            resultList = query.SearchQuery(resultList);
            MovieList movies = new MovieList(resultList);
            return movies;

        }

    }
}
