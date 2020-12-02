<Query Kind="Program">
  <Output>DataGrids</Output>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

async Task Main()
{
	var input = await File.ReadAllLinesAsync(@"C:\Repos\GH\AdventOfCode\2020\Day2Input.txt").ConfigureAwait(false);
	var processedLines = ProcessInput(input).ToList();

	processedLines.Count(x => IsValidPasswordPart1(x.PolicyMin, x.PolicyMax, x.Character, x.Password)).Dump("Day 2 - Part 1");
	processedLines.Count(x => IsValidPasswordPart2(x.PolicyMin, x.PolicyMax, x.Character, x.Password)).Dump("Day 2 - Part 2");
}

private static bool IsValidPasswordPart1(int policyMin, int policyMax, char character, string password)
{
	var characterOccurences = password.Count(p => p == character);

	return characterOccurences >= policyMin && characterOccurences <= policyMax;
}

private static bool IsValidPasswordPart2(int policyMin, int policyMax, char character, string password) =>
	password[policyMin - 1] == character ^ password[policyMax - 1] == character;

private IEnumerable<(int PolicyMin, int PolicyMax, char Character, string Password)> ProcessInput(IEnumerable<string> input)
{
	return input.Select(x =>
		{
			var splitLine = x.Split(' ');

			return (
				int.Parse(splitLine[0].Split('-')[0]),
				int.Parse(splitLine[0].Split('-')[1]),
				splitLine[1][0],
				splitLine[2]
			);
		});
}