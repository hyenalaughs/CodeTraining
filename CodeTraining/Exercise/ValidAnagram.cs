using Microsoft.VisualBasic;

namespace CodeTraining.Exercise
{
    internal class ValidAnagram
    {
        //Given two strings s and t, return true if t is an anagram of s, and false otherwise.
        //Example 1:
        //Input: s = "anagram", t = "nagaram"
        //Output: true

        //Example 2:
        //Input: s = "rat", t = "car"
        //Output: false

        public void Test()
        {
            var s = "aacc";
            var t = "ccac";

            Console.WriteLine( Execute(s, t));
        }

        // Работает, но я бы улучшил
        // Наверняка есть менее тяжелый способ
        public bool Execute(string s, string t)
        {
            //if (s.Length != t.Length)
            //    return false;

            //Dictionary<char, int> symbolsS = new Dictionary<char, int>();
            //Dictionary<char, int> symbolsT = new Dictionary<char, int>();

            //for (int i = 0; i < s.Length; i++)
            //{
            //    if (symbolsS.TryGetValue(s[i], out int j))
            //        symbolsS[s[i]] = symbolsS[s[i]]++;
            //    else
            //        symbolsS[s[i]] = 1;

            //    if (symbolsT.TryGetValue(t[i], out int g))
            //        symbolsT[t[i]] = g++;
            //    else
            //        symbolsT[t[i]] = 1;
            //}

            ////var sortS = symbolsS.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
            ////var sortT = symbolsT.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);

            //if (symbolsT.SequenceEqual(symbolsT))
            //    return true;

            //return false;





            //if (s.Length != t.Length)
            //    return false;

            //var currentChar = s[0];
            //var currentIndex = 0;
            //var sCount = 0;
            //var tCount = 0;

            //for (   int i = 0; i < s.Length; i++) 
            //{

            //    if (currentChar == t[i])
            //    {
            //        sCount++;
            //        tCount++;
            //    }

            //    if (i == s.Length)
            //    {
            //        if(sCount != tCount)
            //            return false;
            //        currentIndex++;
            //        i = currentIndex;
            //    }
            //}

            //return true;

            if (s.Length != t.Length)
                return false;

            Dictionary<char ,int> symbols = new Dictionary<char ,int>();

            foreach(var ch in s)
            {
                if(!symbols.ContainsKey(ch))
                    symbols[ch] = 0;

                symbols[ch]++;
            }

            foreach (var ch in t)
            {
                if(!symbols.ContainsKey(ch))
                    return false;

                symbols[ch]--;

                if (symbols[ch] < 0)
                    return false;
            }

            return true;
        }
    }
}
