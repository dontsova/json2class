using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace json2class
{
    class Program
    {
        static void Main(string[] args)
        {             
            //Console.WriteLine("Введите путь к файлу: ");
            //string FilePath = Console.ReadLine();

            string FilePath = "classes.json";

            try
            {   // Open the text file using a stream reader.
                using (StreamReader sr = new StreamReader(FilePath))
                {
                    // Read the stream to a string, and write the string to the console.
                    String line = sr.ReadToEnd();

                    
                    Parser pr = new Parser(line);
                    pr.ParseJson();

                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }

            
        }
    }
}
