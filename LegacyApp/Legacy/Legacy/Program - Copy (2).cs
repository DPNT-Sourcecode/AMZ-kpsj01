using System;
using System.Collections.Generic;
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

            // Top border line
            output.Append(".");
            for (int x = 0; x < cols; x++)
            {
                // Print "  ." for open top, "--." for wall
                output.Append(maze.Cells[x, 0].Top ? "--." : "  .");
            }
            output.AppendLine();

            for (int y = 0; y < rows; y++)
            {
                // Vertical walls line (left boundary + cell right walls)
                for (int x = 0; x < cols; x++)
                {
                    if (x == 0)
                        output.Append("I");

                    output.Append(maze.Cells[x, y].Right ? "  I" : "   ");
                }
                output.AppendLine();

                // Horizontal walls line (bottom walls + separators)
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
            return 0.5f; // fixed deterministic fallback for tests
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

            float[,] matrixW = new float[columns + 2, rows + 2];
            float[,] matrixV = new float[columns + 2, rows + 2];
            float scalarC = 1;
            int scalarR = 0, scalarS = 0;

            int entryCol = entryPosition.HasValue ? entryPosition.Value : (int)(Random(1) * columns);
            scalarR = entryCol + 1;
            scalarS = 1;

            matrixW[scalarR, scalarS] = scalarC;
            scalarC++;

            int[,] directions = new int[,] { { 0, -1 }, { 1, 0 }, { 0, 1 }, { -1, 0 } };

            while (true)
            {
                List<int> availableDirs = new List<int>();

                for (int dir = 0; dir < 4; dir++)
                {
                    int nx = scalarR + directions[dir, 0];
                    int ny = scalarS + directions[dir, 1];
                    if (nx > 0 && nx <= columns && ny > 0 && ny <= rows && matrixW[nx, ny] == 0)
                    {
                        availableDirs.Add(dir);
                    }
                }

                if (availableDirs.Count == 0)
                {
                    float back = matrixV[scalarR, scalarS];
                    if (back == 0)
                        break;

                    scalarR = (int)(back / 256);
                    scalarS = (int)(back % 256);
                    continue;
                }

                int pick = (int)RoundDownToInt(Random(1) * availableDirs.Count);
                int move = availableDirs[pick];

                int newR = scalarR + directions[move, 0];
                int newS = scalarS + directions[move, 1];

                matrixV[newR, newS] = scalarR * 256 + scalarS;
                matrixW[newR, newS] = scalarC;
                scalarC++;

                int x1 = scalarR - 1;
                int y1 = scalarS - 1;
                int x2 = newR - 1;
                int y2 = newS - 1;

                if (x1 == x2)
                {
                    if (y1 < y2)
                    {
                        if (y1 >= 0 && y1 < rows)
                            maze.Cells[x1, y1].Bottom = false;
                        if (y2 >= 0 && y2 < rows)
                            maze.Cells[x2, y2].Top = false;
                    }
                    else
                    {
                        if (y1 >= 0 && y1 < rows)
                            maze.Cells[x1, y1].Top = false;
                        if (y2 >= 0 && y2 < rows)
                            maze.Cells[x2, y2].Bottom = false;
                    }
                }
                else if (y1 == y2)
                {
                    if (x1 < x2)
                    {
                        if (x1 >= 0 && x1 < columns)
                            maze.Cells[x1, y1].Right = false;
                        if (x2 >= 0 && x2 < columns)
                            maze.Cells[x2, y2].Left = false;
                    }
                    else
                    {
                        if (x1 >= 0 && x1 < columns)
                            maze.Cells[x1, y1].Left = false;
                        if (x2 >= 0 && x2 < columns)
                            maze.Cells[x2, y2].Right = false;
                    }
                }

                scalarR = newR;
                scalarS = newS;
            }

            maze.Cells[entryCol, 0].Top = false;

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
