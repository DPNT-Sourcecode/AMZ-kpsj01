using BeFaster.Runner.Exceptions;
using System.Diagnostics;
using System.Text;

namespace BeFaster.App.Solutions.AMZ
{
    public class AmazingSolution
    {
        public string AmazingMaze(int rows, int columns, Dictionary<string, string> mazeGenerationOptions)
        {
            // Define the path to the legacy executable/script
            string legacyExecutablePath = "amazing.exe"; // Adjust the filename if it's different (e.g., amazing.py, amazing.sh)

            // Set up the process start info
            var startInfo = new ProcessStartInfo
            {
                FileName = legacyExecutablePath,
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            try
            {
                using (var process = new Process { StartInfo = startInfo })
                {
                    var outputBuilder = new StringBuilder();

                    process.Start();

                    // Write input: columns first (width), then rows (length)
                    using (StreamWriter writer = process.StandardInput)
                    {
                        if (writer.BaseStream.CanWrite)
                        {
                            writer.WriteLine($"{columns} {rows}");
                        }
                    }

                    // Read and filter output
                    using (StreamReader reader = process.StandardOutput)
                    {
                        string? line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            // Filter out any prompt like "WHAT ARE YOUR WIDTH AND LENGTH?"
                            if (!line.Trim().ToUpper().Contains("WHAT ARE YOUR WIDTH AND LENGTH"))
                            {
                                outputBuilder.AppendLine(line);
                            }
                        }
                    }

                    process.WaitForExit();

                    return outputBuilder.ToString().TrimEnd(); // remove trailing newline
                }
            }
            catch (Exception ex)
            {
                return $"Error running maze generator: {ex.Message}";
            }
        }
    }
}
