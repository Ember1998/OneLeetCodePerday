using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeperday.Easy
{
    public class LongestCommonPrefix
    {
        string[] strs = ["cir", "car"];
        //string[] strs = ["reflower","flow","flight"];
        //string[] strs = ["abca", "aba", "aaab"];



        public string LongestCommonPrefixFunc()
        {
            string first= strs[0];
            string common="";
            bool dobreak = false;
            int length = strs.Min(x => x.Length);
            if (strs.Length == 1)
                common = strs[0];

            for (int i = 0; i < length; i++) 
            {
                for (int j = 1; j < strs.Length; j++)
                {
                    var s = strs[j][i];
                    if (j == 1)
                    {
                        if (first[i] == s)
                            common += s;
                        else
                        {
                            dobreak = true;
                            break;
                        }
                    }
                    else if (common[i]!=s)
                    {
                        common=common.Remove(i);
                        dobreak = true;
                        break;
                    }
                }
                if(dobreak)
                    break;
            }
            return common;
        }

        public string LongestCommonPrefixBetter(string[] strs)
        {
            int len = strs[0].Length;
            for (int i = 0; i < strs.Length && len > 0; i++)
            {
                if (strs[i].Length < len) len = strs[i].Length;
                for (int j = 0; j < len; j++)
                {
                    if (strs[i][j] != strs[0][j])
                    {
                        len = j;
                        break;
                    }
                }
            }
            return strs[0][..len];
        }
    }
}
