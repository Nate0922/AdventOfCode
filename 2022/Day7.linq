<Query Kind="Program" />

void Main()
{
    var input = File.ReadLines(@"C:\Repos\AdventOfCode\2022\Day7Input.txt").Skip(1).ToList();

    ElfDirectory root = new() { Name = "/" };
    HydrateFileSystem(root, input);

    List<int> directorySizes = new();
    Traverse(root, directorySizes);

    directorySizes.Where(x => x <= 100_000).Sum().Dump("Day 7 Part 1");

    var neededSpace = 30_000_000 - (70_000_000 - root.Size);
    directorySizes.Order().First(x => x >= neededSpace).Dump("Day 7 Part 2");
}

void Traverse(ElfDirectory node, IList<int> sizes)
{
    if (node == null) return;

    sizes.Add(node.Size);

    foreach (var dir in node.SubDirectories)
    {
        Traverse(dir, sizes);
    }
}

void HydrateFileSystem(ElfDirectory root, IList<string> input)
{
    var currentDirectory = root;

    foreach (var l in input)
    {
        var line = l.Split(' ');

        if (line[0] == "dir")
        {
            currentDirectory.AddDirectory(new() { Name = line[1], Parent = currentDirectory });
            continue;
        }

        if (int.TryParse(line[0], out int n))
        {
            currentDirectory.AddFile(new() { Name = line[1], Parent = currentDirectory, Size = n });
            continue;
        }

        if (line is ["$", "cd", ..])
        {
            if (line[2] == "..")
            {
                currentDirectory = currentDirectory.Parent;
                continue;
            }

            currentDirectory = currentDirectory.SubDirectories.Single(x => x.Name == line[2]);
        }
    }
}

record ElfFile
{
    public string Name { get; init; }
    public ElfDirectory Parent { get; init; }
    public int Size { get; init; }
}

record ElfDirectory
{
    public string Name { get; init; }
    public ElfDirectory Parent { get; init; }
    public IList<ElfDirectory> SubDirectories { get; private set; } = new List<ElfDirectory>();
    public IList<ElfFile> Files { get; private set; } = new List<ElfFile>();
    public int Size => SubDirectories.Sum(sd => sd.Size) + Files.Sum(f => f.Size);

    public void AddDirectory(ElfDirectory dir) => SubDirectories.Add(dir);
    public void AddFile(ElfFile file) => Files.Add(file);
}