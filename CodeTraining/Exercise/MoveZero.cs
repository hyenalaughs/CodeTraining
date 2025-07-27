namespace CodeTraining.Exercise
{
    internal class MoveZero
    {
        //Given an integer array nums, move all 0's to the end of
        //it while maintaining the relative order of the non-zero elements.
        //Note that you must do this in-place without making a copy of the array.
        public void Test()
        {
            Console.WriteLine(Execute(new int[] {0, 1, 0, 3, 12} ));
        }

        public int[] Execute(int[] nums)
        {
            // дан массив с числами.
            // Нужно переместить все нули в конец.
            // Нельзя создавать ещё один массив.

            var nonZeroIndex = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] != 0)
                {
                    var support = nums[i];
                    nums[i] = nums[nonZeroIndex];
                    nums[nonZeroIndex] = support;

                    nonZeroIndex++;
                }
            }

            return nums;
        }
    }
}
