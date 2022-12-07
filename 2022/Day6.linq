<Query Kind="Statements">
  <NuGetReference>morelinq</NuGetReference>
  <Namespace>static MoreLinq.Extensions.WindowExtension</Namespace>
</Query>

var input = File.ReadAllText(@"C:\Repos\AdventOfCode\2022\Day6Input.txt");

FirstMarkerIndex(4).Dump("Day 6 Part 1");
FirstMarkerIndex(14).Dump("Day 6 Part 2");

int FirstMarkerIndex(int n) =>
    input.Select((x, i) => (Value: x, Index: i))
         .Window(n)
         .First(x => x.DistinctBy(x => x.Value).Count() == n)
         .Last().Index + 1;