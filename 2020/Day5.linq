<Query Kind="Program">
  <Output>DataGrids</Output>
</Query>

void Main()
{
	var input = File.ReadLines(@"C:\Repos\GH\AdventOfCode\2020\Day5Input.txt")
				.Select(i => Convert.ToInt32(string.Concat(i.Select(c => c switch { 'F' => '0', 'B' => '1', 'L' => '0', 'R' => '1' })), 2));

	input.Max().Dump("Day 5 Part 1");

	Enumerable.Range(input.Min(), input.Count()).Except(input).Dump("Day 5 Part 2");
}
