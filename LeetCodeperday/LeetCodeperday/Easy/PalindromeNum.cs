using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeperday.Easy
{
    public class PalindromeNum
    {
        int target = 12321;

        public bool IsPalindrome()
        {
            int x= target;
            int reverse=0;
            if (target < 0) return false;
            while (x != 0) 
            {
                int reminder = x % 10;
                reverse= (reverse*10) + reminder;
                x = x / 10;
            }
            if(target == reverse) return true;
            return false;
        }
    }
}
