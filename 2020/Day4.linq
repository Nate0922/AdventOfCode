<Query Kind="Program">
  <Output>DataGrids</Output>
  <Namespace>System.Threading.Tasks</Namespace>
  <RuntimeVersion>5.0</RuntimeVersion>
</Query>

async Task Main()
{
	var input = ProcessInput(await File.ReadAllTextAsync(@"C:\Repos\GH\AdventOfCode\2020\Day4Input.txt").ConfigureAwait(false));

	var validator = new Dictionary<string, Func<string, bool>> {
		{ "byr", x => PassportValidator.IsValidBirthYear(x) },
		{ "iyr", x => PassportValidator.IsValidIssueYear(x) },
		{ "eyr", x => PassportValidator.IsValidExpirationYear(x) },
		{ "hgt", x => PassportValidator.IsValidHeight(x) },
		{ "hcl", x => PassportValidator.IsValidHairColor(x) },
		{ "ecl", x => PassportValidator.IsValidEyeColor(x) },
		{ "pid", x => PassportValidator.IsValidPassportId(x) },
	};

	input.Count(i => validator.All(v => i.Keys.Contains(v.Key))).Dump("Day 4 Part 1");

	input
		.Where(i => validator.Keys.All(k => i.Keys.Contains(k)))
		.Count(i => validator.All(v => i.TryGetValue(v.Key, out var val) && v.Value.Invoke(val)))
		.Dump("Day 4 Part 2");
}

public IEnumerable<Dictionary<string, string>> ProcessInput(string input) =>
	input
		.Split(Environment.NewLine + Environment.NewLine)
		.Select(s =>
			s.Split(new[] { ' ', '\n' }, StringSplitOptions.TrimEntries)
			.ToDictionary(x => x[..3], x => x[4..])
		);

public static class PassportValidator
{
	public static bool IsValidBirthYear(string birthYear) => int.TryParse(birthYear, out int year) && year >= 1920 && year <= 2002;

	public static bool IsValidIssueYear(string issueYear) => int.TryParse(issueYear, out int year) && year >= 2010 && year <= 2020;

	public static bool IsValidExpirationYear(string expirationYear) => int.TryParse(expirationYear, out int year) && year >= 2020 && year <= 2030;

	public static bool IsValidHeight(string height)
	{

		if (height.EndsWith("cm") && int.TryParse(height[..3], out int cms) && cms >= 150 && cms <= 193)
			return true;

		if (height.EndsWith("in") && int.TryParse(height[..2], out int inches) && inches >= 59 && inches <= 76)
			return true;

		return false;
	}

	public static bool IsValidHairColor(string hairColor) => Regex.IsMatch(hairColor, "^#[0-9a-f]{6}$");

	private static readonly HashSet<string> validColors = new HashSet<string> { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" };
	public static bool IsValidEyeColor(string eyeColor) => validColors.Contains(eyeColor);

	public static bool IsValidPassportId(string passportId) => passportId.Length == 9 && passportId.All(char.IsDigit);
}