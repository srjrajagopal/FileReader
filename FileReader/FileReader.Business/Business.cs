using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using FileReader.DataAccess;
namespace FileReader.Business
{
    public sealed class FileReaderBL
    {
        //Process the command
        public static void processFile(string userCommand)
        {
            //string regexPattern = @"^(?:[\w]\:)(\\[A-Za-z_\-\s0-9\.]+)+\.(json|txt|csv)+\s(\/e|\/c|\/d)$";
            //string regexPattern = @"^(?:[\w]\:)(\\[A-Za-z_\-\s0-9\.]+)+\.[a-zA-Z]+\s(\/e|\/c|\/d)$";
            string regexPattern = Constants.RegExString;
            try
            {
                //Allow only specified command type
                if (!Regex.IsMatch(userCommand, regexPattern, RegexOptions.IgnoreCase))
                {
                    Console.WriteLine("");
                    Console.WriteLine(ErrorMsg.NotaValidCmd);
                }
                else
                {
                    //Split the command with the space to get the file path and the command to process
                    string[] userInput = userCommand.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                    string fName = string.Empty;
                    string lName = string.Empty;
                    string extn = string.Empty;

                    if (userInput.Length < 3)
                    {
                        extn = Path.GetExtension(userInput[0].ToLower());
                        if (extn.Equals(".json") || extn.Equals(".csv") || extn.Equals(".txt"))
                        {
                            if (File.Exists(userInput[0]))
                            {
                                try
                                {
                                    if (extn.Equals(".json"))
                                    {
                                        JObject json = JObject.Parse(File.ReadAllText(userInput[0]));
                                        fName = Convert.ToString(json.SelectToken("FirstName"));
                                        lName = Convert.ToString(json.SelectToken("LastName"));
                                    }
                                    else
                                    {
                                        IEnumerable<string> file = File.ReadAllLines(userInput[0]);

                                        if (extn.Equals(".txt"))
                                        {
                                            var names = getNames(file.FirstOrDefault(), file.LastOrDefault());
                                            fName = names.Item1;
                                            lName = names.Item2;

                                        }
                                        else
                                        {
                                            string[] fileInput = file.FirstOrDefault().Replace(@"""", "").Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                                            var names = getNames(fileInput[0], fileInput[1]);
                                            fName = names.Item1;
                                            lName = names.Item2;
                                        }
                                    }

                                    switch (userInput[1])
                                    {
                                        case "/c":
                                            printOnConsole(fName, lName);
                                            break;
                                        case "/d":
                                            writeToDB(fName, lName);
                                            break;
                                        case "/e":
                                            sendEmail(fName, lName);
                                            break;
                                        default:
                                            Console.WriteLine("");
                                            Console.WriteLine(ErrorMsg.CmdTypeNotSupported);
                                            break;
                                    }

                                }
                                catch
                                {
                                    Console.WriteLine("");
                                    Console.WriteLine(ErrorMsg.InvldFileCntnt);
                                }
                            }
                            else
                            {
                                Console.WriteLine("");
                                Console.WriteLine(ErrorMsg.FileNotFnd);
                            }
                        }
                        else
                        {
                            Console.WriteLine("");
                            Console.WriteLine(ErrorMsg.FileFormatErr);
                        }

                    }
                    else
                    {
                        Console.WriteLine("");
                        Console.WriteLine(ErrorMsg.InvalidInput);
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        //Get only F.Name & L.Name ignoring their lable
        private static Tuple<string, string> getNames(string fName, string lName)
        {
            return new Tuple<string, string>(fName.Replace("FirstName:", "").Trim(), lName.Replace("LastName:", "").Trim());
        }

        //Print on the console
        private static void printOnConsole(string fName, string lName)
        {
            Console.WriteLine(fName);
            Console.WriteLine(lName);
            Console.WriteLine("");
        }
        //Send email
        private static void sendEmail(string fName, string lName)
        {
            printOnConsole(fName, lName);
            Console.WriteLine(string.Format("Email sent to 'stal@westernmutual.com' with the values: ({0},{1})", fName, lName));
        }

        //Write to DB
        private static void writeToDB(string fName, string lName)
        {
            List<string> dbData = new List<string> { fName, lName };
            if(FileReaderDataAccess.ExecuteNonQuery(dbData))
            {
                printOnConsole(fName, lName);
                Console.WriteLine(string.Format("insert into names (FirstName, LastName) values({0},{1})", fName, lName));
            }
        }
    }
}
