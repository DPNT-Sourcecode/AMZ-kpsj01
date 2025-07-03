using BeFaster.Runner.Exceptions;
using System.Diagnostics;

namespace BeFaster.App.Solutions.ULT
{
    public class UltimateSolution
    {
        public string UltimateMaze(int rows, int columns, Dictionary<string, string> mazeGenerationOptions)
        {
            //throw new SolutionNotImplementedException();
            var process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "Legacy.exe", // Or python, amazing.sh, etc.
                    Arguments = columns.ToString() + " " + rows.ToString(),
                    RedirectStandardInput = false,
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                }
            };

            process.Start();

            //using (StreamWriter writer = process.StandardInput)
            //{
            //    writer.WriteLine(columns); // Width
            //    writer.WriteLine(rows);    // Length
            //}

            string output = process.StandardOutput.ReadToEnd().Trim();
            process.WaitForExit();
            return output;
        }
    }
}
