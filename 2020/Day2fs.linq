<Query Kind="FSharpProgram">
  <Output>DataGrids</Output>
</Query>

type Policy = { Min: int; Max: int; Character: char; Password: string }

let parseLine (line:string) =
    let splitLine = line.Split(' ')
    {
        Min = splitLine.[0].Split('-').[0] |> int
        Max = splitLine.[0].Split('-').[1] |> int
        Character = splitLine.[1].[0]
        Password = splitLine.[2]
    }
    
let isValidPasswordPart1 (line:Policy) = 
    let characterOccurences = line.Password.Count(fun x -> x = line.Character)
    characterOccurences >= line.Min && characterOccurences <= line.Max
    

let input = @"C:\Repos\GH\AdventOfCode\2020\Day2Input.txt"
            |> File.ReadLines
            |> Seq.map parseLine

input
    |> Seq.map isValidPasswordPart1
    |> Seq.filter id
    |> Seq.length
    |> Dump
    
let isValidPasswordPart2 (line:Policy) = (line.Password.[line.Min - 1] = line.Character) <> (line.Password.[line.Max - 1] = line.Character)

input
    |> Seq.map isValidPasswordPart2
    |> Seq.filter id
    |> Seq.length
    |> Dump
