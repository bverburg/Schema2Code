using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Console.Command;
using NLog;

namespace Console
{
    class Program
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        static void Main(string[] args)
        {
            var options = new Options();
            if (CommandLine.Parser.Default.ParseArguments(args, options))
            {
                // Values are available here
                if (options.Verbose) logger.Info("Filename: {0}", options.InputFile);
            }
        }
    }
}
