namespace SOFTW2_Uebungen.Models;

public class Movie
{
    public int Id { get; set; }
    public string Name { get; set; }
    public Movie(int Id, string Name)
    {
        this.Id = Id;
        this.Name = Name;
    }

}