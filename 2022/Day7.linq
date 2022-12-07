<Query Kind="Program" />

void Main()
{
    var input = File.ReadLines(@"C:\Repos\AdventOfCode\2022\Day7Input.txt").Skip(1);
    ElfDirectory root = HydrateFileSystem(input);
    List<int> directorySizes = new();

    Traverse(root, directorySizes);

    directorySizes.Where(x => x <= 100_000).Sum().Dump("Day 7 Part 1");

    var neededSpace = 30_000_000 - (70_000_000 - root.Size);
    directorySizes.Where(x => x >= neededSpace).Min().Dump("Day 7 Part 2");
}

void Traverse(ElfDirectory directory, IList<int> sizes)
{
    if (directory == null) return;

    sizes.Add(directory.Size);

    foreach (var sub in directory.SubDirectories)
    {
        Traverse(sub, sizes);
    }
}

ElfDirectory HydrateFileSystem(IEnumerable<string> input)
{
    ElfDirectory root = new() { Name = "/" };
    var currentDirectory = root;

    foreach (var line in input)
    {
        switch (line.Split(' '))
        {
            case ["dir", var name]:
                currentDirectory.AddDirectory(new() { Name = name, Parent = currentDirectory });
                break;

            case ["$", "cd", ".."]:
                currentDirectory = currentDirectory.Parent;
                break;

            case ["$", "cd", var name]:
                currentDirectory = currentDirectory.SubDirectories.Single(x => x.Name == name);
                break;

            case [var num, var name]:
                if (int.TryParse(num, out int n)) currentDirectory.AddFile(new() { Name = name, Size = n });
                break;
        }
    }

    return root;
}

record ElfFile
{
    public string Name { get; init; }
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