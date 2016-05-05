using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[10];
            SetArr(arr);
            Console.WriteLine(arr[0]);
            Console.ReadLine();
        }

        public static void SetArr(int[] arr)
        {
            arr[0] = 1;
        }
    }
}
