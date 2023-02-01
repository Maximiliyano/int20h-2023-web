namespace FoodSimpleWebApi.Helpers;

public static class AppHelper
{
    private const string RandomCharsAndSymbols = "ABCDEFGHIJKLMNOPQRSTUVWXYZ.,<>!:''@#$%^&*()_+?-{}|/";
        private static readonly Random Random = new();

    public static int RandomizeNumber(int from = 1, int to = 100) =>
        Random.Next(from, to);
    
    public static char RandomizeCharacter() =>
        (char)('a' + RandomizeNumber(1, 26));

    public static string RandomizeCharsAndSymbol(int length) =>
        new(Enumerable.Repeat(RandomCharsAndSymbols, length)
            .Select(s => s[Random.Next(s.Length)]).ToArray());
    
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

    public static decimal RandomizeDecimalNumber(double minValue = 0.01, double maxValue = 999.0)
    {
        var number = (decimal)(Random.NextDouble() * (maxValue - minValue) + minValue);
        number = Math.Round(number, 2);
        return number;
    }
}