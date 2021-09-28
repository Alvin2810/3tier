using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _3tier.Models.Actor;
using LOGIC.Services.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _3tier.Controllers
{
    [EnableCors("angular")]
    [Route("api/[controller]")]
    [ApiController]
    public class ActorController : ControllerBase
    {
        private IActor_Service _Actor_Service;

        public ActorController(IActor_Service Actor_Service)
        {
            _Actor_Service = Actor_Service;
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> AddActor(string fname, string lname,string gender)
        {
            var result = await _Actor_Service.AddActor(fname, lname, gender);
            switch (result.success)
            {
                case true:
                    return Ok(result);

                case false:
                    return StatusCode(500, result);
            }
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAllActors()
        {
            var result = await _Actor_Service.GetAllActors();
            switch (result.success)
            {
                case true:
                    return Ok(result);

                case false:
                    return StatusCode(500, result);
            }
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> UpdateActor(Actor_Pass_Object actor)
        {
            var result = await _Actor_Service.UpdateActor(actor.id, actor.fname, actor.lname, actor.gender);
            switch (result.success)
            {
                case true:
                    return Ok(result);

                case false:
                    return StatusCode(500, result);
            }
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> DeleteActor(Actor_Pass_Object actor)
        {
            var result = await _Actor_Service.DeleteActor(actor.id);
            switch (result.success)
            {
                case true:
                    return Ok(result);

                case false:
                    return StatusCode(500, result);
            }
        }

    }
}
