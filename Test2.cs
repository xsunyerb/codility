using System;

namespace dotnettest
{
  public static class Test2
  {
    /*
    test2
    You want to park your bicycle in a bicycle parking area where bike racks are aligned in a row. 
    There are already N bikes parked there(each bike is attached to exactly one rack, but a rack can have multiple bikes attached to it). 
    We call racks that already have bikes attached used.
    You want to park your bike in a rack in the parking area according to the following criteria:
        the chosen rack must lie between the first and the last used racks(inclusive);
        the distance between the chose rack and any other used rack is as big as possible.
    A description of the bikes already parked in the racks is given in a non-empty zero-indexed array A: 
      element A[K] denotes the postion of the rack to which bike number K is attached (for 0 <= K < N). 
    The central position in the parking area is position 0. A positive value means that the rack is located A[K] meters to the right of the cetral position 0; 
    a negative value means that it's located |A[K]| meters to the left.
    That, given a non-empty zero-indexed array A of N integers, returns the largest possible distance in meters between the chosen rack and any other used rack.
    Assume that:
        N is an integer within the range [2..100,000];
        each element of array A is an integer within the range [-1,000,000,000..1,000,000,000].
    Complexity:
        expected worst-case time complexity isO(N*log(N));
        expected worst-case space complexity is O(N), beyond input storage (not counting the storage required for input arguments).
    */
    public static void Run()
    {
        Console.WriteLine("TEST 2");

        // N bikes parked
        // the chosen rack must lie between the first and the last used racks(inclusive);
        // the distance between the chose rack and any other used rack is as big as possible.
        // element A[K] denotes the postion of the rack to which bike number K is attached (for 0 <= K < N). 
        // The central position in the parking area is position 0.
        //A positive value means that the rack is located A[K] meters to the right of the cetral position 0; 
        //a negative value means that it's located |A[K]| meters to the left.
        //given a non-empty zero-indexed array A of N integers, returns the largest possible distance in meters between the chosen rack and any other used rack.

        int[] A = { 8, -4, 0, 2, 3 };

        // A.length >= 2
        // A[1] = position where bike 1 is attached
        // A[0] = -2 -> bike 0 is attached 2 meters left from center
        // A[1] = 4 -> bike 1 is attached 4 meters right from center
        // A[2] = 3 -> bike 2 is attached 3 meters right from center

        int result = -1;

        // max distance is 0
        int max_distance = 0;
        // order array A from minus to max
        Array.Sort(A);        
        // check distance between 2 consecutive positions
        for (int i=1; i< A.Length; i++)
        {
          int distance = A[i] - A[i-1];
          // if distance is greater than max distance
          if (distance > max_distance)
          {
              // max_distance = distance
              max_distance = distance;

              // result position = previous_pos + (distance / 2)
              result = A[i-1] + (distance / 2);
          }
        }

        Console.WriteLine("> " + result);
    }
  }
}