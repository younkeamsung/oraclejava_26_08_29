using Microsoft.EntityFrameworkCore;
using MovieStore.Api.Models;

namespace MovieStore.Api.Data;

public class MovieStoreContext(DbContextOptions<MovieStoreContext> options)
    : DbContext(options)
{
    public DbSet<Movie> Movies => Set<Movie>();
    public DbSet<Genre> Genres => Set<Genre>();
    //Movie와 Genre에 있는 model들을 상속받아 세팅
}

