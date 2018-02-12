using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;
using FileReader.Business;
namespace FileReader
{
    class Program
    {
        static void Main(string[] args)
        {
            string userCommand = String.Empty;
            try
            {
                Console.WriteLine(Instructions.NoteGeneral_9);
                Console.WriteLine(Instructions.NoteGeneral_10);
                do
                {
                    Console.WriteLine("");
                    Console.Write("FileReader.exe ");
                    //make input as case insensitive 
                    userCommand = Console.ReadLine().ToString().ToLower();
                    switch (userCommand)
                    {
                        case "exit":
                            break;
                        case "cls":
                            Console.Clear();
                            break;
                        case "?":
                            Console.WriteLine("");
                            Console.WriteLine(Instructions.Separator);
                            Console.WriteLine(Instructions.NoteGeneral_1);
                            Console.WriteLine("");
                            Console.WriteLine(Instructions.NoteGeneral_2);
                            Console.WriteLine("");
                            Console.WriteLine(Instructions.NoteGeneral_3);
                            Console.WriteLine(Instructions.NoteGeneral_4);
                            Console.WriteLine(Instructions.NoteGeneral_5);
                            Console.WriteLine(Instructions.NoteGeneral_6);
                            Console.WriteLine(Instructions.NoteGeneral_7);
                            Console.WriteLine("");
                            Console.WriteLine(Instructions.NoteGeneral_8);
                            Console.WriteLine(Instructions.Separator);
                            Console.WriteLine("");
                            break;
                        default:
                            FileReaderBL.processFile(userCommand);
                            break;
                    }
                }
                //exit the console application
                while (userCommand.ToLower() != "exit");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
