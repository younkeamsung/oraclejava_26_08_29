using BlazorApp1.Converters;
using BlazorApp1.Validations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BlazorApp1.Models;

public class MovieDetails
{
    public int Id { get; set; }

    [Required(ErrorMessage ="제목을 입력해주세요.")]
    [StringLength(50, ErrorMessage = "제목은 50자 이내로 입력해주세요.")]
    public required string Name { get; set; } // required = Name값이 없으면 에러 항상 값을 넣어야됨 없어도 되는건 string?

    [Required(ErrorMessage = "장르는 필수 입력입니다.")]
    [JsonConverter(typeof(Converters.StringConverter))]
    public string? GenreId { get; set; }

    //[Range(1, 50000, ErrorMessage = "가격은 1~50,000원 사이로 입력해주세요.")]
    [Required(ErrorMessage = "영화금액을 입력해주세요.")]
    [MoviePrice]
    public decimal? Price {  get; set; }

    [Required(ErrorMessage = "출시년도를 입력해주세요.")]
    [MovieReleaseYear]
    public int? ReleaseYear { get; set; }

}
