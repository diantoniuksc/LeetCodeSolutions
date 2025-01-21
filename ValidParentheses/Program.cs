using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidParentheses
{
    internal class Program
    {
        /// <summary>
        /// https://leetcode.com/problems/valid-parentheses/description/
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            string s = Console.ReadLine();
            Console.WriteLine(IsValid(s).ToString());
            Console.ReadKey();
        }
      /*  static bool CheckParentheses(string s)
        {
            int[] pairedParentheses = new int[s.Length];

            if(s.Length % 2 == 1 || s.Length < 1) return false;
            if (!IsOpening(s[0])) return false;
            for (int i = 0; i < s.Length - 1; i++)
            {
                int j = i + 1;
                if (IsOpening(s[i]))
                {
                    for (; j < s.Length; j++)
                    {
                        if (pairedParentheses.Contains(j)) break;

                        if (s[i] == '{' && s[j] == '}')
                        {
                            pairedParentheses[i] = j; break;
                        }
                        else if (s[i] == '[' && s[j] == ']')
                        {
                            pairedParentheses[i] = j; break;
                        }
                        else if (s[i] == '(' && s[j] == ')')
                        {
                            pairedParentheses[i] = j; break;
                        }
                        if (j == s.Length - 1) return false;
                    }
                    if (j - i - 1 % 2 == 1) return false;
                    if (j - i - 1 > 0 && !CheckParentheses(s.Substring(i + 1, j - i - 1))) return false;
                }
                else return false;
                i = j;
            }
            return true;
        }
        static bool IsOpening(char parentheses)
        {
            if (parentheses == '{' || parentheses == '[' || parentheses == '(') return true;
            return false;
        }*/
        public static bool IsValid(string s)
        {
            Stack<char> parenthesesStack = new Stack<char>();
            for(int i = 0; i < s.Length; i++)
            {
                if (s[i] == '{' || s[i] == '[' || s[i] == '(') parenthesesStack.Push(s[i]);
                else
                {
                    if (parenthesesStack.Count == 0) return false;
                    char top = parenthesesStack.Peek();

                    if (top == '{' && s[i] == '}' ||
                        top == '[' && s[i] == ']' ||
                        top == '(' && s[i] == ')')
                    {
                        parenthesesStack.Pop();
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            if (parenthesesStack.Count == 0) return true;
            return false;
        }
    }
}
