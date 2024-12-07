using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeperday.Medium
{
    public class AddTwoNumbers
    {
        int[] l1 = [1,2,3]; int[] l2 = [4, 5, 6];
        public int[] AddTwoNumbersFunc()
        {
            var num1 = l1[2] * 100 + l1[1] * 10 + l1[0];
            var num2 = l2[2] * 100 + l2[1] * 10 + l2[0];
            var sum = ((num1 + num2).ToString()).Reverse();
            int[] returmVal = new int[3];
            int j = 0;
            foreach (var i in sum)
            {
                returmVal[j++] = int.Parse(Convert.ToString(i));
            }
            return returmVal;
        }
    }
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }
}
