using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Legacy
{
    class Program
    {
        public static void Main(string[] args)
        {
            Dictionary<string, string> dict = ParseOptions(args);
            Maze maze = GenerateMaze(args[0], args[1], dict);
            string asciiMaze = RenderMaze(maze);
            Console.Write(asciiMaze);
        }

        static Dictionary<string, string> ParseOptions(string[] args)
        {
            var dict = new Dictionary<string, string>();
            for (int i = 2; i < args.Length; i++)
            {
                var kv = args[i].Split('=');
                if (kv.Length == 2)
                {
                    dict[kv[0]] = kv[1];
                }
            }
            return dict;
        }

        public static string RenderMaze(Maze maze)
        {
            StringBuilder output = new StringBuilder();
            int rows = maze.Rows;
            int cols = maze.Columns;

            // First line: top borders
            output.Append(".");
            for (int x = 0; x < cols; x++)
            {
                output.Append(maze.Cells[x, 0].Top ? "--." : "  .");
            }
            output.AppendLine();

            for (int y = 0; y < rows; y++)
            {
                // Vertical walls
                for (int x = 0; x < cols; x++)
                {
                    if (x == 0)
                        output.Append("I");
                    output.Append(maze.Cells[x, y].Right ? "  I" : "   ");
                }
                output.AppendLine();

                // Horizontal walls
                for (int x = 0; x < cols; x++)
                {
                    if (x == 0)
                        output.Append(":");

                    bool isLastCell = x == cols - 1;
                    string ending = isLastCell ? "." : ":";

                    output.Append(maze.Cells[x, y].Bottom ? "--" + ending : "  " + ending);
                }
                output.AppendLine();
            }

            return output.ToString();
        }

        static float RoundDownToInt(double variable) => (float)Math.Floor(variable);

        static float? magicRandomValue = null;
        public static float Random(int dummy)
        {
            if (magicRandomValue.HasValue)
                return magicRandomValue.Value;
            return (float)new Random().NextDouble();
        }

        public static Maze GenerateMaze(string width, string length, Dictionary<string, string> mazeGenerationOptions)
        {
            int? entryPosition = null;
            if (mazeGenerationOptions != null && mazeGenerationOptions.ContainsKey("ENTRY_COLUMN"))
                entryPosition = int.Parse(mazeGenerationOptions["ENTRY_COLUMN"]) - 1;

            if (mazeGenerationOptions != null && mazeGenerationOptions.ContainsKey("LEGACY_RANDOM_MAGIC_NUMBER"))
                magicRandomValue = float.Parse(mazeGenerationOptions["LEGACY_RANDOM_MAGIC_NUMBER"]);

            int columns = int.Parse(width);
            int rows = int.Parse(length);
            Maze maze = new Maze(rows, columns);

            int entryCol = entryPosition ?? (int)(Random(1) * columns);
            maze.Cells[entryCol, 0].Top = false;

            bool[,] visited = new bool[columns, rows];

            int[] dx = { 0, 1, 0, -1 };
            int[] dy = { -1, 0, 1, 0 };

            void Carve(int x, int y)
            {
                visited[x, y] = true;
                var dirs = Enumerable.Range(0, 4).OrderBy(_ => Random(1)).ToArray();
                foreach (int dir in dirs)
                {
                    int nx = x + dx[dir];
                    int ny = y + dy[dir];
                    if (nx >= 0 && nx < columns && ny >= 0 && ny < rows && !visited[nx, ny])
                    {
                        switch (dir)
                        {
                            case 0:
                                maze.Cells[x, y].Top = false;
                                maze.Cells[nx, ny].Bottom = false;
                                break;
                            case 1:
                                maze.Cells[x, y].Right = false;
                                maze.Cells[nx, ny].Left = false;
                                break;
                            case 2:
                                maze.Cells[x, y].Bottom = false;
                                maze.Cells[nx, ny].Top = false;
                                break;
                            case 3:
                                maze.Cells[x, y].Left = false;
                                maze.Cells[nx, ny].Right = false;
                                break;
                        }
                        Carve(nx, ny);
                    }
                }
            }

            Carve(entryCol, 0);

            // Optional exit at bottom-right for legacy compatibility
            maze.Cells[columns - 1, rows - 1].Bottom = false;

            return maze;
        }
    }

    class MazeCell
    {
        public bool Top = true;
        public bool Right = true;
        public bool Bottom = true;
        public bool Left = true;
    }

    class Maze
    {
        public int Rows;
        public int Columns;
        public MazeCell[,] Cells;

        public Maze(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
            Cells = new MazeCell[columns, rows];
            for (int x = 0; x < columns; x++)
                for (int y = 0; y < rows; y++)
                    Cells[x, y] = new MazeCell();
        }
    }
}
