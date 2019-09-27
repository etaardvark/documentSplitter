using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace documentSplitter
{
    class Program
    {
        static void Main(string[] args)
        {
            if(!System.IO.File.Exists(args[0]))
            {
                Console.WriteLine("Input file does not exist ");
                Environment.Exit(-1);
            }
            if(!System.IO.Directory.Exists(args[1]))
            {
                Console.WriteLine("Output directory does not exist");
                Environment.Exit(-1);
            }

            documentSplitter splitter = new documentSplitter(args[0], args[1]);
            splitter.SplitDocument();
            Environment.Exit(0);
        }
    }
}
