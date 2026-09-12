using BlazorApp1.Models;

namespace BlazorApp1.Clients;

public class GenreClient(HttpClient httpClient)
{
    public async Task<Genre[]> GetGenresAsync()
        => await httpClient.GetFromJsonAsync<Genre[]>("genres") ?? [];
}
