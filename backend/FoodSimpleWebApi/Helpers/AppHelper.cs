namespace FoodSimpleWebApi.Helpers;

public static class AppHelper
{
	private const string RandomCharsAndSymbols = "ABCDEFGHIJKLMNOPQRSTUVWXYZ.,<>!:\"'@#$%^&*()_+?-{}|/";
	private static readonly Random Random = new();

	public static int RandomizeNumber(int from = 1, int to = 100) =>
		Random.Next(from, to);
	
	public static char RandomizeCharacter() =>
		(char)('a' + RandomizeNumber(1, 26));

	public static string RandomizeCharsAndSymbol(int length) =>
		new(Enumerable.Repeat(RandomCharsAndSymbols, length)
			.Select(s => s[Random.Next(s.Length)]).ToArray());

	public static string RandomizeLowerLetters(int len) {
		const string characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
		var result = new char[len];
		for (var i = 0; i < len; i++)
			result[i] = characters[Random.Next(characters.Length)];
		return new string(result);
	}

	public static string RandomizeUpperLetters(int len) {
		const string characters = "abcdefghijklmnopqrstuvwxyz";
		var result = new char[len];
		for (var i = 0; i < len; i++)
			result[i] = characters[Random.Next(characters.Length)];
		return new string(result);
	}

	public static decimal RandomizeDecimalNumber(double minValue = 0.01, double maxValue = 999.0) =>
		Math.Round((decimal)(Random.NextDouble() * (maxValue - minValue) + minValue), 2);
}