<Query Kind="Statements" />

var input = from x in File.ReadAllLines(@"C:\Repos\AdventOfCode\2022\Day4Input.txt")
            let elf1 = x.Split(',')[0]
            let elf2 = x.Split(',')[1]
            select (
                Elf1Min: int.Parse(elf1.Split('-')[0]),
                Elf1Max: int.Parse(elf1.Split('-')[1]),
                Elf2Min: int.Parse(elf2.Split('-')[0]),
                Elf2Max: int.Parse(elf2.Split('-')[1])
            );

input.Count(IsContained).Dump("Day 4 Part 1");

input.Count(IsOverlap).Dump("Day 4 Part 2");

bool IsContained((int Elf1Min, int Elf1Max, int Elf2Min, int Elf2Max) ids) =>
    (ids.Elf1Min <= ids.Elf2Min && ids.Elf1Max >= ids.Elf2Max) || (ids.Elf2Min <= ids.Elf1Min && ids.Elf2Max >= ids.Elf1Max);

bool IsOverlap((int Elf1Min, int Elf1Max, int Elf2Min, int Elf2Max) ids) =>
    (ids.Elf1Min <= ids.Elf2Max && ids.Elf1Max >= ids.Elf2Min) || (ids.Elf2Min <= ids.Elf1Max && ids.Elf2Max >= ids.Elf1Min);