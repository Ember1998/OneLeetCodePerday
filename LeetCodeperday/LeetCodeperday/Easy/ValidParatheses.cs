using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeperday.Easy
{
    public class ValidParatheses
    {
        string s = ")";

        
        public bool ValidParanthesesFunc()
        {
            Dictionary<char, char> brackets = new Dictionary<char, char>();
            brackets['('] = ')';
            brackets['{'] = '}';
            brackets['['] = ']';
            var openBrackets = brackets.Keys.ToArray();
            var closedBrackets = brackets.Values.ToArray();


            List<BracketDetail> b = new List<BracketDetail>();
            for (int i = 0; i < s.Length; i++)
            {
                if (openBrackets.Contains(s[i]))
                {
                    b.Add(new BracketDetail { OpenStatus = true, Bracket = s[i], Position = i });
                }
                else if (closedBrackets.Contains(s[i]))
                {
                    var openBracket = brackets.FirstOrDefault(x => x.Value == s[i]).Key;
                    if (b.OrderByDescending(x => x.Position)?.FirstOrDefault()?.Bracket == openBracket)
                    {
                        b.Remove(b.OrderByDescending(x => x.Position).FirstOrDefault());
                    }
                    else 
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            
            return !b.Any();
        }

        public bool IsValid(string s)
        {
            Stack<char> stacki = new Stack<char>();
            stacki.Push(s[0]);
            int len = s.Length;
            int i = 1;
            int shesvla = 1;
            while (i < len)
            {
                if (s[i] == '(' || s[i] == '[' || s[i] == '{')
                {
                    stacki.Push(s[i]);
                    shesvla++;
                }
                if (stacki.Count == 0)
                {
                    return false;
                }
                char cur_element = stacki.Peek();
                if ((s[i] == ')' && cur_element == '(') ||
                (s[i] == '}' && cur_element == '{') ||
                (s[i] == ']' && cur_element == '['))
                {
                    stacki.Pop();
                    shesvla++;
                }
                i++;
            }
            if (shesvla < i)
            {
                return false;
            }
            return (stacki.Count == 0) ? true : false;
        }
    }
    public class BracketDetail
    {
        public bool OpenStatus { get; set; }
        public char Bracket { get; set; }
        public int Position { get; set; }
    }
}
