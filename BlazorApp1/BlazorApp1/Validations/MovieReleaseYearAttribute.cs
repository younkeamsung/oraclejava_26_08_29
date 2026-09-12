using System.ComponentModel.DataAnnotations;

namespace BlazorApp1.Validations;

public class MovieReleaseYearAttribute : ValidationAttribute
{
    int currentYear = DateTime.UtcNow.Year;
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value is int releaseYear)
        {
            if (releaseYear < 1895 || releaseYear > currentYear)
            {
                return new ValidationResult(
                    ErrorMessage ?? $"출시 년도는 1895~{currentYear}까지 설정가능합니다.",
                    new[] { validationContext.MemberName! });
            }
            return ValidationResult.Success;
        }
        return new ValidationResult("올바른 연도 형식이 아닙니다.");
    }
}
