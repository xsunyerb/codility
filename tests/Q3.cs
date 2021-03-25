using System;
using System.Linq;

namespace dotnettest
{
  public class Q3
  {
    /*
    test
    */
    public void Run()
    {
        Console.WriteLine("Q3");

        string[] A = {"co", "dil", "ity"};
        int result1 = solution(A);
        Console.WriteLine("> " + result1);

        string[] B = {"abc", "yyy", "def", "csv"};
        int result2 = solution(B);
        Console.WriteLine("> " + result2);
        
        string[] C = {"potato", "kayac", "banana", "racecar"};
        int result3 = solution(C);
        Console.WriteLine("> " + result3);
        
        string[] D = {"eva", "jqw", "tyn", "jan"};
        int result4 = solution(D);
        Console.WriteLine("> " + result4);

        // int result = solution(A);
        // Console.WriteLine("> " + result);
    }

    public int solution(string[] A) {
        // write your code in C# 6.0 with .NET 4.5 (Mono)

        int result = 0;
        result = Concatenate(A, 0, string.Empty, 0);
        return result;
    }

    int Concatenate(string[] A, int currentWordIndex, string resultString, int maxResult)
    {
      if (currentWordIndex == A.Length) {
        return maxResult;
      }

      // calculate score without using current word
      int score1 = maxResult;
      score1 = Concatenate(A, currentWordIndex+1, resultString, score1);

      // calculate score using current word
      int score2 = 0;
      if (CanConcatenate(resultString, A[currentWordIndex]))
      {
        resultString += A[currentWordIndex];
        score2 = resultString.Length;
        score2 = Concatenate(A, currentWordIndex+1, resultString, score2);
      }

      maxResult = Math.Max(score1, score2);
      return maxResult;
    }

    bool CanConcatenate(string result, string word)
    {
      // check if there are repeated letters in result
      char[] tmp = new char[result.Length];
      char[] resultChars = result.ToCharArray();
      for(int i=0; i < resultChars.Length; i++)
      {
        if (tmp.Contains(resultChars[i]))
        {
          return false;
        }
        else{
          tmp[i] = resultChars[i];
        }
      }

      // check if there are repeated letters in word
      char[] tmp2 = new char[word.Length];
      char[] wordChars = word.ToCharArray();
      for(int i=0; i < wordChars.Length; i++)
      {
        if (tmp2.Contains(wordChars[i]))
        {
          return false;
        }
        else{
          tmp2[i] = wordChars[i];
        }
      }

      // check if there are repeated chars between words
      foreach(char c in wordChars)
      {
        if (resultChars.Contains(c))
        {
          return false;
        }
      }
      return true;
    }
  }
}
