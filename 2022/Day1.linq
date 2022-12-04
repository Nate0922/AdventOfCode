<Query Kind="Statements">
  <NuGetReference>morelinq</NuGetReference>
  <Namespace>MoreLinq</Namespace>
</Query>

var input = File.ReadLines(@"C:\Repos\AdventOfCode\2022\Day1Input.txt")
                .Split(x => x == "", y => y.Sum(int.Parse))
                .ToArray();

input.Max().Dump("Day 1 Part 1");

input.OrderDescending().Take(3).Sum().Dump("Day 1 Part 2");