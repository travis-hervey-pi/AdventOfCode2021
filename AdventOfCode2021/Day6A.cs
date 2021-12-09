using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021
{
    internal class Day6A : IPuzzle
    {
        public string Input => "1,3,4,1,5,2,1,1,1,1,5,1,5,1,1,1,1,3,1,1,1,1,1,1,1,2,1,5,1,1,1,1,1,4,4,1,1,4,1,1,2,3,1,5,1,4,1,2,4,1,1,1,1,1,1,1,1,2,5,3,3,5,1,1,1,1,4,1,1,3,1,1,1,2,3,4,1,1,5,1,1,1,1,1,2,1,3,1,3,1,2,5,1,1,1,1,5,1,5,5,1,1,1,1,3,4,4,4,1,5,1,1,4,4,1,1,1,1,3,1,1,1,1,1,1,3,2,1,4,1,1,4,1,5,5,1,2,2,1,5,4,2,1,1,5,1,5,1,3,1,1,1,1,1,4,1,2,1,1,5,1,1,4,1,4,5,3,5,5,1,2,1,1,1,1,1,3,5,1,2,1,2,1,3,1,1,1,1,1,4,5,4,1,3,3,1,1,1,1,1,1,1,1,1,5,1,1,1,5,1,1,4,1,5,2,4,1,1,1,2,1,1,4,4,1,2,1,1,1,1,5,3,1,1,1,1,4,1,4,1,1,1,1,1,1,3,1,1,2,1,1,1,1,1,2,1,1,1,1,1,1,1,2,1,1,1,1,1,1,4,1,1,1,1,1,1,1,1,1,1,1,1,1,1,2,1,1,2,5,1,2,1,1,1,1,1,1,1,1,1";
        //public string Input => "3,4,3,1,2";

        public string Day => "6A";

        public string GetSolution()
        {
            var fishes = Input.Split('\u002C').Select(x => Int32.Parse(x)).ToList();
            var days = 80;
            var newFish = 0;
            for(var day = 0; day < days; day++)
            {
                
                Console.Write($"Day: {day+1}");
                for(var i = 0; i < fishes.Count(); i++)
                {
                    if (fishes[i] == 0)
                    {
                        newFish++;
                        fishes[i] = 6;
                    }
                    else
                    {
                        fishes[i]--;
                    }
                }
                while (newFish > 0)
                {
                    fishes.Add(8);
                    newFish--;
                }
                Console.Write($" - {fishes.Count()}");
                Console.WriteLine();
                //fishes.ForEach(x => Console.Write($"{x},"));
                //Console.WriteLine();
                //Console.ReadKey();
            }

            return fishes.Count().ToString();
        }
    }
}
