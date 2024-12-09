using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeperday.Easy
{
    internal class RomanToInt
    {
        string s = "MMMCMXCIX";
        public int RomanToIntFunc()
        {
            s=s.ToUpper();
            int num = 0;
            Dictionary<char, int> roman = new Dictionary<char, int>();
            roman['I'] = 1;
            roman['V'] = 5;
            roman['X'] = 10;
            roman['L'] = 50;
            roman['C'] = 100;
            roman['D'] = 500;
            roman['M'] = 1000;

            if (s.Contains("IV"))
            {
                s=s.Replace("IV", null);
                num += 4;
            }
            else if(s.Contains("IX"))
            {
                s = s.Replace("IX", null);
                num += 9;
            }

            if (s.Contains("XL"))
            {
                s = s.Replace("XL", null);
                num += 40;
            }
            else if (s.Contains("XC"))
            {
                s = s.Replace("XC", null);
                num += 90;
            }


            if (s.Contains("CD"))
            {
                s = s.Replace("CD", null);
                num += 400;
            }
            else if (s.Contains("CM"))
            {
                s=s.Replace("CM", null);
                num += 900;
            }

            var array = s.ToCharArray();
            for (int i = 0; i < s.Length; i++)
            {
                num += roman[array[i]];
            }
            return num;
        }

        public int RomanToIntBetterFunc()
        {

            int total = 0;
            int previousValue = 0;
            for (int i = s.Length - 1; i >= 0; i--)
            {
                int currentValue = GetValue(s[i]);
                if (previousValue > currentValue)
                {
                    total -= currentValue;
                }
                else
                {
                    total += currentValue;
                }
                previousValue = currentValue;
            }

            return total;
        }

        public int GetValue(char romanChar)
        {
            switch (romanChar)
            {
                case 'I': return 1;
                case 'V': return 5;
                case 'X': return 10;
                case 'L': return 50;
                case 'C': return 100;
                case 'D': return 500;
                case 'M': return 1000;
                default: return 0;
            }
        }

    }
}
