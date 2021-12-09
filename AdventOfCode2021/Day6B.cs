using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021
{
    internal class Day6B : IPuzzle
    {
        public string Input => "1,3,4,1,5,2,1,1,1,1,5,1,5,1,1,1,1,3,1,1,1,1,1,1,1,2,1,5,1,1,1,1,1,4,4,1,1,4,1,1,2,3,1,5,1,4,1,2,4,1,1,1,1,1,1,1,1,2,5,3,3,5,1,1,1,1,4,1,1,3,1,1,1,2,3,4,1,1,5,1,1,1,1,1,2,1,3,1,3,1,2,5,1,1,1,1,5,1,5,5,1,1,1,1,3,4,4,4,1,5,1,1,4,4,1,1,1,1,3,1,1,1,1,1,1,3,2,1,4,1,1,4,1,5,5,1,2,2,1,5,4,2,1,1,5,1,5,1,3,1,1,1,1,1,4,1,2,1,1,5,1,1,4,1,4,5,3,5,5,1,2,1,1,1,1,1,3,5,1,2,1,2,1,3,1,1,1,1,1,4,5,4,1,3,3,1,1,1,1,1,1,1,1,1,5,1,1,1,5,1,1,4,1,5,2,4,1,1,1,2,1,1,4,4,1,2,1,1,1,1,5,3,1,1,1,1,4,1,4,1,1,1,1,1,1,3,1,1,2,1,1,1,1,1,2,1,1,1,1,1,1,1,2,1,1,1,1,1,1,4,1,1,1,1,1,1,1,1,1,1,1,1,1,1,2,1,1,2,5,1,2,1,1,1,1,1,1,1,1,1";
        //public string Input => "3,4,3,1,2";

        public string Day => "6B";

        public string GetSolution()
        {
            var fishes = Input.Split('\u002C').Select(x => Int32.Parse(x)).ToList();
            var days = 256;
            long totalFish = fishes.Count();
            var fishTracker = new Dictionary<int, long>();
            // Load initial state
            foreach (var fish in fishes)
            {
                if (fishTracker.ContainsKey(fish))
                {
                    fishTracker[fish]++;
                } else
                {
                    fishTracker.Add(fish, 1);
                }
            }

            for(var day = 0; day < days; day++)
            {
                var dayTracker = new Dictionary<int, long>();
                foreach(var fish in fishTracker)
                {
                    if (fish.Key == 0)
                    {
                        dayTracker.AddItem(8, fish.Value);
                        dayTracker.AddItem(6, fish.Value);
                    } 
                    else
                    {
                        dayTracker.AddItem(fish.Key-1,fish.Value);
                    }
                }
                fishTracker = dayTracker;
                var dailyFishCnt = fishTracker.Values.Sum();
                Console.WriteLine($"Day: {day+1} - Fish {dailyFishCnt}");
                //Console.ReadKey();
            }

            return fishTracker.Values.Sum().ToString();
        }
    }

    public static class DictionaryHelper
    {
        public static void AddItem(this Dictionary<int, long> dictionary, int key, long value)
        {
            if (dictionary.ContainsKey(key))
            {
                dictionary[key] += value;
            }
            else
            {
                dictionary.Add(key, value);
            }
        }
    }
}
