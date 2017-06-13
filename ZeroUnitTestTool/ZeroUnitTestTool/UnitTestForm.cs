using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZeroUnitTestTool
{
  public partial class UnitTestForm : Form
  {
    public UnitTestForm()
    {
      InitializeComponent();
    }

    private void LocationsPanel_Paint(object sender, PaintEventArgs e)
    {

    }

    private void LogProjectResult(string logMessage)
    {
      this.LogResultsTextBox.Text += logMessage;
    }

    private void RunTestsButton_Click(object sender, EventArgs e)
    {
      var args = new CommandArgs();
      args.ZeroExePath = this.ZeroExePathTextBox.Text;
      args.UnitTestProjectsPath = this.UnitTestProjectsPathTextBox.Text;

      var projectsToRun = new List<string>();
      for(var i = 0; i < this.ProjectCheckedListBox.CheckedIndices.Count; ++i)
      {
        var checkedIndex = this.ProjectCheckedListBox.CheckedIndices[i];
        var projectInfo = (UnitTestProjectInfo)this.ProjectCheckedListBox.Items[checkedIndex];
        projectsToRun.Add(projectInfo.FullPath);
      }

      this.LogResultsTextBox.Text = "";
      var unitTestRunner = new UnitTestRunner();
      unitTestRunner.mLoggingDelegate += this.LogProjectResult;
      unitTestRunner.RunProjects(args.ZeroExePath, projectsToRun, args.MaxTimeout);
    }

    private void ZeroExePathTextBox_DragDrop(object sender, DragEventArgs e)
    {
      string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
      foreach(var file in files)
      {
        this.ZeroExePathTextBox.Text = file;
        break;
      }
    }

    private void ZeroExePathTextBox_DragEnter(object sender, DragEventArgs e)
    {
      e.Effect = DragDropEffects.All;
    }

    private void UnitTestProjectsPathTextBox_DragEnter(object sender, DragEventArgs e)
    {
      e.Effect = DragDropEffects.All;
    }

    private void UnitTestProjectsPathTextBox_DragDrop(object sender, DragEventArgs e)
    {
      string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
      foreach (var file in files)
      {
        this.UnitTestProjectsPathTextBox.Text = file;
        break;
      }
    }

    private void UpdateProjectList()
    {
      var projectsPath = Path.GetFullPath(this.UnitTestProjectsPathTextBox.Text);
      if (!Directory.Exists(projectsPath))
        return;

      this.ProjectCheckedListBox.Items.Clear();
      var projectPaths = UnitTestRunner.FindAllZeroProj(projectsPath);
      foreach(var projectPath in projectPaths)
      {
        var projectInfo = new UnitTestProjectInfo();
        projectInfo.FullPath = projectPath;
        this.ProjectCheckedListBox.Items.Add(projectInfo, true);
      }
    }

    private void UnitTestProjectsPathTextBox_TextChanged(object sender, EventArgs e)
    {
      this.UpdateProjectList();
    }

    private void UnitTestForm_Load(object sender, EventArgs e)
    {
      this.UpdateProjectList();
    }
  }

  class UnitTestProjectInfo
  {
    public String FullPath;

    public override string ToString()
    {
      return Path.GetFileName(this.FullPath);
    }
  }
}
