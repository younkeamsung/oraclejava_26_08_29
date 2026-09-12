using BlazorApp1.Models;

namespace BlazorApp1.Clients;

public class MoviesClient(HttpClient httpClient)
{

    public async Task<MovieSummary[]> GetMoviesAsync() 
        => await httpClient.GetFromJsonAsync<MovieSummary[]>("movies") ?? [];

    public async Task AddMovieAsync(MovieDetails movie)
        => await httpClient.PostAsJsonAsync("movies", movie);

    public async Task<MovieDetails> GetMovieAsync(int id)
        => await httpClient.GetFromJsonAsync<MovieDetails>($"movies/{id}")
                ?? throw new Exception("영화를 찾을 수 없습니다!");

    public async Task UpdateMovieAsync(MovieDetails updatedMovie)
        => await httpClient.PutAsJsonAsync($"/movies/{updatedMovie.Id}", 
                updatedMovie);

    public async Task DeleteMovieAsync(int id)
        => await httpClient.DeleteAsync($"/movies/{id}");

}
