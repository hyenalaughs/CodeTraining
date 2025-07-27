namespace CodeTraining.Exercise
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

        }

        public int Execute(int[] nums)
        {
            // sum, <starIndex, endIndex>
            Dictionary<int, (int, int)> dict = new Dictionary<int, (int, int)>();

            var prefSumm = new int[nums.Length];
            var startindex = 0;
            var endIndex = nums.Length - 1;

            for (int i = 0; i < nums.Length; i++) 
            { 
                var sum = GetSum(nums, startindex, endIndex);
                dict.Add(sum, (startindex, endIndex));  

                
            }

            return 1;
        }

        private int GetSum(int[] nums, int startIndex, int endIndex)
        {
            var sum = 0;
            for (int i = startIndex; i < endIndex; i++)
            {
                sum += nums[i];
            }

            return sum;
        }
    }
}
