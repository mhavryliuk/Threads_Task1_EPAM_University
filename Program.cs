using System;
using System.Threading;
using System.IO;

// Create an application that writes strings from random numbers to one file simultaneously writes string with words to another text file.
// Создать приложение, которое записывает строки из случайных чисел в один файл, одновременно записывая строку со словами в другой текстовый файл.

namespace _20180329_Task1_Thread
{
    class Program
    {
        private static readonly Random random = new Random();

        private static void FirstTread()
        {
            var first_out = new StreamWriter(@"FirstTread.txt", false);

            for (int i = 0; i < 10; i++)
            {
                first_out.WriteLine(random.Next());
            }
            first_out.Close();
        }

        private static void SecondTread()
        {
            var second_out = new StreamWriter(@"SecondTread.txt", false);
            
            for (int i = 0; i < 10; i++)
            {
                second_out.WriteLine("Hello User!");
            }
            second_out.Close();
        }

        private static void Main()
        {
            // The first thread
            var firstThread = new Thread(FirstTread);

            // The second thread
            var secondThread = new Thread(SecondTread);

            firstThread.Start();
            secondThread.Start();

            Console.WriteLine("Check contents of the created files.");

            Console.ReadKey();
        }
    }
}