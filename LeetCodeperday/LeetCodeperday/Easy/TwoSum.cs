using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeperday.Easy
{
    public class TwoSum
    {
        int[] nums = [3, 2, 4];
        int target = 6;

        public int[] TwoSumFunc()
        {
            Dictionary<int, int> keyValuePairs = new Dictionary<int, int>();
            int[] arrayreturn = new int[2];
            for (int i = 0; i < nums.Length; i++)
            {
                int diff = target - nums[i];

                if (keyValuePairs.ContainsKey(diff)) {
                    
                    return new int[] { keyValuePairs[diff],i };
                }

                keyValuePairs.Add(nums[i], i);
            }
            return new int[] { 0,0};
        }
    }
}
