using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace ZeroUnitTestTool
{
  class ProcessKiller : IDisposable
  {
    public Process Process;

    public ProcessKiller(Process process)
    {
      this.Process = process;
    }

    public void Dispose()
    {
      try
      {
        this.Process.Kill();
      }
      catch
      {
      }
    }
  }
  class PathHelpers
  {
    static public String FindFileOfNameRecursive(String fileName, String rootFolder)
    {
      foreach (var filePath in Directory.GetFiles(rootFolder))
      {
        if (Path.GetFileName(filePath) == fileName)
          return filePath;
      }

      foreach (var dir in Directory.GetDirectories(rootFolder))
      {
        var result = FindFileOfNameRecursive(fileName, dir);
        if (result.Length != 0)
          return result;
      }
      return "";
    }

    static public String FindFileOfName(String rootSearchDir, String fileName)
    {
      return FindFileOfNameRecursive(fileName, rootSearchDir);
    }

    public static void DeleteDirectory(String sourceDir)
    {
      if (Directory.Exists(sourceDir) == false)
        return;

      foreach (var file in Directory.GetFiles(sourceDir))
        File.Delete(file);

      foreach (var dir in Directory.GetDirectories(sourceDir))
        DeleteDirectory(dir);

      try { Directory.Delete(sourceDir); }
      catch (Exception) { }
    }

    public static void ForceDeleteDirectory(string target_dir)
    {
      if(!Directory.Exists(target_dir))
        return;

      string[] files = Directory.GetFiles(target_dir);
      string[] dirs = Directory.GetDirectories(target_dir);

      foreach (string file in files)
      {
        RetrySafe(() => File.SetAttributes(file, FileAttributes.Normal));
        RetrySafe(() => File.Delete(file));
      }

      foreach (string dir in dirs)
      {
        ForceDeleteDirectory(dir);
      }

      RetrySafe(() =>
      {
        Directory.Delete(target_dir, true);
      });
    }

    private static void RetrySafe(Action action)
    {
      for (var i = 0; i < 100; ++i)
      {
        try
        {
          action();
          break;
        }
        catch
        {
          Thread.Sleep(10);
        }
      }
    }

    public static void FindFilesOfExtension(String searchDir, List<String> extensions, ref List<String> results)
    {
      foreach (var filePath in Directory.GetFiles(searchDir))
      {
        String extension = Path.GetExtension(filePath);
        if (extensions.Contains(extension))
          results.Add(filePath);
      }

      foreach (var dir in Directory.GetDirectories(searchDir))
      {
        FindFilesOfExtension(dir, extensions, ref results);
      }
    }

    public static void FindFolderRecursive(String searchDir, List<String> directoryNames, List<String> directoriesToSkip, ref List<String> results)
    {
      foreach (var dir in Directory.GetDirectories(searchDir))
      {
        var directoryName = Path.GetFileName(dir);
        if (directoriesToSkip.Contains(directoryName))
          continue;

        if (directoryNames.Contains(directoryName))
          results.Add(dir);

        FindFolderRecursive(dir, directoryNames, directoriesToSkip, ref results);
      }
    }
  }
}
