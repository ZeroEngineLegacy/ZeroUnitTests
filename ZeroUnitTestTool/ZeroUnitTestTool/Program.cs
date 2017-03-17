using CommandLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZeroUnitTestTool
{
  static class Program
  {
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main(string[] args)
    {
      var commandArgs = new CommandArgs();
      var settings = new CommandLine.ParserSettings();
      settings.IgnoreUnknownArguments = false;
      CommandLine.Parser parser = new Parser(with => with.HelpWriter = Console.Error);

      // Try to parse the command line arguments
      if (parser.ParseArguments(args, commandArgs) == false)
      {
        // If we failed to parse print out the usage of this program
        //Console.Write(commandArgs.GetUsage());

        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new UnitTestForm());
        return;
      }

      var unitTestRunner = new UnitTestRunner();
      unitTestRunner.Run(commandArgs);
    }
  }
}
