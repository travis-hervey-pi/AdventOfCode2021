using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode2021
{
    internal class Day4A : IPuzzle
    {
        public string Input => "49,48,98,84,71,59,37,36,6,21,46,30,5,33,3,62,63,45,43,35,65,77,57,75,19,44,4,76,88,92,12,27,7,51,14,72,96,9,0,17,83,64,38,95,54,20,1,74,69,80,81,56,10,68,42,15,99,53,93,94,47,13,29,34,60,41,82,90,25,85,78,91,32,70,58,28,61,24,55,87,39,11,79,50,22,8,89,26,16,2,73,23,18,66,52,31,86,97,67,40";

        public string Day => "4A";

        //public string Input => "7,4,9,5,11,17,23,2,0,14,21,24,10,16,13,6,15,25,12,22,18,20,8,19,3,26,1";

        public string GetSolution()
        {
            var boards = ReadBoards();
            var values = Input.Split(',').Select(x => Int32.Parse(x)).ToArray();
            var winningSum = 0;
            foreach (var val in values)
            {
                var z = boards.Where(x => x.ContainsKey(val)).ToList();
                foreach(var b in z)
                {
                    b[val].Called = true;
                }

                foreach(var board in boards)
                {
                    // Check Rows
                    for(int i = 0; i < 5; i++)
                    {
                        var rowcnt = board.Count(x => x.Value.Row == i && x.Value.Called);
                        var colcnt = board.Count(x => x.Value.Column == i && x.Value.Called);

                        if (rowcnt == 5 || colcnt == 5)
                        {
                            winningSum = board.Where(x => !x.Value.Called).Sum(x => x.Value.Value);
                        }
                    }

                    if (winningSum > 0)
                    {
                        winningSum *= val;
                        break;
                    }

                }

                if (winningSum > 0)
                    break;

            }
            return winningSum.ToString();
        }

        private IList<Dictionary<int, BingoObject>> ReadBoards()
        {
            var boards = new List<BingoBoard>();
            var boards2 = new List<Dictionary<int, BingoObject>>();
            var board = new List<BingoObject>();
            var board2 = new Dictionary<int, BingoObject>();
            var row = 0;
            foreach(var line in File.ReadLines($"{Directory.GetCurrentDirectory()}\\Data\\Day4Boards.txt"))
            {
                if (!string.IsNullOrEmpty(line) && line != "EOF")
                {
                    var regex = new Regex(@"\d+");
                    var values = regex.Matches(line)
                        .Select(x => Int32.Parse(x.Value)).ToArray();
                    for(int i = 0; i < values.Count(); i++)
                    {
                        board.Add(new BingoObject { Row = row, Column = i, Value = values[i] });
                        board2.Add(values[i], new BingoObject { Row = row, Column = i, Value = values[i] });
                    }
                    row++;
                }
                else
                {
                    boards.Add(new BingoBoard { Board = board });
                    boards2.Add(board2);
                    row = 0;
                    board = new List<BingoObject>();
                    board2 = new Dictionary<int, BingoObject>();
                }
            }

            return boards2;
        }
    }

    internal class BingoBoard
    {
        public IList<BingoObject> Board { get; set; }
    }

    internal class BingoObject
    {
        public int Value { get; set; }
        public int Row { get; set; }
        public int Column { get; set; }
        public bool Called { get; set; } = false;
    }
}
