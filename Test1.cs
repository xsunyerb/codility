using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dotnettest
{
  public static class Test1
  {
    /*
    test 1
    Write a function that takes two strings, s1 and s1
    and returns the longest common subsequence of s1 and s2

    "ABAZDC", "BACBAD" => "ABAD"
    "AGGTAB", "GXTXAYB" => "GTAB"
    "aaaa", "aa" => "aa"
    "ABBA, "ABCABA" => "ABBA"
    */
    public static void Run()
    {
        Console.WriteLine("TEST 1");

        string s1 = "ABAZDC";
        string s2 = "ABAD";
        var res = CalculateMaxSubSequence(s1, s2);
        Console.WriteLine(s1 + ", " + s2 + " => " + res);

        s1 = "AGGTAB";
        s2 = "GXTXAYB";
        res = CalculateMaxSubSequence(s1, s2);
        Console.WriteLine(s1 + ", " + s2 + " => " + res);

        s1 = "aaaa";
        s2 = "aa";
        res = CalculateMaxSubSequence(s1, s2);
        Console.WriteLine(s1 + ", " + s2 + " => " + res);

        s1 = "ABBA";
        s2 = "ABCABA";
        res = CalculateMaxSubSequence(s1, s2);
        Console.WriteLine(s1 + ", " + s2 + " => " + res);
    }

    static string CalculateMaxSubSequence(string s1, string s2) 
    {
        string maxSubSequence = string.Empty;

        List<string> subsequences = new List<string>();
        for(int i = 0; i< s1.Length; i++) 
        {
            string currS1 = s1.Substring(i);
            string subsequence = getLongestSubsequence(currS1, s2);
            subsequences.Add(subsequence);
        }           
        maxSubSequence = subsequences.OrderByDescending(s => s.Length).First();

        return maxSubSequence;
    }

    private static string getLongestSubsequence(string s1, string s2)
    {
        string result = string.Empty;

        int curr = 0;
        string currS2 = s2;
        byte[] s1Bytes = Encoding.ASCII.GetBytes(s1);
        char[] s1Chars = Encoding.ASCII.GetChars(s1Bytes);
        while(curr < s1.Length) 
        {
            char currS1Char = s1Chars[curr];
            int index = currS2.IndexOf(currS1Char);
            if (index != -1) 
            {
                result += currS1Char;
                currS2 = currS2.Substring(index+1);
            }
            curr++;
        }

        return result;
    }
  }
}