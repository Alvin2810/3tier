using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _3tier.Models.Movie;
using LOGIC.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _3tier.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private IMovie_Service _movie_Service;
        public MovieController(IMovie_Service movie_Service)
        {
            _movie_Service = movie_Service;
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> AddMovie(Movie_Pass_Object movie)
        {
            var result = await _movie_Service.AddSingleMovie(movie.title, movie.year); 
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
        public async Task<IActionResult> GetAllMovies()
        {
            var result = await _movie_Service.GetAllMovies();
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
        public async Task<IActionResult> UpdateMovie(MovieUpdate_Pass_Object movie)
        {
            var result = await _movie_Service.UpdateMovie(movie.id, movie.title, movie.year);
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
