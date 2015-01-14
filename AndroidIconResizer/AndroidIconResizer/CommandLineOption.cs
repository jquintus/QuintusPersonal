﻿using CommandLine;
using CommandLine.Text;
using System;
using System.IO;

namespace AndroidIconResizer
{
    public class CommandLineOption
    {
        public DirectoryInfo InputDir { get; set; }

        [Option('i', "input-dir", DefaultValue = ".", HelpText = "Location of the images to process.  Defaults to current directory.")]
        public string InputDirString
        {
            get { return InputDir.FullName; }
            set { InputDir = new DirectoryInfo(value); }
        }

        public DirectoryInfo OutputDir { get; set; }

        [Option('o', "output-dir", DefaultValue = ".", HelpText = "Location of the output directory.  Defaults to current directory.")]
        public string OutputDirString
        {
            get { return OutputDir.FullName; }
            set { OutputDir = new DirectoryInfo(value); }
        }

        [Option('s', "size", Required = true, HelpText = "The size of the image in pixels in the MDPI folder")]
        public int Size { get; set; }


        [HelpOption]
        public string GetUsage()
        {
            return HelpText.AutoBuild(this,
              (HelpText current) => HelpText.DefaultParsingErrorsHandler(this, current));
        }

        public static CommandLineOption Read(string[] args)
        {
            var options = new CommandLineOption();
            if (CommandLine.Parser.Default.ParseArguments(args, options))
            {
                return options;
            }
            else
            {
                return null;
            }
        }
    }
}