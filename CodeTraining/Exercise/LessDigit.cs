namespace Leetcode.Exercise
{
    internal class LessDigit
    {
        public void Test()
        {
            var less = Execute(new int[] {3, 7, 2, 9, 6, 4, 5, 1});
            var less2 = ExecuteSecond(new int[] {3, 7, 2, 9, 6, 4, 5, 1});
            var less3 = ExecuteThird(new int[] { 3, 7, 2, 6, 4, 5, 1, 9 }, 45);
            Console.WriteLine(less3);
        }

        public int Execute(int[] arr)
        {
            int target = 1;
            int less = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == target)
                {
                    target++;
                    i = -1;
                    continue;
                }

                if (i + 1 >= arr.Length)
                    less = target;
            }

            return less;
        }

        public int ExecuteSecond(int[] arr)
        {
            var target = 0;
            arr = arr.OrderBy(x => x).ToArray();
            for (int i = 0; i < arr.Length; i++)
            {
                if (i + 1 >= arr.Length)
                {
                    target = arr[i-1]+1;
                    break;
                }

                if (arr[i] - arr[i+1] == 2)
                    target = arr[i]+1;
            }

            return target;
        }

        public int ExecuteThird(int[] arr, int targetSum)
        {
            var sum = arr.Sum(x => x);
            
            return targetSum - sum;
        }
    }
}
