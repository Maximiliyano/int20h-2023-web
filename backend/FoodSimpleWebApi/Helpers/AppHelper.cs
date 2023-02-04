using FoodSimpleWebApi.Enums;

namespace FoodSimpleWebApi.Helpers;

<<<<<<< HEAD
public static class AppHelper {
    private const string RandomCharsAndSymbols = "ABCDEFGHIJKLMNOPQRSTUVWXYZ.,<>!:''@#$%^&*()_+?-{}|/";
    private static readonly Random Random = new();

    public static int RandomizeNumber(int from = 1, int to = 100) {
        return Random.Next(from, to);
    }

    public static char RandomizeCharacter() {
        return (char)('a' + RandomizeNumber(1, 26));
    }

    public static string RandomizeCharsAndSymbol(int length) {
        return new(Enumerable.Repeat(RandomCharsAndSymbols, length)
            .Select(s => s[Random.Next(s.Length)]).ToArray());
    }

    public static string RandomizeCharacters(int lenght) {
=======
public static class AppHelper
{
    private static readonly Random Random = new();

    public static int RandomizeNumber(int from = 1, int to = 100) =>
        Random.Next(from, to);

    public static string RandomizeCharacters(int lenght)
    {
>>>>>>> 1f754b1 (complete services)
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        char[] stringChars = new char[lenght];
        for (int i = 0; i < stringChars.Length; i++)
            stringChars[i] = chars[Random.Next(chars.Length)];
        return new string(stringChars);
    }
<<<<<<< HEAD

    public static decimal RandomizeDecimalNumber(double minValue = 0.01, double maxValue = 999.0) {
        decimal number = (decimal)((Random.NextDouble() * (maxValue - minValue)) + minValue);
        number = Math.Round(number, 2);
        return number;
=======
    
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
>>>>>>> 1f754b1 (complete services)
    }
}