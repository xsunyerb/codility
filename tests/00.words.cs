using System;

namespace dotnettest
{
  public class Words
  {
    /*
    test
    */
    public void Run()
    {
        Console.WriteLine("Words");

        string[] words = {"dog","cat","dad","good"};
        char[] letters = {'a','a','c','d','d','d','g','o','o'};
        int[] score = {1,0,9,5,0,0,3,0,0,0,0,0,0,0,2,0,0,0,0,0,0,0,0,0,0,0};

        // string[] words = {"xxxz","ax","bx","cx"};
        // char[] letters = {"z","a","b","c","x","x","x"};
        // int[] score = {4,4,4,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5,0,10};

        // string[] words = {"leetcode"};
        // char[] letters = {"l","e","t","c","o","d"};
        // int[] score = {0,0,1,1,1,0,0,0,0,0,0,1,0,0,1,0,0,0,0,1,0,0,0,0,0,0};


        int result = CalculateMaxScoreWords(words, letters,score);
        Console.WriteLine("> " + result);
    }

    public int CalculateMaxScoreWords(string[] words, char[] letters, int[] score) 
    {
      Console.WriteLine("CalculateMaxScoreWords");

      int maxScore = 0;

      // count number of each letter
      int[] lettersCount = new int[26];
      foreach (char letter in letters) {
        lettersCount[letter - 'a'] += 1;
      }
      Console.WriteLine("CalculateMaxScoreWords.CURRENT LETTERS: [{0}]", string.Join(", ", lettersCount));

      // calculate max score
      maxScore = CalculateNextWord(words, lettersCount, score, maxScore, 0);
      Console.WriteLine("CalculateMaxScoreWords.maxScore: "+maxScore);

      return maxScore;
    }

    int CalculateNextWord(string[] words, int[] lettersCount, int[] score, int maxScore, int currentWordIndex)
    {
      if (currentWordIndex == words.Length)
        return maxScore;

      // calculate score without using current word
      maxScore = CalculateNextWord(words, lettersCount, score, maxScore, currentWordIndex+1);

      // calculate score using current word
      if (CanUseWord(words[currentWordIndex], lettersCount, out int[] newLettersCount, score, out int scoreWord))
      {
        maxScore += scoreWord;
        int score2 = CalculateNextWord(words, newLettersCount, score, maxScore, currentWordIndex+1);
        maxScore = Math.Max(maxScore, score2);
      }  

      return maxScore;
    }

    private bool CanUseWord(string currentWord, int[] lettersCount, out int[] newLettersCount, int[] score, out int scoreWord)
    {
      // check if there are enought letters
      Console.WriteLine("CURRENT WORD: ", currentWord);
      Console.WriteLine("CURRENT LETTERS: [{0}]", string.Join(", ", lettersCount));

      scoreWord = 0;
      newLettersCount = new int[26];
      Array.Copy(lettersCount, newLettersCount, lettersCount.Length);
      foreach(char c in currentWord.ToCharArray())
      {
        if (newLettersCount[c - 'a'] > 0)
        {
          newLettersCount[c - 'a'] = newLettersCount[c - 'a'] - 1;
          scoreWord += score[c - 'a'];
        }
        else {
          Console.WriteLine("CANNOT USE WORD: " + currentWord);
          return false;
        }
      }
      Console.WriteLine("CAN USE WORD: " + currentWord);
      Console.WriteLine("SCORE WORD: " + scoreWord);
      return true;
    }

    // public int MaxScoreWords(string[] words, char[] letters, int[] score) 
    // {
    //   // char to number: int index = (int)c - 'a';
    //   int a_score = score[letters[0] - 'a'];
    //   Console.WriteLine("a score: " + a_score);

    //   // count number of each letter
    //   int[] letterCount = new int[26];
    //   foreach (char letter in letters) {
    //     letterCount[letter - 'a'] += 1;
    //   }

    //   // calculate words punctuation
    //   int[] word_points = new int[words.Length];
    //   for (int i=0; i< words.Length; i++)
    //   {
    //     // check word punctuation
    //     int points = 0;
    //     foreach(var letter in words[i])
    //     {
    //       points += score[letter % 32 - 1];
    //     }
    //     word_points[i] = points;
    //   }

    //   // try to create words with max punctuation


    //   //*
    //     int[] count = new int[26];
    //     foreach (char letter in letters) {
    //         count[letter - 'a'] += 1;
    //     }
        
    //     int n = words.Length;
    //     int mask = 1 << n, ans = 0;
    //     for (int i = 1; i < mask; i++) {
    //         int[] tempCount = new int[26];
    //         for (int j = 0; j < n; j++) {
    //             if ((i >> j & 1) == 0) continue;
    //             foreach (char c in words[j].ToCharArray()) {
    //                 tempCount[c - 'a'] += 1;
    //             }
    //         }
            
    //         int sum = 0;
    //         for (int j = 0; j < count.Length; j++) {
    //             if (tempCount[j] > count[j]) {
    //                 sum = 0;
    //                 break;
    //             }
    //             sum += score[j] * tempCount[j];
    //         }
    //         ans = Math.Max(ans, sum);
    //     }
    //     return ans;
    //   //*/

    //   return 0;
    // }
  }
}

/*
1255. Maximum Score Words Formed by Letters

Given a list of words, list of  single letters (might be repeating) and score of every character.

Return the maximum score of any valid set of words formed by using the given letters (words[i] cannot be used two or more times).

It is not necessary to use all characters in letters and each letter can only be used once. Score of letters 'a', 'b', 'c', ... ,'z' is given by score[0], score[1], ... , score[25] respectively.

Example 1:

Input: words = ["dog","cat","dad","good"], letters = ["a","a","c","d","d","d","g","o","o"], score = [1,0,9,5,0,0,3,0,0,0,0,0,0,0,2,0,0,0,0,0,0,0,0,0,0,0]
Output: 23
Explanation:
Score  a=1, c=9, d=5, g=3, o=2
Given letters, we can form the words "dad" (5+1+5) and "good" (3+2+2+5) with a score of 23.
Words "dad" and "dog" only get a score of 21.

Example 2:

Input: words = ["xxxz","ax","bx","cx"], letters = ["z","a","b","c","x","x","x"], score = [4,4,4,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5,0,10]
Output: 27
Explanation:
Score  a=4, b=4, c=4, x=5, z=10
Given letters, we can form the words "ax" (4+5), "bx" (4+5) and "cx" (4+5) with a score of 27.
Word "xxxz" only get a score of 25.

Example 3:

Input: words = ["leetcode"], letters = ["l","e","t","c","o","d"], score = [0,0,1,1,1,0,0,0,0,0,0,1,0,0,1,0,0,0,0,1,0,0,0,0,0,0]
Output: 0
Explanation:
Letter "e" can only be used once.

Constraints:

    1 <= words.length <= 14
    1 <= words[i].length <= 15
    1 <= letters.length <= 100
    letters[i].length == 1
    score.length == 26
    0 <= score[i] <= 10
    words[i], letters[i] contains only lower case English letters.

*/
