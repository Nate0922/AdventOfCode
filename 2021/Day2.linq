<Query Kind="Statements">
  <Output>DataGrids</Output>
</Query>

var input = File.ReadLines(@"C:\Repos\GH\AdventOfCode\2021\Day2Input.txt")
				.Select(x => (Direction: x.Split(' ')[0], Distance: int.Parse(x.Split(' ')[1])));

var horizontalacc = input.Where(x => x.Direction == "forward").Sum(x => x.Distance);

var depth = input.Where(x => x.Direction == "up" || x.Direction == "down")
				 .Sum(x =>
					x.Direction switch
					{
						"up" => x.Distance * -1,
						"down" => x.Distance,
						_ => 0
					});
					
(horizontalacc * depth).Dump("Day 2 Part 1");

var part2Result = input.Aggregate((horizontal: 0, depth: 0, aim: 0), (acc, next) => next switch
{
	("forward", var x) => (acc.horizontal + x, acc.depth + acc.aim * x, acc.aim),
	("up", var x) => (acc.horizontal, acc.depth, acc.aim - x),
	("down", var x) => (acc.horizontal, acc.depth, acc.aim + x),
	_ => acc
});

(part2Result.horizontal * part2Result.depth).Dump("Day 2 Part 2");