<Query Kind="Program">
  <Output>DataGrids</Output>
</Query>

void Main()
{
	var input = File.ReadAllLines(@"C:\Repos\GH\AdventOfCode\2020\Day13Input.txt");

	var FADD = int.Parse(input[0]);
	var busIds = input[1].Split(',').Where(x => x != "x").Select(int.Parse);

	var nextBusTimes = busIds
				.Select(b => new { Bus = b, NextTime = b * (FADD / b + 1) })
				.OrderBy(b => b.NextTime);
	
	((nextBusTimes.First().NextTime - FADD) * nextBusTimes.First().Bus).Dump("Day 13 Part 1");
}


