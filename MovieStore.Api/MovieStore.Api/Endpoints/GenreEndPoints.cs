using Microsoft.EntityFrameworkCore;
using MovieStore.Api.Data;

namespace MovieStore.Api.Endpoints;

public static class GenreEndPoints
{
    public static void MapGenreEndPoints(this WebApplication app)
    {
        var group = app.MapGroup("/genres");

        group.MapGet("/", async (MovieStoreContext dbContext) =>
        
            await dbContext.Genres
            .AsNoTracking()
            .ToListAsync()
        );

    }
}
