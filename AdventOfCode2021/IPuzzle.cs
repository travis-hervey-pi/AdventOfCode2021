using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021
{
    public interface IPuzzle
    {
        string Input { get; }
        string GetSolution();

        string Day { get; }
    }
}
