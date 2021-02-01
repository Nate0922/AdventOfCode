<Query Kind="Program">
  <Output>DataGrids</Output>
</Query>

void Main()
{
	var input = new List<int>() { 1,0,0,3,1,1,2,3,1,3,4,3,1,5,0,3,2,1,10,19,1,6,19,23,2,23,6,27,2,6,27,31,2,13,31,35,1,10,35,39,2,39,13,43,1,43,13,47,1,6,47,51,1,10,51,55,2,55,6,59,1,5,59,63,2,9,63,67,1,6,67,71,2,9,71,75,1,6,75,79,2,79,13,83,1,83,10,87,1,13,87,91,1,91,10,95,2,9,95,99,1,5,99,103,2,10,103,107,1,107,2,111,1,111,5,0,99,2,14,0,0 };
	input[1] = 12;
	input[2] = 2;
	var program = input.Select((x,i) => input.Skip(i * 4).Take(4).ToList()).ToList();
	
	foreach (var line in program)
	{
		if (line[0] == 99) break;
		
		input[line[3]] = line[0] switch {
			1 => input[line[1]] + input[line[2]],
			2 => input[line[1]] * input[line[2]]
		};
	}
	
	input[0].Dump("Day 2 Part 1");//5434663
}