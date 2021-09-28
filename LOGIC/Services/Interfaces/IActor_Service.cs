using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LOGIC.Services.Models;
using LOGIC.Services.Models.Actor;

namespace LOGIC.Services.Interfaces
{
    public interface IActor_Service
    {
        /* fetch methods */
        Task<Generic_ResultSet<List<Actor_ResultSet>>> GetAllActors();
        Task<Generic_ResultSet<Actor_ResultSet>> GetActorById(Int64 id);


        /* Create/Edit/Delete methods */
        Task<Generic_ResultSet<Actor_ResultSet>> AddActor(string fname, string lname, string gender);
        Task<Generic_ResultSet<Actor_ResultSet>> UpdateActor(Int64 id, string fname, string lname, string gender);
        Task<Generic_ResultSet<bool>> DeleteActor(Int64 id);

    }
}
