<Query Kind="Program">
  <Output>DataGrids</Output>
</Query>

void Main()
{
	var input = File.ReadLines(@"C:\Repos\GH\AdventOfCode\2020\Day7Input.txt")
				.Select(l => l.Split("bags contain", StringSplitOptions.TrimEntries))
				.Where(l => l[1] != "no other bags.")
				.ToDictionary(i => i[0], BagContentToDictionary);

	input.Keys.Count(k => BagContainsBaseColor(input, "shiny gold", k)).Dump("Day 7 Part 1");
	
	NumberOfBagsContained(input, "shiny gold").Dump("Day 7 Part 2");
}

private static bool BagContainsBaseColor(Dictionary<string, Dictionary<string, string>> input, string baseColor, string searchColor) =>
	input.ContainsKey(searchColor)
	&& input[searchColor].Any(x => x.Key == baseColor || BagContainsBaseColor(input, baseColor, x.Key));

private static int NumberOfBagsContained(Dictionary<string, Dictionary<string, string>> input, string searchColor) =>
	input.ContainsKey(searchColor)
	? input[searchColor].Sum(x => int.Parse(x.Value) + int.Parse(x.Value) * NumberOfBagsContained(input, x.Key))
	: 0;

private static Dictionary<string, string> BagContentToDictionary(string[] bags) =>
	bags[1]
		.Split(',', StringSplitOptions.TrimEntries)
		.Select(x => x.Split(' ', 2))
		.ToDictionary(x => x[1].Split(" bag")[0], x => x[0]);
