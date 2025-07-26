namespace Leetcode.Exercise
{
    internal class NextGreaterElement
    {
        public void Test()
        {
            //foreach (var num in Execute(new int[] { 3, 1, 5, 7, 9, 2, 6 },
            //                          new int[] { 1, 2, 3, 5, 6, 7, 9, 11 }))
            //{
            //    Console.Write(num + " ");
            //}

            //Console.WriteLine();

            foreach (var num in Execute(new int[] { 4, 1, 2 },
                          new int[] { 1, 3, 4, 2 }))
            {
                Console.Write(num + " ");
            }
        }

        public static int[] Execute(int[] nums1, int[] nums2)
        {
            var result = new List<int>();

            foreach (var number in nums1)
            {
                var index = Array.IndexOf(nums2, number);
                var greaterIndex = index + 1;

                for(var i = greaterIndex; i <= nums2.Length; i++)
                {
                    if (i >= nums2.Length)
                    {
                        result.Add(-1);
                        break;
                    }

                    if (number < nums2[i])
                    {
                        result.Add(nums2[i]);
                        break;
                    }
                }
            }

            return result.ToArray();
        }
    }
}
