using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using MovieStore.Api.Data;
using MovieStore.Api.Dtos;
using MovieStore.Api.Models;

namespace MovieStore.Api.Endpoints;

public static class MovieEndPoints
{
    const string GetMovieEndPointName = "GetMovie";

    private static readonly List<MovieDto> movies = [
    new MovieDto(1, "썬더볼츠", "액션/어드벤처", 5000M, 2025),
    new MovieDto(2, "쥬라기월드", "액션/어드벤처", 1400M, 2025),
    new MovieDto(3, "블랙아담", "액션/어드벤처", 500M, 2022)
    ];
    public static void MapMoviesEndPoints(this WebApplication app)
    {

        var group = app.MapGroup("/movies");

        group.MapGet("/", () => movies);

        group.MapGet("/{id}", (int id) =>
        {
            var movie = movies.Find(movie => movie.Id == id);
            //return movie;
            return movie is null ? Results.NotFound() : Results.Ok(movie);
        }).WithName(GetMovieEndPointName);

        group.MapPost("/", (CreateMovieDto newMovie, 
            MovieStoreContext dbContext) =>
        {
            Movie movie = new Movie
            {
                Name = newMovie.Name,
                GenreId = newMovie.GenreId,
                Price = newMovie.Price,
                ReleaseYear = newMovie.ReleaseYear
            };
            dbContext.Movies.Add(movie);
            dbContext.SaveChanges();

            return Results.CreatedAtRoute(GetMovieEndPointName, new { id = movie.Id }, movie);
        });

        group.MapPut("/{id}", (int id, UpdateMovieDto updatedMovie) =>
        {
            var index = movies.FindIndex(movie => movie.Id == id);
            if (index == -1)
            {
                return Results.NotFound();
            }
            movies[index] = new MovieDto(
                id, updatedMovie.Name, updatedMovie.Genre,
                updatedMovie.Price, updatedMovie.ReleaseYear
                );
            return Results.NoContent();
        });

        group.MapDelete("/{id}", (int id) =>
        {
            movies.RemoveAll(movie => movie.Id == id);
            return Results.NoContent();
        });
    }
}
