using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var list = new List<string>();
            Console.WriteLine("Chose search location:");
            string path = Console.ReadLine();
            Console.WriteLine("Pick with number;\n 1.Search by extension \n 2.Search by name");
            int odabir = 0;
            odabir = int.Parse(Console.ReadLine());
            switch (odabir)
            {
                case 1:
                    Console.WriteLine("Chose extension, include dot:");
                    string a = "*" + Console.ReadLine();
                    DirSearch(list, path, a);
                    Print(list);
                    break;
                case 2:
                    Console.WriteLine("Chose name:");
                    string b = Console.ReadLine() + "*" + ".*";
                    DirSearchName(list, path, b);
                    Print(list);
                    break;
            }

        }

        public static void DirSearch(List<string> files, string path, string a)
        {

            try
            {
                foreach (string file in Directory.GetFiles(path, a))
                {
                    string extension = Path.GetExtension(file);

                    if (extension != null)
                    {
                        files.Add(file);
                    }
                }

                SearchDir(files, path, a);
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public static void DirSearchName(List<string> files, string path, string b)
        {

            try
            {
                foreach (string file in Directory.GetFiles(path, b))
                {
                    string extension = Path.GetFileName(file);

                    if (extension != null)
                    {
                        files.Add(file);
                    }
                }

                SearchDir(files, path, b);
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public static void SearchDir(List<string> files, string path, string x)
        {
            foreach (string directory in Directory.GetDirectories(path))
            {
                DirSearch(files, directory, x);
            }
        }
        public static void Print(List<string> files)
        {
            foreach (var file in files)
            {
                Console.WriteLine(file);
            }
        }


    }
}
