<Query Kind="Statements" />

var input = File.ReadAllLines(@"C:\Repos\AdventOfCode\2022\Day2Input.txt");

//X=1, Y=2, Z=3
//win=6, loss=0, draw=3
var pointsPart1 = new Dictionary<string, int>() {
    { "A Y", 8 }, { "B Z", 9 }, { "C X", 7 }, //Win
    { "A Z", 3 }, { "B X", 1 }, { "C Y", 2 }, //Loss
    { "A X", 4 }, { "B Y", 5 }, { "C Z", 6 }, //Draw
};

input.Sum(x => pointsPart1[x]).Dump("Day 2 Part 1");

//X=1, Y=2, Z=3
//win=6, loss=0, draw=3
//X=loss, Y=draw, Z=win
var pointsPart2 = new Dictionary<string, int>() {
    { "A Z", 8 }, { "B Z", 9 }, { "C Z", 7 }, //Win
    { "A X", 3 }, { "B X", 1 }, { "C X", 2 }, //Loss
    { "A Y", 4 }, { "B Y", 5 }, { "C Y", 6 }, //Draw
};

input.Sum(x => pointsPart2[x]).Dump("Day 2 Part 2");