using LOGIC.Services.Models;
using LOGIC.Services.Models.Movie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGIC.Services.Interfaces
{
    public interface IMovie_Service
    {
        /* fetch methods */
        Task<Generic_ResultSet<List<Movie_ResultSet>>> GetAllMovies();
        Task<Generic_ResultSet<Movie_ResultSet>> GetMovieById(Int64 id);


        /* Create/Edit/Delete methods */
        Task<Generic_ResultSet<Movie_ResultSet>> AddMovie(string title, int year);
        Task<Generic_ResultSet<Movie_ResultSet>> UpdateMovie(Int64 id, string title, int year);
        Task<Generic_ResultSet<bool>> DeleteMovie(Int64 id);

    }
}