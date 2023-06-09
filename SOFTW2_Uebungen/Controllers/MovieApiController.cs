﻿using Microsoft.AspNetCore.Mvc;
using SOFTW2_Uebungen.Dto;
using SOFTW2_Uebungen.Models;
using SOFTW2_Uebungen.Models.Excxeption;

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
    public IActionResult
        AddMovie([FromBody] String name) // task 2 ask -> get rid of dto since incoming data ist just single string
        //todo take single string
        // ask -> [FromBody] oder DTO
    {
        Movie movie = _movieController.AddMovie(name);
        return CreatedAtAction("addMovie", new
        {
            id = movie.Id,
        }, movie.Id);
    }


    [HttpGet("id/{id:int}")]
    public IActionResult GetMovieById(int id) // task 3
    {
        try
        {
            Movie movie = _movieController.GetMovieById(id);
            return Ok(movie);
        }
        catch (MovieNotFoundException movieNotFoundException)
        {
            _logger.LogWarning(movieNotFoundException.Message);
            return NotFound($"There is no Movie with the ID: {id}");
        }
    }


    [HttpGet("name/{name}")] // ask -> doesnt need typehint @DeleteMovieWithId
    public IActionResult GetMovieByName(string name) // task 4
    {
        try
        {
            return Ok(_movieController.GetMovieByName(name.ToLower()));
        }
        catch (MovieNotFoundException movieNotFoundException)
        {
            _logger.LogWarning(movieNotFoundException.Message); // ask -> why compile time constant?
            return NotFound($"There is no Movie with the Name: {name}");
        }
    }

    [HttpDelete("id/{id:int}")] //ask -> needs type hint
    public IActionResult DeleteMovieWithId(int id)
    {
        _logger.LogTrace("Deleting: {Id}", id);
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