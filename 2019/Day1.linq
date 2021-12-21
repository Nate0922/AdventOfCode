<Query Kind="Statements">
  <Output>DataGrids</Output>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

var input = File.ReadLines(@"C:\Repos\GH\AdventOfCode\2019\Day1Input.txt").Select(x => int.Parse(x));

input.Sum(i => i / 3 - 2).Dump("2019 Day 1 Part 1");

input.Sum(i => FuelMassCalculator(i)).Dump("2019 Day 1 Part 2");

int FuelMassCalculator(int x) {
	var y = x / 3 - 2;
	
	return y > 0 ? y + FuelMassCalculator(y) : 0;
}