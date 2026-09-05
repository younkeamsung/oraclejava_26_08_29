using System.ComponentModel.DataAnnotations;

namespace MovieStore.Api.Dtos;

public record UpdateMovieDto(
    [Required][StringLength(50)] string Name,
    [Required] int GenreId,
    [Range(1, 50000)] decimal Price,
    int ReleaseYear
    );
