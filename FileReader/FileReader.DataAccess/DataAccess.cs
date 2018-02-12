using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileReader.DataAccess;
namespace FileReader.DataAccess
{
    public sealed class FileReaderDataAccess
    {
        public static bool ExecuteNonQuery(List<string> input)
        {
            bool flag = false;
            try
            {
                //Write to DB
                flag = true;
            }
            catch (Exception)
            {

                throw;
            }
            return flag;
        }

        public static void ExecureReader(List<string> input)
        {
            //TODO
        }
    }
}
