using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeperday.Medium
{
    public class LengthOfLongestSubstring
    {
        string s = "";
        public int LengthOfLongestSubstringFunc()
        {
            int maxLength=1;
            HashSet<char> charSet = new HashSet<char>();
            if (s.Length == 0)
                return 0;
            for (int i = 0; i < s.Length; i++) 
            {
                foreach (char v in s.Substring(i))
                {
                    if (!charSet.Add(v))
                    {
                        if (maxLength < charSet.Count)
                            maxLength = charSet.Count;
                        charSet.Clear();
                        break;
                    }
                }
            }
            return maxLength;
        }
        public int LengthOfLongestSubstringBetterFunc()
        {
            int result = 0;
            int left = 0;
            var letters = new int[128];

            for (int right = 0; right < s.Length; right++)
            {
                left = Math.Max(left, letters[s[right]]);
                letters[s[right]] = right + 1;
                result = Math.Max(result, right - left + 1);
            }

            return result;
        }
    }
   
}
