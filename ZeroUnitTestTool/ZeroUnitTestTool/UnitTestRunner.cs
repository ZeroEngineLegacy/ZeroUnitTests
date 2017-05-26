using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ZeroUnitTestTool
{
  class UnitTestRunner
  {
    public delegate void LoggingDelegate(string message);
    public LoggingDelegate mLoggingDelegate = null;

    public void Run(CommandArgs args)
    {
      var projectPaths = FindAllZeroProj(args.UnitTestProjectsPath);
      RunProjects(args.ZeroExePath, projectPaths, args.MaxTimeout);
    }

    public static List<string> FindAllZeroProj(string path)
    {
      List<string> results = new List<string>();
      PathHelpers.FindFilesOfExtension(path, new List<string>() { ".zeroproj" }, ref results);

      return results;
    }

    public void RunProjects(string exePath, List<string> projectPaths, int maxTimeoutSeconds)
    {
      foreach (var projectPath in projectPaths)
        RunProject(exePath, projectPath, maxTimeoutSeconds);
    }

    public void RunProject(string exePath, string projectPath, int maxTimeoutSeconds)
    {
      string maxTimeoutFile = Path.Combine(Path.GetDirectoryName(projectPath), "MaxTimeout.txt");
      if(File.Exists(maxTimeoutFile))
      {
        int.TryParse(File.ReadAllText(maxTimeoutFile), out maxTimeoutSeconds);
      }

      string args = string.Format("\"{0}\" -RunUnitTests -logStdOut", projectPath);
      string results = RunProcess(exePath, args, maxTimeoutSeconds * 1000);

      var failedRegex = new Regex(".*Unit Test Failed:.*");
      MatchCollection matchResults = failedRegex.Matches(results);
      StringBuilder builder = new StringBuilder();
      foreach(Match match in matchResults)
      {
        String message = match.Captures[0].Value.ToString();
        builder.Append("  " + message + "\n");
      }
      if (builder.Length != 0)
        LogFailure(projectPath, builder.ToString());
      else
        LogSuccess(projectPath);
    }

    public void Log(string msg)
    {
      mLoggingDelegate?.Invoke(msg);
      Console.WriteLine(msg);
    }

    public void LogFailure(string projectPath, string message)
    {
      string logMessage = string.Format("Project '{0}' Failed:\n{1}", projectPath, message);
      Log(logMessage);
    }

    public void LogSuccess(string projectPath)
    {
      string logMessage = string.Format("Project '{0}' Succeeded:\n", projectPath);
      Log(logMessage);
    }

    String RunProcess(string exePath, string arguments, int maxTimeAllowed)
    {
      var processOutputStream = new StringBuilder();

      ProcessStartInfo info = new ProcessStartInfo();
      info.Arguments = arguments;
      info.FileName = exePath;
      info.UseShellExecute = false;
      info.CreateNoWindow = true;
      info.RedirectStandardOutput = true;
      info.WindowStyle = ProcessWindowStyle.Hidden;

      Log(String.Format("Running project '{0}' with arguments '{1}' with max time of {2}ms\n", exePath, arguments, maxTimeAllowed));

      Stopwatch stopwatch = Stopwatch.StartNew();

      var process = Process.Start(info);
      process.OutputDataReceived += (sender, outputLine) => { if (outputLine.Data != null) processOutputStream.AppendLine(outputLine.Data); };
      process.BeginOutputReadLine();
      bool gracefullyExited = process.WaitForExit(maxTimeAllowed);
      if (!gracefullyExited)
      {
        process.Kill();
        return String.Format("Unit Test Failed: Timed out after {0}ms", stopwatch.ElapsedMilliseconds);
      }

      int exitCode = process.ExitCode;
      if (exitCode != 0)
        processOutputStream.AppendFormat("Unit Test Failed: Process exited with code {0}\n", exitCode);
      return processOutputStream.ToString();
    }
  }
}
