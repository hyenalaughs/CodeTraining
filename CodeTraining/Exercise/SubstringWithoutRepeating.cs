namespace Leetcode.Exercise
{
    internal class SubstringWithoutRepeating
    {
        // Given a string s, find the length of the longest substring without duplicate characters.
        //Example 1:
        //Input: s = "abcabcbb"
        //Output: 3
        //Explanation: The answer is "abc", with the length of 3.

        public void Test() 
        {
            Console.WriteLine(Execute("pwwkew"));
        }

        public int Execute(string s) 
        {
            //string dummy = s[0].ToString();
            //bool isEqual = false;

            //for (int i = 0; i < s.Length; i++)
            //{
            //    for(int j = 0; j < dummy.Length; j++) 
            //    {
            //        if(s[i] == dummy[j]) 
            //        {
            //            isEqual = true;
            //            break;
            //        }
            //    }

            //    if (!isEqual) 
            //    {
            //        dummy += s[i];
            //    }

            //    isEqual = false;
            //}

            //return dummy.Length;
            var lastSeen = new Dictionary<char, int>(); // pw
            int left = 0; // 
            int maxLength = 0; // 2

            for (int right = 0; right < s.Length; right++) // right = 2 
            {
                if (lastSeen.ContainsKey(s[right])) // pwW прошёл сюда, поскольку содержится.
                {
                    // Перемещаем левую границу окна, если символ уже был
                    left = Math.Max(left, lastSeen[s[right]] + 1); // 0, s = 2
                }

                lastSeen[s[right]] = right;
                maxLength = Math.Max(maxLength, right - left + 1);
            }

            return maxLength;

        }
    }
}
