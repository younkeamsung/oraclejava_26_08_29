using System.ComponentModel.DataAnnotations;

namespace BlazorApp1.Validations;

public class MoviePriceAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if(value is decimal price)
        {
            if(price < 0 || price > 50000)
            {
                return new ValidationResult(
                    ErrorMessage ?? "영화 가격은 1~5만원 사이로 입력바랍니다.",
                    new[] { validationContext.MemberName! });
            }
            return ValidationResult.Success;
        }
        return new ValidationResult("가격 포맷이 잘못되었습니다");
    }
        
}
