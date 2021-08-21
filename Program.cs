using System;
using System.IO;

namespace Example
{
    class Program
    {
        static int instances;
        static string datpath = @"/var/log/application/dat";
        static string varpath = @"/var/log/application/var";

        static void Main(string[] args)
        {

            string[] vs = GetVar();
            foreach (string line in GetDat())
            {
                foreach (string v in vs)
                {
                    if (v.IndexOf(line, StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        Console.WriteLine(line);
                        instances++;
                    }
                }
            }
            Console.WriteLine($"instances = {instances}");
        }

        static string[] GetDat()
        {
            return File.ReadAllLines(datpath);
        }

        static string[] GetVar()
        {
            return File.ReadAllLines(varpath);
        }
    }
}
