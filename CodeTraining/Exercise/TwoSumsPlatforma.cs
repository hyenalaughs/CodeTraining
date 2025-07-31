namespace Leetcode.Exercise
{
    internal class TwoSumsPlatforma
    {

        public void Test()
        {

        }


        public void Execute() 
        {
            //Дан массив целых чисел nums и целевое число target, 
            //необходимо вернуть индексы двух чисел так, чтобы они в сумме давали target. 
            //Можно предположить, что каждый вход будет иметь ровно одно решение, и нельзя
            //использовать один и тот же элемент дважды. Вы можете вернуть ответ в любом порядке.
            //Пример 1:Вход: nums = [2, 7, 11, 15], target = 9 Выход: [0, 1]

            int[] arr = new int[] { 2, 7, 11, 15 };
            Dictionary<int, int> dict = new Dictionary<int, int>();
            var target = 9;

            for (int i = 0; i < arr.Length; i++)
            {
                int current = arr[i];
                int need = target - arr[i];

                if (dict.TryGetValue(need, out int j))
                {
                    Console.WriteLine($"i: {i}, j: {j}");
                    break;
                }

                dict.Add(current, i);
            }


        }

        public int[] TwoSum(int[] nums, int target)
        {
            Dictionary<int, int> seen = new();
            var result = new int[2];

            for (int i = 0; i < nums.Length; i++)
            {
                var current = nums[i];
                var need = target - current;

                if (seen.TryGetValue(need, out var j))
                {
                    result[0] = i;
                    result[1] = j;
                    break;
                }

                seen.Add(current, i);
            }

            return result;
        }
    }
}
