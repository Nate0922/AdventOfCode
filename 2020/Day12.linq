<Query Kind="Program">
  <Output>DataGrids</Output>
</Query>

private static readonly char[] directions = new[] { 'E', 'S', 'W', 'N' };

void Main()
{
	var instructions = File.ReadLines(@"C:\Repos\GH\AdventOfCode\2020\Day12Input.txt")
						.Select(x => new { Action = x[0], Value = int.Parse(x[1..]) })
						.ToList();

	var position = new[] { 0, 0 };
	var currentDirection = 'E';

	foreach (var instruction in instructions)
	{
		var currentAction = instruction.Action == 'F' ? currentDirection : instruction.Action;
		
		switch (currentAction)
		{
			case 'N': position[1] += instruction.Value; break;
			case 'S': position[1] -= instruction.Value; break;
			case 'E': position[0] += instruction.Value; break;
			case 'W': position[0] -= instruction.Value; break;
			case 'R': 
				var directionAmount = instruction.Value / 90;
				currentDirection = directions[(Array.IndexOf(directions, currentDirection) + directionAmount) % 4]; 
				break;
			case 'L': 
				directionAmount = instruction.Value / 90;
				currentDirection = directions[(Array.IndexOf(directions, currentDirection) - directionAmount + 4) % 4]; 
				break;
		};
	}

	(Math.Abs(position[0]) + Math.Abs(position[1])).Dump("Day 12 Part 1");
}
