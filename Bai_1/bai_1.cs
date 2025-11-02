using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DauNgoacMaThuat
{
    class Program
    {
        static void Main()
        {
            Console.Write("Nhap chuoi can kiem tra: ");
            string s = Console.ReadLine();   
            if (KiemTraHopLe(s))
                Console.WriteLine("YES");
            else
                Console.WriteLine("NO");
        }

        static bool KiemTraHopLe(string s)
        {
            Stack<char> stack = new Stack<char>();

            foreach (char c in s)
            {
                if (c == '(' || c == '[' || c == '{')
                {
                    stack.Push(c);
                }
                else if (c == ')' || c == ']' || c == '}')
                {
                    if (stack.Count == 0)
                        return false;

                    char top = stack.Pop();

                    if ((c == ')' && top != '(') ||
                        (c == ']' && top != '[') ||
                        (c == '}' && top != '{'))
                    {
                        return false; 
                    }
                }
            }

            return stack.Count == 0;
        }
    }
}
