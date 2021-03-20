using System;

namespace dotnettest
{
  public class Test3
  {
    /*
    test
    

    This is a demo task.

    Write a function:

        class Solution { public int solution(int[] A); }

    that, given an array A of N integers, returns the smallest positive integer (greater than 0) that does not occur in A.

    For example, given A = [1, 3, 6, 4, 1, 2], the function should return 5.

    Given A = [1, 2, 3], the function should return 4.

    Given A = [−1, −3], the function should return 1.

    Write an efficient algorithm for the following assumptions:

    N is an integer within the range [1..100,000];
    each element of array A is an integer within the range [−1,000,000..1,000,000].


    */
    public void Run()
    {
        Console.WriteLine("TEST 3");


/*
[1, 3, 6, 4, 1, 2]
[-1, -3, -6, -4, 0]
[1, 3, -6, -4, 1, 2, 200]
[1]
[0]
[2]
*/

        int [] A = {102, 103};

        int res = FindLowerInteger(A);
        Console.WriteLine(res);

    }

    int FindLowerInteger(int[] A)
    {
        // write your code in C# 6.0 with .NET 4.5 (Mono)
        if (A.Length == 1) {
          if (A[0] == 1) return 2;
          else return 1;
        }

        Array.Sort(A);
        if (A[0] > 1) return 1;
        if (A[A.Length-1] <= 0) return 1;

        for(int i=1; i<A.Length; i++)
        {
          if (A[i] < 2)
            continue;

          int distance = A[i] - A[i-1];
          if (distance > 1){
            int res = A[i-1]+1;
            if (A[i-1] < 1) return 1;
            else return A[i-1]+1;
          }
        }
        return A[A.Length-1]+1;
    }
  }
}