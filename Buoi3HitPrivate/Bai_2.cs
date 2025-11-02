using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buoi3HitPrivate
{
    internal class Bai_2
    {
        static string ReverseString(string str)
        {
            string result = "";
            for(int i = str.Length - 1; i >= 0; i--)
            {
                result = result + str[i];
            }
            return result;
        }
        static void Main(string[] args)
        {
            Console.Write("Nhap chuoi: ");
            string input = Console.ReadLine();
            string reversed = ReverseString(input);
            Console.WriteLine("Chuoi dao nguoc: " + reversed);
        }
    }
}
