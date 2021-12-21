<Query Kind="Statements">
  <Output>DataGrids</Output>
  <NuGetReference>morelinq</NuGetReference>
  <Namespace>MoreLinq</Namespace>
</Query>

var input = File.ReadLines(@"C:\Repos\GH\AdventOfCode\2021\Day1Input.txt").Select(int.Parse);

input.Window(2).Count(x => x[1] > x[0]).Dump("Day 1 Part 1");

input.Window(3).Window(2).Count(x => x[1].Sum() > x[0].Sum()).Dump("Day 1 Part 2");

input.Zip(input.Skip(1), (p, n) => (p, n)).Count(x => x.n > x.p).Dump();// n > p ? 1 : 0).Sum().Dump();