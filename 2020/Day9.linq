<Query Kind="Program">
  <Output>DataGrids</Output>
  <NuGetReference>morelinq</NuGetReference>
  <Namespace>MoreLinq</Namespace>
</Query>

void Main()
{
	var input = File.ReadAllLines(@"C:\Repos\GH\AdventOfCode\2020\Day9Input.txt").Select(long.Parse).ToList();

	var validNumbers = from i in input.Select((value, index) => new { value, index }).Skip(25)
			   let previous25 = input.Skip(i.index - 25).Take(25)
			   from x in previous25
			   where previous25.Any(p => p + x == i.value && p != x)
			   select i.value;

	var result = input.Skip(25).Except(validNumbers).First().Dump("Day 9 Part 1");
	
	
	//var inputUpToAnswer = input.Take(input.IndexOf(result)).ToList();
	//
	//var startValue = inputUpToAnswer.Where((r, i) => inputUpToAnswer.Skip(i).Scan((x, y) => x + y).Contains(result));
	//var startValueIndex = input.IndexOf(startValue.First());
	//
	//var count = inputUpToAnswer.Skip(startValueIndex).Scan((x, y) => x == result ? x : x + y).Where(x => x < result).Count();
	//var range = inputUpToAnswer.Skip(startValueIndex).Take(count);
	//(range.Min() + range.Max()).Dump("Day 9 Part 2");
}
