<Query Kind="Statements" />

var input = File.ReadAllLines(@"C:\Repos\AdventOfCode\2022\Day3Input.txt");

var rucksacks = from x in input
                let mid = x.Length / 2
                select new
                {
                    r1 = x.Substring(0, mid),
                    r2 = x.Substring(mid)
                };

rucksacks.Select(x => x.r1.Intersect(x.r2).Single())
         .Sum(CharToPoints)
         .Dump("Day 3 Part 1");

input.Chunk(3)
     .Select(x => x[0].Intersect(x[1])
                      .Intersect(x[2])
                      .Single())
     .Sum(CharToPoints)
     .Dump("Day 3 Part 2");

int CharToPoints(char c) => char.IsLower(c) ? (int)c - 96 : (int)c - 38;