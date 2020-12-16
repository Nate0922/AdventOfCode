<Query Kind="Program">
  <Output>DataGrids</Output>
</Query>

void Main()
{
	var input = File.ReadLines(@"C:\Repos\GH\AdventOfCode\2020\Day8Input.txt")
				.Select(x => (Command: x[..3], Value: int.Parse(x.Split(' ')[1])))
				.ToList();

	Part1(input).Accumulator.Dump("Day 8 Part 1");
	Part2(input).Dump("Day 8 Part 2");
}

private (int Accumulator, bool IsComplete) Part1(IList<(string Command, int Value)> input)
{
	var visitedIndexes = new HashSet<int>();
	var accumulator = 0;
	var currentIndex = 0;

	while (!visitedIndexes.Contains(currentIndex) && currentIndex < input.Count)
	{
		visitedIndexes.Add(currentIndex);

		switch (input[currentIndex].Command) {
			case "acc": 
				accumulator += input[currentIndex++].Value; 
				break;
			case "jmp": 
				currentIndex += input[currentIndex].Value; 
				break;
			default: 
				currentIndex++; 
				break;
		}
	}

	return (accumulator, currentIndex >= input.Count);
}

private int Part2(IList<(string Command, int Value)> input)
{
	(int Accumulator, bool IsComplete) result = (0, false);

	for (int i = 0; i < input.Count; i++)
	{
		var temp = new List<(string Command, int Value)>(input);

		temp[i] = input[i].Command switch
		{
			"jmp" => ("nop", input[i].Value),
			"nop" => ("jmp", input[i].Value),
			_ => input[i]
		};

		result = Part1(temp);

		if (result.IsComplete)
		{
			break;
		}
	}

	return result.Accumulator;
}