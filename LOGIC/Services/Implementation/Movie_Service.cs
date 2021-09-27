using DAL.Functions.Crud;
using DAL.Functions.Interfaces;
using DAL.Entities;
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
        //Reference to our crud functions
        private ICRUD _crud = new Crud();

        
        public async Task<Generic_ResultSet<Movie_ResultSet>> AddSingleMovie(string title, int year)
        {
            Generic_ResultSet<Movie_ResultSet> result = new Generic_ResultSet<Movie_ResultSet>();
            try
            {
                
                Movie Movie = new Movie
                {
                    Movie_Title = title,
                    Movie_Year = year
                };

                Movie = await _crud.Create<Movie>(Movie);

                Movie_ResultSet movieAdded = new Movie_ResultSet
                {
                    id = Movie.Movie_ID,
                    title = Movie.Movie_Title,
                    year = Movie.Movie_Year
                };

                result.userMessage = string.Format("The supplied Movie {0} was added successfully", title);
                result.internalMessage = "LOGIC.Services.Implementation.Movie_Service: AddSingleMovie() method executed successfully.";
                result.result_set = movieAdded;
                result.success = true;
            }
            catch (Exception exception)
            {
                
                result.exception = exception;
                result.userMessage = "We failed to register your information for the Movie supplied. Please try again.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Movie_Service: AddSingleMovie(): {0}", exception.Message); ;
                
            }
            return result;
        }

        public async Task<Generic_ResultSet<List<Movie_ResultSet>>> GetAllMovies()
        {
            Generic_ResultSet<List<Movie_ResultSet>> result = new Generic_ResultSet<List<Movie_ResultSet>>();
            try
            {

                List<Movie> Movies = await _crud.ReadAll<Movie>();

                result.result_set = new List<Movie_ResultSet>();
                Movies.ForEach(dg => {
                    result.result_set.Add(new Movie_ResultSet
                    {
                        id = dg.Movie_ID,
                        title = dg.Movie_Title,
                        year = dg.Movie_Year
                    });
                });

                result.userMessage = string.Format("All Movies obtained successfully");
                result.internalMessage = "LOGIC.Services.Implementation.Movie_Service: GetAllMovies() method executed successfully.";
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed fetch all the required Movies from the database.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Movie_Service: GetAllMovies(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
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


                Movie = await _crud.Update<Movie>(Movie, id);

                Movie_ResultSet movieUpdated = new Movie_ResultSet
                {
                    id = Movie.Movie_ID,
                    title = Movie.Movie_Title,
                    year = Movie.Movie_Year
                };

                result.userMessage = string.Format("The supplied Movie {0} was updated successfully", title);
                result.internalMessage = "LOGIC.Services.Implementation.Movie_Service: UpdateMovie() method executed successfully.";
                result.result_set = movieUpdated;
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed to update your information for the Movie supplied. Please try again.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.UpdateMovie: AddSingleMovie(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }
    }
}
