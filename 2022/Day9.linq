<Query Kind="Statements" />

var input = File.ReadAllLines(@"C:\Repos\AdventOfCode\2022\Day9Input.txt")
                .Select(x => new { Direction = x[0], Distance = int.Parse(x.Substring(2)) });

Visited(2).Dump("Day 9 Part 1");
Visited(10).Dump("Day 9 Part 2");

int Visited(int numberOfKnots)
{
    HashSet<(int, int)> visited = new();
    var knots = new (int X, int Y)[numberOfKnots];

    foreach (var move in input)
    {
        for (int i = 0; i < move.Distance; i++)
        {
            knots[0] = move.Direction switch
            {
                'L' => (--knots[0].X, knots[0].Y),
                'R' => (++knots[0].X, knots[0].Y),
                'U' => (knots[0].X, ++knots[0].Y),
                'D' => (knots[0].X, --knots[0].Y),
                _ => throw new InvalidOperationException("we broke"),
            };

            for (int j = 1; j < numberOfKnots; j++)
            {
                var xDist = knots[j - 1].X - knots[j].X;
                var yDist = knots[j - 1].Y - knots[j].Y;

                if (Math.Abs(xDist) > 1 || Math.Abs(yDist) > 1)
                {
                    knots[j].X += Math.Sign(xDist);
                    knots[j].Y += Math.Sign(yDist);
                }
            }

            visited.Add(knots.Last());
        }
    }

    return visited.Count;
}