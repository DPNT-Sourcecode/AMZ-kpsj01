﻿using BeFaster.Runner.Exceptions;

namespace BeFaster.App.Solutions.HLO
{
    public class HelloSolution
    {
        public string Hello(string? friendName)
        {
            return $"Hello, {friendName ?? ""}!";
            //return "Hello, World!";
            //throw new SolutionNotImplementedException();
        }
    }
}
