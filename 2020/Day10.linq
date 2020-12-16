<Query Kind="Program">
  <Output>DataGrids</Output>
  <NuGetReference>morelinq</NuGetReference>
  <Namespace>MoreLinq</Namespace>
</Query>

void Main()
{
	var input = File.ReadLines(@"C:\Repos\GH\AdventOfCode\2020\Day10Input.txt")
				.Select(int.Parse)
				.OrderBy(x => x)
				.ToList();
	
	Imperative(input).Dump("Part 1 - Imperative");

	Functional(input).Dump("Part 1 - Functional");
}

private int Imperative(IList<int> input)
{
	var diffCount = (One: 1, Three: 1);

	for (int i = 1; i < input.Count; i++)
	{
		switch (input[i] - input[i - 1])
		{
			case 1: diffCount.One++; break;
			case 2: break;
			case 3: diffCount.Three++; break;
			default: throw new InvalidOperationException("wtf");
		}
	}

	return diffCount.One * diffCount.Three;
}

private int Functional(IList<int> input) =>
	Enumerable
		.Range(1, input.Count - 1)
		.GroupBy(i => input[i] - input[i - 1])
		.Select(x => x.Count() + 1)
		.Aggregate((x, y) => x * y);
		