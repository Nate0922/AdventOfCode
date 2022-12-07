<Query Kind="Statements">
  <NuGetReference>morelinq</NuGetReference>
  <Namespace>static MoreLinq.Extensions.SplitExtension</Namespace>
</Query>

var input = File.ReadLines(@"C:\Repos\AdventOfCode\2022\Day5Input.txt").Split("").ToArray();

var stacks = new List<Stack<char>>() {
    new Stack<char>(new[] { 'S', 'C', 'V', 'N' }),
    new Stack<char>(new[] { 'Z', 'M', 'J', 'H', 'N', 'S' }),
    new Stack<char>(new[] { 'M', 'C', 'T', 'G', 'J', 'N', 'D' }),
    new Stack<char>(new[] { 'T', 'D', 'F', 'J', 'W', 'R', 'M' }),
    new Stack<char>(new[] { 'P', 'F', 'H' }),
    new Stack<char>(new[] { 'C', 'T', 'Z', 'H', 'J' }),
    new Stack<char>(new[] { 'D', 'P', 'R', 'Q', 'F', 'S', 'L', 'Z' }),
    new Stack<char>(new[] { 'C', 'S', 'L', 'H', 'D', 'F', 'P', 'W' }),
    new Stack<char>(new[] { 'D', 'S', 'M', 'P', 'F', 'N', 'G', 'Z' }),
};

foreach (var line in input[1])
{
    var splitLine = line.Split(' ');
    var n = int.Parse(splitLine[1]);
    var from = int.Parse(splitLine[3]);
    var to = int.Parse(splitLine[5]);

    while (n-- > 0)
    {
        stacks[to - 1].Push(stacks[from - 1].Pop());
    }
}

string.Join("", stacks.Select(x => x.Peek())).Dump("Day 5 Part 1");

var stacksPart2 = new List<Stack<char>>() {
    new Stack<char>(new[] { 'S', 'C', 'V', 'N' }),
    new Stack<char>(new[] { 'Z', 'M', 'J', 'H', 'N', 'S' }),
    new Stack<char>(new[] { 'M', 'C', 'T', 'G', 'J', 'N', 'D' }),
    new Stack<char>(new[] { 'T', 'D', 'F', 'J', 'W', 'R', 'M' }),
    new Stack<char>(new[] { 'P', 'F', 'H' }),
    new Stack<char>(new[] { 'C', 'T', 'Z', 'H', 'J' }),
    new Stack<char>(new[] { 'D', 'P', 'R', 'Q', 'F', 'S', 'L', 'Z' }),
    new Stack<char>(new[] { 'C', 'S', 'L', 'H', 'D', 'F', 'P', 'W' }),
    new Stack<char>(new[] { 'D', 'S', 'M', 'P', 'F', 'N', 'G', 'Z' }),
};

foreach (var line in input[1])
{
    var splitLine = line.Split(' ');
    var n = int.Parse(splitLine[1]);
    var from = int.Parse(splitLine[3]);
    var to = int.Parse(splitLine[5]);

    var tempStack = new Stack<char>();
    while (n-- > 0)
    {
        tempStack.Push(stacksPart2[from - 1].Pop());
    }

    while (tempStack.Count > 0)
    {
        stacksPart2[to - 1].Push(tempStack.Pop());
    }
}

string.Join("", stacksPart2.Select(x => x.Peek())).Dump("Day 5 Part 2");