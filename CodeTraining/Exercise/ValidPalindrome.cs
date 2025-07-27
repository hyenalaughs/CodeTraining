using System.Text.RegularExpressions;

namespace CodeTraining.Exercise
{
    internal class ValidPalindrome
    {
        // A phrase is a palindrome if, after converting all uppercase letters into lowercase
        // letters and removing all non-alphanumeric characters, it reads the same forward and backward.
        // Alphanumeric characters include letters and numbers.
        // Given a string s, return true if it is a palindrome, or false otherwise.
              
        // Example 1:
           
        // Input: s = "A man, a plan, a canal: Panama"
        // Output: true
        // Explanation: "amanaplanacanalpanama" is a palindrome.
        
        
        // Example 2:
           
        // Input: s = "race a car"
        // Output: false
        // Explanation: "raceacar" is not a palindrome.


        // Example 3:
           
        // Input: s = " "
        // Output: true
        // Explanation: s is an empty string "" after removing non-alphanumeric characters.
        // Since an empty string reads the same forward and backward, it is a palindrome.

        public void Test()
        {
            Console.WriteLine(Execute("A man, a plan, a canal: Panama"));
        }

        public bool Execute(string s)
        {
            if(s == null || s.Length == 0) 
                return false;

            s = s.Trim().ToLower().Replace(' ', char.MinValue);
            s = Regex.Replace(s, "[^a-zA-Z0-9]+", "");

            var j = s.Length-1;
            for(int i = 0; i < s.Length/2; i++)
            {
                if(j - i == 0 && s[i] == s[j])
                    return true;

                if (s[i] != s[j])
                    return false;

                j--;
            } 

            return true;
        }
    }
}
