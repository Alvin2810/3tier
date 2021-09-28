using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LOGIC.Services.Models;
using LOGIC.Services.Models.Genre;

namespace LOGIC.Services.Interfaces
{
    public interface IGenre_Service
    {
        /* fetch methods */
        Task<Generic_ResultSet<List<Genre_ResultSet>>> GetAllGenres();
        Task<Generic_ResultSet<Genre_ResultSet>> GetGenreById(Int64 id);


        /* Create/Edit/Delete methods */
        Task<Generic_ResultSet<Genre_ResultSet>> AddGenre(string name);
        Task<Generic_ResultSet<Genre_ResultSet>> UpdateGenre(Int64 id, string name);
        Task<Generic_ResultSet<bool>> DeleteGenre(Int64 id);

    }
}
