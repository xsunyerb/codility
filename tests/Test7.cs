using System;

namespace dotnettest
{
  public class Test7
  {
    /*
    test

    TODO: this test is scoring bad in codily
    */
    public void Run()
    {
        Console.WriteLine("TEST7");

        int[] A = {1,2,3};
        var res = solution(A);
        Console.WriteLine("> " + res);
    }

    public int solution(int[] A) 
    {
        // write your code in C# 6.0 with .NET 4.5 (Mono)

        if (A.Length == 1) return A[0]+1;

        Array.Sort(A);
        for (int i=1; i<A.Length; i++)
        {
            int distance = A[i]-A[i-1];
            if (distance > 1)
                return A[i-1]+1;
        }

        return A[A.Length-1]+1;
    }
  }
}

/*
An array A consisting of N different integers is given. The array contains integers in the range [1..(N + 1)], which means that exactly one element is missing.

Your goal is to find that missing element.

Write a function:

    class Solution { public int solution(int[] A); }

that, given an array A, returns the value of the missing element.

For example, given array A such that:
  A[0] = 2
  A[1] = 3
  A[2] = 1
  A[3] = 5

the function should return 4, as it is the missing element.

Write an efficient algorithm for the following assumptions:

        N is an integer within the range [0..100,000];
        the elements of A are all distinct;
        each element of array A is an integer within the range [1..(N + 1)].

Copyright 2009–2021 by Codility Limited. All Rights Reserved. Unauthorized copying, publication or disclosure prohibited. 
*/