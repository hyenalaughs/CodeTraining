using System;

namespace Leetcode.Exercise
{
    internal class DailyTemperatures
    {
        public void Test()
        {
            foreach (var num in Execute(new int[] { 73, 74, 75, 71, 69, 72, 76, 73 }))
            {
                Console.Write(num + " ");
            }
        }

        public static int[] Execute(int[] temrepatures)
        {
            var result = new List<int>();

            for (int i = 0; i < temrepatures.Length; i++)
            {
                var length = temrepatures.Length;

                for (int j = i; j <= temrepatures.Length; j++)
                {
                    if (j == length)
                    {
                        result.Add(0);
                        break;
                    }

                    if (temrepatures[i] < temrepatures[j])
                    {
                        result.Add(j - i);
                        break;
                    }
                }
            }

            return result.ToArray();
        }
    }
}
