using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _3tier.Models.Genre;
using LOGIC.Services.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _3tier.Controllers
{
    [EnableCors("angular")]
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private IGenre_Service _Genre_Service;

        public GenreController(IGenre_Service Genre_Service)
        {
            _Genre_Service = Genre_Service;
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> AddGenre(string name)
        {
            var result = await _Genre_Service.AddGenre(name);
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
        public async Task<IActionResult> GetAllGenres()
        {
            var result = await _Genre_Service.GetAllGenres();
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
        public async Task<IActionResult> UpdateGenre(Genre_Pass_Object genre)
        {
            var result = await _Genre_Service.UpdateGenre(genre.id, genre.name);
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
        public async Task<IActionResult> DeleteGenre(Genre_Pass_Object genre)
        {
            var result = await _Genre_Service.DeleteGenre(genre.id);
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
