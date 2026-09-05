using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using MovieStore.Api.Data;
using MovieStore.Api.Dtos;
using MovieStore.Api.Models;

namespace MovieStore.Api.Endpoints;

public static class MovieEndPoints
{
    const string GetMovieEndPointName = "GetMovie";

    public static void MapMoviesEndPoints(this WebApplication app)
    {

        var group = app.MapGroup("/movies");

        group.MapGet("/", async (MovieStoreContext dbContext)
        => await dbContext.Movies
            .Include(movie => movie.Genre)
            .Select(movie => new MovieSummaryDto(
                movie.Id, movie.Name, movie.Genre!.Name,
                movie.Price, 
                movie.ReleaseYear))
            .AsNoTracking()
            .ToArrayAsync());

        group.MapGet("/{id}", async (int id, MovieStoreContext dbContext) =>
        {
            var movie = await dbContext.Movies.FindAsync(id);
            //return movie;

            return movie is null ? Results.NotFound()
                : Results.Ok(new MovieDetailsDto(
                    movie.Id, movie.Name, movie.GenreId,
                    movie.Price, movie.ReleaseYear, "damansa"));
        }).WithName(GetMovieEndPointName);

        group.MapPost("/", async (CreateMovieDto newMovie, 
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
            await dbContext.SaveChangesAsync();

            MovieDetailsDto movieDto = new MovieDetailsDto(
                movie.Id, movie.Name, movie.GenreId, movie.Price, 
                movie.ReleaseYear, "아놔~"); ;
            return Results.CreatedAtRoute(GetMovieEndPointName, new { id = movie.Id }, movieDto);
        });

        group.MapPut("/{id}", async (int id, UpdateMovieDto updatedMovie,
            MovieStoreContext dbContext) =>
        {
            //var index = movies.FindIndex(movie => movie.Id == id);
            var existingMovie = await dbContext.Movies.FindAsync(id);
            if (existingMovie is null)
            {
                return Results.NotFound();
            }
            existingMovie.Name = updatedMovie.Name;
            existingMovie.GenreId = updatedMovie.GenreId;
            existingMovie.Price = updatedMovie.Price;
            existingMovie.ReleaseYear = updatedMovie.ReleaseYear;

            await dbContext.SaveChangesAsync();


            return Results.NoContent();
        });

        group.MapDelete("/{id}", async (int id, MovieStoreContext dbContext) =>
        {
            //movies.RemoveAll(movie => movie.Id == id);
            await dbContext.Movies.Where(movie => movie.Id == id)
                    .ExecuteDeleteAsync();
            return Results.NoContent();
        });
    }
}
