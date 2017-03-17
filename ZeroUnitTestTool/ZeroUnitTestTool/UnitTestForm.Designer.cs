namespace ZeroUnitTestTool
{
  partial class UnitTestForm
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.RunTestsButton = new System.Windows.Forms.Button();
      this.ProjectCheckedListBox = new System.Windows.Forms.CheckedListBox();
      this.ZeroExePathTextBox = new System.Windows.Forms.TextBox();
      this.ZeroExePathLable = new System.Windows.Forms.Label();
      this.TextBoxPanel = new System.Windows.Forms.Panel();
      this.LocationsPanel = new System.Windows.Forms.Panel();
      this.panel1 = new System.Windows.Forms.Panel();
      this.UnitTestProjectsPathTextBox = new System.Windows.Forms.TextBox();
      this.UnitTestProjectsPathLable = new System.Windows.Forms.Label();
      this.panel2 = new System.Windows.Forms.Panel();
      this.LogResultsTextBox = new System.Windows.Forms.RichTextBox();
      this.TextBoxPanel.SuspendLayout();
      this.LocationsPanel.SuspendLayout();
      this.panel1.SuspendLayout();
      this.panel2.SuspendLayout();
      this.SuspendLayout();
      // 
      // RunTestsButton
      // 
      this.RunTestsButton.Dock = System.Windows.Forms.DockStyle.Fill;
      this.RunTestsButton.Location = new System.Drawing.Point(0, 0);
      this.RunTestsButton.Name = "RunTestsButton";
      this.RunTestsButton.Size = new System.Drawing.Size(693, 34);
      this.RunTestsButton.TabIndex = 0;
      this.RunTestsButton.Text = "Run Unit Tests";
      this.RunTestsButton.UseVisualStyleBackColor = true;
      this.RunTestsButton.Click += new System.EventHandler(this.RunTestsButton_Click);
      // 
      // ProjectCheckedListBox
      // 
      this.ProjectCheckedListBox.Dock = System.Windows.Forms.DockStyle.Left;
      this.ProjectCheckedListBox.FormattingEnabled = true;
      this.ProjectCheckedListBox.Location = new System.Drawing.Point(0, 54);
      this.ProjectCheckedListBox.Name = "ProjectCheckedListBox";
      this.ProjectCheckedListBox.Size = new System.Drawing.Size(302, 318);
      this.ProjectCheckedListBox.TabIndex = 1;
      // 
      // ZeroExePathTextBox
      // 
      this.ZeroExePathTextBox.AllowDrop = true;
      this.ZeroExePathTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
      this.ZeroExePathTextBox.Location = new System.Drawing.Point(75, 0);
      this.ZeroExePathTextBox.Name = "ZeroExePathTextBox";
      this.ZeroExePathTextBox.Size = new System.Drawing.Size(618, 20);
      this.ZeroExePathTextBox.TabIndex = 2;
      this.ZeroExePathTextBox.Text = "..\\..\\..\\..\\..\\BuildOutput\\Out\\Win32\\Debug\\Win32Editor\\ZeroEditor.exe";
      this.ZeroExePathTextBox.DragDrop += new System.Windows.Forms.DragEventHandler(this.ZeroExePathTextBox_DragDrop);
      this.ZeroExePathTextBox.DragEnter += new System.Windows.Forms.DragEventHandler(this.ZeroExePathTextBox_DragEnter);
      // 
      // ZeroExePathLable
      // 
      this.ZeroExePathLable.AutoSize = true;
      this.ZeroExePathLable.Dock = System.Windows.Forms.DockStyle.Left;
      this.ZeroExePathLable.Location = new System.Drawing.Point(0, 0);
      this.ZeroExePathLable.Name = "ZeroExePathLable";
      this.ZeroExePathLable.Size = new System.Drawing.Size(75, 13);
      this.ZeroExePathLable.TabIndex = 4;
      this.ZeroExePathLable.Text = "Zero Exe Path";
      // 
      // TextBoxPanel
      // 
      this.TextBoxPanel.Controls.Add(this.ZeroExePathTextBox);
      this.TextBoxPanel.Controls.Add(this.ZeroExePathLable);
      this.TextBoxPanel.Dock = System.Windows.Forms.DockStyle.Top;
      this.TextBoxPanel.Location = new System.Drawing.Point(0, 0);
      this.TextBoxPanel.Name = "TextBoxPanel";
      this.TextBoxPanel.Size = new System.Drawing.Size(693, 24);
      this.TextBoxPanel.TabIndex = 5;
      // 
      // LocationsPanel
      // 
      this.LocationsPanel.Controls.Add(this.panel1);
      this.LocationsPanel.Controls.Add(this.TextBoxPanel);
      this.LocationsPanel.Dock = System.Windows.Forms.DockStyle.Top;
      this.LocationsPanel.Location = new System.Drawing.Point(0, 0);
      this.LocationsPanel.Name = "LocationsPanel";
      this.LocationsPanel.Size = new System.Drawing.Size(693, 54);
      this.LocationsPanel.TabIndex = 6;
      this.LocationsPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.LocationsPanel_Paint);
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.UnitTestProjectsPathTextBox);
      this.panel1.Controls.Add(this.UnitTestProjectsPathLable);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
      this.panel1.Location = new System.Drawing.Point(0, 24);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(693, 24);
      this.panel1.TabIndex = 6;
      // 
      // UnitTestProjectsPathTextBox
      // 
      this.UnitTestProjectsPathTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
      this.UnitTestProjectsPathTextBox.Location = new System.Drawing.Point(80, 0);
      this.UnitTestProjectsPathTextBox.Name = "UnitTestProjectsPathTextBox";
      this.UnitTestProjectsPathTextBox.Size = new System.Drawing.Size(613, 20);
      this.UnitTestProjectsPathTextBox.TabIndex = 2;
      this.UnitTestProjectsPathTextBox.Text = "..\\..\\..\\..\\UnitTestProjects";
      this.UnitTestProjectsPathTextBox.TextChanged += new System.EventHandler(this.UnitTestProjectsPathTextBox_TextChanged);
      this.UnitTestProjectsPathTextBox.DragDrop += new System.Windows.Forms.DragEventHandler(this.UnitTestProjectsPathTextBox_DragDrop);
      this.UnitTestProjectsPathTextBox.DragEnter += new System.Windows.Forms.DragEventHandler(this.UnitTestProjectsPathTextBox_DragEnter);
      // 
      // UnitTestProjectsPathLable
      // 
      this.UnitTestProjectsPathLable.AutoSize = true;
      this.UnitTestProjectsPathLable.Dock = System.Windows.Forms.DockStyle.Left;
      this.UnitTestProjectsPathLable.Location = new System.Drawing.Point(0, 0);
      this.UnitTestProjectsPathLable.Name = "UnitTestProjectsPathLable";
      this.UnitTestProjectsPathLable.Size = new System.Drawing.Size(80, 13);
      this.UnitTestProjectsPathLable.TabIndex = 4;
      this.UnitTestProjectsPathLable.Text = "Unit Tests Path";
      // 
      // panel2
      // 
      this.panel2.Controls.Add(this.RunTestsButton);
      this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.panel2.Location = new System.Drawing.Point(0, 372);
      this.panel2.Name = "panel2";
      this.panel2.Size = new System.Drawing.Size(693, 34);
      this.panel2.TabIndex = 7;
      // 
      // LogResultsTextBox
      // 
      this.LogResultsTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
      this.LogResultsTextBox.Location = new System.Drawing.Point(302, 54);
      this.LogResultsTextBox.Name = "LogResultsTextBox";
      this.LogResultsTextBox.Size = new System.Drawing.Size(391, 318);
      this.LogResultsTextBox.TabIndex = 8;
      this.LogResultsTextBox.Text = "";
      this.LogResultsTextBox.WordWrap = false;
      // 
      // UnitTestForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(693, 406);
      this.Controls.Add(this.LogResultsTextBox);
      this.Controls.Add(this.ProjectCheckedListBox);
      this.Controls.Add(this.panel2);
      this.Controls.Add(this.LocationsPanel);
      this.Name = "UnitTestForm";
      this.Text = "UnitTestForm";
      this.Load += new System.EventHandler(this.UnitTestForm_Load);
      this.TextBoxPanel.ResumeLayout(false);
      this.TextBoxPanel.PerformLayout();
      this.LocationsPanel.ResumeLayout(false);
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      this.panel2.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Button RunTestsButton;
    private System.Windows.Forms.CheckedListBox ProjectCheckedListBox;
    private System.Windows.Forms.TextBox ZeroExePathTextBox;
    private System.Windows.Forms.Label ZeroExePathLable;
    private System.Windows.Forms.Panel TextBoxPanel;
    private System.Windows.Forms.Panel LocationsPanel;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.TextBox UnitTestProjectsPathTextBox;
    private System.Windows.Forms.Label UnitTestProjectsPathLable;
    private System.Windows.Forms.Panel panel2;
    private System.Windows.Forms.RichTextBox LogResultsTextBox;
  }
}

