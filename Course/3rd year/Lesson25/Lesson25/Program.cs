// using System;
// using System.Collections.Generic;
// using System.IO;

// class Program
// {
//     static void Main()
//     {
//         using var input = new StreamReader(Console.OpenStandardInput());
//         using var output = new StreamWriter(Console.OpenStandardOutput());

//         int t = int.Parse(input.ReadLine());
//         for (int _ = 0; _ < t; _++)  
//         {
//             var line = input.ReadLine().Split();
//             long n = long.Parse(line[0]);
//             long m = long.Parse(line[1]);

//             if (n == 1 && m == 1)  
//             {
//                 output.WriteLine(1);
//                 output.WriteLine("1 1 R");
//                 continue;
//             }
//             if (n == 1 && m > 1)  
//             {
//                 output.WriteLine(1);
//                 output.WriteLine("1 1 R");
//                 continue;
//             }
//             if (m == 1 && n > 1)  
//             {
//                 output.WriteLine(1);
//                 output.WriteLine("1 1 D");
//                 continue;
//             }

//             output.WriteLine(2);
//             output.WriteLine($"1 1 D");
//             output.WriteLine($"{n} {m} U");
//         }
//     }
// }

using System;
using System.IO;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        using var input = new StreamReader(Console.OpenStandardInput());
        using var output = new StreamWriter(Console.OpenStandardOutput());

        int t = int.Parse(input.ReadLine());

        for (int i = 0; i < t; i++)
        {
            int n = int.Parse(input.ReadLine());

            // Множество для хранения уникальных цифр
            HashSet<char> digits = new HashSet<char>();

            // Проходим по числам от 0 до n
            for (int j = 0; j <= n; j++)
            {
                string numberStr = j.ToString();  // Преобразуем число в строку
                foreach (char digit in numberStr) 
                {
                    digits.Add(digit);  // Добавляем каждую цифру в множество
                }
            }

            // Выводим количество уникальных цифр
            output.WriteLine(digits.Count);
        }
    }
}
