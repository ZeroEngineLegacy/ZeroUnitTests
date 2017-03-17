using CommandLine;
using CommandLine.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeroUnitTestTool
{

  // The command line options that we parse
  public class CommandArgs
  {
    [Option("ZeroExePath", Required = true, HelpText = "Where the exe to run is.")]
    public string ZeroExePath { get; set; }

    [Option("UnitTestProjectsPath", Required = true, HelpText = "Where to find all unit test projects")]
    public string UnitTestProjectsPath { get; set; }

    [Option("MaxTimeout", Required = true, HelpText = "Maximum timeout in seconds")]
    public int MaxTimeoutProperty{ get { return MaxTimeout; } set { MaxTimeout = value; } }
    public int MaxTimeout = 60;

    [HelpOption(HelpText = "Display this help screen.")]
    public string GetUsage()
    {
      return HelpText.AutoBuild(this, current => HelpText.DefaultParsingErrorsHandler(this, current));
    }
  }
}
