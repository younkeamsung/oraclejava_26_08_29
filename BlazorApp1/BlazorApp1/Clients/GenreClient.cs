using BlazorApp1.Models;

namespace BlazorApp1.Clients;

public class GenreClient
{
    private readonly Genre[] genres =
        [
            new(){
                Id = 1,
                Name = "액션/어드벤처"
            },
            new(){
                    Id = 2,
                    Name = "SF"
                },
            new(){
                    Id = 1,
                    Name = "드라마"
                },
        ];
    public Genre[] GetGenres() => genres;
}
