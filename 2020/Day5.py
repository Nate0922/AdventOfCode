# %%
map = str.maketrans("FBLR", "0101")

input = [int(line.translate(map), 2) for line in open(r"C:\Repos\GH\AdventOfCode\2020\Day5Input.txt", "r")  \
        .read()                                                                                             \
        .splitlines()]

print(f"Part 1: {max(input)}")

# %%
part2 = [x for x in range(min(input), len(input)) if not x in input]

print(f"Part 2: {part2}")

# %%
