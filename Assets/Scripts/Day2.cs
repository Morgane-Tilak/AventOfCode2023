using System;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

namespace DefaultNamespace
{
    public class Day2
    {
        public static void Part1(TextAsset inputTextDay2)
        {
            Dictionary<int, List<Set>> parsed = Parse(inputTextDay2);
            int result = parsed
                .Where(val => val.Value.All(s => s is {RedCount: <= 12, BlueCount: <= 14, GreenCount: <= 13}))
                .Sum(x => x.Key);
            Debug.Log(result);
        }

        public static void Part2(TextAsset input)
        {
            Dictionary<int, List<Set>> parsed = Parse(input);
            var v = parsed.Values.Select(
                game => game.Max(s => s.BlueCount) * game.Max(s => s.RedCount) * game.Max(s => s.GreenCount)
            );
            Debug.Log(v.Sum());
        }
        
        private static Dictionary<int,List<Set>> Parse(TextAsset inputTextDay2)
        {
            Dictionary<int, List<Set>> parsed = new Dictionary<int, List<Set>>();
            List<string> lines = inputTextDay2.text.Split("\n").ToList();
            
            //for each lines
            for (int i = 0; i < lines.Count; i++)
            {
                lines[i] = lines[i].Substring(lines[i].IndexOf(':') + 1).Replace("\r", String.Empty);
                List<Set> sets = new List<Set>();
                List<string> separatedSets = lines[i].Split(';').ToList();
                foreach (string separatedSet in separatedSets)
                {
                    Set set = new Set();
                    foreach (string s in separatedSet.Split(',').ToList())
                    {
                        List<string> cube = s.Split(' ').Where(x => !string.IsNullOrWhiteSpace(x)).ToList();
                        set = SetColorNumber(cube[1], int.Parse(cube[0]), set);
                    }
                    sets.Add(set);
                }
                
                parsed.Add(i+1, sets);
            }

            return parsed;
        }

        private static Set SetColorNumber(string type, int number, Set set)
        {
            switch (type)
            {
                case "red":
                    set.RedCount = number;
                    break;
                case "blue":
                    set.BlueCount = number;
                    break;
                case "green":
                    set.GreenCount = number;
                    break;
                default:
                    throw new Exception("the string is incorrect");
            }
            return set;
        }


        private static int CountNumberOfSets(string line)
        {
            int result = 0;
            for (int i = line.IndexOf(';'); i > -1; i = line.IndexOf(';', i + 1))
            {
                result++;
            }

            return result;
        }
        
        private struct Set
        {
            public int BlueCount;
            public int RedCount;
            public int GreenCount;
        }
    }
}