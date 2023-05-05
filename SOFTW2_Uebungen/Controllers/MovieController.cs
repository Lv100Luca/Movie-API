using SOFTW2_Uebungen.Models;
using SOFTW2_Uebungen.Models.Excxeption;

namespace SOFTW2_Uebungen.Controllers;

public class MovieController
{
    private readonly List<Movie> _movies = new List<Movie>();
    private readonly ILogger<MovieController> _logger;
    public MovieController(ILogger<MovieController> logger)
    {
        this._logger = logger;
        _movies.Add(new Movie(1, "Rambo"));
        _movies.Add(new Movie(2, "Alien"));
        _movies.Add(new Movie(3, "TesT"));
        _movies.Add(new Movie(4, "TEST"));
        _movies.Add(new Movie(5, "Test"));
    }

    public IEnumerable<Movie> GetMovies()
    {
        return this._movies;
    }

    public Movie GetMovieById(int id)
    {
        if (this.Has(id))
        {
            return _movies.Single(movie => movie.Id == id);
        }
        else
        {
            _logger.LogWarning("Movie with id {Id} doesnt exist", id);
            throw new MovieNotFoundException($"Movie with id {id} doesnt exist");
        }
    }

    public Movie[] GetMovieByName(string name) // ask -> single movie with matching name or multiple 
    {
        if (this.Has(name))
        {
            return _movies.Where(movie => movie.Name.ToLower() == name).ToArray();
        }
        else
        {
            _logger.LogWarning("Movie with name {Name} doesnt exist", name);
            throw new MovieNotFoundException($"Movie with name {name} doesnt exist");
        }
    }

    public Movie AddMovie(string name) // ask must adding movies provide an ID
    {
        Movie movie = new Movie(name)
        {
            Id = _movies.MaxBy(e => e.Id).Id + 1 // fixme 
        }; // todo implement better structure
        this._movies.Add(movie);
        return movie;
    }


    public bool DeleteMovie(int id)
    {
        if (this.Has(id))
        {
            this._movies.RemoveAll(movie => movie.Id == id);
            return true;
        }
        else
        {
            return false;
        }
    }

    private bool Has(string name)
    {
        Console.Out.WriteLine(name + "/");
        return _movies.Any(movie => String.Equals(movie.Name, name, StringComparison.CurrentCultureIgnoreCase));
    }
    private bool Has(int id)
    {
        return _movies.Any(movie => movie.Id == id);
    }
}