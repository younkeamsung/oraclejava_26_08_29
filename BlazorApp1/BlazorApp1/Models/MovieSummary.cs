namespace BlazorApp1.Models;

public class MovieSummary
{
    public int Id { get; set; }
    public required string Name { get; set; } // required = Name값이 없으면 에러 항상 값을 넣어야됨 없어도 되는건 string?
    public required string Genre { get; set; }
    
    public decimal Price {  get; set; }
    public int ReleaseYear { get; set; }

}
