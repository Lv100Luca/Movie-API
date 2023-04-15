using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using SOFTW2_Uebungen.Models;

namespace SOFTW2_Uebungen.Controllers;
[ApiController]
[Route("[controller]/[action]")]
public class MoviesApi : ControllerBase
{
    private List<Movie> _movies = new List<Movie>();

    [HttpGet]
    public IEnumerable<Movie> GetMovies()
    {
        // return Enumerable.;
        return;
    }

    [HttpPost]
    public IActionResult AddMovie(Movie movie)
    {
        this._movies.Add(movie);
        return Ok();
    }
}