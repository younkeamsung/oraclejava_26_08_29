namespace MovieStore.Api.Dtos;

public record MovieDetailsDto(
    int Id, string Name, int GenreId, decimal Price,
    int ReleaseYear, string Comment
    );
