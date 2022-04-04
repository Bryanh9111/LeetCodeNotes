using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeNotes.括号
{
    class Leetcode_20
    {
        public bool IsValid(string s)
        {
            Stack<char> st = new Stack<char>();
            var arr = s.ToCharArray();
            foreach (var c in arr)
            {
                if (char.Equals(c, '(') || char.Equals(c, '[') || char.Equals(c, '{'))
                    st.Push(c);
                else
                {
                    if (st.Count > 0 && ((char.Equals(c, ')') && char.Equals(st.Peek(), '('))
                    || (char.Equals(c, ']') && char.Equals(st.Peek(), '['))
                    || (char.Equals(c, '}') && char.Equals(st.Peek(), '{'))))
                        st.Pop();
                    else
                        return false;
                }
            }
            return st.Count == 0;
        }
    }
}
