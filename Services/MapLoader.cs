using GoblinApp.Models;

namespace GoblinApp.Services;

public class LoadedMap
{
    public int Width { get; }
    public int Height { get; }
    public Field[,] Fields { get; }
    public List<Goblin> Goblins { get; } = new();

    public LoadedMap(int width, int height, Field[,] fields)
    {
        Width = width;
        Height = height;
        Fields = fields;
    }
}

public static class MapLoader
{
    public static LoadedMap LoadFromFile(string path)
    {
        var lines = File.ReadAllLines(path);
        var height = lines.Length;
        var width = lines.Max(line => line.Length);

        var fields = new Field[height, width];
        for (var y = 0; y < height; y++)
        {
            for (var x = 0; x < width; x++)
            {
                fields[y, x] = new Field();
            }
        }

        for (var y = 0; y < height; y++)
        {
            for (var x = 0; x < width; x++)
            {
                var field = fields[y, x];
                if (y > 0) { field.SetNeighbor(Direction.Up, fields[y - 1, x]); }
                if (y < height - 1) { field.SetNeighbor(Direction.Down, fields[y + 1, x]); }
                if (x > 0) { field.SetNeighbor(Direction.Left, fields[y, x - 1]); }
                if (x < width - 1) { field.SetNeighbor(Direction.Right, fields[y, x + 1]); }
            }
        }

        var map = new LoadedMap(width, height, fields);

        for (var y = 0; y < height; y++)
        {
            var line = lines[y];
            for (var x = 0; x < line.Length; x++)
            {
                var field = fields[y, x];

                switch (line[x])
                {
                    case '#':
                        field.Enter(new Wall());
                        break;
                    case 'R':
                        field.Enter(new Boulder());
                        break;
                    case '1':
                        var g1 = new Goblin("Goblin 1", strength: 2);
                        field.Enter(g1);
                        map.Goblins.Add(g1);
                        break;
                    case '2':
                        var g2 = new Goblin("Goblin 2", strength: 2);
                        field.Enter(g2);
                        map.Goblins.Add(g2);
                        break;
                }
            }
        }

        return map;
    }
}