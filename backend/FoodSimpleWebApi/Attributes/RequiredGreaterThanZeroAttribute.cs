using System.ComponentModel.DataAnnotations;

namespace FoodSimpleWebApi.Attributes;

public class RequiredGreaterThanZeroAttribute : ValidationAttribute
{
    public override bool IsValid(object value)
    {
        return value != null && int.TryParse(value.ToString(), out var i) && i > 0;
    }
}