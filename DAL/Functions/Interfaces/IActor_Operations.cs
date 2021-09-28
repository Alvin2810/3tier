using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace DAL.Functions.Interfaces
{
    public interface IActor_Operations
    {
        Task<Actor> Create(Actor objectToAdd);
        Task<Actor> Read(Int64 entityId);
        Task<List<Actor>> ReadAll();
        Task<Actor> Update(Actor objectToUpdate, Int64 entityId);
        Task<bool> Delete(Int64 entityId);
    }
}
