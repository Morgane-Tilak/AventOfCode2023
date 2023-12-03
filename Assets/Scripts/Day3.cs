using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace DefaultNamespace
{
    public class Day3
    {
        private static List<string> lines;
        public static void Part1(TextAsset input)
        {
            lines = input.text.Split("\r\n").ToList();
            List<int> numberParted = new List<int>();
            string currentNumber = String.Empty;
            bool currentIsPart = false;
            for (int i = 0; i < lines.Count; i++)
            {
                for (int j = 0; j < lines[i].Length; j++)
                {
                    char currentChar = lines[i][j];
                    if (char.IsDigit(currentChar))
                    {
                        currentNumber += currentChar;
                        currentIsPart = currentIsPart || IsPart(i, j);
                    }
                    else
                    {
                        if (currentIsPart)
                        {
                            numberParted.Add(int.Parse(currentNumber)); 
                        }
                        currentNumber = String.Empty;
                        currentIsPart = false;
                    }
                }
                currentNumber = String.Empty;
                currentIsPart = false;
            }
            Debug.Log(numberParted.Sum());
            
        }

        private static bool IsPart(int indexLine, int indexString)
        {
            return IsSymbol(indexString >= 1 ? lines[indexLine][indexString - 1]: null) ||
                   IsSymbol(indexString < lines[indexLine].Length-1 ? lines[indexLine][indexString + 1] : null) ||
                   IsSymbol(indexLine >= 1 && indexString >= 1 ? lines[indexLine - 1][indexString - 1] : null) ||
                   IsSymbol(indexLine >= 1 ? lines[indexLine - 1][indexString] : null) ||
                   IsSymbol(indexLine >= 1 && indexString < lines[indexLine].Length-1 ? lines[indexLine - 1][indexString + 1] : null) ||
                   IsSymbol(indexLine < lines.Count-1 && indexString >= 1 ? lines[indexLine + 1][indexString - 1] : null) ||
                   IsSymbol(indexLine < lines.Count-1 ? lines[indexLine + 1][indexString] : null) ||
                   IsSymbol(indexLine < lines.Count-1 && indexString < lines[indexLine].Length-1 ? lines[indexLine + 1][indexString + 1] : null);
        }

        private static bool IsSymbol(char? s)
        {
            if (!s.HasValue)
                return false;
            return !char.IsDigit(s.Value) && !s.Equals('.');
        }
    }
}