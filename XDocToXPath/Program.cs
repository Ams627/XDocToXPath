using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace XDocToXPath
{
    class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                if (args.Length < 2)
                {
                    throw new Exception("You must specify a filename and a list of nodes to scan for.");
                }
                var doc = XDocument.Load(args[0], LoadOptions.SetLineInfo);
                foreach (var node in args.Skip(1))
                {
                    foreach (var foundNode in doc.Descendants(node))
                    {
                        var xpath = XExtensions.GetAbsoluteXPath(foundNode);
                        Console.WriteLine($"{xpath}");
                    }
                }
            }
            catch (Exception ex)
            {
                var fullname = System.Reflection.Assembly.GetEntryAssembly().Location;
                var progname = Path.GetFileNameWithoutExtension(fullname);
                Console.Error.WriteLine(progname + ": Error: " + ex.Message);
            }

        }
    }
}
