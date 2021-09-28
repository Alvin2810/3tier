using DAL.Entities;
using DAL.Functions.Interfaces;
using DAL.Functions.Specific;
using LOGIC.Services.Interfaces;
using LOGIC.Services.Models;
using LOGIC.Services.Models.Actor;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LOGIC.Services.Implementation
{

    public class Actor_Service : IActor_Service
    {

        private IActor_Operations _actor_operations = new Actor_Operations();

        public async Task<Generic_ResultSet<List<Actor_ResultSet>>> GetAllActors()
        {
            Generic_ResultSet<List<Actor_ResultSet>> result = new Generic_ResultSet<List<Actor_ResultSet>>();
            try
            {

                List<Actor> Actors = await _actor_operations.ReadAll();

                result.result_set = new List<Actor_ResultSet>();
                Actors.ForEach(a =>
                {
                    result.result_set.Add(new Actor_ResultSet
                    {
                        id = a.Actor_ID,
                        fname = a.Actor_fname,
                        lname = a.Actor_lname,
                        gender = a.Actor_gender

                    });
                });


                result.userMessage = string.Format("All Actors obtained successfully");
                result.internalMessage = "LOGIC.Services.Implementation.Actor_Service: GetAllActors() method executed successfully.";
                result.success = true;
            }
            catch (Exception exception)
            {

                result.exception = exception;
                result.userMessage = "We failed fetch all the required Actors from the database.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Actor_Service: GetAllActors(): {0}", exception.Message); ;

            }
            return result;
        }


        public async Task<Generic_ResultSet<Actor_ResultSet>> GetActorById(long id)
        {
            Generic_ResultSet<Actor_ResultSet> result = new Generic_ResultSet<Actor_ResultSet>();
            try
            {
                var Actor = await _actor_operations.Read(id);


                result.result_set = new Actor_ResultSet
                {
                    fname = Actor.Actor_fname,
                    lname = Actor.Actor_lname,
                    gender = Actor.Actor_gender,
                    id = Actor.Actor_ID
                };


                result.userMessage = string.Format("Get ByID - Actor  obtained successfully");
                result.internalMessage = "LOGIC.Services.Implementation.Actor_Service: Get ByID() method executed successfully.";
                result.success = true;
            }
            catch (Exception exception)
            {

                result.exception = exception;
                result.userMessage = "We failed fetch Get ByID the required Actor  from the database.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Actor_Service: Get ByID(): {0}", exception.Message); ;

            }
            return result;
        }



        public async Task<Generic_ResultSet<Actor_ResultSet>> AddActor(string fname, string lname, string gender)
        {
            Generic_ResultSet<Actor_ResultSet> result = new Generic_ResultSet<Actor_ResultSet>();
            try
            {

                Actor Actor = new Actor
                {
                    Actor_fname = fname,
                    Actor_lname = lname,
                    Actor_gender = gender
                };


                Actor = await _actor_operations.Create(Actor);

                Actor_ResultSet actorAdded = new Actor_ResultSet
                {
                    fname = Actor.Actor_fname,
                    lname = Actor.Actor_lname,
                    gender = Actor.Actor_gender,
                    id = Actor.Actor_ID
                };


                result.userMessage = string.Format("The supplied Actor Actor {0} was added successfully", fname);
                result.internalMessage = "LOGIC.Services.Implementation.Actor_Service: AddActor() method executed successfully.";
                result.result_set = actorAdded;
                result.success = true;
            }
            catch (Exception exception)
            {

                result.exception = exception;
                result.userMessage = "We failed to register your information for the Actor supplied. Please try again.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Actor_Service: AddActor(): {0}", exception.Message); ;

            }
            return result;
        }


        public async Task<Generic_ResultSet<Actor_ResultSet>> UpdateActor(Int64 id, string fname, string lname, string gender)
        {
            Generic_ResultSet<Actor_ResultSet> result = new Generic_ResultSet<Actor_ResultSet>();
            try
            {

                Actor Actor = new Actor
                {
                    Actor_ID = id,
                    Actor_fname = fname,
                    Actor_lname= lname,
                    Actor_gender = gender
                };


                Actor = await _actor_operations.Update(Actor, id);


                Actor_ResultSet actorUpdated = new Actor_ResultSet
                {
                    fname = Actor.Actor_fname,
                    lname = Actor.Actor_lname,
                    gender = Actor.Actor_gender,
                    id = Actor.Actor_ID
                };


                result.userMessage = string.Format("The supplied Actor Actor {0} was updated successfully", fname);
                result.internalMessage = "LOGIC.Services.Implementation.Actor_Service: UpdateActor() method executed successfully.";
                result.result_set = actorUpdated;
                result.success = true;
            }
            catch (Exception exception)
            {

                result.exception = exception;
                result.userMessage = "We failed to update your information for the Actor Actor supplied. Please try again.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Actor_Service: UpdateActor(): {0}", exception.Message); ;

            }
            return result;
        }


        public async Task<Generic_ResultSet<bool>> DeleteActor(long id)
        {
            Generic_ResultSet<bool> result = new Generic_ResultSet<bool>();
            try
            {

                var actorDeleted = await _actor_operations.Delete(id);

                result.userMessage = string.Format("The supplied Actor Actor {0} was deleted successfully", id);
                result.internalMessage = "LOGIC.Services.Implementation.Actor_Service: DeleteActor() method executed successfully.";
                result.result_set = actorDeleted;
                result.success = true;
            }
            catch (Exception exception)
            {

                result.exception = exception;
                result.userMessage = "We failed to Delete your information for the Actor Actor supplied. Please try again.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Actor_Service: DeleteActor(): {0}", exception.Message); ;

            }
            return result;
        }

    }
}
