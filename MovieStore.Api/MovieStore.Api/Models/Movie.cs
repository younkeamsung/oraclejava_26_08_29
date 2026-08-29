namespace MovieStore.Api.Models;

public class Movie
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public Genre? Genre { get; set; }
    public int GenreId { get; set; }    // 포린 키
    public decimal Price { get; set; }
    public int ReleaseYear { get; set; }
}
