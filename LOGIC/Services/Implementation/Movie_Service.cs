using DAL.Entities;
using DAL.Functions.Interfaces;
using DAL.Functions.Specific;
using LOGIC.Services.Interfaces;
using LOGIC.Services.Models;
using LOGIC.Services.Models.Movie;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LOGIC.Services.Implementation
{

    public class Movie_Service : IMovie_Service
    {
        
        private IMovie_Operations _movie_operations = new Movie_Operations();

        public async Task<Generic_ResultSet<List<Movie_ResultSet>>> GetAllMovies()
        {
            Generic_ResultSet<List<Movie_ResultSet>> result = new Generic_ResultSet<List<Movie_ResultSet>>();
            try
            {

                List<Movie> Movies = await _movie_operations.ReadAll();
  
                result.result_set = new List<Movie_ResultSet>();
                Movies.ForEach(m =>
                {
                    result.result_set.Add(new Movie_ResultSet
                    {
                        id = m.Movie_ID,
                        title = m.Movie_Title,
                        year = m.Movie_Year
                    });
                });


                result.userMessage = string.Format("All Movies obtained successfully");
                result.internalMessage = "LOGIC.Services.Implementation.Movie_Service: GetAllMovies() method executed successfully.";
                result.success = true;
            }
            catch (Exception exception)
            {

                result.exception = exception;
                result.userMessage = "We failed fetch all the required Movies from the database.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Movie_Service: GetAllMovies(): {0}", exception.Message); ;
                
            }
            return result;
        }


        public async Task<Generic_ResultSet<Movie_ResultSet>> GetMovieById(long id)
        {
            Generic_ResultSet<Movie_ResultSet> result = new Generic_ResultSet<Movie_ResultSet>();
            try
            {
                var Movie = await _movie_operations.Read(id);


                result.result_set = new Movie_ResultSet
                {
                    title = Movie.Movie_Title,
                    year = Movie.Movie_Year,
                    id = Movie.Movie_ID
                };


                result.userMessage = string.Format("Get ByID - Movie  obtained successfully");
                result.internalMessage = "LOGIC.Services.Implementation.Movie_Service: Get ByID() method executed successfully.";
                result.success = true;
            }
            catch (Exception exception)
            {

                result.exception = exception;
                result.userMessage = "We failed fetch Get ByID the required Movie  from the database.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Movie_Service: Get ByID(): {0}", exception.Message); ;

            }
            return result;
        }



        public async Task<Generic_ResultSet<Movie_ResultSet>> AddMovie(string title, int year)
        {
            Generic_ResultSet<Movie_ResultSet> result = new Generic_ResultSet<Movie_ResultSet>();
            try
            {

                Movie Movie = new Movie
                {
                    Movie_Title = title,
                    Movie_Year = year
                };


                Movie = await _movie_operations.Create(Movie);

                Movie_ResultSet movieAdded = new Movie_ResultSet
                {
                    title = Movie.Movie_Title,
                    id = Movie.Movie_ID,
                    year = Movie.Movie_Year
                };


                result.userMessage = string.Format("The supplied Movie movie {0} was added successfully", title);
                result.internalMessage = "LOGIC.Services.Implementation.Movie_Service: AddMovie() method executed successfully.";
                result.result_set = movieAdded;
                result.success = true;
            }
            catch (Exception exception)
            {

                result.exception = exception;
                result.userMessage = "We failed to register your information for the Movie supplied. Please try again.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Movie_Service: AddMovie(): {0}", exception.Message); ;

            }
            return result;
        }


        public async Task<Generic_ResultSet<Movie_ResultSet>> UpdateMovie(Int64 id, string title, int year)
        {
            Generic_ResultSet<Movie_ResultSet> result = new Generic_ResultSet<Movie_ResultSet>();
            try
            {

                Movie Movie = new Movie
                {
                    Movie_ID = id,
                    Movie_Title = title,
                    Movie_Year = year

                };


                Movie = await _movie_operations.Update(Movie, id);


                Movie_ResultSet movieUpdated = new Movie_ResultSet
                {
                    title = Movie.Movie_Title,
                    id = Movie.Movie_ID,
                    year = Movie.Movie_Year
                };


                result.userMessage = string.Format("The supplied Movie movie {0} was updated successfully", title);
                result.internalMessage = "LOGIC.Services.Implementation.Movie_Service: UpdateMovie() method executed successfully.";
                result.result_set = movieUpdated;
                result.success = true;
            }
            catch (Exception exception)
            {

                result.exception = exception;
                result.userMessage = "We failed to update your information for the Movie movie supplied. Please try again.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Movie_Service: UpdateMovie(): {0}", exception.Message); ;

            }
            return result;
        }


        public async Task<Generic_ResultSet<bool>> DeleteMovie(long id)
        {
            Generic_ResultSet<bool> result = new Generic_ResultSet<bool>();
            try
            {

                var movieDeleted = await _movie_operations.Delete(id);

                result.userMessage = string.Format("The supplied Movie movie {0} was deleted successfully", id);
                result.internalMessage = "LOGIC.Services.Implementation.Movie_Service: DeleteMovie() method executed successfully.";
                result.result_set = movieDeleted;
                result.success = true;
            }
            catch (Exception exception)
            {

                result.exception = exception;
                result.userMessage = "We failed to Delete your information for the Movie movie supplied. Please try again.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Movie_Service: DeleteMovie(): {0}", exception.Message); ;
               
            }
            return result;
        }

    }
}
