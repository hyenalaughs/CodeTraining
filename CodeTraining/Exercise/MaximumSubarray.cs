﻿namespace CodeTraining.Exercise
{
    internal class MaximumSubarray
    {
        // Given an integer array nums, find the subarray with the largest sum, and return its sum.
           
        // Example 1:
           
        // Input: nums = [-2, 1, -3, 4, -1, 2, 1, -5, 4]
        // Output: 6
        // Explanation: The subarray [4, -1, 2, 1] has the largest sum 6.
        

        // Example 2:
           
        // Input: nums = [1]
        // Output: 1
        // Explanation: The subarray [1] has the largest sum 1.


        // Example 3:
           
        // Input: nums = [5, 4, -1, 7, 8]
        // Output: 23
        // Explanation: The subarray [5, 4, -1, 7, 8] has the largest sum 23.
        public void Test()
        {
            Console.WriteLine(Execute(new int[] { -2, 1, -3, 4, -1, 2, 1, -5, 4 }));
        }

        public int Execute(int[] nums)
        {
            int currentSum = nums[0];
            int maxSum = nums[0];

            for (int i = 1; i < nums.Length; i++)
            {
                currentSum = Math.Max(nums[i], currentSum + nums[i]);
                maxSum = Math.Max(maxSum, currentSum);
            }

            return maxSum;
        }
    }
}
