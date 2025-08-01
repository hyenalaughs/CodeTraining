﻿namespace CodeTraining.Exercise
{
    internal class ProductArrayExceptSelf
    {
        // https://leetcode.com/problems/product-of-array-except-self/description/

        // Given an integer array nums, return an array answer such that answer[i]
        // is equal to the product of all the elements of nums except nums[i].
        // The product of any prefix or suffix of nums is guaranteed to fit in a 32-bit integer.
        // You must write an algorithm that runs in O(n) time and without using the division operation.

        //Example 1:
        //Input: nums = [1, 2, 3, 4]
        //Output: [24, 12, 8, 6]

        //Example 2:
        //Input: nums = [-1, 1, 0, -3, 3]
        //Output: [0, 0, 9, 0, 0]

        public void Test()
        {

        }

        private int[] Execute(int[] nums)
        {
            var result = new int[nums.Length];
            result[0] = 1;

            for (int i = 1; i < nums.Length; i++)
            {
                result[i] = result[i - 1] * nums[i - 1];
            }

            var right = 1;
            for (int i = nums.Length - 1; i >= 0; i--)
            {
                result[i] *= right;
                right *= nums[i];
            }

            return result;
        }

        public int[] ProductExceptSelf(int[] nums)
        {

            var result = new int[nums.Length];
            result[0] = 1;

            for (int i = 1; i < nums.Length; i++)
            {
                result[i] = result[i - 1] * nums[i - 1];
            }

            var right = 1;
            for (int i = nums.Length - 1; i >= 0; i--)
            {
                result[i] *= right;
                right *= nums[i];
            }

            return result;
        }
    }
}
