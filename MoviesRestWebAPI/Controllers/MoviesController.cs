using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MoviesRestWebAPI.Data;
using MoviesRestWebAPI.Models;
using System.ComponentModel.Design;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MoviesRestWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public MoviesController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: api/<MoviesController>
        [HttpGet]
        public IEnumerable<Movie> Get()
        {
            var allMovies = _context.Movies.ToList();
            return allMovies;
        }

        // GET api/<MoviesController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var movieById = _context.Movies
                    .Where(m => m.Id == id).Single();
                return Ok(movieById);
            }
            catch (InvalidOperationException)
            {
                return NotFound($"No movie with Id = {id}");
            }
        }

        // POST api/<MoviesController>
        [HttpPost]
        public IActionResult Post([FromBody] Movie movie)
        {
            _context.Movies.Add(movie);
            _context.SaveChanges();
            return StatusCode(201, movie);
        }

        // PUT api/<MoviesController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Movie updatedMovie)
        {
            try
            {
                var movieById = _context.Movies
                       .Where(m => m.Id == id).Single();
                //var newTitle = movieById.Title;
                //var newRunningTime = movieById.RunningTime;
                //var newGenre = movieById.Genre;
                movieById.Title = updatedMovie.Title;
                movieById.RunningTime = updatedMovie.RunningTime;
                movieById.Genre = updatedMovie.Genre;
                //movieById = updatedMovie;
                _context.Movies.Update(movieById);
                _context.SaveChanges();
                return Ok(updatedMovie);
            }
            catch (InvalidOperationException)
            {
                return NotFound($"No movie with Id = {id}");
            }
        }

        // DELETE api/<MoviesController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var movieToDelete = _context.Movies
                    .Where(m => m.Id == id).Single();
                
                _context.Movies.Remove(movieToDelete);
                _context.SaveChanges();
                return NoContent();
            }
            catch (InvalidOperationException)
            {
                return NotFound($"No movie with Id = {id}");
            }
        }
    }
}
