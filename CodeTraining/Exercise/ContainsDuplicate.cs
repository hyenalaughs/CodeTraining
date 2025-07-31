namespace CodeTraining.Exercise
{
    internal class ContainsDuplicate
    {
        // Given an integer array nums, return true if any value appears at least twice in the array,
        // and return false if every element is distinct.


        //Example 1
        //Input: nums = [1, 2, 3, 1]
        //Output: true

        //Explanation:
        //The element 1 occurs at the indices 0 and 3.



        //Example 2:
        //Input: nums = [1, 2, 3, 4
        //Output: false

        //Explanation:
        //All elements are distinct.

        public void Test()
        {

        }

        private void Execute()
        {

        }

        public bool ContainsDuplicateExecute(int[] nums)
        {
            HashSet<int> seen = new();

            foreach (var i in nums)
            {
                if (!seen.Add(i))
                    return true;
            }

            return false;
        }
    }
}
