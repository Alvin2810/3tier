using DAL.Entities;
using DAL.Functions.Interfaces;
using DAL.Functions.Specific;
using LOGIC.Services.Interfaces;
using LOGIC.Services.Models;
using LOGIC.Services.Models.Genre;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LOGIC.Services.Implementation
{

    public class Genre_Service : IGenre_Service
    {

        private IGenre_Operations _genre_operations = new Genre_Operations();

        public async Task<Generic_ResultSet<List<Genre_ResultSet>>> GetAllGenres()
        {
            Generic_ResultSet<List<Genre_ResultSet>> result = new Generic_ResultSet<List<Genre_ResultSet>>();
            try
            {

                List<Genre> Genres = await _genre_operations.ReadAll();

                result.result_set = new List<Genre_ResultSet>();
                Genres.ForEach(g =>
                {
                    result.result_set.Add(new Genre_ResultSet
                    {
                        id = g.Genre_ID,
                        name = g.Genre_Name
                    });
                });


                result.userMessage = string.Format("All Genres obtained successfully");
                result.internalMessage = "LOGIC.Services.Implementation.Genre_Service: GetAllGenres() method executed successfully.";
                result.success = true;
            }
            catch (Exception exception)
            {

                result.exception = exception;
                result.userMessage = "We failed fetch all the required Genres from the database.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Genre_Service: GetAllGenres(): {0}", exception.Message); ;

            }
            return result;
        }


        public async Task<Generic_ResultSet<Genre_ResultSet>> GetGenreById(long id)
        {
            Generic_ResultSet<Genre_ResultSet> result = new Generic_ResultSet<Genre_ResultSet>();
            try
            {
                var Genre = await _genre_operations.Read(id);


                result.result_set = new Genre_ResultSet
                {
                    name = Genre.Genre_Name,
                    id = Genre.Genre_ID
                };


                result.userMessage = string.Format("Get ByID - Genre  obtained successfully");
                result.internalMessage = "LOGIC.Services.Implementation.Genre_Service: Get ByID() method executed successfully.";
                result.success = true;
            }
            catch (Exception exception)
            {

                result.exception = exception;
                result.userMessage = "We failed fetch Get ByID the required Genre  from the database.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Genre_Service: Get ByID(): {0}", exception.Message); ;

            }
            return result;
        }



        public async Task<Generic_ResultSet<Genre_ResultSet>> AddGenre(string name)
        {
            Generic_ResultSet<Genre_ResultSet> result = new Generic_ResultSet<Genre_ResultSet>();
            try
            {

                Genre Genre = new Genre
                {
                    Genre_Name = name,
                };


                Genre = await _genre_operations.Create(Genre);

                Genre_ResultSet genreAdded = new Genre_ResultSet
                {
                    name = Genre.Genre_Name,
                    id = Genre.Genre_ID
                };


                result.userMessage = string.Format("The supplied Genre Genre {0} was added successfully", name);
                result.internalMessage = "LOGIC.Services.Implementation.Genre_Service: AddGenre() method executed successfully.";
                result.result_set = genreAdded;
                result.success = true;
            }
            catch (Exception exception)
            {

                result.exception = exception;
                result.userMessage = "We failed to register your information for the Genre supplied. Please try again.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Genre_Service: AddGenre(): {0}", exception.Message); ;

            }
            return result;
        }


        public async Task<Generic_ResultSet<Genre_ResultSet>> UpdateGenre(Int64 id, string name)
        {
            Generic_ResultSet<Genre_ResultSet> result = new Generic_ResultSet<Genre_ResultSet>();
            try
            {

                Genre Genre = new Genre
                {
                    Genre_ID = id,
                    Genre_Name = name,
                };


                Genre = await _genre_operations.Update(Genre, id);


                Genre_ResultSet genreUpdated = new Genre_ResultSet
                {
                    name = Genre.Genre_Name,
                    id = Genre.Genre_ID
                };


                result.userMessage = string.Format("The supplied Genre Genre {0} was updated successfully", name);
                result.internalMessage = "LOGIC.Services.Implementation.Genre_Service: UpdateGenre() method executed successfully.";
                result.result_set = genreUpdated;
                result.success = true;
            }
            catch (Exception exception)
            {

                result.exception = exception;
                result.userMessage = "We failed to update your information for the Genre Genre supplied. Please try again.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Genre_Service: UpdateGenre(): {0}", exception.Message); ;

            }
            return result;
        }


        public async Task<Generic_ResultSet<bool>> DeleteGenre(long id)
        {
            Generic_ResultSet<bool> result = new Generic_ResultSet<bool>();
            try
            {

                var genreDeleted = await _genre_operations.Delete(id);

                result.userMessage = string.Format("The supplied Genre Genre {0} was deleted successfully", id);
                result.internalMessage = "LOGIC.Services.Implementation.Genre_Service: DeleteGenre() method executed successfully.";
                result.result_set = genreDeleted;
                result.success = true;
            }
            catch (Exception exception)
            {

                result.exception = exception;
                result.userMessage = "We failed to Delete your information for the Genre Genre supplied. Please try again.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Genre_Service: DeleteGenre(): {0}", exception.Message); ;

            }
            return result;
        }

    }
}
