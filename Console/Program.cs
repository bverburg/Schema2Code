using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using AutoMapper;
using Console.Command;
using NLog;
using Ninject;
using Schema2Code.Mapping;

namespace Console
{
    class Program
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        static void Main(string[] args)
        {
            var options = new Options();
            if (CommandLine.Parser.Default.ParseArguments(args, options))
            {
                // Values are available here  
                if (options.Verbose) Logger.Info("Filgename: {0}", options.InputFile);
            }

            var kernel = new StandardKernel();
            kernel.Load(AppDomain.CurrentDomain.GetAssemblies());

        }
    }
}
