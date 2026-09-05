namespace MovieStore.Api.Dtos;

public record MovieSummaryDto
(
    int Id, string Name, string Genre, decimal Price,
    int ReleaseYear

);
