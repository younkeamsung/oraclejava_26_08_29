using System.ComponentModel.DataAnnotations;

namespace MovieStore.Api.Dtos;

public record CreateMovieDto(
    [Required][StringLength(50)] string Name,
    int GenreId, 
    [Range(1, 50000)]decimal Price,
    int ReleaseYear
    );