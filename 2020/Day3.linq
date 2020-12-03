<Query Kind="Program">
  <Output>DataGrids</Output>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

private readonly (Func<int, int> horizontal, int vertical) right3down1 = (i => (i + 1) * 3, 1);
private readonly (Func<int, int> horizontal, int vertical) right1down1 = (i => (i + 1) * 1, 1);
private readonly (Func<int, int> horizontal, int vertical) right5down1 = (i => (i + 1) * 5, 1);
private readonly (Func<int, int> horizontal, int vertical) right7down1 = (i => (i + 1) * 7, 1);
private readonly (Func<int, int> horizontal, int vertical) right1down2 = (i => (i + 1) * 1, 2);

async Task Main()
{
	var input = await File.ReadAllLinesAsync(@"C:\Repos\GH\AdventOfCode\2020\Day3Input.txt").ConfigureAwait(false);

	input.Skip(1).Select((x, i) => x[((i + 1) * 3) % x.Length]).Count(x => x == '#').Dump("Day 3 - Part 1");

	var slopes = new List<(Func<int, int> horizontal, int vertical)>() {
		(right3down1.horizontal, right3down1.vertical),
		(right1down1.horizontal, right1down1.vertical),
		(right5down1.horizontal, right5down1.vertical),
		(right7down1.horizontal, right7down1.vertical),
		(right1down2.horizontal, right1down2.vertical),
	};

	slopes
		.Select(
			s => input
				.Skip(s.vertical)
				.Where((x, i) => i % s.vertical == 0)
				.Select((x, i) => x[s.horizontal(i) % x.Length])
				.LongCount(x => x == '#'))
		.Aggregate((x, y) => x * y)
		.Dump("Day 3 - Part 2");
}