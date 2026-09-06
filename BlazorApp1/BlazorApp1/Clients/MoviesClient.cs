using BlazorApp1.Models;

namespace BlazorApp1.Clients;

public class MoviesClient
{
    private readonly List<MovieSummary> movies =
        [
            new MovieSummary{
            Id = 1, Name = "달마야 놀자", Genre="코메디", Price=2000,
            ReleaseYear=2001
            },
            new MovieSummary{
            Id = 2, Name = "너의 이름은", Genre="드라마", Price=1000,
            ReleaseYear=2023
            },
            new MovieSummary{
            Id = 3, Name = "날씨의 아이", Genre="드라마", Price=2000,
            ReleaseYear=2024
            },
        ];

    private readonly Genre[] genres = new GenreClient().GetGenres();

    public MovieSummary[] GetMovies() => [.. movies]; //To Array와 같음
    
    public void AddMovie(MovieDetails movie)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(movie.GenreId);   // 장르의 아이디가 null거나 공백이면 이셉션걸림
        var genre = genres.Single(genre => 
            genre.Id == int.Parse(movie.GenreId));
        var movieSummary = new MovieSummary
        {
            Id = movies.Count + 1,
            Name = movie.Name,
            Genre = genre.Name,
            Price = movie.Price,
            ReleaseYear = movie.ReleaseYear
        };
        movies.Add(movieSummary);
    }
}
