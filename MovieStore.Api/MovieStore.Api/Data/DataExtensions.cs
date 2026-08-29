using MovieStore.Api.Models;

namespace MovieStore.Api.Data;

public static class DataExtensions
{
    public static void AddMovieStoreDb(this WebApplicationBuilder builder)
    {
        var connString = builder.Configuration.GetConnectionString("DefaultConnection");
        builder.Services.AddSqlServer<MovieStoreContext>(
            connString,
            optionsAction: options => options.UseSeeding((context, _) =>
            {
                if (!context.Set<Genre>().Any())
                {
                    context.Set<Genre>().AddRange(
                        new Genre { Name = "액션/어드벤처" },
                        new Genre { Name = "SF" },
                        new Genre { Name = "Drama" },
                        new Genre { Name = "Family" },
                        new Genre { Name = "Sports" },
                        new Genre { Name = "코메디" }
                        );
                    context.SaveChanges();
                }
            })
            );

    }
}
