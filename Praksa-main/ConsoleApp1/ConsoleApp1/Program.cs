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
            if (path==string.Empty)
            {
                path = (@"C:\");
            }
            bool loopbreak = true;
            while (loopbreak) 
            {
                Console.WriteLine("Pick with number;\n 1.Search by extension \n 2.Search by name \n 3.Quit");
                var choise = int.Parse(Console.ReadLine());
                switch (choise)
                {
                    case 1:
                        Console.WriteLine("Chose extension, include dot:");
                        string SearchPatternByExtension = "*" + Console.ReadLine();
                        RecursiveSearchFileByExtension(list, path, SearchPatternByExtension);
                        Print(list);
                        list.Clear();
                        break;
                    case 2:
                        Console.WriteLine("Chose name:");
                        string SearchPatternByName = Console.ReadLine() + "*.*";
                        RecursiveSearchFileByName(list, path, SearchPatternByName);
                        Print(list);
                        break;
                    case 3:
                        loopbreak = false;
                        break;

                    default:
                        Console.WriteLine("Something went wrong! \nTry again!");
                        break;
                    

                }

            }
        }

        public static void RecursiveSearchFileByExtension(List<string> files, string path, string find)
        {

            try
            {
                foreach (string file in Directory.GetFiles(path, find))
                {
                    string extension = Path.GetExtension(file);

                    if (extension != null)
                    {
                        files.Add(file);
                    }
                }

                foreach (string directory in Directory.GetDirectories(path))
                {
                    RecursiveSearchFileByExtension(files, directory, find);
                }
            }
            catch (System.Exception error)
            {
                Console.WriteLine(error.Message);
            }
        }
        public static void RecursiveSearchFileByName(List<string> files, string path, string find)
        {

            try
            {
                foreach (string file in Directory.GetFiles(path, find))
                {
                    string extension = Path.GetFileName(file);

                    if (extension != null)
                    {
                        files.Add(file);
                    }
                }

                foreach (string directory in Directory.GetDirectories(path))
                {
                    RecursiveSearchFileByName(files, directory, find);
                }
            }
            catch (System.Exception error)
            {
                Console.WriteLine(error.Message);
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
