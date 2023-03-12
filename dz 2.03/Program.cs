using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace dz02_03
{
    static class MyRevClass
    {
        public static string MyReverse(this string DataFromFile)
        {
            return new string(DataFromFile.Reverse().ToArray());
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            //ex1
            int[] mas = new int[100];
            Random rand = new Random();
            for(int i = 0; i < mas.Length; i++) {
                mas[i] = rand.Next(0, 150);
            }
            StreamWriter file_num = new StreamWriter("Numbers.txt", true);
            StreamWriter file_fib = new StreamWriter("Fibonachi.txt", true);
            List<int> fib = new List<int>();
            int end = 144; int k = 1;
            for (int i = 1; i <= end; i += k) {
                k = i - k;
                fib.Add(i);
            }
            for(int i = 0; i < mas.Length; i++) {
                for(int j = 0; j < fib.Count; j++) {
                    if (mas[i] == fib[j]) {
                        file_fib.WriteLine(mas[i]);
                    }
                }
            }
            
            file_num.Close();
            file_fib.Close();
            

            //ex2
            FileStream file = new FileStream("File.txt", FileMode.Create, FileAccess.Write);
            StreamWriter SW = new StreamWriter(file);
            string Data = "1 line" + "\n" + "2 line" + "\n" + "3 line" + "\n" + "4 line";
            SW.WriteLine(Data);
            SW.WriteLine("- - - -");
            SW.WriteLine(Data.Replace("line", "str"));
            SW.Close();
            file.Close();
            

            //ex3
            FileStream File = new FileStream("File.txt", FileMode.Create, FileAccess.Write);
            StreamWriter SW = new StreamWriter(File);
            string Data = "1 line" + "\n" + "2 line" + "\n" + "3 line" + "\n" + "4 line";
            SW.WriteLine(Data);
            SW.WriteLine("- - - -");
            string Word = Console.ReadLine();
            string Stars = string.Concat(Enumerable.Repeat("*", Word.Length));
            SW.WriteLine(Data.Replace(Word, Stars));
            SW.Close();
            File.Close();
           

             //ex4
            string Path = Console.ReadLine();
            FileStream FileFromUser = new FileStream(Path, FileMode.Open, FileAccess.Read);
            StreamReader SR = new StreamReader(FileFromUser);
            string DataFromFile = SR.ReadToEnd();
            string ReverseData = DataFromFile.MyReverse();
            SR.Close();
            FileFromUser.Close();
            FileStream ReverseFile = new FileStream("ReverseFile.txt", FileMode.Create, FileAccess.Write);
            StreamWriter SW = new StreamWriter(ReverseFile);
            SW.WriteLine(ReverseData);
            SW.Close();
            ReverseFile.Close();
            

        }
    }
}