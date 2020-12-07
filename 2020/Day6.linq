<Query Kind="Program">
  <Output>DataGrids</Output>
</Query>

void Main()
{
	var input = File.ReadAllText(@"C:\Repos\GH\AdventOfCode\2020\Day6Input.txt")
				.Split(Environment.NewLine + Environment.NewLine)
				.Select(x => x.Split(Environment.NewLine));

	input.Sum(i => i.SelectMany(i => i).Distinct().Count(char.IsLetter)).Dump("Day 6 Part 1");
	
	input.Sum(group => group.First().Count(c => group.All(answers => answers.Contains(c)))).Dump("Day 6 Part 2");
}