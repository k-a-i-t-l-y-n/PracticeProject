using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ML;
using Microsoft.ML.Trainers;
using System.IO;
using Microsoft.ML.Data;

namespace PracticeProject
{
    class AI
    {
        public static List<moviesForList> runAI()
        {
            MLContext mlContext = new MLContext();

            (IDataView trainingData, IDataView testData) = getData(mlContext);

            ITransformer trainedModel = buildAndTrainModel(mlContext, trainingData);

            var list = createRecomendationList(mlContext, trainedModel);

            return orderList(list);
        }

        //Function to load the data from the csv file and split it into training and testing data
        public static (IDataView traingData, IDataView testData) getData(MLContext mLContext)
        {
            //get the path of the csv file 
            var dataPath = Path.Combine(Environment.CurrentDirectory, "Data", "ratings_small.csv");

            //load the csv file 
            IDataView dataView = mLContext.Data.LoadFromTextFile<movieRatings>(dataPath, hasHeader: true, separatorChar: ',');

            //split the data into test and train data sets  TODO find a good seed value for the function 
            DataOperationsCatalog.TrainTestData dataSplit = mLContext.Data.TrainTestSplit(dataView,testFraction: .2);

            //create the training data
            IDataView trainData = dataSplit.TrainSet;
            //create the test data
            IDataView testData = dataSplit.TestSet;

            return (trainData, testData);
        }

        //function to train the model
        public static ITransformer buildAndTrainModel(MLContext mlContext, IDataView trainingData)
        {
            //create the matrix factorization trainer
            IEstimator<ITransformer> estimator = mlContext.Transforms.Conversion.MapValueToKey(outputColumnName: "userIdEncoded", inputColumnName: "userId")
    .Append(mlContext.Transforms.Conversion.MapValueToKey(outputColumnName: "movieIdEncoded", inputColumnName: "movieId"));
            var options = new MatrixFactorizationTrainer.Options
            {
                MatrixColumnIndexColumnName = "userIdEncoded",
                MatrixRowIndexColumnName = "movieIdEncoded",
                LabelColumnName = "Label",
                NumberOfIterations = 20,
                ApproximationRank = 100
            };

            var trainerEstimator = estimator.Append(mlContext.Recommendation().Trainers.MatrixFactorization(options));

            //create the trained model
            ITransformer trainedModel = trainerEstimator.Fit(trainingData);

            return trainedModel;
        }

        //fuction to create the lst of recommended movies 
        public static List<moviesForList> createRecomendationList(MLContext mLContext, ITransformer trainedModel)
        {
            //create the prediction engine to make the predictions
            var predictionEngine = mLContext.Model.CreatePredictionEngine<movieRatings, RatingPrediction>(trainedModel);

            //create the list to hold the movie object sto pass to the back-end 
            List<moviesForList> movieList = new List<moviesForList>();

            //loop throught the movies and put the movies with a score above 3.0 in to the movie list
            for(int i = 0; i < 5000; i++)
            {
                //for the large file use user id 270897
                //for the smaller file use user id 672
                movieRatings testInput = new movieRatings { userId = 672, movieId = i };
                
                
                RatingPrediction ratingPrediction = predictionEngine.Predict(testInput);
               
                //if the movie score is above 3.0 add it to the movie list
                if (Math.Round(ratingPrediction.Score, 1) > 3.0)
                {
                    //save the movieId and movieScore to the moviesForList object
                    moviesForList newMovie = new moviesForList(testInput.movieId, ratingPrediction.Score);
                    //add the object to the list to send to the order list function 
                    movieList.Add(newMovie);
                }
            }

            //send the list to be put into descending order
            return movieList;

        }

        //functionm to put the list in descending order and return the list
        public static List<moviesForList> orderList(List<moviesForList> movieList)
        {
            //sort the list into descending order
            movieList.Sort((x, y) => x.getMovieScore().CompareTo(y.getMovieScore()));
            movieList.Reverse();

            //pass the list to be return 
            return movieList;
        }


        

    }
    //class to loasd the data from the csv file that will be used for training and testing
    class movieRatings
    {
        [LoadColumn(0)]
        public float userId;
        [LoadColumn(1)]
        public float movieId;
        [LoadColumn(2)]
        public float Label;

    } 

    //class to hold the score of the predfiction  
    class RatingPrediction
    {
        public float Label;
        public float Score;
    }

    //class to hold the movie id's and score to send to the front end
    class moviesForList
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
