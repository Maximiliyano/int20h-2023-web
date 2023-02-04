using FoodSimpleWebApi.Enums;

namespace FoodSimpleWebApi.Helpers;

public static class AppHelper
{
    private static readonly Random Random = new();

    public static int RandomizeNumber(int from = 1, int to = 100) =>
        Random.Next(from, to);

    public static string RandomizeCharacters(int lenght)
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        var stringChars = new char[lenght];
        for (var i = 0; i < stringChars.Length; i++)
        {
            stringChars[i] = chars[Random.Next(chars.Length)];
        }
        return new string(stringChars);
    }
    
    public static Enum RandomCategoryProduct()
    {
        var values = Enum.GetValues(typeof(CategoryProduct));
        var randomBar = (CategoryProduct)(values.GetValue(Random.Next(values.Length)) ?? throw new InvalidOperationException("Category Product not contain such data!"));
        return randomBar;
    }
    
    public static ProductUnit RandomProductUnit()
    {
        var values = Enum.GetValues(typeof(ProductUnit));
        var randomBar = (ProductUnit)(values.GetValue(Random.Next(values.Length)) ?? throw new InvalidOperationException("Product Unit not contain such data!"));
        return randomBar;
    }
}