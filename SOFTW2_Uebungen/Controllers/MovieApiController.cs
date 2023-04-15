using Microsoft.AspNetCore.Mvc;
using SOFTW2_Uebungen.Models;

namespace SOFTW2_Uebungen.Controllers;

[ApiController]
[Route("[controller]")]
public class MovieApiController : ControllerBase
{
    private readonly MovieController _movieController;
    private readonly ILogger<MovieApiController> _logger;

    public MovieApiController(ILogger<MovieApiController> logger, MovieController movieController)
    {
        this._logger = logger;
        this._movieController = movieController;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Movie>> GetAllMovies() //task 1
    {
        _logger.LogTrace("Showing all Movies");
        return Ok(_movieController.GetMovies());
    }

    [HttpPost]
    public IActionResult AddMovie(Movie movie) // task 2
    {
        movie = _movieController.AddMovie(movie);
        return CreatedAtAction("addMovie", new
        {
            id = movie.Id,
        }, movie);
    }
    //todo exception
    [HttpGet("{id:int}")]
    public IActionResult GetMovieById(int id) // task 3
    {
        try
        {
            Movie movie = _movieController.GetMovieById(id);
            return Ok(movie);
        }
        catch (Exception exception)
        {
            return NotFound($"There is no Movie with the ID: {id}");
        }
        ;
    }
    //todo exception
    [HttpGet("name/{name}")]
    public IActionResult GetMovieByName(string name) // task 4
    {
        try
        {
            return Ok(_movieController.GetMovieByName(name.ToLower()));
        }
        catch (Exception exception)
        {
            return NotFound($"There is no Movie with the Name: {name}");
        }
    }

    [HttpDelete("id{id:int}")]
    public IActionResult DeleteMovieWithId(int id)
    {
        bool deleteResult = _movieController.DeleteMovie(id);
        if (deleteResult == true)
        {
            return NoContent();
        }
        else
        {
            return NotFound($"There is no Movie with the ID: {id}");
        }
    }
}