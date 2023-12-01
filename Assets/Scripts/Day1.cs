using System;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class Day1
{
    public static void Part1(TextAsset inputTextDay1)
    {
        List<string> lines = inputTextDay1.text.Split("\n").ToList();
        int result = 0;
        foreach (string line in lines)
        {
            result += (int.Parse(string.Concat(line.First(char.IsDigit), line.Last(char.IsDigit)))); 
        }
        Debug.Log(result);
    }
    
    public static void Part2(TextAsset inputTextDay1)
    {
        List<string> lines = inputTextDay1.text.Split("\n").ToList();
        int result = 0;
        foreach (string line in lines)
        {

            int? indexFirstDigit;
            if (line.FirstOrDefault(char.IsDigit) == 0)
            {
                indexFirstDigit = null;
            }
            else
            {
                indexFirstDigit = line.IndexOf(line.First(char.IsDigit)) == -1 ? null : line.IndexOf(line.First(char.IsDigit));
            }
            
            (string word, int? index) firstLetter = FindFirstNumber(line);
            
            char first;
            if (!indexFirstDigit.HasValue)
                first = ParseToChar(firstLetter.word);
            else
            {
                first = !firstLetter.index.HasValue || indexFirstDigit.Value < firstLetter.index
                    ? line.First(char.IsDigit)
                    : ParseToChar(firstLetter.word);
            }
            
            int? indexLastDigit;
            if (line.FirstOrDefault(char.IsDigit) == 0)
            {
                indexLastDigit = null;
            }
            else
            {
                indexLastDigit = line.LastIndexOf(line.LastOrDefault(char.IsDigit)) == -1 ? null : line.LastIndexOf(line.Last(char.IsDigit));
            }
            (string word, int? index) lastLetter = FindLastNumber(new string(line.Reverse().ToArray()));
            
            char last;
            if (!indexLastDigit.HasValue)
                last = ParseToChar(new string(lastLetter.word.Reverse().ToArray()));
            else
            {
                last = !lastLetter.index.HasValue || indexLastDigit.Value > lastLetter.index
                    ? line.Last(char.IsDigit)
                    : ParseToChar(new string(lastLetter.word.Reverse().ToArray()));
            }
            
            Debug.Log($"line {line} = {string.Concat(first, last)}");
            result += int.Parse(string.Concat(first, last));
        }
        Debug.Log(result);
    }

    private static List<string> possibleString3 = new List<string>(){"one", "two", "six"};
    private static List<string> possibleString4 = new List<string>(){"zero", "four", "five", "nine"};
    private static List<string> possibleString5 = new List<string>(){"three", "seven", "eight"};
    
    private static List<string> reversedPossibleString3 = new List<string>(){"eno", "owt", "xis"};
    private static List<string> reversedPossibleString4 = new List<string>(){"orez", "ruof", "evif", "enin"};
    private static List<string> reversedPossibleString5 = new List<string>(){"eerht", "neves", "thgie"};

    
    private static (string word, int? index) FindFirstNumber(string s)
    {
        for (int i = 0; i <= s.Length - 5; i++)
        {
            string sub = s.Substring(i, 3);
            if (possibleString3.Contains(sub))
                return (sub, i);

            int subLength = s.Length - i;
            if (subLength >= 4)
            {
                sub = s.Substring(i, 4);
                if (possibleString4.Contains(sub))
                    return (sub, i);
            }
            
            if (subLength >= 5)
            {
                sub = s.Substring(i, 5);
                if (possibleString5.Contains(sub))
                    return (sub, i);
            }
        }

        return (null, null);
    }
    
    private static (string word, int? index) FindLastNumber(string s)
    {
        for (int i = 0; i <= s.Length - 3; i++)
        {
            string sub = s.Substring(i, 3);
            if (reversedPossibleString3.Contains(sub))
                return (sub, s.Length - i - sub.Length);

            int subLength = s.Length - i;
            if (subLength >= 4)
            {
                sub = s.Substring(i, 4);
                if (reversedPossibleString4.Contains(sub))
                    return (sub, s.Length - i - sub.Length);
            }
            
            if (subLength >= 5)
            {
                sub = s.Substring(i, 5);
                if (reversedPossibleString5.Contains(sub))
                    return (sub, s.Length - i - sub.Length);
            }
        }

        return (null, null);
    }

    private static char ParseToChar(string s)
    {
        switch (s)
        {
            case "zero":
                return '0';
            case "one":
                return '1';
            case "two":
                return '2';
            case "three":
                return '3';
            case "four":
                return '4';
            case "five":
                return '5';
            case "six":
                return '6';
            case "seven":
                return '7';
            case "eight":
                return '8';
            case "nine":
                return '9';
            default:
                throw new Exception("the string is incorrect");
        }
    }

}

    
