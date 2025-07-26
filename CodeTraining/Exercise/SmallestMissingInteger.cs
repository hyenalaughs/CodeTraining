namespace Leetcode.Exercise
{
    internal class SmallestMissingInteger
    {
        public void Test()
        {
            Console.WriteLine(Execute(new int[] { 1, 2, 3, 9, 2, 10, 8, 3, 10, 2 }));
        }

        public static int Execute(int[] nums)
        {
            var prefix = new List<int> { nums[0] };

            var prevNumber = nums[0];
            var length = nums.Length;
            for (int i = 1; i < length; i++)
            {
                if (i + 1 >= length)
                    break;

                if (nums[i] - prevNumber == 1)
                {
                    prefix.Add(nums[i]);
                    prevNumber = nums[i];
                }
                else
                    break;
            }

            var maxValue = prefix.Last();
            
            var needNumber = prefix.Sum();

            while(true)
            {
                var isContains = !nums.Contains(maxValue);
                var isBigger = prefix.Sum() <= maxValue;

                if (isContains && isBigger)
                    break;

                maxValue++;
            }

            return maxValue;
        }
    }
}
