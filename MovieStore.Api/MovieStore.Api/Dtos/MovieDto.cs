namespace MovieStore.Api.Dtos;

//DTO: Data Transfer Object
public record MovieDto(
    int Id, string Name,
    string Genre, decimal Price,
    int ReleaseYear
    );
