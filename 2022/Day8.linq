<Query Kind="Statements">
  <NuGetReference>morelinq</NuGetReference>
  <Namespace>MoreLinq</Namespace>
</Query>

var input = File.ReadLines(@"C:\Repos\AdventOfCode\2022\Day8Input.txt").Select(x => x.Select(y => y - '0').ToArray()).ToArray();

List<Func<int[][], int, int, bool>> visibilityChecks = new() {
    (grid, row, col) => !grid[row].Take(col).Any(x => x >= grid[row][col]), //visible from left
    (grid, row, col) => !grid[row].Skip(col + 1).Any(x => x >= grid[row][col]), //visible from right
    (grid, row, col) => !Enumerable.Range(0, row).Any(i => grid[i][col] >= grid[row][col]), //visible from top
    (grid, row, col) => !Enumerable.Range(row + 1, 99 - (row + 1)).Any(i => grid[i][col] >= grid[row][col]), //visible from bottom
};

Enumerable.Range(0, 99)
          .Select(row => Enumerable.Range(0, 99)
                                   .Count(col => visibilityChecks.Any(x => x(input, row, col))))
          .Sum()
          .Dump("Day 8 Part 1");


List<Func<int[][], int, int, int>> visibilityDistance = new() {
    (grid, row, col) => Enumerable.Range(0, col).Reverse().TakeUntil(x => grid[row][x] >= grid[row][col]).Count(), //number visible west
    (grid, row, col) => Enumerable.Range(col + 1, 99 - col - 1).TakeUntil(x => grid[row][x] >= grid[row][col]).Count(), //number visible east
    (grid, row, col) => Enumerable.Range(0, row).Reverse().TakeUntil(x => grid[x][col] >= grid[row][col]).Count(), //number visible north
    (grid, row, col) => Enumerable.Range(row + 1, 99 - row - 1).TakeUntil(x => grid[x][col] >= grid[row][col]).Count(), //number visible south
};

Enumerable.Range(0, 99)
          .Select(row => Enumerable.Range(0, 99)
                                   .Select(col => visibilityDistance.Aggregate(1, (score, x) => score * x(input, row, col))))
          .SelectMany(x => x)
          .Max()
          .Dump("Day 8 Part 2");