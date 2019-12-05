﻿using DotNetCli;
using NEcho;
using NStandard;
using System;
using System.Reflection;

namespace Dawnx.Tools
{
    public class Program
    {
        public static readonly string CLI_VERSION = Assembly.GetExecutingAssembly().GetName().Version.ToString();

        public static CommandContainer CommandContainer;
        public static ProjectInfo ProjectInfo => CommandContainer.ProjectInfo;

        static void Main(string[] args)
        {
            CommandContainer = new CommandContainer(ProjectInfo.GetCurrent(), "ts");
            CommandContainer.CacheCommands(Assembly.GetExecutingAssembly());

            PrintWelcome();

            var conArgs = new ConArgs(args, "-");
            CommandContainer.PrintProjectInfo();
            CommandContainer.Run(conArgs);
        }

        public static void PrintWelcome()
        {
            Console.WriteLine($@"
{"ヽ(*^▽^)ノ".Center(60)}

TypeSharp .NET Command-line Tools {CLI_VERSION}");
        }

    }
}